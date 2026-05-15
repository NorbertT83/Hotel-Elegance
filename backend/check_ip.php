<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json");

$hotel_ips = ["1.23.45.67", "::1", "127.0.0.1"];

$client_ip = $_SERVER['REMOTE_ADDR'];
if (isset($_SERVER['HTTP_X_FORWARDED_FOR'])) {
    $client_ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
}

$is_at_hotel = in_array($client_ip, $hotel_ips);

echo json_encode([
    "isAtHotel" => $is_at_hotel,
    "debug_your_ip" => $client_ip
]);

// TODO - minden kérésnél lefut ez is és szemeteli a JSON-t!!!!