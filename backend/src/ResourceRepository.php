<?php

function fetchResource(PDO $pdo, string $table, string $idOrAll, string $idColumn, array $allowedFilters = [], array $allowedSorts = []): mixed {
    $params = [];
    $sql = "SELECT * FROM `$table`";

    if ($idOrAll !== 'all') {
        $sql .= " WHERE `$idColumn` = ?";
        $params[] = $idOrAll;
    } else {
        $whereConditions = [];

        foreach ($_GET as $key => $value) {
            if (in_array($key, $allowedFilters, true) && $value !== '') {
                if ($key === 'end_of_stay_after') {
                    $whereConditions[] = "`end_of_stay` > ?";
                } else {
                    $whereConditions[] = "`$key` = ?";
                }
                $params[] = $value;
            }
        }

        if ($whereConditions) {
            $sql .= ' WHERE ' . implode(' AND ', $whereConditions);
        }

        if (!empty($_GET['sort']) && in_array($_GET['sort'], $allowedSorts, true)) {
            $direction = (isset($_GET['order']) && strtolower($_GET['order']) === 'desc') ? 'DESC' : 'ASC';
            $sql .= " ORDER BY `{$_GET['sort']}` $direction";
        }
    }

    $stmt = $pdo->prepare($sql);
    $stmt->execute($params);

    return $idOrAll === 'all' ? $stmt->fetchAll() : $stmt->fetch();
}

function createResource(PDO $pdo, string $table, array $data, array $allowedFields): bool {
    if (empty($data)) {
        return false;
    }

    $filtered = array_intersect_key($data, array_flip($allowedFields));
    if (empty($filtered)) {
        return false;
    }

    $columns = array_keys($filtered);
    $placeholders = array_fill(0, count($filtered), '?');
    $sql = "INSERT INTO `$table` (`" . implode('`, `', $columns) . "`) VALUES (" . implode(', ', $placeholders) . ")";

    $stmt = $pdo->prepare($sql);
    $stmt->execute(array_values($filtered));

    return true;
}

function updateResource(PDO $pdo, string $table, string $idColumn, string $id, array $data, ?array $allowedFields = null): int {
    if (empty($data)) {
        return 0;
    }

    if (is_array($allowedFields) && $allowedFields !== []) {
        $data = array_intersect_key($data, array_flip($allowedFields));
    }

    unset($data[$idColumn]);
    if (empty($data)) {
        return 0;
    }

    $columns = array_keys($data);
    $assignments = array_map(fn($col) => "`$col` = ?", $columns);
    $sql = "UPDATE `$table` SET " . implode(', ', $assignments) . " WHERE `$idColumn` = ?";
    $params = array_merge(array_values($data), [$id]);

    $stmt = $pdo->prepare($sql);
    $stmt->execute($params);

    return $stmt->rowCount();
}

function deleteResource(PDO $pdo, string $table, string $idColumn, string $id): int {
    $stmt = $pdo->prepare("DELETE FROM `$table` WHERE `$idColumn` = ?");
    $stmt->execute([$id]);
    return $stmt->rowCount();
}
