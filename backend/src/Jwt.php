<?php

function base64url_encode(string $data): string {
    return rtrim(strtr(base64_encode($data), '+/', '-_'), '=');
}

function base64url_decode(string $data): string {
    $remainder = strlen($data) % 4;
    if ($remainder) {
        $data .= str_repeat('=', 4 - $remainder);
    }
    return base64_decode(strtr($data, '-_', '+/'));
}

function generateJwt(array $payload, string $secret, int $expirySeconds): string {
    $header = json_encode(['typ' => 'JWT', 'alg' => 'HS256']);
    $payload['exp'] = time() + $expirySeconds;
    $payload['iat'] = time();

    $base64UrlHeader = base64url_encode($header);
    $base64UrlPayload = base64url_encode(json_encode($payload));
    $signature = hash_hmac('sha256', $base64UrlHeader . '.' . $base64UrlPayload, $secret, true);
    $base64UrlSignature = base64url_encode($signature);

    return sprintf('%s.%s.%s', $base64UrlHeader, $base64UrlPayload, $base64UrlSignature);
}

function verifyJwt(string $jwt, string $secret) {
    $tokenParts = explode('.', $jwt);
    if (count($tokenParts) !== 3) {
        return false;
    }

    [$headerEncoded, $payloadEncoded, $signatureProvided] = $tokenParts;
    $headerJson = base64url_decode($headerEncoded);
    $header = json_decode($headerJson, true);

    if (!is_array($header) || ($header['alg'] ?? '') !== 'HS256') {
        return false;
    }

    $signatureValid = base64url_encode(hash_hmac('sha256', $headerEncoded . '.' . $payloadEncoded, $secret, true));
    if (!hash_equals($signatureValid, $signatureProvided)) {
        return false;
    }

    $payloadJson = base64url_decode($payloadEncoded);
    $payload = json_decode($payloadJson, true);

    if (!is_array($payload)) {
        return false;
    }

    if (isset($payload['exp']) && $payload['exp'] < time()) {
        return false;
    }

    return $payload;
}
