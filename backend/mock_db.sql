-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Máj 21. 10:56
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `c82533nrbrt`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `bookings`
--

CREATE TABLE `bookings` (
  `id` int(11) NOT NULL,
  `room_number` smallint(5) UNSIGNED DEFAULT NULL,
  `room_type` enum('standard','deluxe','suite','') NOT NULL,
  `needs_view` enum('city','garden','panorama','') NOT NULL,
  `guest1_id` int(11) NOT NULL,
  `beginning_of_stay` date NOT NULL,
  `end_of_stay` date NOT NULL CHECK (`end_of_stay` > `beginning_of_stay`),
  `checkin` datetime DEFAULT NULL,
  `checkout` datetime DEFAULT NULL,
  `guest2_id` int(11) DEFAULT NULL,
  `guest3_id` int(11) DEFAULT NULL,
  `guest4_id` int(11) DEFAULT NULL,
  `catering_level` enum('breakfast','halfboard','fullboard','') NOT NULL DEFAULT 'breakfast'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `bookings`
--

INSERT INTO `bookings` (`id`, `room_number`, `room_type`, `needs_view`, `guest1_id`, `beginning_of_stay`, `end_of_stay`, `checkin`, `checkout`, `guest2_id`, `guest3_id`, `guest4_id`, `catering_level`) VALUES
(1, 101, '', 'city', 8, '2026-04-01', '2026-04-03', '2026-04-01 14:10:00', '2026-04-03 10:05:00', 1, NULL, NULL, 'breakfast'),
(2, 102, '', 'city', 7, '2026-04-02', '2026-04-04', '2026-04-02 13:30:00', '2026-04-04 09:00:00', NULL, NULL, NULL, 'breakfast'),
(3, 201, '', 'city', 3, '2026-04-03', '2026-04-05', '2026-04-03 15:00:00', '2026-04-05 11:00:00', 9, NULL, NULL, 'breakfast'),
(4, 202, '', 'city', 2, '2026-04-04', '2026-04-06', '2026-04-04 14:45:00', '2026-04-06 10:30:00', NULL, NULL, NULL, 'breakfast'),
(5, 103, '', 'city', 4, '2026-04-05', '2026-04-08', '2026-04-05 13:15:00', '2026-04-08 10:00:00', NULL, NULL, NULL, 'breakfast'),
(6, 301, '', 'city', 6, '2026-04-06', '2026-04-09', '2026-04-06 14:20:00', '2026-04-09 10:10:00', 5, NULL, NULL, 'breakfast'),
(7, 302, '', 'city', 11, '2026-04-07', '2026-04-09', '2026-04-07 15:10:00', '2026-04-09 11:20:00', 10, NULL, NULL, 'breakfast'),
(8, 203, '', 'city', 15, '2026-04-08', '2026-04-10', '2026-04-08 13:50:00', '2026-04-10 10:00:00', 12, NULL, NULL, 'breakfast'),
(9, 303, 'deluxe', 'city', 13, '2026-04-09', '2026-04-11', '2026-04-09 14:30:00', '2026-04-11 11:00:00', 14, NULL, NULL, 'breakfast'),
(10, 402, 'suite', 'city', 16, '2026-04-10', '2026-04-12', '2026-04-10 12:45:00', '2026-04-12 09:30:00', NULL, NULL, NULL, 'breakfast');

--
-- Eseményindítók `bookings`
--
DELIMITER $$
CREATE TRIGGER `trg_booking_date_check` BEFORE INSERT ON `bookings` FOR EACH ROW BEGIN
    IF NEW.beginning_of_stay < CURDATE() THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'beginning_of_stay cannot be in the past';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `employees`
--

CREATE TABLE `employees` (
  `id` int(11) NOT NULL,
  `fname` varchar(30) NOT NULL,
  `lname` varchar(30) NOT NULL,
  `tax_number` varchar(20) NOT NULL,
  `paid_holidays_left` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `address` text DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `date_of_hiring` date NOT NULL,
  `role` varchar(50) DEFAULT NULL,
  `salary` int(10) UNSIGNED NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `employees`
--

INSERT INTO `employees` (`id`, `fname`, `lname`, `tax_number`, `paid_holidays_left`, `address`, `date_of_birth`, `date_of_hiring`, `role`, `salary`, `created_at`, `updated_at`) VALUES
(1, 'Gábor', 'Nagy', 'TX100001', 18, 'Budapest, Andrássy út 10.', '1985-03-12', '2015-06-01', 'HK Manager', 950000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(2, 'Eszter', 'Kovács', 'TX100002', 20, 'Budapest, Bartók Béla út 22.', '1988-07-25', '2018-09-15', 'F&B Manager', 880000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(3, 'Anna', 'Szabó', 'TX100003', 12, 'Budapest, Váci út 45.', '1995-11-02', '2021-03-10', 'Receptionist', 420000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(4, 'Dániel', 'Tóth', 'TX100004', 10, 'Budapest, Üllői út 78.', '1998-05-19', '2022-07-01', 'Receptionist', 400000, '2026-03-30 07:06:55', '2026-05-15 07:53:19'),
(5, 'Mária', 'Horváth', 'TX100005', 8, 'Budapest, József körút 33.', '1972-09-14', '2019-11-20', 'Cleaner', 300000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(6, 'József', 'Varga', 'TX100006', 6, 'Budapest, Kerepesi út 101.', '1968-01-30', '2017-04-05', 'Cleaner', 290000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(7, 'Lilla', 'Molnár', 'TX100007', 9, 'Budapest, Rákóczi út 12.', '1999-02-17', '2023-02-01', 'Room Service', 350000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(8, 'Bence', 'Farkas', 'TX100008', 11, 'Budapest, Fehérvári út 56.', '1996-08-09', '2020-06-18', 'Room Service', 360000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(9, 'Zoltán', 'Balogh', 'TX100009', 14, 'Budapest, Hungária körút 88.', '1982-12-05', '2016-01-10', 'Front Office Manager', 910000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(10, 'Petra', 'Papp', 'TX100010', 7, 'Budapest, Alkotás utca 3.', '1993-04-22', '2021-10-01', 'Cleaner', 410000, '2026-03-30 07:06:55', '2026-03-30 07:06:55');

--
-- Eseményindítók `employees`
--
DELIMITER $$
CREATE TRIGGER `trg_employees_birth_check` BEFORE INSERT ON `employees` FOR EACH ROW BEGIN
    IF NEW.date_of_birth > CURDATE() THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'date_of_birth cannot be in the future';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_employees_hiring_check_insert` BEFORE INSERT ON `employees` FOR EACH ROW BEGIN
    IF NEW.date_of_hiring > CURDATE() THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'date_of_hiring cannot be in the future';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_employees_hiring_check_update` BEFORE UPDATE ON `employees` FOR EACH ROW BEGIN
    IF NEW.date_of_hiring > CURDATE() THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'date_of_hiring cannot be in the future';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `guests`
--

CREATE TABLE `guests` (
  `id` int(11) NOT NULL,
  `email` varchar(64) NOT NULL,
  `id_card_number` varchar(20) DEFAULT NULL,
  `fname` varchar(50) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `date_of_birth` date NOT NULL,
  `country` varchar(50) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `car_plate_number` varchar(10) DEFAULT NULL,
  `cumulative_nights` int(11) DEFAULT 0,
  `loyalty_level` int(11) GENERATED ALWAYS AS (least(floor(`cumulative_nights` / 5),10)) STORED
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `guests`
--

INSERT INTO `guests` (`id`, `email`, `id_card_number`, `fname`, `lname`, `date_of_birth`, `country`, `address`, `car_plate_number`, `cumulative_nights`) VALUES
(1, 'kovacs.bence2015@gmail.com', 'ID100001', 'Bence', 'Kovács', '2015-06-12', 'Hungary', 'Budapest, Váci út 12.', NULL, 0),
(2, 'szabo.anna.debrecen@freemail.hu', 'ID100002', 'Anna', 'Szabó', '1990-03-25', 'Hungary', 'Debrecen, Kossuth tér 5.', 'ABC123', 2),
(3, 'john.smith85@outlook.com', 'ID100003', 'John', 'Smith', '1985-11-02', 'United Kingdom', 'London, Baker Street 221B', NULL, 3),
(4, 'emma.j.ny@icloud.com', 'ID100004', 'Emma', 'Johnson', '2018-09-14', 'United States', 'New York, 5th Avenue 10.', NULL, 0),
(5, 'luca.rossi2001@libero.it', 'ID100005', 'Luca', 'Rossi', '2001-07-30', 'Italy', 'Rome, Via Milano 45.', 'XYZ789', 1),
(6, 'noah.muller78@t-online.de', 'ID100006', 'Noah', 'Müller', '1978-01-19', 'Germany', 'Berlin, Alexanderplatz 3.', 'BER456', 4),
(7, 'mia.novak.sk@atlas.sk', 'ID100007', 'Mia', 'Novák', '2012-12-05', 'Slovakia', 'Bratislava, Main Street 8.', NULL, 0),
(8, 'nagy.david95@gmail.com', 'ID100008', 'David', 'Nagy', '1995-05-21', 'Hungary', 'Szeged, Tisza Lajos krt. 22.', 'SZG234', 2),
(9, 'sophie.dubois.paris@orange.fr', 'ID100009', 'Sophie', 'Dubois', '1988-08-17', 'France', 'Paris, Rue de Rivoli 15.', NULL, 3),
(10, 'horvath.matej.2010@citromail.hu', 'ID100010', 'Matej', 'Horváth', '2010-04-11', 'Hungary', 'Győr, Baross út 9.', NULL, 1),
(11, 'oliver.brown.manchester@yahoo.co.uk', 'ID100011', 'Oliver', 'Brown', '2003-02-09', 'United Kingdom', 'Manchester, King St 44.', 'UK1234', 1),
(12, 'isabella.garcia92@hotmail.es', 'ID100012', 'Isabella', 'Garcia', '1992-10-28', 'Spain', 'Madrid, Gran Via 18.', 'ESP567', 2),
(13, 'toth.levente80@gmail.com', 'ID100013', 'Levente', 'Tóth', '1980-06-06', 'Hungary', 'Pécs, Király utca 33.', NULL, 5),
(14, 'ella.williams2016@aol.com', 'ID100014', 'Ella', 'Williams', '2016-01-03', 'United States', 'Los Angeles, Sunset Blvd 77.', NULL, 0),
(15, 'varga.daniel.miskolc@freemail.hu', 'ID100015', 'Dániel', 'Varga', '1999-09-09', 'Hungary', 'Miskolc, Széchenyi utca 1.', 'MIS999', 2),
(16, 'szekeres.nora89@gmail.com', 'ID100321', 'Nóra', 'Szekeres', '1989-07-01', 'Hungary', 'Győr, Bajcsi Zs. utca 12.', NULL, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rooms`
--

CREATE TABLE `rooms` (
  `room_number` smallint(5) UNSIGNED NOT NULL,
  `room_type` enum('standard','deluxe','suite','') NOT NULL,
  `floorspace` tinyint(3) UNSIGNED NOT NULL,
  `bed_type` enum('single','twin','queen','kingsize') NOT NULL,
  `has_balcony` tinyint(1) NOT NULL,
  `has_view` enum('city','garden','panorama') DEFAULT NULL,
  `max_adults` tinyint(3) UNSIGNED NOT NULL,
  `extras` mediumtext DEFAULT NULL,
  `status` enum('available','occupied','dont_disturb','needs_cleaning','cleaning','under_maintenence','unavailable') NOT NULL DEFAULT 'unavailable',
  `price_per_night` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `rooms`
--

INSERT INTO `rooms` (`room_number`, `room_type`, `floorspace`, `bed_type`, `has_balcony`, `has_view`, `max_adults`, `extras`, `status`, `price_per_night`) VALUES
(101, 'standard', 18, 'queen', 0, 'city', 2, '', 'cleaning', 22000),
(102, 'standard', 20, 'twin', 0, 'city', 2, '', 'occupied', 21000),
(103, 'standard', 22, 'queen', 1, 'garden', 2, '', 'needs_cleaning', 24000),
(201, 'deluxe', 28, 'kingsize', 1, 'garden', 3, '', 'available', 38000),
(202, 'deluxe', 30, 'kingsize', 1, 'city', 3, '', 'occupied', 42000),
(203, 'deluxe', 27, 'queen', 1, 'city', 2, '', 'cleaning', 36000),
(301, 'standard', 28, 'twin', 1, 'garden', 2, '', 'available', 34500),
(302, 'deluxe', 32, 'kingsize', 1, 'garden', 2, '', 'dont_disturb', 42000),
(303, 'deluxe', 27, 'kingsize', 1, 'city', 2, '', 'occupied', 29900),
(401, 'suite', 50, 'kingsize', 1, 'panorama', 3, 'jacuzzi', 'available', 76000),
(402, 'suite', 50, 'kingsize', 1, 'panorama', 3, 'kitchen', 'unavailable', 76000),
(403, 'suite', 55, 'kingsize', 1, 'panorama', 4, 'jacuzzi, kitchen', 'needs_cleaning', 80000);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `servicebookings`
--

CREATE TABLE `servicebookings` (
  `booking_id` int(11) NOT NULL,
  `service_id` int(11) NOT NULL,
  `timestamp` datetime NOT NULL DEFAULT current_timestamp(),
  `quantity` int(11) NOT NULL CHECK (`quantity` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `servicebookings`
--

INSERT INTO `servicebookings` (`booking_id`, `service_id`, `timestamp`, `quantity`) VALUES
(1, 1, '2026-04-01 15:00:00', 1),
(1, 6, '2026-04-01 19:30:00', 2),
(2, 2, '2026-04-02 10:00:00', 1),
(2, 3, '2026-04-02 09:00:00', 1),
(3, 4, '2026-04-03 08:00:00', 1),
(3, 6, '2026-04-03 20:00:00', 1),
(4, 11, '2026-04-04 14:00:00', 1),
(4, 12, '2026-04-04 16:00:00', 1),
(4, 13, '2026-04-04 17:30:00', 1),
(5, 5, '2026-04-05 11:00:00', 2),
(5, 7, '2026-04-05 13:00:00', 1),
(6, 8, '2026-04-06 18:00:00', 3),
(6, 9, '2026-04-06 14:00:00', 1),
(6, 10, '2026-04-06 14:00:00', 1),
(7, 1, '2026-04-07 15:30:00', 2),
(7, 14, '2026-04-07 17:00:00', 1),
(8, 15, '2026-04-08 09:00:00', 2),
(8, 17, '2026-04-08 10:30:00', 2),
(9, 6, '2026-04-09 20:00:00', 1),
(9, 11, '2026-04-09 18:00:00', 1),
(9, 12, '2026-04-09 16:00:00', 1),
(10, 3, '2026-04-10 08:00:00', 1),
(10, 6, '2026-04-10 19:00:00', 2),
(10, 16, '2026-04-10 09:00:00', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `services`
--

CREATE TABLE `services` (
  `id` int(11) NOT NULL,
  `name_hu` varchar(50) NOT NULL,
  `description_hu` mediumtext DEFAULT NULL,
  `price` int(10) UNSIGNED NOT NULL,
  `service_type_hu` enum('Wellness','Extrák','Logisztika') DEFAULT NULL,
  `name_en` varchar(50) DEFAULT NULL,
  `description_en` mediumtext DEFAULT NULL,
  `service_type_en` enum('Wellness','Extras','Logistics') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `services`
--

INSERT INTO `services` (`id`, `name_hu`, `description_hu`, `price`, `service_type_hu`, `name_en`, `description_en`, `service_type_en`) VALUES
(1, 'Testmasszázs', 'Svédmasszázs 60 perc', 12000, 'Wellness', 'Body massage', 'Swedish massage 60 minutes', 'Wellness'),
(2, 'Parkolás', 'Zárt parkoló napi díj', 3000, 'Logisztika', 'Parking', 'Gated parking daily fee', 'Logistics'),
(3, 'Transzfer', 'Reptéri transzfer egy irányba', 10000, 'Logisztika', 'Transfer', 'Airport transfer one way', 'Logistics'),
(4, 'Autóbérlés', 'Napi autóbérlés alap csomag', 15000, 'Logisztika', 'Car rental', 'Daily car rental basic package', 'Logistics'),
(5, 'Mosatás', 'Ruhák mosása és vasalása', 5000, 'Extrák', 'Laundry', 'Washing and ironing of clothes', 'Extras'),
(6, 'Szobaszerviz', 'Étel-ital rendelés szobába', 2500, 'Extrák', 'Room service', 'Food and beverage room service', 'Extras'),
(7, 'Extra takarítás', 'Napi extra takarítás kérésre', 4000, 'Extrák', 'Extra cleaning', 'Daily extra cleaning upon request', 'Extras'),
(8, 'Gyerekfelügyelet', 'Szakképzett felügyelet óránként', 3500, 'Extrák', 'Babysitting', 'Professional supervision per hour', 'Extras'),
(9, 'Pótágy', 'Extra ágy biztosítása', 7000, 'Extrák', 'Extra bed', 'Provision of an extra bed', 'Extras'),
(10, 'Kiságy', 'Babaágy biztosítása', 3000, 'Extrák', 'Baby cot', 'Provision of a baby cot', 'Extras'),
(11, 'Aromaterápiás masszázs', 'Illóolajos relaxációs masszázs 60 perc', 13000, 'Wellness', 'Aromatherapy massage', 'Essential oil relaxation massage 60 minutes', 'Wellness'),
(12, 'Forró köves masszázs', 'Hot stone masszázs 60 perc', 15000, 'Wellness', 'Hot stone massage', 'Hot stone massage 60 minutes', 'Wellness'),
(13, 'Arckezelés', 'Hidratáló és revitalizáló arckezelés', 10000, 'Wellness', 'Facial treatment', 'Hydrating and revitalizing facial treatment', 'Wellness'),
(14, 'Testkezelés', 'Bőrradírozás és hidratáló kezelés', 11000, 'Wellness', 'Body treatment', 'Exfoliation and moisturizing treatment', 'Wellness'),
(15, 'Kerékpár bérlés', 'Kerékpár bérlés napi díj', 4000, 'Logisztika', 'Bicycle rental', 'Bicycle rental daily fee', 'Logistics'),
(16, 'Elektromos kerékpár bérlés', 'Elektromos kerékpár bérlés napi díj', 8000, 'Logisztika', 'Electric bicycle rental', 'E-bike rental daily fee', 'Logistics'),
(17, 'E-roller bérlés', 'Elektromos roller bérlés óradíj', 2500, 'Logisztika', 'E-scooter rental', 'Electric scooter rental hourly fee', 'Logistics'),
(18, 'Szauna szeánsz', 'Vezetett szauna élmény különböző atmoszférákat teremtő felöntésekkel', 4500, 'Wellness', 'Sauna session', 'A guided sauna experience with infusion rituals creating different atmospheres.', 'Wellness');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_bookings_room` (`room_number`),
  ADD KEY `fk_guest1` (`guest1_id`),
  ADD KEY `fk_guest2` (`guest2_id`),
  ADD KEY `fk_guest3` (`guest3_id`),
  ADD KEY `fk_guest4` (`guest4_id`);

--
-- A tábla indexei `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `tax_number` (`tax_number`),
  ADD KEY `idx_employees_name` (`lname`,`fname`);

--
-- A tábla indexei `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`) USING BTREE,
  ADD UNIQUE KEY `id_card_number` (`id_card_number`);

--
-- A tábla indexei `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`room_number`);

--
-- A tábla indexei `servicebookings`
--
ALTER TABLE `servicebookings`
  ADD PRIMARY KEY (`booking_id`,`service_id`,`timestamp`),
  ADD KEY `fk_servicebookings_service` (`service_id`);

--
-- A tábla indexei `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `bookings`
--
ALTER TABLE `bookings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `employees`
--
ALTER TABLE `employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `guests`
--
ALTER TABLE `guests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT a táblához `services`
--
ALTER TABLE `services`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `bookings`
--
ALTER TABLE `bookings`
  ADD CONSTRAINT `fk_bookings_room` FOREIGN KEY (`room_number`) REFERENCES `rooms` (`room_number`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_guest1` FOREIGN KEY (`guest1_id`) REFERENCES `guests` (`id`),
  ADD CONSTRAINT `fk_guest2` FOREIGN KEY (`guest2_id`) REFERENCES `guests` (`id`),
  ADD CONSTRAINT `fk_guest3` FOREIGN KEY (`guest3_id`) REFERENCES `guests` (`id`),
  ADD CONSTRAINT `fk_guest4` FOREIGN KEY (`guest4_id`) REFERENCES `guests` (`id`);

--
-- Megkötések a táblához `servicebookings`
--
ALTER TABLE `servicebookings`
  ADD CONSTRAINT `fk_servicebookings_booking` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_servicebookings_service` FOREIGN KEY (`service_id`) REFERENCES `services` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
