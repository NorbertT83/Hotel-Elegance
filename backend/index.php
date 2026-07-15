<?php

$config = require __DIR__ . '/config.php';

require_once __DIR__ . '/src/Helpers.php';
require_once __DIR__ . '/src/Database.php';
require_once __DIR__ . '/src/Jwt.php';
require_once __DIR__ . '/src/RateLimiter.php';
require_once __DIR__ . '/src/ResourceRepository.php';
require_once __DIR__ . '/src/ApiConfig.php';
require_once __DIR__ . '/src/AuthMiddleware.php';
require_once __DIR__ . '/src/Controllers/AuthController.php';
require_once __DIR__ . '/src/Controllers/FoodBeverageController.php';
require_once __DIR__ . '/src/Controllers/ServiceBookingController.php';
require_once __DIR__ . '/src/Controllers/BookingController.php';
require_once __DIR__ . '/src/Controllers/ResourceController.php';

$allowedOrigins = ['http://localhost:5173', 'http://127.0.0.1:5173', 'https://nrbrt-codes.hu'];
sendCorsHeaders($allowedOrigins);

if (getRequestMethod() === 'OPTIONS') {
    http_response_code(200);
    exit;
}

try {
    $pdo = createDatabaseConnection($config);
} catch (PDOException $e) {
    sendError('Adatbázis hiba: ' . $e->getMessage(), 500);
}

$requestPath = getRequestUriPath();
$apiPos = strpos($requestPath, '/api/');
if ($apiPos !== false) {
    $relativeRoute = substr($requestPath, $apiPos + 5);
} else {
    $relativeRoute = trim($requestPath, '/');
}

$urlParts = explode('/', trim($relativeRoute, '/'));
$resource = $urlParts[0] ?? '';
$id = $urlParts[1] ?? 'all';
$method = getRequestMethod();

if (!$resource) {
    sendError('Nincs megadva erőforrás.', 400);
}

$inputData = getRequestBody();
$authenticatedUser = authenticateRequest($pdo, $resource, $method, $config['jwt_secret']);

if ($authenticatedUser !== null) {
    applyGuestRestrictions($resource, $method, $id, $authenticatedUser, $pdo, $inputData);
}

$endpoints = getApiEndpoints();

if ($resource === 'auth') {
    handleAuthRequest($pdo, $id, $method, $inputData, $config['jwt_secret'], isHttpsRequest());
}

if ($resource === 'foodbeverage' && $id === 'categories' && $method === 'GET') {
    handleFoodBeverageCategories($pdo);
}

if ($resource === 'servicebooking' && $id === 'updatestatus' && $method === 'POST') {
    handleServiceBookingUpdateStatus($pdo, $inputData);
}

if ($resource === 'booking' && $id === 'services' && $method === 'GET') {
    handleBookingServices($pdo, $authenticatedUser ?? []);
}

if (array_key_exists($resource, $endpoints)) {
    $configEndpoint = $endpoints[$resource];

    if ($resource === 'freerooms') {
        $start = $_GET['start_date'] ?? $_GET['beginning_of_stay'] ?? null;
        $end = $_GET['end_date'] ?? $_GET['end_of_stay'] ?? null;

        if (!$start || !$end) {
            sendError('A szabad szobák lekérdezéséhez a dátumok megadása kötelező.', 400);
        }

        $sql = 'SELECT * FROM `rooms` WHERE `room_number` NOT IN (
                    SELECT DISTINCT `room_number` FROM `bookings`
                    WHERE `room_number` IS NOT NULL AND `beginning_of_stay` < ? AND `end_of_stay` > ?
                )';
        $params = [$end, $start];

        $allowedRoomFilters = ['room_type', 'status', 'bed_type', 'has_balcony'];
        foreach ($_GET as $key => $value) {
            if (in_array($key, $allowedRoomFilters, true) && $value !== '') {
                $sql .= " AND `$key` = ?";
                $params[] = $value;
            }
        }

        $allowedRoomSorts = ['room_number', 'price_per_night', 'floorspace'];
        if (!empty($_GET['sort']) && in_array($_GET['sort'], $allowedRoomSorts, true)) {
            $direction = (isset($_GET['order']) && strtolower($_GET['order']) === 'desc') ? 'DESC' : 'ASC';
            $sql .= " ORDER BY `{$_GET['sort']}` $direction";
        }

        try {
            $stmt = $pdo->prepare($sql);
            $stmt->execute($params);
            sendJsonResponse($stmt->fetchAll());
        } catch (PDOException $e) {
            sendError('Adatbázis hiba: ' . $e->getMessage(), 500);
        }
    }

    if (isset($configEndpoint['table'], $configEndpoint['id'])) {
        handleGenericResource($pdo, $configEndpoint, $resource, $id, $method, $inputData);
    }
}

sendError('Ismeretlen végpont: ' . $resource, 404);
