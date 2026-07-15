<?php

function isRateLimited(PDO $pdo, string $key, int $maxAttempts, int $windowSeconds): bool {
    $windowStart = date('Y-m-d H:i:s', time() - $windowSeconds);

    $stmt = $pdo->prepare(
        "INSERT INTO `rate_limits` (`key`, `attempts`, `window_start`)\n" .
        "VALUES (?, 1, NOW())\n" .
        "ON DUPLICATE KEY UPDATE\n" .
        "    attempts = IF(window_start < ?, 1, attempts + 1),\n" .
        "    window_start = IF(window_start < ?, NOW(), window_start)"
    );

    $stmt->execute([$key, $windowStart, $windowStart]);

    $stmt = $pdo->prepare('SELECT `attempts` FROM `rate_limits` WHERE `key` = ?');
    $stmt->execute([$key]);

    return (int)$stmt->fetchColumn() > $maxAttempts;
}
