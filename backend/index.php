<?php
$config = require 'config.php';

$host = $config['db_host'];
$db   = $config['db_name'];
$user = $config['db_user'];
$pass = $config['db_pass'];
$charset = $config['db_char'];


header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, PUT, DELETE, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");


if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
    http_response_code(200);
    exit;
}

$dsn = "mysql:host=$host;dbname=$db;charset=$charset";
$options = [
    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    PDO::ATTR_EMULATE_PREPARES   => false,
    // PDO::MYSQL_ATTR_INIT_COMMAND => "SET SESSION sql_mode='STRICT_ALL_TABLES'" szigorú mód
];

try {
    $pdo = new PDO($dsn, $user, $pass, $options);
} catch (\PDOException $e) {
    http_response_code(500);
    echo json_encode(["error" => "Adatbázis hiba: " . $e->getMessage()]);
    exit;
}

/** 
 * GET: Univerzális erőforrás lekérdező 
 */
function fetchResource($pdo, $table, $idOrAll, $idColumn, $allowedFilters = [], $allowedSorts = []) {
    $params = [];
    $sql = "SELECT * FROM `$table`";

    if ($idOrAll !== 'all') {
        $sql .= " WHERE `$idColumn` = ?";
        $params[] = $idOrAll;
    } else {
        $whereConditions = [];
        foreach ($_GET as $key => $value) {
            if (!$value) {
                echo json_encode(["error" => "Nincs megadva paraméter."]);
                exit;
            }

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

        if (!empty($_GET['limit']) && is_numeric($_GET['limit'])) {
            $limit = (int)$_GET['limit'];
            $sql .= " LIMIT $limit";

            if (!empty($_GET['offset']) && is_numeric($_GET['offset'])) {
                $offset = (int)$_GET['offset'];
                $sql .= " OFFSET $offset";
            }
        }
    }

    $stmt = $pdo->prepare($sql);
    $stmt->execute($params);

    return ($idOrAll === 'all') ? $stmt->fetchAll() : $stmt->fetch();
}

/** 
 * POST: Univerzális erőforrás létrehozó 
 */
function createResource($pdo, $table, $data) {
    if (empty($data)) return false;

    $columns = array_keys($data);
    $placeholders = array_fill(0, count($data), '?');
    
    $sql = "INSERT INTO `$table` (`" . implode("`, `", $columns) . "`) VALUES (" . implode(", ", $placeholders) . ")";
    
    $stmt = $pdo->prepare($sql);
    $stmt->execute(array_values($data));
    
    return true; // Siker esetén true. (Ha auto-increment az ID, itt lehetne $pdo->lastInsertId())
}

/** 
 * PUT: Univerzális erőforrás frissítő 
 */
function updateResource($pdo, $table, $idColumn, $id, $data) {
    if (empty($data)) return 0;

    $setClause = [];
    $params = [];
    
    foreach ($data as $key => $value) {
        $setClause[] = "`$key` = ?";
        $params[] = $value;
    }
    
    // Az ID-t adjuk hozzá utoljára a WHERE feltételhez
    $params[] = $id; 
    
    $sql = "UPDATE `$table` SET " . implode(", ", $setClause) . " WHERE `$idColumn` = ?";
    
    $stmt = $pdo->prepare($sql);
    $stmt->execute($params);
    
    return $stmt->rowCount(); // Visszaadja a módosított sorok számát
}

/** 
 * DELETE: Univerzális erőforrás törlő 
 */
function deleteResource($pdo, $table, $idColumn, $id) {
    $sql = "DELETE FROM `$table` WHERE `$idColumn` = ?";
    $stmt = $pdo->prepare($sql);
    $stmt->execute([$id]);
    
    return $stmt->rowCount(); // Visszaadja a törölt sorok számát
}


// --- ROUTING ÉS KÉRÉS FELDOLGOZÁSA ---

$requestPath = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
$scriptPath = dirname($_SERVER['SCRIPT_NAME']); 
$requestUri = str_replace($scriptPath, '', $requestPath);
$requestUri = trim($requestUri, '/');

$parts = explode('/', $requestUri);

$resource = $parts[0] ?? null;
$id = $parts[1] ?? 'all'; // Alapértelmezettként 'all', ha nincs ID megadva
$method = $_SERVER['REQUEST_METHOD']; // Metódus lekérése

if (!$resource) {
    http_response_code(400);
    echo json_encode(["error" => "Nincs megadva erőforrás."]);
    exit;
}

// Bemeneti JSON adat beolvasása POST és PUT kérésekhez
$inputData = json_decode(file_get_contents("php://input"), true);

// Definíciók[cite: 1]
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
        'filters' => ['end_of_stay_after']  // Ez egy virtuális végpont lesz, ami egy összetett lekérdezést hajt végre a szabad szobák listázásához.
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

        // Rugalmasan elfogad többféle elnevezést a dátumokra
        $start = $_GET['start_date'] ?? $_GET['beginning_of_stay'] ?? null;
        $end = $_GET['end_date'] ?? $_GET['end_of_stay'] ?? null;

        if (!$start || !$end) {
            http_response_code(400);
            echo json_encode(["error" => "A szabad szobák lekérdezéséhez a kezdő (start_date) és végdátum (end_date) megadása kötelező."]);
            exit;
        }

        $sql = "SELECT * FROM `rooms` WHERE `room_number` NOT IN (
                    SELECT DISTINCT `room_number` FROM `bookings` 
                    WHERE `room_number` IS NOT NULL 
                        AND `beginning_of_stay` < ? 
                        AND `end_of_stay` > ?
                )";
        $params = [$end, $start]; 

        // a szabad szobák szűrési lehetősége
        $allowedRoomFilters = ['room_type', 'status', 'bed_type', 'has_balcony'];
        foreach ($_GET as $key => $value) {
            if (in_array($key, $allowedRoomFilters) && $value !== '') {
                $sql .= " AND `$key` = ?";
                $params[] = $value;
            }
        }

        // a szabad szobák rendezési lehetősége
        $allowedRoomSorts = ['room_number', 'price_per_night', 'floorspace'];
        if (!empty($_GET['sort']) && in_array($_GET['sort'], $allowedRoomSorts)) {
            $sortColumn = $_GET['sort'];
            $direction = (isset($_GET['order']) && strtolower($_GET['order']) === 'desc') ? 'DESC' : 'ASC';
            $sql .= " ORDER BY `$sortColumn` $direction";
        }

        try {
            $stmt = $pdo->prepare($sql);
            $stmt->execute($params);
            $result = $stmt->fetchAll();
            echo json_encode($result);
        } catch (\PDOException $e) {
            http_response_code(500);
            echo json_encode(["error" => "Adatbázis hiba a szabad szobák lekérésekor: " . $e->getMessage()]);
        }
        exit; // ne menjen tovább a normál tábla alapú ágra
    }
    // --- VIRTUÁLIS VÉGPONT VÉGE ---

    $table = $config['table'];
    $idCol = $config['id'];
    
    switch ($method) {
        case 'GET':
            $result = fetchResource($pdo, $table, $id, $idCol, $config['filters'], $config['sorts']);
            if ($result) {
                echo json_encode($result);
            } else {
                http_response_code(404);
                echo json_encode(["error" => "Nincs találat: $resource #$id"]);
            }
            break;

        case 'POST':
            if (empty($inputData)) {
                http_response_code(400);
                echo json_encode(["error" => "Érvénytelen vagy hiányzó JSON adat."]);
                break;
            }
            // Validáció az ENUM mezőkre
            if (isset($config['enums'])) {
                foreach ($config['enums'] as $column => $allowedValues) {
                    // Ha küldtek be adatot ehhez az oszlophoz
                    if (array_key_exists($column, $inputData)) {
                        if (!in_array($inputData[$column], $allowedValues)) {
                            http_response_code(400);
                            echo json_encode([
                                "error" => "Érvénytelen érték a(z) '$column' mezőben.",
                            ]);
                            exit;
                        }
                    }
                }
            }

            try {
                createResource($pdo, $table, $inputData);
                http_response_code(201); // 201 Created
                echo json_encode(["id" => $pdo->lastInsertId(), "message" => "Sikeresen létrehozva."]);
            } catch (\PDOException $e) {
                http_response_code(400);
                echo json_encode(["error" => "Hiba a létrehozás során: " . $e->getMessage()]);
            }
            break;

        case 'PUT':
            if ($id === 'all') {
                http_response_code(400);
                echo json_encode(["error" => "Frissítéshez kötelező megadni az azonosítót (ID/kulcs)."]);
                break;
            }
            if (empty($inputData)) {
                http_response_code(400);
                echo json_encode(["error" => "Érvénytelen vagy hiányzó JSON adat."]);
                break;
            }
            // Validáció az ENUM mezőkre
            if (isset($config['enums'])) {
                foreach ($config['enums'] as $column => $allowedValues) {
                    // Ha küldtek be adatot ehhez az oszlophoz
                    if (array_key_exists($column, $inputData)) {
                        if (!in_array($inputData[$column], $allowedValues)) {
                            http_response_code(400);
                            echo json_encode([
                                "error" => "Érvénytelen érték a(z) '$column' mezőben.",
                            ]);
                            exit;
                        }
                    }
                }
            }

            try {
                $affected = updateResource($pdo, $table, $idCol, $id, $inputData);
                if ($affected > 0) {
                    echo json_encode(["message" => "Sikeresen frissítve.", "affected_rows" => $affected]);
                } else {
                    http_response_code(404);
                    echo json_encode(["message" => "A rekord nem található, vagy az adatok megegyeznek a jelenlegiekkel."]);
                }
            } catch (\PDOException $e) {
                http_response_code(400);
                echo json_encode(["error" => "Hiba a frissítés során: " . $e->getMessage()]);
            }
            break;

        case 'DELETE':
            if ($id === 'all') {
                http_response_code(400);
                echo json_encode(["error" => "Törléshez kötelező megadni az azonosítót."]);
                break;
            }
            try {
                $affected = deleteResource($pdo, $table, $idCol, $id);
                if ($affected > 0) {
                    echo json_encode(["message" => "Sikeresen törölve.", "affected_rows" => $affected]);
                } else {
                    http_response_code(404);
                    echo json_encode(["error" => "A törölni kívánt rekord nem található."]);
                }
            } catch (\PDOException $e) {
                http_response_code(400);
                echo json_encode(["error" => "Hiba a törlés során (pl. kapcsolódó adatok): " . $e->getMessage()]);
            }
            break;

        default:
            http_response_code(405); // 405 Method Not Allowed
            echo json_encode(["error" => "Nem engedélyezett metódus: $method"]);
            break;
    }

} else {
    http_response_code(404);
    echo json_encode(["error" => "Ismeretlen végpont: $resource"]);
}