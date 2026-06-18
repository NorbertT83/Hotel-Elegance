<?php
// WARNING: this file may contain sensitive values. Prefer using environment variables
// and keep a non-sensitive `config.example.php` in the repo. Values below fall back
// to the previous defaults if env vars are not present.
return [
    'db_host' => getenv('DB_HOST') ?: 'localhost',
    'db_name' => getenv('DB_NAME') ?: 'c82533nrbrt',
    'db_user' => getenv('DB_USER') ?: 'NrBrT',
    'db_pass' => getenv('DB_PASS') ?: 'Titkos-11',
    'db_char' => getenv('DB_CHAR') ?: 'utf8mb4',
    'hotel_ip'=> getenv('HOTEL_IP') ?: '127.0.0.1',
    'jwt_secret' => getenv('JWT_SECRET') ?: '5&a0h&D9gabqFwhckk2Q19Y*wN'
];