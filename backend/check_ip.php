<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json");

$hotel_ips = ["78.131.58.217", "91.227.139.94", "::1", "127.0.0.1", "192.168.2.162"];

$client_ip = $_SERVER['REMOTE_ADDR'];
if (isset($_SERVER['HTTP_X_FORWARDED_FOR'])) {
    $client_ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
}

$is_at_hotel = in_array($client_ip, $hotel_ips);

echo json_encode([
    "isAtHotel" => $is_at_hotel,
    "debug_your_ip" => $client_ip
]);