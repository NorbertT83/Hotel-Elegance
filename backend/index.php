<?php
$config = require 'config.php';

$host = $config['db_host'];
$db   = $config['db_name'];
$user = $config['db_user'];
$pass = $config['db_pass'];
$charset = $config['db_char'];
$jwt_secret = $config['jwt_secret'];

$isUsingHttps = (!empty($_SERVER['HTTPS']) && $_SERVER['HTTPS'] !== 'off') || (isset($_SERVER['HTTP_X_FORWARDED_PROTO']) && $_SERVER['HTTP_X_FORWARDED_PROTO'] === 'https');
// In production ensure TLS is used and `isUsingHttps` becomes true so cookies are marked secure.

$allowed_origins = ['http://localhost:5173', 'http://127.0.0.1:5173', 'https://nrbrt-codes.hu'];
$origin = $_SERVER['HTTP_ORIGIN'] ?? '';

if (in_array($origin, $allowed_origins)) {
    header("Access-Control-Allow-Origin: " . $origin);
} else {
    // Alapértelmezett fallback fejlesztéshez
    header("Access-Control-Allow-Origin: http://localhost:5173"); 
}

header("Access-Control-Allow-Credentials: true");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: GET, POST, PUT, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
    http_response_code(200);
    exit;
}


function base64url_encode($data) {
    return rtrim(strtr(base64_encode($data), '+/', '-_'), '=');
}

function base64url_decode($data) {
    $remainder = strlen($data) % 4;
    if ($remainder) {
        $padlen = 4 - $remainder;
        $data .= str_repeat('=', $padlen);
    }
    return base64_decode(strtr($data, '-_', '+/'));
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

    $headerEncoded = $tokenParts[0];
    $payloadEncoded = $tokenParts[1];
    $signatureProvided = $tokenParts[2];

    $headerJson = base64url_decode($headerEncoded);
    $headerArr = json_decode($headerJson, true);
    if (!isset($headerArr['alg']) || $headerArr['alg'] !== 'HS256') return false;

    $signatureValid = base64url_encode(hash_hmac('sha256', $headerEncoded . "." . $payloadEncoded, $secret, true));
    if (!hash_equals($signatureValid, $signatureProvided)) return false;

    $payload = base64url_decode($payloadEncoded);
    $payloadArr = json_decode($payload, true);

    if (!is_array($payloadArr)) return false;
    if (isset($payloadArr['exp']) && $payloadArr['exp'] < time()) return false;

    return $payloadArr;
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
        if (count($whereConditions) > 0) {
            $sql .= " WHERE " . implode(" AND ", $whereConditions);
        }

        if (!empty($_GET['sort']) && in_array($_GET['sort'], $allowedSorts)) {
            $sortColumn = $_GET['sort'];
            $direction = (isset($_GET['order']) && strtolower($_GET['order']) === 'desc') ? 'DESC' : 'ASC';
            $sql .= " ORDER BY `$sortColumn` $direction";
        }
    }
    
    $stmt = $pdo->prepare($sql);
    $stmt->execute($params);
    return ($idOrAll === 'all') ? $stmt->fetchAll() : $stmt->fetch();
}

function createResource($pdo, $table, $data, $allowedFields = null) {
    if (empty($data)) return false;

    // Require an explicit whitelist to avoid blind INSERT of arbitrary keys
    if (!is_array($allowedFields) || count($allowedFields) === 0) {
        throw new \InvalidArgumentException('Insert not allowed without allowedFields list.');
    }

    $filtered = array_intersect_key($data, array_flip($allowedFields));
    if (empty($filtered)) return false;

    $columns = array_keys($filtered);
    $placeholders = array_fill(0, count($filtered), '?');
    $sql = "INSERT INTO `$table` (`" . implode("`, `", $columns) . "`) VALUES (" . implode(", ", $placeholders) . ")";
    $stmt = $pdo->prepare($sql);
    $stmt->execute(array_values($filtered));
    return true;
}
function deleteResource($pdo, $table, $idColumn, $id) {
    $sql = "DELETE FROM `$table` WHERE `$idColumn` = ?";
    $stmt = $pdo->prepare($sql); $stmt->execute([$id]);
    return $stmt->rowCount();
}

function updateResource($pdo, $table, $idColumn, $id, $data, $allowedFields = null) {
    if (empty($data) || !is_array($data)) {
        return false;
    }

    if (is_array($allowedFields) && count($allowedFields) > 0) {
        $data = array_intersect_key($data, array_flip($allowedFields));
    }

    if (isset($data[$idColumn])) {
        unset($data[$idColumn]);
    }

    if (empty($data)) {
        return false;
    }

    $columns = array_keys($data);
    $assignments = array_map(fn($col) => "`$col` = ?", $columns);
    $sql = "UPDATE `$table` SET " . implode(', ', $assignments) . " WHERE `$idColumn` = ?";
    $params = array_values($data);
    $params[] = $id;

    $stmt = $pdo->prepare($sql);
    $stmt->execute($params);
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
    'foodbeverage' => ['GET'],
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

// --- IDOR / BOLA AUTHORIZATION MIDDLEWARE FOR GUESTS ---
if (!$isPublic && isset($authenticatedUser['booking_id'])) {
    $guestId = $authenticatedUser['guest_id'];
    $bookingId = $authenticatedUser['booking_id'];

    // 1. Block guests from accessing employee endpoints
    if ($resource === 'employee') {
        http_response_code(403);
        echo json_encode(["error" => "Access denied. Guests cannot access employee records."]);
        exit;
    }

    // 2. Restrict guests to their own guest profile
    if ($resource === 'guest') {
        if ($id === 'all') {
            $id = $guestId; // Force filter to own guest ID
        } elseif ($id != $guestId) {
            http_response_code(403);
            echo json_encode(["error" => "Access denied to other guest profiles."]);
            exit;
        }
    }

    // 3. Restrict guests to their own booking info
    if ($resource === 'booking') {
        // Special sub-endpoint check for booking/services
        if ($id === 'services') {
            // Handled internally by index.php
        } elseif ($id === 'all') {
            $id = $bookingId; // Force filter to own booking ID
        } elseif ($id !== $bookingId) {
            http_response_code(403);
            echo json_encode(["error" => "Access denied to other bookings."]);
            exit;
        }
    }

    // 4. Restrict guests to their assigned room
    if ($resource === 'room') {
        // Fetch the assigned room number for this booking
        $stmt = $pdo->prepare("SELECT `room_number` FROM `bookings` WHERE `id` = ? LIMIT 1");
        $stmt->execute([$bookingId]);
        $assignedRoom = $stmt->fetchColumn();

        if ($id === 'all') {
            $id = $assignedRoom ? $assignedRoom : 'none';
        } elseif ($id != $assignedRoom) {
            http_response_code(403);
            echo json_encode(["error" => "Access denied. You can only access details for your assigned room."]);
            exit;
        }
    }

    // 5. Restrict guests to their own service bookings
    if ($resource === 'servicebooking') {
        if ($method === 'POST') {
            // Enforce that guest can only create service bookings for their own booking
            $inputData['booking_id'] = $bookingId;
        } elseif ($id !== 'all') {
            // Check ownership of the requested service booking
            $stmt = $pdo->prepare("SELECT `booking_id` FROM `servicebookings` WHERE `id` = ? LIMIT 1");
            $stmt->execute([$id]);
            $ownerBookingId = $stmt->fetchColumn();

            if ($ownerBookingId !== $bookingId) {
                http_response_code(403);
                echo json_encode(["error" => "Access denied to this service booking."]);
                exit;
            }
        }
    }
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

        $stmt = $pdo->prepare("SELECT * FROM `guests` WHERE `email` = ? LIMIT 1");
        $stmt->execute([$email]);
        $guest = $stmt->fetch();

        if (!$guest) {
            http_response_code(401);
            echo json_encode(["success" => false, "errorType" => "noMatchingEmailOrBooking"]);
            exit;
        }

        $stmt = $pdo->prepare("SELECT * FROM `bookings` WHERE `id` = ? LIMIT 1");
        $stmt->execute([$bookingId]);
        $booking = $stmt->fetch();

        if (!$booking || $booking['guest1_id'] != $guest['id']) {
            http_response_code(401);
            echo json_encode(["success" => false, "errorType" => "noMatchingEmailOrBooking"]);
            exit;
        }

        if (!empty($booking['checkout']) || date('Y-m-d', strtotime($booking['end_of_stay'])) < date('Y-m-d')) {
            http_response_code(401);
            echo json_encode(["success" => false, "errorType" => "bookingExpired"]);
            exit;
        }

        $guestId = (int)$guest['id'];
        $jti = bin2hex(random_bytes(16)); // randomizált tokenazonosító

        $accessTokenPayload = [
            'guest_id' => $guestId,
            'booking_id' => $booking['id']
        ];

        $refreshTokenPayload = [
            'guest_id' => $guestId,
            'booking_id' => $booking['id'],
            'jti' => $jti
        ];

        $accessToken = generate_jwt($accessTokenPayload, $jwt_secret, 900);       // 15 perc
        $refreshToken = generate_jwt($refreshTokenPayload, $jwt_secret, 604800);   // 7 nap

        $expiresAt = date('Y-m-d H:i:s', time() + 604800);
        $dbStmt = $pdo->prepare("INSERT INTO `refresh_tokens` (`guest_id`, `token_id`, `expires_at`) VALUES (?, ?, ?)");
        $dbStmt->execute([$guestId, $jti, $expiresAt]);

        setcookie('refresh_token', $refreshToken, [
            'expires' => time() + 604800,
            'path' => '/',
            'domain' => '', 
            'secure' => $isUsingHttps,
            'httponly' => true,
            'samesite' => 'Lax'
        ]);

        echo json_encode([
            "success" => true,
            "accessToken" => $accessToken
        ]);
        exit;
    }

    // B: TOKEN REFRESH FOLYAMAT
    if ($id === 'refresh' && $method === 'POST') {
        $refreshToken = $_COOKIE['refresh_token'] ?? null;

        if (!$refreshToken) {
            http_response_code(401);
            echo json_encode(["success" => false, "error" => "Nincs refresh token a sutikben."]);
            exit;
        }

        $payload = verify_jwt($refreshToken, $jwt_secret);

        if (!$payload) {
            http_response_code(401);
            echo json_encode(["success" => false, "error" => "Lejart vagy manipulalt refresh token."]);
            exit;
        }

        if (!isset($payload['jti'])) {
            http_response_code(401);
            echo json_encode(["success" => false, "error" => "Hibás token struktúra."]);
            exit;
        }

        $dbStmt = $pdo->prepare("SELECT * FROM `refresh_tokens` WHERE `token_id` = ? AND `expires_at` > NOW() LIMIT 1");
        $dbStmt->execute([$payload['jti']]);
        $dbToken = $dbStmt->fetch();

        if (!$dbToken) {
            http_response_code(401);
            echo json_encode(["success" => false, "error" => "A refresh tokent érvénytelenítették vagy lejárt (kijelentkezett)."]);
            exit;
        }

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

    // C: LOGOUT FOLYAMAT
    if ($id === 'logout' && $method === 'POST') {
        $refreshToken = $_COOKIE['refresh_token'] ?? null;

        if ($refreshToken) {
            $payload = verify_jwt($refreshToken, $jwt_secret);
            
            if ($payload && isset($payload['jti'])) {
                $dbStmt = $pdo->prepare("DELETE FROM `refresh_tokens` WHERE `token_id` = ?");
                $dbStmt->execute([$payload['jti']]);
            }
        }

        setcookie('refresh_token', '', [
            'expires' => time() - 3600, // Lejárt 1 órája
            'path' => '/',
            'domain' => '', 
            'secure' => $isUsingHttps,
            'httponly' => true,
            'samesite' => 'Lax'
        ]);

        http_response_code(200);
        echo json_encode([
            "success" => true,
            "message" => "Sikeres kijelentkezés, token azonosító törölve az adatbázisból."
        ]);
        exit;
    }

    // C -> D: PUBLIKUS FOGLALÁS
    if ($id === 'public-booking' && $method === 'POST') {
        $email = $inputData['email'] ?? null;
        
        if (!$email) {
            http_response_code(400);
            echo json_encode(["success" => false, "error" => "Az e-mail cím megadása kötelező."]);
            exit;
        }

        try {
            $pdo->beginTransaction();

            $stmt = $pdo->prepare("SELECT `id`, `fname`, `lname` FROM `guests` WHERE `email` = ? LIMIT 1");
            $stmt->execute([$email]);
            $existingGuest = $stmt->fetch();

            if ($existingGuest) {
                // Prevent account takeover by verifying first and last name match existing record
                $existingFname = mb_strtolower(trim($existingGuest['fname']), 'UTF-8');
                $existingLname = mb_strtolower(trim($existingGuest['lname']), 'UTF-8');
                $inputFname = mb_strtolower(trim($inputData['fname'] ?? ''), 'UTF-8');
                $inputLname = mb_strtolower(trim($inputData['lname'] ?? ''), 'UTF-8');

                if ($existingFname !== $inputFname || $existingLname !== $inputLname) {
                    http_response_code(400);
                    echo json_encode([
                        "success" => false, 
                        "error" => "Ez az e-mail cím már regisztrálva van egy másik névvel."
                    ]);
                    $pdo->rollBack();
                    exit;
                }
                $guestId = $existingGuest['id'];
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

            $bookingId = $inputData['booking_id'] ?? null;
            if ($bookingId) {
                $stmt = $pdo->prepare("SELECT COUNT(*) FROM `bookings` WHERE `id` = ?");
                $stmt->execute([$bookingId]);
                if ($stmt->fetchColumn() > 0) {
                    http_response_code(400);
                    echo json_encode(["success" => false, "error" => "A megadott foglalási azonosító már létezik."]);
                    $pdo->rollBack();
                    exit;
                }
            }
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
            if ($pdo->inTransaction()) { $pdo->rollBack(); }
            
            error_log($e->getMessage()); 
            
            http_response_code(500);
            echo json_encode(["success" => false, "error" => "Adatbázis hiba történt a foglalás során."]);
            exit;
        }
    }

    http_response_code(404);
    echo json_encode(["error" => "Ismeretlen auth muvelet."]);
    exit;
}

if ($resource == "foodbeverage" && $id == "categories" && $method == "GET") {
    try {
        $pdo->beginTransaction();

        $stmt = $pdo->prepare("SELECT DISTINCT category FROM food_and_beverage ORDER BY category");
        $stmt->execute();
        $foodbevCategories = $stmt->fetchAll(PDO::FETCH_COLUMN);
        http_response_code(200);
        echo json_encode(["success" => true, "categories" => $foodbevCategories]);
        exit;

    } catch (\Throwable $e) {
        if ($pdo->inTransaction()) { $pdo->rollBack(); }
        
        error_log($e->getMessage()); 
        
        http_response_code(500);
        echo json_encode(["success" => false, "error" => "Adatbázis hiba történt a lekérés során."]);
        exit;
    }
}

if ($resource == "servicebooking" && $id == "updatestatus" && $method == "POST") {
    
    if (empty($inputData) || !isset($inputData['id']) || !isset($inputData['status'])) { 
        http_response_code(400); 
        echo json_encode(["success" => false, "error" => "Hiányzó vagy hibás JSON adatok."]); 
        exit; 
    }

    try {
        $serviceBookingId = $inputData['id'];
        $status = $inputData['status'];

        $stmt = $pdo->prepare("SELECT id FROM servicebookings WHERE id = ?");
        $stmt->execute([$serviceBookingId]);
        $exists = $stmt->fetch();

        if (!$exists) { 
            http_response_code(404);
            echo json_encode(["success" => false, "error" => "Nem létező ID."]); 
            exit; 
        }

        $stmt = $pdo->prepare("UPDATE servicebookings SET `status` = ? WHERE id = ?");
        $stmt->execute([$status, $serviceBookingId]);

        echo json_encode(["success" => true, "message" => "Sikeres frissítés."]);
        exit;

    } catch (\Throwable $e) {
        error_log($e->getMessage()); 
        
        http_response_code(500);
        echo json_encode(["success" => false, "error" => "Adatbázis hiba történt a művelet során."]);
        exit;
    }
}

// --- NORMÁL TÁBLA ALAPÚ ENDPOINTEK DEFINÍCIÓJA ---
$endpoints = [
    'room' => [
        'table'   => 'rooms',
        'id'      => 'room_number',
        'filters' => ['room_type', 'status', 'bed_type', 'has_balcony'],
        'sorts'   => ['room_number', 'price_per_night', 'floorspace'],
        'enums'   => [
            'status' => ['available','occupied','under_maintenance','unavailable'],
            'room_type' => ['standard','deluxe','suite'],
            'bed_type' => ['single', 'twin', 'kingsize'],
            'has_view' => ['city', 'garden', 'panorama']
        ],
        'update_fields' => ['room_type','floorspace','bed_type','has_balcony','has_view','max_adults','extras','status','door_locked','needs_cleaning','is_cleaning','dont_disturb','ac_temp','price_per_night'],
    ],
    'guest' => [
        'table'   => 'guests',
        'id'      => 'id',
        'filters' => ['city', 'country', 'loyalty_level', 'email'],
        'sorts'   => ['fname', 'lname', 'country', 'loyalty_level'],
        'insert_fields' => ['email','fname','lname','zip_code','country','city','street']
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
        'sorts'   => ['name_hu', 'name_en', 'price', 'service_type_hu', 'service_type_en'],
        'insert_fields' => ['name_hu','name_en','price','service_type_hu','service_type_en']
    ],
    'booking' => [
        'table'   => 'bookings',
        'id'      => 'id',
        'filters' => ['room_number', 'guest1_id','end_of_stay_after'],
        'sorts'   => ['beginning_of_stay', 'room_number', 'guest1_id'],
        'enums'   => [
            'room_type'  => ['standard','deluxe','suite'],
            'needs_view' => ['city', 'garden', 'panorama']
        ]
    ],
    'servicebooking' => [
        'table'   => 'servicebookings',
        'id'      => 'id',
        'filters' => ['status', 'booking_id'],
        'sorts'   => ['status', 'updated_at'],
        'enums'   => ['status' => ['created', 'pending', 'completed', 'deleted']],
        'insert_fields' => ['booking_id','service_id','quantity','status','price_at_booking']
    ],
    'foodbeverage' => [
        'table'   => 'food_and_beverage',
        'id'      => 'id',
        'filters' => ['category'],
        'sorts'   => ['category', 'price', 'name_hu', 'name_en'],
        'enums'   => ['category' => ['breakfast','starter','soup','main_course','dessert','hot_drink','soft_drink','alcoholic_drink']]
    ],
    'freerooms' => [
        'filters' => ['end_of_stay_after']
    ]
];

if (array_key_exists($resource, $endpoints)) {
    $config = $endpoints[$resource];

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

    // --- EGYEDI AL-VÉGPONT: FOGLALÁSHOZ TARTOZÓ SZOLGÁLTATÁSOK LEKÉRDEZÉSE ---
    if ($resource === 'booking' && $id === 'services') {
        if ($method !== 'GET') {
            http_response_code(405);
            echo json_encode(["error" => "Nem engedélyezett metódus: $method"]);
            exit;
        }

        $currentBookingId = $authenticatedUser['booking_id'] ?? null;

        if (!$currentBookingId) {
            http_response_code(400);
            echo json_encode(["error" => "Nem található érvényes foglalási azonosító a tokenben."]);
            exit;
        }

        try {
            $sql = "SELECT 
                        sb.id,
                        sb.quantity,
                        sb.status,
                        sb.requested_at,
                        sb.updated_at,
                        sb.price_at_booking,
                        s.id AS service_id,
                        s.name_hu,
                        s.name_en,
                        s.service_type_hu,
                        s.service_type_en
                    FROM `servicebookings` sb
                    INNER JOIN `services` s ON sb.service_id = s.id
                    WHERE sb.booking_id = ?";

            $stmt = $pdo->prepare($sql);
            $stmt->execute([$currentBookingId]);
            $services = $stmt->fetchAll();

            echo json_encode($services);
            exit;
        } catch (\PDOException $e) {
            http_response_code(500);
            echo json_encode(["error" => "Adatbázis hiba: " . $e->getMessage()]);
            exit;
        }
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
                if (!isset($config['insert_fields']) || !is_array($config['insert_fields']) || count($config['insert_fields']) === 0) {
                    http_response_code(403);
                    echo json_encode(["error" => "Insert not allowed for this resource."]);
                    break;
                }

                createResource($pdo, $table, $inputData, $config['insert_fields']);
                http_response_code(201);
                echo json_encode(["id" => $pdo->lastInsertId(), "success" => true, "message" => "Sikeresen létrehozva."]);
            } catch (\InvalidArgumentException $e) {
                http_response_code(403);
                echo json_encode(["error" => $e->getMessage()]);
            } catch (\PDOException $e) { http_response_code(400); echo json_encode(["error" => $e->getMessage()]); }
            break;

        case 'DELETE':
            if ($id === 'all') { http_response_code(400); echo json_encode(["error" => "Hianyzo ID."]); break; }
            try {
                $affected = deleteResource($pdo, $table, $idCol, $id);
                if ($affected > 0) { echo json_encode(["success" => true, "message" => "Torolve."]); } 
                else { http_response_code(404); echo json_encode(["error" => "Nem talalhato."]); }
            } catch (\PDOException $e) { http_response_code(400); echo json_encode(["error" => $e->getMessage()]); }
            break;
        case 'PUT':
            if ($id === 'all') { http_response_code(400); echo json_encode(["error" => "Hianyzo ID."]); break; }
            if (empty($inputData) || !is_array($inputData)) { http_response_code(400); echo json_encode(["error" => "Hianyzo vagy hibas JSON adatok."]); break; }
            try {
                $allowedFields = $config['update_fields'] ?? $config['insert_fields'] ?? null;
                $affected = updateResource($pdo, $table, $idCol, $id, $inputData, $allowedFields);
                if ($affected > 0) {
                    echo json_encode(["success" => true, "message" => "Sikeres frissítés."]);
                } else {
                    http_response_code(404);
                    echo json_encode(["error" => "Nem talalhato vagy nincs valtozas."]);
                }
            } catch (\PDOException $e) { http_response_code(400); echo json_encode(["error" => $e->getMessage()]); }
            break;
    }
} else {
    http_response_code(404);
    echo json_encode(["error" => "Ismeretlen végpont: $resource"]);
}