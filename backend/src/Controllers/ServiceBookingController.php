<?php

function handleServiceBookingUpdateStatus(PDO $pdo, array $inputData): void {
    if (empty($inputData['id']) || !isset($inputData['status'])) {
        sendJsonResponse(['success' => false, 'error' => 'Hiányzó vagy hibás JSON adatok.'], 400);
    }

    try {
        $stmt = $pdo->prepare('SELECT id FROM servicebookings WHERE id = ?');
        $stmt->execute([$inputData['id']]);
        if (!$stmt->fetch()) {
            sendJsonResponse(['success' => false, 'error' => 'Nem létező ID.'], 404);
        }

        $update = $pdo->prepare('UPDATE servicebookings SET `status` = ? WHERE id = ?');
        $update->execute([$inputData['status'], $inputData['id']]);
        sendJsonResponse(['success' => true, 'message' => 'Sikeres frissítés.']);
    } catch (Throwable $e) {
        error_log($e->getMessage());
        sendJsonResponse(['success' => false, 'error' => 'Adatbázis hiba történt a művelet során.'], 500);
    }
}
