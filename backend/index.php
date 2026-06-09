<?php
$config = require 'config.php';

$host = $config['db_host'];
$db   = $config['db_name'];
$user = $config['db_user'];
$pass = $config['db_pass'];
$charset = $config['db_char'];
$jwt_secret = $config['jwt_secret'];


$allowed_origins = ['http://localhost:5173', 'http://127.0.0.1:5173', 'http://localhost:3000', 'https://nrbrt-codes.hu'];
$origin = $_SERVER['HTTP_ORIGIN'] ?? '';

if (in_array($origin, $allowed_origins)) {
    header("Access-Control-Allow-Origin: " . $origin);
} else {
    // Alapértelmezett fallback fejlesztéshez
    header("Access-Control-Allow-Origin: http://localhost:5173"); 
}

header("Access-Control-Allow-Credentials: true");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: GET, POST, DELETE, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
    http_response_code(200);
    exit;
}


function base64url_encode($data) {
    return rtrim(strtr(base64_encode($data), '+/', '-_'), '=');
}

function base64url_decode($data) {
    return base64_decode(str_pad(strtr($data, '-_', '+/'), strlen($data) % 4, '=', STR_PAD_RIGHT));
}

function generate_jwt($payload, $secret, $expiry_seconds) {
    $header = json_encode(['typ' => 'JWT', 'alg' => 'HS256']);
    $payload['exp'] = time() + $expiry_seconds;
    $payload['iat'] = time();
    
    $base64UrlHeader = base64url_encode($header);
    $base64UrlPayload = base64url_encode(json_encode($payload));
    
    $signature = hash_hmac('sha256', $base64UrlHeader . "." . $base64UrlPayload, $secret, true);
    $base64UrlSignature = base64url_encode($signature);
    
    return $base64UrlHeader . "." . $base64UrlPayload . "." . $base64UrlSignature;
}

function verify_jwt($jwt, $secret) {
    $tokenParts = explode('.', $jwt);
    if (count($tokenParts) !== 3) return false;
    
    $header = base64url_decode($tokenParts[0]);
    $payload = base64url_decode($tokenParts[1]);
    $signatureProvided = $tokenParts[2];

    $payloadArr = json_decode($payload, true);
    if (isset($payloadArr['exp']) && $payloadArr['exp'] < time()) {
        return false;
    }

    $base64UrlHeader = base64url_encode($header);
    $base64UrlPayload = base64url_encode($payload);
    $signatureValid = base64url_encode(hash_hmac('sha256', $base64UrlHeader . "." . $base64UrlPayload, $secret, true));

    if (hash_equals($signatureValid, $signatureProvided)) {
        return $payloadArr;
    }
    return false;
}

// --- ADATBÁZIS CSATLAKOZÁS ---
$dsn = "mysql:host=$host;dbname=$db;charset=$charset";
$options = [
    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    PDO::ATTR_EMULATE_PREPARES   => false,
];

try {
    $pdo = new PDO($dsn, $user, $pass, $options);
} catch (\PDOException $e) {
    http_response_code(500);
    echo json_encode(["error" => "Adatbázis hiba: " . $e->getMessage()]);
    exit;
}


function fetchResource($pdo, $table, $idOrAll, $idColumn, $allowedFilters = [], $allowedSorts = []) {
    $params = [];
    $sql = "SELECT * FROM `$table`";
    if ($idOrAll !== 'all') {
        $sql .= " WHERE `$idColumn` = ?";
        $params[] = $idOrAll;
    } else {
        $whereConditions = [];
        foreach ($_GET as $key => $value) {
            if (in_array($key, $allowedFilters) && $value !== '') {
                if ($key === 'end_of_stay_after') {
                    $whereConditions[] = "`end_of_stay` > ?"; 
                    $params[] = $value;
                } else {
                    $whereConditions[] = "`$key` = ?";
                    $params[] = $value;
                }
            }
        }
        if (count($whereConditions) > 0) $sql .= " WHERE " . implode(" AND ", $whereConditions);
    }
    $stmt = $pdo->prepare($sql);
    $stmt->execute($params);
    return ($idOrAll === 'all') ? $stmt->fetchAll() : $stmt->fetch();
}
function createResource($pdo, $table, $data) {
    if (empty($data)) return false;
    $columns = array_keys($data);
    $placeholders = array_fill(0, count($data), '?');
    $sql = "INSERT INTO `$table` (`" . implode("`, `", $columns) . "`) VALUES (" . implode(", ", $placeholders) . ")";
    $stmt = $pdo->prepare($sql);
    $stmt->execute(array_values($data));
    return true;
}
function deleteResource($pdo, $table, $idColumn, $id) {
    $sql = "DELETE FROM `$table` WHERE `$idColumn` = ?";
    $stmt = $pdo->prepare($sql); $stmt->execute([$id]);
    return $stmt->rowCount();
}

// --- ROUTING ÉS KÉRÉS FELDOLGOZÁSA ---
$requestPath = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
$scriptPath = dirname($_SERVER['SCRIPT_NAME']); 
$requestUri = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);

$apiPos = strpos($requestUri, '/api/');
if ($apiPos !== false) {
    $relativeRoute = substr($requestUri, $apiPos + 5);
} else {
    $relativeRoute = trim($requestUri, '/');
}
$urlParts = explode('/', trim($relativeRoute, '/'));

$resource = $urlParts[0] ?? '';
$id = $urlParts[1] ?? 'all';


// $requestUri = str_replace($scriptPath, '', $requestPath);
// $requestUri = trim($requestUri, '/');

// $parts = explode('/', $requestUri);
// $resource = $parts[0] ?? null;
// $id = $parts[1] ?? 'all'; 
$method = $_SERVER['REQUEST_METHOD']; 

if (!$resource) {
    http_response_code(400);
    echo json_encode(["error" => "Nincs megadva erőforrás."]);
    exit;
}

$inputData = json_decode(file_get_contents("php://input"), true);

// MIDDLEWARE: A WHITELIST KIVÉTELÉVEL MINDEN MÁS VÉGPONT ELLENŐRZI A JWT TOKENT
$publicRoutes = [
    'service' => ['GET'],
    'freerooms'     => ['GET'],
];

$isPublic = false;

if ($resource === 'auth' || $method === 'OPTIONS') {
    $isPublic = true;
} 
elseif (isset($publicRoutes[$resource]) && in_array($method, $publicRoutes[$resource])) {
    $isPublic = true;
}

if (!$isPublic) {    
    $allHeaders = getallheaders();
    $authHeader = $allHeaders['Authorization'] ?? $allHeaders['authorization'] ?? null;

    if (!$authHeader || !preg_match('/Bearer\s(\S+)/', $authHeader, $matches)) {
        http_response_code(401);
        echo json_encode(["error" => "Hiányzó vagy érvénytelen Authorization token."]);
        exit;
    }

    $token = $matches[1];
    $tokenPayload = verify_jwt($token, $jwt_secret);

    if (!$tokenPayload) {
        http_response_code(401);
        echo json_encode(["error" => "A token lejárt vagy érvénytelen."]);
        exit;
    }

    $authenticatedUser = $tokenPayload; 
}



// --- 3. DEDIKÁLT VIRTUAL ENDPOINT: AUTH KEZELÉSE ---
if ($resource === 'auth') {

    // A: LOGIN FOLYAMAT
    if ($id === 'login' && $method === 'POST') {
        $email = $inputData['email'] ?? null;
        $bookingId = $inputData['booking_id'] ?? null;

        if (!$email || !$bookingId) {
            http_response_code(400);
            echo json_encode(["success" => false, "errorType" => "missingFields"]);
            exit;
        }

        // 1. Vendég ellenőrzése
        $stmt = $pdo->prepare("SELECT * FROM `guests` WHERE `email` = ? LIMIT 1");
        $stmt->execute([$email]);
        $guest = $stmt->fetch();

        if (!$guest) {
            http_response_code(401);
            echo json_encode(["success" => false, "errorType" => "noMatchingEmailOrBooking"]);
            exit;
        }

        // 2. Foglalás ellenőrzése
        $stmt = $pdo->prepare("SELECT * FROM `bookings` WHERE `id` = ? LIMIT 1");
        $stmt->execute([$bookingId]);
        $booking = $stmt->fetch();

        // Passzol a foglalás a vendéghez?
        if (!$booking || $booking['guest1_id'] != $guest['id']) {
            http_response_code(401);
            echo json_encode(["success" => false, "errorType" => "noMatchingEmailOrBooking"]);
            exit;
        }

        // 3. Lejárati ellenőrzés (már checkout v. régebbi a távozás mint a mai nap)
        if (!empty($booking['checkout']) || strtotime($booking['end_of_stay']) <= time()) {
            http_response_code(401);
            echo json_encode(["success" => false, "errorType" => "bookingExpired"]);
            exit;
        }

        // 4. Token összeállítása
        $tokenPayload = [
            'guest_id' => (int)$guest['id'],
            'booking_id' => $booking['id']
        ];

        $accessToken = generate_jwt($tokenPayload, $jwt_secret, 900);       // 15 percig jó
        $refreshToken = generate_jwt($tokenPayload, $jwt_secret, 604800);   // 7 napig jó

        // 5. Refresh token elrejtése egy HttpOnly Cookie-ba
        setcookie('refresh_token', $refreshToken, [
            'expires' => time() + 604800,
            'path' => '/',
            'domain' => '', 
            'secure' => false,   // Helyi tesztelésnél (HTTP) false, éles (HTTPS) szerveren kötelezően TRUE!
            'httponly' => true,
            'samesite' => 'Lax'
        ]);

        echo json_encode([
            "success" => true,
            "accessToken" => $accessToken
        ]);
        exit;
    }

    // B: REFRESH (TOKEN MEGÚJÍTÁS) FOLYAMAT
    if ($id === 'refresh' && $method === 'POST') {
        $refreshToken = $_COOKIE['refresh_token'] ?? null;

        if (!$refreshToken) {
            http_response_code(401);
            echo json_encode([
                "success" => false,
                "error" => "Nincs refresh token a sutikben."
            ]);
            exit;
        }

        // Token hitelesítése
        $payload = verify_jwt($refreshToken, $jwt_secret);

        if (!$payload) {
            http_response_code(401);
            echo json_encode([
                "success" => false,
                "error" => "Lejart vagy manipulalt refresh token."
            ]);
            exit;
        }

        // Új Access Token kibocsátása változatlan adatokkal, újabb 15 percre
        $newAccessToken = generate_jwt([
            'guest_id' => $payload['guest_id'],
            'booking_id' => $payload['booking_id']
        ], $jwt_secret, 900);

        echo json_encode([
            "success" => true,
            "accessToken" => $newAccessToken
        ]);
        exit;
    }

    // C: PUBLIKUS FOGLALÁS (VENDÉG ELLENŐRZÉSSEL ÉS ÖSSZEFÉSÜLÉSSEL)
    if ($id === 'public-booking' && $method === 'POST') {
        $email = $inputData['email'] ?? null;
        
        if (!$email) {
            http_response_code(400);
            echo json_encode(["success" => false, "error" => "Az e-mail cím megadása kötelező."]);
            exit;
        }

        try {
            $pdo->beginTransaction();

            $stmt = $pdo->prepare("SELECT id FROM `guests` WHERE `email` = ? LIMIT 1");
            $stmt->execute([$email]);
            $existingGuest = $stmt->fetch();

            if ($existingGuest) {
                $guestId = $existingGuest['id'];
                // TODO
                // Itt egy UPDATE-tel frissíthető a vendég adatai 
            } else {
                $stmt = $pdo->prepare("INSERT INTO `guests` (`email`, `fname`, `lname`, `zip_code`, `country`, `city`, `street`) VALUES (?, ?, ?, ?, ?, ?, ?)");
                $stmt->execute([
                    $email,
                    $inputData['fname'] ?? '',
                    $inputData['lname'] ?? '',
                    $inputData['zip_code'] ?? '',
                    $inputData['country'] ?? '',
                    $inputData['city'] ?? '',
                    $inputData['street'] ?? ''
                ]);
                $guestId = $pdo->lastInsertId();
            }

            // 2. Létrehozzuk magát a foglalást a kinyert $guestId használatával
            $bookingId = $inputData['booking_id'] ?? null;
            $stmt = $pdo->prepare("INSERT INTO `bookings` (`id`, `guest1_id`, `room_number`, `room_type`, `beginning_of_stay`, `end_of_stay`, `catering_level`) VALUES (?, ?, ?, ?, ?, ?, ?)");
            $stmt->execute([
                $bookingId,
                $guestId,
                $inputData['room_number'] ?? null,
                $inputData['room_type'] ?? null,
                $inputData['beginning_of_stay'] ?? null,
                $inputData['end_of_stay'] ?? null,
                $inputData['catering_level'] ?? null
            ]);
            // 3. Ha volt extra szolgáltatás bejelölve azt is hozzáadjuk a servicebookings táblába
            if (!empty($inputData['services']) && is_array($inputData['services'])) {
                $getServiceStmt = $pdo->prepare("SELECT `id` FROM `services` WHERE `name_en` LIKE ? LIMIT 1");
                $insertServiceStmt = $pdo->prepare("INSERT INTO `servicebookings` (`booking_id`, `service_id`, `quantity`) VALUES (?, ?, ?)");

                foreach ($inputData['services'] as $serviceName) {  
                    $getServiceStmt->execute([$serviceName]);
                    $serviceData = $getServiceStmt->fetch();

                    if ($serviceData) {
                        $insertServiceStmt->execute([
                            $bookingId,
                            $serviceData['id'],
                            1
                        ]);
                    }
                }
            }
            $pdo->commit();

            http_response_code(201);
            echo json_encode([
                "success" => true,
                "message" => "A foglalás sikeresen rögzítve!",
                "booking_id" => $inputData['booking_id'] ?? null,
                "guest_id" => $guestId
            ]);
            exit;

        } catch (\Throwable $e) {
            if ($pdo->inTransaction()) {
                $pdo->rollBack();
            }
            http_response_code(500);
            echo json_encode(["success" => false, "error" => "Hiba történt a foglalás során: " . $e->getMessage()]);
            exit;
        }
    }

    http_response_code(404);
    echo json_encode(["error" => "Ismeretlen auth muvelet."]);
    exit;
}

// --- NORMÁL TÁBLA ALAPÚ ENDPOINTEK DEFINÍCIÓJA ---
$endpoints = [
    'room' => [
        'table'   => 'rooms',
        'id'      => 'room_number',
        'filters' => ['room_type', 'status', 'bed_type', 'has_balcony'],
        'sorts'   => ['room_number', 'price_per_night', 'floorspace'],
        'enums'   => [
            'status' => ['available','occupied','dont_disturb','needs_cleaning','cleaning','under_maintenence','unavailable'],
            'room_type' => ['standard','deluxe','suite'],
            'bed_type' => ['single', 'twin', 'queen', 'kingsize'],
            'has_view' => ['city', 'garden', 'panorama']
        ]
    ],
    'guest' => [
        'table'   => 'guests',
        'id'      => 'id',
        'filters' => ['city', 'country', 'loyalty_level', 'email'],
        'sorts'   => ['fname', 'lname', 'country', 'loyalty_level']
    ],
    'employee' => [
        'table'   => 'employees',
        'id'      => 'id',
        'filters' => ['role'],
        'sorts'   => ['fname', 'lname', 'salary', 'date_of_birth', 'date_of_hiring']
    ],
    'service' => [
        'table'   => 'services',
        'id'      => 'id',
        'filters' => ['service_type_hu', 'service_type_en'],
        'sorts'   => ['name_hu', 'name_en', 'price', 'service_type_hu', 'service_type_en']
    ],
    'booking' => [
        'table'   => 'bookings',
        'id'      => 'id',
        'filters' => ['room_number', 'guest1_id','end_of_stay_after'],
        'sorts'   => ['beginning_of_stay', 'room_number', 'guest1_id'],
        'enums'   => [
            'room_type' => ['standard','deluxe','suite'],
            'needs_view' => ['city', 'garden', 'panorama']
        ]
    ],
    'freerooms' => [
        'filters' => ['end_of_stay_after']
    ]
];

if (array_key_exists($resource, $endpoints)) {
    $config = $endpoints[$resource];

    // --- VIRTUÁLIS VÉGPONT: FREEROOMS KEZELÉSE ---
    if ($resource === 'freerooms') {
        if ($method !== 'GET') {
            http_response_code(405);
            echo json_encode(["error" => "Nem engedélyezett metódus: $method"]);
            exit;
        }
        $start = $_GET['start_date'] ?? $_GET['beginning_of_stay'] ?? null;
        $end = $_GET['end_date'] ?? $_GET['end_of_stay'] ?? null;

        if (!$start || !$end) {
            http_response_code(400);
            echo json_encode(["error" => "A szabad szobák lekérdezéséhez a dátumok megadása kötelező."]);
            exit;
        }

        $sql = "SELECT * FROM `rooms` WHERE `room_number` NOT IN (
                    SELECT DISTINCT `room_number` FROM `bookings` 
                    WHERE `room_number` IS NOT NULL AND `beginning_of_stay` < ? AND `end_of_stay` > ?
                )";
        $params = [$end, $start]; 

        $allowedRoomFilters = ['room_type', 'status', 'bed_type', 'has_balcony'];
        foreach ($_GET as $key => $value) {
            if (in_array($key, $allowedRoomFilters) && $value !== '') {
                $sql .= " AND `$key` = ?"; $params[] = $value;
            }
        }

        $allowedRoomSorts = ['room_number', 'price_per_night', 'floorspace'];
        if (!empty($_GET['sort']) && in_array($_GET['sort'], $allowedRoomSorts)) {
            $sortColumn = $_GET['sort'];
            $direction = (isset($_GET['order']) && strtolower($_GET['order']) === 'desc') ? 'DESC' : 'ASC';
            $sql .= " ORDER BY `$sortColumn` $direction";
        }

        try {
            $stmt = $pdo->prepare($sql); $stmt->execute($params);
            echo json_encode($stmt->fetchAll());
        } catch (\PDOException $e) {
            http_response_code(500);
            echo json_encode(["error" => "Adatbázis hiba: " . $e->getMessage()]);
        }
        exit;
    }

    $table = $config['table'];
    $idCol = $config['id'];
    
    switch ($method) {
        case 'GET':
            $result = fetchResource($pdo, $table, $id, $idCol, $config['filters'], $config['sorts']);
            if ($result) { echo json_encode($result); } 
            else { http_response_code(404); echo json_encode(["error" => "Nincs talalat"]); }
            break;

        case 'POST':
            if (empty($inputData)) { http_response_code(400); echo json_encode(["error" => "Hianyzo JSON."]); break; }
            try {
                createResource($pdo, $table, $inputData);
                http_response_code(201);
                echo json_encode(["id" => $pdo->lastInsertId(), "message" => "Sikeresen létrehozva."]);
            } catch (\PDOException $e) { http_response_code(400); echo json_encode(["error" => $e->getMessage()]); }
            break;

        case 'DELETE':
            if ($id === 'all') { http_response_code(400); echo json_encode(["error" => "Hianyzo ID."]); break; }
            try {
                $affected = deleteResource($pdo, $table, $idCol, $id);
                if ($affected > 0) { echo json_encode(["message" => "Torolve."]); } 
                else { http_response_code(404); echo json_encode(["error" => "Nem talalhato."]); }
            } catch (\PDOException $e) { http_response_code(400); echo json_encode(["error" => $e->getMessage()]); }
            break;
    }
} else {
    http_response_code(404);
    echo json_encode(["error" => "Ismeretlen végpont: $resource"]);
}