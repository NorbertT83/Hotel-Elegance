<?php
$config = require 'config.php';

$host = $config['db_host'];
$db   = $config['db_name'];
$user = $config['db_user'];
$pass = $config['db_pass'];
$charset = $config['db_char'];

header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Origin: *");

$dsn = "mysql:host=$host;dbname=$db;charset=$charset";
$options = [
    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    PDO::ATTR_EMULATE_PREPARES   => false,
];


/**
 * Univerzális erőforrás lekérdező
 * * @param PDO $pdo Az adatbázis kapcsolat
 * @param string $table A tábla neve
 * @param string $idOrAll Az ID vagy az 'all' kulcsszó
 * @param string $idColumn A tábla azonosító oszlopa (pl. 'id' vagy 'room_number')
 * @param array $allowedFilters Azok az oszlopok, amikre engedünk szűrni
 */
function fetchResource($pdo, $table, $idOrAll, $idColumn, $allowedFilters = [], $allowedSorts = []) {
    $params = [];
    $sql = "SELECT * FROM `$table`";

    if ($idOrAll !== 'all') {
        // Egy konkrét rekord
        $sql .= " WHERE `$idColumn` = ?";
        $params[] = $idOrAll;
    } else {
        // --- 1. WHERE szűrés ---
        $whereConditions = [];
        foreach ($_GET as $key => $value) {
            if (in_array($key, $allowedFilters) && $value !== '') {
                $whereConditions[] = "`$key` = ?";
                $params[] = $value;
            }
        }
        if (count($whereConditions) > 0) {
            $sql .= " WHERE " . implode(" AND ", $whereConditions);
        }

        // --- 2. ORDER BY (Rendezés) ---
        // Használat: ?sort=price&order=desc
        if (!empty($_GET['sort']) && in_array($_GET['sort'], $allowedSorts)) {
            $sortColumn = $_GET['sort'];
            $direction = (isset($_GET['order']) && strtolower($_GET['order']) === 'desc') ? 'DESC' : 'ASC';
            $sql .= " ORDER BY `$sortColumn` $direction";
        }

        // --- 3. LIMIT & OFFSET (Lapozás) ---
        // Használat: ?limit=10&offset=0
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


try {
    $pdo = new PDO($dsn, $user, $pass, $options);
} catch (\PDOException $e) {
    http_response_code(500);
    echo json_encode(["error" => "Adatbázis hiba: " . $e->getMessage()]);
    exit;
}


$requestPath = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
$scriptPath = dirname($_SERVER['SCRIPT_NAME']); 
$requestUri = str_replace($scriptPath, '', $requestPath);
$requestUri = trim($requestUri, '/');

$parts = explode('/', $requestUri);

$resource = $parts[0] ?? null;
$id = $parts[1] ?? null;

if (!$resource) {
    http_response_code(400);
    echo json_encode(["error" => "Nincs megadva erőforrás."]);
    exit;
}

$sql = "";
$params = [];


// Definíciók: Melyik végponthoz melyik tábla és melyik szűrhető oszlopok tartoznak
$endpoints = [
    'room' => [
        'table'   => 'rooms',
        'id'      => 'room_number',
        'filters' => ['room_type', 'status', 'bed_type', 'has_balcony'],
        'sorts'   => ['room_number', 'price_per_night', 'floorspace']
    ],
    'guest' => [
        'table'   => 'guests',
        'id'      => 'id_card_number',
        'filters' => ['country', 'loyalty_level'],
        'sorts'   => ['fname', 'lname', 'country']
    ],
    'employee' => [
        'table'   => 'employees',
        'id'      => 'id',
        'filters' => ['job_title'],
        'sorts'   => ['fname', 'lname', 'salary', 'date_of_birth', 'date_of_hiring']
    ],
    'service' => [
        'table'   => 'services',
        'id'      => 'id',
        'filters' => ['service_type'],
        'sorts'   => ['name', 'price', 'service_type']
    ]
];

if (array_key_exists($resource, $endpoints)) {
    $config = $endpoints[$resource];
    
    $result = fetchResource(
        $pdo, 
        $config['table'], 
        $id, 
        $config['id'], 
        $config['filters'],
        $config['sorts']
    );

    if ($result) {
        echo json_encode($result);
    } else {
        http_response_code(404);
        echo json_encode(["error" => "Nincs találat: $resource #$id"]);
    }
} else {
    http_response_code(404);
    echo json_encode(["error" => "Ismeretlen végpont: $resource"]);
}