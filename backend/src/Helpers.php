<?php

function getRequestMethod(): string {
    return $_SERVER['REQUEST_METHOD'] ?? 'GET';
}

function getRequestUriPath(): string {
    return parse_url($_SERVER['REQUEST_URI'] ?? '', PHP_URL_PATH) ?: '';
}

function getRequestBody(): array {
    $input = file_get_contents('php://input');
    return json_decode($input, true) ?: [];
}

function getRequestHeaders(): array {
    if (function_exists('getallheaders')) {
        return getallheaders();
    }

    $headers = [];
    foreach ($_SERVER as $name => $value) {
        if (str_starts_with($name, 'HTTP_')) {
            $headerName = str_replace(' ', '-', ucwords(strtolower(str_replace('_', ' ', substr($name, 5)))));
            $headers[$headerName] = $value;
        }
    }
    return $headers;
}

function getBearerToken(): ?string {
    $headers = getRequestHeaders();
    $authHeader = $headers['Authorization'] ?? $headers['authorization'] ?? null;
    if (!$authHeader) {
        return null;
    }

    return preg_match('/Bearer\s+(\S+)/', $authHeader, $matches) ? $matches[1] : null;
}

function getClientIp(): string {
    return $_SERVER['REMOTE_ADDR'] ?? 'unknown';
}

function getRequestOrigin(): string {
    return $_SERVER['HTTP_ORIGIN'] ?? '';
}

function isHttpsRequest(): bool {
    return (!empty($_SERVER['HTTPS']) && $_SERVER['HTTPS'] !== 'off') ||
        (isset($_SERVER['HTTP_X_FORWARDED_PROTO']) && $_SERVER['HTTP_X_FORWARDED_PROTO'] === 'https');
}

function sendCorsHeaders(array $allowedOrigins): void {
    $origin = getRequestOrigin();
    $allowedOrigin = in_array($origin, $allowedOrigins, true) ? $origin : 'http://localhost:5173';

    header("Access-Control-Allow-Origin: $allowedOrigin");
    header('Access-Control-Allow-Credentials: true');
    header('Content-Type: application/json; charset=UTF-8');
    header('Access-Control-Allow-Methods: GET, POST, PUT, OPTIONS');
    header('Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With');
}

function sendJsonResponse(array $payload, int $status = 200): void {
    http_response_code($status);
    echo json_encode($payload);
    exit;
}

function sendError(string $message, int $status = 400, array $extra = []): void {
    $payload = array_merge(['error' => $message], $extra);
    sendJsonResponse($payload, $status);
}
