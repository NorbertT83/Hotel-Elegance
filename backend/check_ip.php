<?php
// Tighten CORS and X-Forwarded-For handling
$config = require __DIR__ . '/config.php';
$allowed_origins = ['http://localhost:5173', 'http://127.0.0.1:5173', 'https://nrbrt-codes.hu'];
$origin = $_SERVER['HTTP_ORIGIN'] ?? '';
if (in_array($origin, $allowed_origins)) {
    header("Access-Control-Allow-Origin: " . $origin);
} else {
    header("Access-Control-Allow-Origin: http://localhost:5173");
}
header("Access-Control-Allow-Credentials: true");
header("Content-Type: application/json; charset=UTF-8");

$hotel_ips = ["78.131.58.217", "91.227.139.94", "::1", "127.0.0.1", "192.168.2.162"];

$client_ip = $_SERVER['REMOTE_ADDR'] ?? '';
if (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
    // X-Forwarded-For may be a comma-separated list - take the first (original client)
    $parts = explode(',', $_SERVER['HTTP_X_FORWARDED_FOR']);
    $first = trim($parts[0]);
    if (filter_var($first, FILTER_VALIDATE_IP)) {
        $client_ip = $first;
    }
}

$is_at_hotel = in_array($client_ip, $hotel_ips, true);

$response = [
    "isAtHotel" => $is_at_hotel
];

// Only include debug ip in non-production environments
if (getenv('DEBUG_IP') === '1') {
    $response['debug_your_ip'] = $client_ip;
}

echo json_encode($response);
