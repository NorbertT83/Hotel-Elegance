<?php

function handleAuthRequest(PDO $pdo, string $id, string $method, array $inputData, string $jwtSecret, bool $isUsingHttps): void {
    if ($id === 'login' && $method === 'POST') {
        handleAuthLogin($pdo, $inputData, $jwtSecret, $isUsingHttps);
    }

    if ($id === 'refresh' && $method === 'POST') {
        handleAuthRefresh($pdo, $jwtSecret);
    }

    if ($id === 'logout' && $method === 'POST') {
        handleAuthLogout($pdo, $jwtSecret, $isUsingHttps);
    }

    if ($id === 'public-booking' && $method === 'POST') {
        handlePublicBooking($pdo, $inputData);
    }

    sendError('Ismeretlen auth muvelet.', 404);
}

function handleAuthLogin(PDO $pdo, array $inputData, string $jwtSecret, bool $isUsingHttps): void {
    if (isRateLimited($pdo, 'login:' . getClientIp(), 10, 900)) {
        header('Retry-After: 900');
        sendJsonResponse(['success' => false, 'errorType' => 'rateLimited', 'error' => 'Túl sok bejelentkezési kísérlet. Kérjük, várjon 15 percet.'], 429);
    }

    $email = $inputData['email'] ?? null;
    $bookingId = $inputData['booking_id'] ?? null;

    if (!$email || !$bookingId) {
        sendError('Hibás kérelem: email és booking_id kötelező.', 400, ['success' => false, 'errorType' => 'missingFields']);
    }

    $stmt = $pdo->prepare('SELECT * FROM `guests` WHERE `email` = ? LIMIT 1');
    $stmt->execute([$email]);
    $guest = $stmt->fetch();

    if (!$guest) {
        sendJsonResponse(['success' => false, 'errorType' => 'noMatchingEmailOrBooking'], 401);
    }

    $stmt = $pdo->prepare('SELECT * FROM `bookings` WHERE `id` = ? LIMIT 1');
    $stmt->execute([$bookingId]);
    $booking = $stmt->fetch();

    if (!$booking || $booking['guest1_id'] != $guest['id']) {
        sendJsonResponse(['success' => false, 'errorType' => 'noMatchingEmailOrBooking'], 401);
    }

    if (!empty($booking['checkout']) || date('Y-m-d', strtotime($booking['end_of_stay'])) < date('Y-m-d')) {
        sendJsonResponse(['success' => false, 'errorType' => 'bookingExpired'], 401);
    }

    $guestId = (int)$guest['id'];
    $jti = bin2hex(random_bytes(16));

    $accessToken = generateJwt(['guest_id' => $guestId, 'booking_id' => $booking['id']], $jwtSecret, 900);
    $refreshToken = generateJwt(['guest_id' => $guestId, 'booking_id' => $booking['id'], 'jti' => $jti], $jwtSecret, 604800);

    $expiresAt = date('Y-m-d H:i:s', time() + 604800);
    $dbStmt = $pdo->prepare('INSERT INTO `refresh_tokens` (`guest_id`, `token_id`, `expires_at`) VALUES (?, ?, ?)');
    $dbStmt->execute([$guestId, $jti, $expiresAt]);

    setcookie('refresh_token', $refreshToken, [
        'expires' => time() + 604800,
        'path' => '/',
        'domain' => '',
        'secure' => $isUsingHttps,
        'httponly' => true,
        'samesite' => 'Lax',
    ]);

    sendJsonResponse(['success' => true, 'accessToken' => $accessToken]);
}

function handleAuthRefresh(PDO $pdo, string $jwtSecret): void {
    $refreshToken = $_COOKIE['refresh_token'] ?? null;
    if (!$refreshToken) {
        sendJsonResponse(['success' => false, 'error' => 'Nincs refresh token a sutikben.'], 401);
    }

    $payload = verifyJwt($refreshToken, $jwtSecret);
    if (!$payload || !isset($payload['jti'])) {
        sendJsonResponse(['success' => false, 'error' => 'Lejart vagy manipulalt refresh token.'], 401);
    }

    $dbStmt = $pdo->prepare('SELECT * FROM `refresh_tokens` WHERE `token_id` = ? AND `expires_at` > NOW() LIMIT 1');
    $dbStmt->execute([$payload['jti']]);
    $dbToken = $dbStmt->fetch();

    if (!$dbToken) {
        sendJsonResponse(['success' => false, 'error' => 'A refresh tokent érvénytelenítették vagy lejárt (kijelentkezett).'], 401);
    }

    $newAccessToken = generateJwt(['guest_id' => $payload['guest_id'], 'booking_id' => $payload['booking_id']], $jwtSecret, 900);
    sendJsonResponse(['success' => true, 'accessToken' => $newAccessToken]);
}

function handleAuthLogout(PDO $pdo, string $jwtSecret, bool $isUsingHttps): void {
    $refreshToken = $_COOKIE['refresh_token'] ?? null;

    if ($refreshToken) {
        $payload = verifyJwt($refreshToken, $jwtSecret);
        if ($payload && isset($payload['jti'])) {
            $dbStmt = $pdo->prepare('DELETE FROM `refresh_tokens` WHERE `token_id` = ?');
            $dbStmt->execute([$payload['jti']]);
        }
    }

    setcookie('refresh_token', '', [
        'expires' => time() - 3600,
        'path' => '/',
        'domain' => '',
        'secure' => $isUsingHttps,
        'httponly' => true,
        'samesite' => 'Lax',
    ]);

    sendJsonResponse(['success' => true, 'message' => 'Sikeres kijelentkezés, token azonosító törölve az adatbázisból.']);
}

function handlePublicBooking(PDO $pdo, array $inputData): void {
    if (isRateLimited($pdo, 'booking:' . getClientIp(), 5, 3600)) {
        header('Retry-After: 3600');
        sendJsonResponse(['success' => false, 'error' => 'Túl sok foglalási kísérlet. Kérjük, várjon egy órát.'], 429);
    }

    $email = $inputData['email'] ?? null;
    if (!$email) {
        sendJsonResponse(['success' => false, 'error' => 'Az e-mail cím megadása kötelező.'], 400);
    }

    try {
        $pdo->beginTransaction();

        $stmt = $pdo->prepare('SELECT `id`, `fname`, `lname` FROM `guests` WHERE `email` = ? LIMIT 1');
        $stmt->execute([$email]);
        $existingGuest = $stmt->fetch();

        if ($existingGuest) {
            $existingFname = mb_strtolower(trim($existingGuest['fname']), 'UTF-8');
            $existingLname = mb_strtolower(trim($existingGuest['lname']), 'UTF-8');
            $inputFname = mb_strtolower(trim($inputData['fname'] ?? ''), 'UTF-8');
            $inputLname = mb_strtolower(trim($inputData['lname'] ?? ''), 'UTF-8');

            if ($existingFname !== $inputFname || $existingLname !== $inputLname) {
                $pdo->rollBack();
                sendJsonResponse(['success' => false, 'error' => 'Ez az e-mail cím már regisztrálva van egy másik névvel.'], 400);
            }
            $guestId = $existingGuest['id'];
        } else {
            $insertGuest = $pdo->prepare('INSERT INTO `guests` (`email`, `fname`, `lname`, `zip_code`, `country`, `city`, `street`) VALUES (?, ?, ?, ?, ?, ?, ?)');
            $insertGuest->execute([
                $email,
                $inputData['fname'] ?? '',
                $inputData['lname'] ?? '',
                $inputData['zip_code'] ?? '',
                $inputData['country'] ?? '',
                $inputData['city'] ?? '',
                $inputData['street'] ?? '',
            ]);
            $guestId = $pdo->lastInsertId();
        }

        $bookingId = $inputData['booking_id'] ?? null;
        if ($bookingId) {
            $stmt = $pdo->prepare('SELECT COUNT(*) FROM `bookings` WHERE `id` = ?');
            $stmt->execute([$bookingId]);
            if ($stmt->fetchColumn() > 0) {
                $pdo->rollBack();
                sendJsonResponse(['success' => false, 'error' => 'A megadott foglalási azonosító már létezik.'], 400);
            }
        }

        $insertBooking = $pdo->prepare('INSERT INTO `bookings` (`id`, `guest1_id`, `room_number`, `room_type`, `beginning_of_stay`, `end_of_stay`, `catering_level`) VALUES (?, ?, ?, ?, ?, ?, ?)');
        $insertBooking->execute([
            $bookingId,
            $guestId,
            $inputData['room_number'] ?? null,
            $inputData['room_type'] ?? null,
            $inputData['beginning_of_stay'] ?? null,
            $inputData['end_of_stay'] ?? null,
            $inputData['catering_level'] ?? null,
        ]);

        if (!empty($inputData['services']) && is_array($inputData['services'])) {
            $getServiceStmt = $pdo->prepare('SELECT `id` FROM `services` WHERE `name_en` LIKE ? LIMIT 1');
            $insertServiceStmt = $pdo->prepare('INSERT INTO `servicebookings` (`booking_id`, `service_id`, `quantity`) VALUES (?, ?, ?)');
            $insertChampagneStmt = $pdo->prepare('INSERT INTO `servicebookings` (`booking_id`, `service_id`, `quantity`, `price_at_booking`) VALUES (?, ?, ?, ?)');

            foreach ($inputData['services'] as $serviceName) {
                if (!in_array(strtolower($serviceName), ['champagne', 'transfer'], true)) {
                    continue;
                }

                if (strtolower($serviceName) === 'champagne') {
                    $fbStmt = $pdo->prepare("SELECT `price` FROM `food_and_beverage` WHERE `description_en` LIKE '%champagne%' LIMIT 1");
                    $fbStmt->execute();
                    $champagnePrice = $fbStmt->fetchColumn();

                    $rsStmt = $pdo->prepare("SELECT `id` FROM `services` WHERE `name_en` = 'Room service' LIMIT 1");
                    $rsStmt->execute();
                    $roomServiceId = $rsStmt->fetchColumn();

                    if ($champagnePrice !== false && $roomServiceId) {
                        $insertChampagneStmt->execute([$bookingId, $roomServiceId, 1, $champagnePrice]);
                    }
                } else {
                    $getServiceStmt->execute([$serviceName]);
                    $serviceData = $getServiceStmt->fetch();

                    if ($serviceData) {
                        $insertServiceStmt->execute([$bookingId, $serviceData['id'], 1]);
                    }
                }
            }
        }

        $pdo->commit();

        sendJsonResponse([
            'success' => true,
            'message' => 'A foglalás sikeresen rögzítve!',
            'booking_id' => $inputData['booking_id'] ?? null,
            'guest_id' => $guestId,
        ], 201);
    } catch (Throwable $e) {
        if ($pdo->inTransaction()) {
            $pdo->rollBack();
        }

        error_log($e->getMessage());
        sendJsonResponse(['success' => false, 'error' => 'Adatbázis hiba történt a foglalás során.'], 500);
    }
}
