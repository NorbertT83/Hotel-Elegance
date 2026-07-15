<?php

function handleFoodBeverageCategories(PDO $pdo): void {
    try {
        $stmt = $pdo->prepare('SELECT DISTINCT category FROM food_and_beverage ORDER BY category');
        $stmt->execute();
        $categories = $stmt->fetchAll(PDO::FETCH_COLUMN);
        sendJsonResponse(['success' => true, 'categories' => $categories]);
    } catch (Throwable $e) {
        error_log($e->getMessage());
        sendJsonResponse(['success' => false, 'error' => 'Adatbázis hiba történt a lekérés során.'], 500);
    }
}
