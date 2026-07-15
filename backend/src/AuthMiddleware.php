<?php

function getPublicRoutes(): array {
    return [
        'service' => ['GET'],
        'foodbeverage' => ['GET'],
        'freerooms' => ['GET'],
    ];
}

function isPublicRoute(string $resource, string $method): bool {
    if ($resource === 'auth' || $method === 'OPTIONS') {
        return true;
    }

    $publicRoutes = getPublicRoutes();
    return isset($publicRoutes[$resource]) && in_array($method, $publicRoutes[$resource], true);
}

function authenticateRequest(PDO $pdo, string $resource, string $method, string $jwtSecret) {
    if (isPublicRoute($resource, $method)) {
        return null;
    }

    $token = getBearerToken();
    if (!$token) {
        sendError('Hiányzó vagy érvénytelen Authorization token.', 401);
    }

    $payload = verifyJwt($token, $jwtSecret);
    if (!$payload) {
        sendError('A token lejárt vagy érvénytelen.', 401);
    }

    return $payload;
}

function applyGuestRestrictions(string $resource, string $method, string &$id, array $authenticatedUser, PDO $pdo, array &$inputData): void {
    if (!isset($authenticatedUser['booking_id']) || !isset($authenticatedUser['guest_id'])) {
        return;
    }

    $guestId = $authenticatedUser['guest_id'];
    $bookingId = $authenticatedUser['booking_id'];

    if ($resource === 'employee') {
        sendError('Access denied. Guests cannot access employee records.', 403);
    }

    if ($resource === 'guest') {
        if ($id === 'all') {
            $id = (string)$guestId;
        } elseif ($id !== (string)$guestId) {
            sendError('Access denied to other guest profiles.', 403);
        }
    }

    if ($resource === 'booking') {
        if ($id === 'services') {
            return;
        }
        if ($id === 'all') {
            $id = (string)$bookingId;
        } elseif ($id !== (string)$bookingId) {
            sendError('Access denied to other bookings.', 403);
        }
    }

    if ($resource === 'room') {
        $stmt = $pdo->prepare('SELECT `room_number` FROM `bookings` WHERE `id` = ? LIMIT 1');
        $stmt->execute([$bookingId]);
        $assignedRoom = $stmt->fetchColumn();

        if ($id === 'all') {
            $id = $assignedRoom ? (string)$assignedRoom : 'none';
        } elseif ($id !== (string)$assignedRoom) {
            sendError('Access denied. You can only access details for your assigned room.', 403);
        }
    }

    if ($resource === 'servicebooking') {
        if ($method === 'POST') {
            $inputData['booking_id'] = $bookingId;
            return;
        }

        if ($id !== 'all') {
            $stmt = $pdo->prepare('SELECT `booking_id` FROM `servicebookings` WHERE `id` = ? LIMIT 1');
            $stmt->execute([$id]);
            $ownerBookingId = $stmt->fetchColumn();

            if ($ownerBookingId !== $bookingId) {
                sendError('Access denied to this service booking.', 403);
            }
        }
    }
}
