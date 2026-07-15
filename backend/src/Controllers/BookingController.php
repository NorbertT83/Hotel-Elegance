<?php

function handleBookingServices(PDO $pdo, array $authenticatedUser): void {
    $currentBookingId = $authenticatedUser['booking_id'] ?? null;
    if (!$currentBookingId) {
        sendJsonResponse(['error' => 'Nem található érvényes foglalási azonosító a tokenben.'], 400);
    }

    try {
        $sql = 'SELECT 
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
                WHERE sb.booking_id = ?';

        $stmt = $pdo->prepare($sql);
        $stmt->execute([$currentBookingId]);
        $services = $stmt->fetchAll();

        sendJsonResponse($services);
    } catch (Throwable $e) {
        error_log($e->getMessage());
        sendJsonResponse(['error' => 'Adatbázis hiba: ' . $e->getMessage()], 500);
    }
}
