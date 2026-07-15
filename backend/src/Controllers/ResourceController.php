<?php

function handleGenericResource(PDO $pdo, array $config, string $resource, string $id, string $method, array $inputData): void {
    $table = $config['table'];
    $idCol = $config['id'];

    switch ($method) {
        case 'GET':
            $result = fetchResource($pdo, $table, $id, $idCol, $config['filters'] ?? [], $config['sorts'] ?? []);
            if ($id === 'all') {
                sendJsonResponse($result ?: []);
            }

            if ($result !== false) {
                sendJsonResponse($result);
            }

            sendError('Nincs talalat', 404);
            break;

        case 'POST':
            if (empty($inputData)) {
                sendError('Hianyzo JSON.', 400);
            }

            if (empty($config['insert_fields']) || !is_array($config['insert_fields'])) {
                sendError('Insert not allowed for this resource.', 403);
            }

            $created = createResource($pdo, $table, $inputData, $config['insert_fields']);
            if (!$created) {
                sendError('Hibás vagy hiányzó adat az inserthez.', 400);
            }

            sendJsonResponse(['id' => $pdo->lastInsertId(), 'success' => true, 'message' => 'Sikeresen létrehozva.'], 201);
            break;

        case 'DELETE':
            if ($id === 'all') {
                sendError('Hianyzo ID.', 400);
            }

            $affected = deleteResource($pdo, $table, $idCol, $id);
            if ($affected > 0) {
                sendJsonResponse(['success' => true, 'message' => 'Torolve.']);
            }
            sendError('Nem talalhato.', 404);
            break;

        case 'PUT':
            if ($id === 'all') {
                sendError('Hianyzo ID.', 400);
            }

            if (empty($inputData) || !is_array($inputData)) {
                sendError('Hianyzo vagy hibas JSON adatok.', 400);
            }

            $allowedFields = $config['update_fields'] ?? $config['insert_fields'] ?? null;
            $affected = updateResource($pdo, $table, $idCol, $id, $inputData, $allowedFields);
            if ($affected > 0) {
                sendJsonResponse(['success' => true, 'message' => 'Sikeres frissítés.']);
            }
            sendError('Nem talalhato vagy nincs valtozas.', 404);
            break;

        default:
            sendError('Nem engedelyezett metodus: ' . $method, 405);
    }
}
