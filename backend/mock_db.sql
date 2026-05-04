-- phpMyAdmin SQL Dump
-- version 5.2.1deb1+deb12u1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 30, 2026 at 05:28 PM
-- Server version: 10.11.14-MariaDB-0+deb12u2
-- PHP Version: 8.2.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `c82533nrbrt`
--
CREATE DATABASE IF NOT EXISTS `c82533nrbrt` DEFAULT CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci;
USE `c82533nrbrt`;

-- --------------------------------------------------------

--
-- Table structure for table `bookings`
--

CREATE TABLE `bookings` (
  `id` int(11) NOT NULL,
  `room_number` smallint(5) UNSIGNED DEFAULT NULL,
  `guest_id1` varchar(20) NOT NULL,
  `beginning_of_stay` date NOT NULL,
  `end_of_stay` date NOT NULL CHECK (`end_of_stay` > `beginning_of_stay`),
  `checkin` datetime DEFAULT NULL,
  `checkout` datetime DEFAULT NULL,
  `guest_id2` varchar(20) DEFAULT NULL,
  `guest_id3` varchar(20) DEFAULT NULL,
  `guest_id4` varchar(20) DEFAULT NULL,
  `level_of_service` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `bookings`
--

INSERT INTO `bookings` (`id`, `room_number`, `guest_id1`, `beginning_of_stay`, `end_of_stay`, `checkin`, `checkout`, `guest_id2`, `guest_id3`, `guest_id4`, `level_of_service`) VALUES
(1, 101, 'ID100002', '2026-04-01', '2026-04-03', '2026-04-01 14:10:00', '2026-04-03 10:05:00', 'ID100008', NULL, NULL, 'standard'),
(2, 102, 'ID100003', '2026-04-02', '2026-04-04', '2026-04-02 13:30:00', '2026-04-04 09:00:00', NULL, NULL, NULL, 'business'),
(3, 201, 'ID100005', '2026-04-03', '2026-04-05', '2026-04-03 15:00:00', '2026-04-05 11:00:00', 'ID100011', NULL, NULL, 'deluxe'),
(4, 202, 'ID100008', '2026-04-04', '2026-04-06', '2026-04-04 14:45:00', '2026-04-06 10:30:00', NULL, NULL, NULL, 'wellness'),
(5, 103, 'ID100010', '2026-04-05', '2026-04-08', '2026-04-05 13:15:00', '2026-04-08 10:00:00', NULL, NULL, NULL, 'standard'),
(6, 301, 'ID100001', '2026-04-06', '2026-04-09', '2026-04-06 14:20:00', '2026-04-09 10:10:00', 'ID100007', 'ID100014', NULL, 'family'),
(7, 302, 'ID100004', '2026-04-07', '2026-04-09', '2026-04-07 15:10:00', '2026-04-09 11:20:00', 'ID100012', NULL, NULL, 'premium'),
(8, 203, 'ID100007', '2026-04-08', '2026-04-10', '2026-04-08 13:50:00', '2026-04-10 10:00:00', 'ID100010', NULL, NULL, 'standard'),
(9, 303, 'ID100009', '2026-04-09', '2026-04-11', '2026-04-09 14:30:00', '2026-04-11 11:00:00', 'ID100003', 'ID100006', NULL, 'premium'),
(10, 402, 'ID100006', '2026-04-10', '2026-04-12', '2026-04-10 12:45:00', '2026-04-12 09:30:00', NULL, NULL, NULL, 'business');

--
-- Triggers `bookings`
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
-- Table structure for table `employees`
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
  `job_title` varchar(50) DEFAULT NULL,
  `salary` int(10) UNSIGNED NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `fname`, `lname`, `tax_number`, `paid_holidays_left`, `address`, `date_of_birth`, `date_of_hiring`, `job_title`, `salary`, `created_at`, `updated_at`) VALUES
(1, 'Gábor', 'Nagy', 'TX100001', 18, 'Budapest, Andrássy út 10.', '1985-03-12', '2015-06-01', 'HK Manager', 950000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(2, 'Eszter', 'Kovács', 'TX100002', 20, 'Budapest, Bartók Béla út 22.', '1988-07-25', '2018-09-15', 'F&B Manager', 880000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(3, 'Anna', 'Szabó', 'TX100003', 12, 'Budapest, Váci út 45.', '1995-11-02', '2021-03-10', 'Receptionist', 420000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(4, 'Dániel', 'Tóth', 'TX100004', 10, 'Budapest, Üll?i út 78.', '1998-05-19', '2022-07-01', 'Receptionist', 400000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(5, 'Mária', 'Horváth', 'TX100005', 8, 'Budapest, József körút 33.', '1972-09-14', '2019-11-20', 'Cleaner', 300000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(6, 'József', 'Varga', 'TX100006', 6, 'Budapest, Kerepesi út 101.', '1968-01-30', '2017-04-05', 'Cleaner', 290000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(7, 'Lilla', 'Molnár', 'TX100007', 9, 'Budapest, Rákóczi út 12.', '1999-02-17', '2023-02-01', 'Room Service', 350000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(8, 'Bence', 'Farkas', 'TX100008', 11, 'Budapest, Fehérvári út 56.', '1996-08-09', '2020-06-18', 'Room Service', 360000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(9, 'Zoltán', 'Balogh', 'TX100009', 14, 'Budapest, Hungária körút 88.', '1982-12-05', '2016-01-10', 'Front Office Manager', 910000, '2026-03-30 07:06:55', '2026-03-30 07:06:55'),
(10, 'Petra', 'Papp', 'TX100010', 7, 'Budapest, Alkotás utca 3.', '1993-04-22', '2021-10-01', 'Cleaner', 410000, '2026-03-30 07:06:55', '2026-03-30 07:06:55');

--
-- Triggers `employees`
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
-- Table structure for table `guests`
--

CREATE TABLE `guests` (
  `id_card_number` varchar(20) NOT NULL,
  `fname` varchar(50) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `date_of_birth` date NOT NULL,
  `country` varchar(50) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `car_plate_number` varchar(10) DEFAULT NULL,
  `loyalty_level` tinyint(3) UNSIGNED DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `guests`
--

INSERT INTO `guests` (`id_card_number`, `fname`, `lname`, `date_of_birth`, `country`, `address`, `car_plate_number`, `loyalty_level`) VALUES
('ID100001', 'Bence', 'Kovács', '2015-06-12', 'Hungary', 'Budapest, Váci út 12.', NULL, 0),
('ID100002', 'Anna', 'Szabó', '1990-03-25', 'Hungary', 'Debrecen, Kossuth tér 5.', 'ABC123', 2),
('ID100003', 'John', 'Smith', '1985-11-02', 'United Kingdom', 'London, Baker Street 221B', NULL, 3),
('ID100004', 'Emma', 'Johnson', '2018-09-14', 'United States', 'New York, 5th Avenue 10.', NULL, 0),
('ID100005', 'Luca', 'Rossi', '2001-07-30', 'Italy', 'Rome, Via Milano 45.', 'XYZ789', 1),
('ID100006', 'Noah', 'Müller', '1978-01-19', 'Germany', 'Berlin, Alexanderplatz 3.', 'BER456', 4),
('ID100007', 'Mia', 'Novák', '2012-12-05', 'Slovakia', 'Bratislava, Main Street 8.', NULL, 0),
('ID100008', 'David', 'Nagy', '1995-05-21', 'Hungary', 'Szeged, Tisza Lajos krt. 22.', 'SZG234', 2),
('ID100009', 'Sophie', 'Dubois', '1988-08-17', 'France', 'Paris, Rue de Rivoli 15.', NULL, 3),
('ID100010', 'Matej', 'Horváth', '2010-04-11', 'Hungary', 'Gyor, Baross út 9.', NULL, 1),
('ID100011', 'Oliver', 'Brown', '2003-02-09', 'United Kingdom', 'Manchester, King St 44.', 'UK1234', 1),
('ID100012', 'Isabella', 'Garcia', '1992-10-28', 'Spain', 'Madrid, Gran Via 18.', 'ESP567', 2),
('ID100013', 'Levente', 'Tóth', '1980-06-06', 'Hungary', 'Pécs, Király utca 33.', NULL, 5),
('ID100014', 'Ella', 'Williams', '2016-01-03', 'United States', 'Los Angeles, Sunset Blvd 77.', NULL, 0),
('ID100015', 'Dániel', 'Varga', '1999-09-09', 'Hungary', 'Miskolc, Széchenyi utca 1.', 'MIS999', 2);

-- --------------------------------------------------------

--
-- Table structure for table `guestservices`
--

CREATE TABLE `guestservices` (
  `service_id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` text DEFAULT NULL,
  `price` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `guestservices`
--

INSERT INTO `guestservices` (`service_id`, `name`, `description`, `price`) VALUES
(1, 'Testmasszázs', 'Svédmasszázs 60 perc', 12000),
(2, 'Parkolás', 'Zárt parkoló napi díj', 3000),
(3, 'Transzfer', 'Reptéri transzfer egy irányba', 10000),
(4, 'Autóbérlés', 'Napi autóbérlés alap csomag', 15000),
(5, 'Mosatás', 'Ruhák mosása és vasalása', 5000),
(6, 'Szobaszerviz', 'Étel-ital rendelés szobába', 2500),
(7, 'Extra takarítás', 'Napi extra takarítás kérésre', 4000),
(8, 'Gyerekfelügyelet', 'Szakképzett felügyelet óránként', 3500),
(9, 'Pótágy', 'Extra ágy biztosítása', 7000),
(10, 'Kiságy', 'Babaágy biztosítása', 3000),
(11, 'Aromaterápiás masszázs', 'Illóolajos relaxációs masszázs 60 perc', 13000),
(12, 'Forró köves masszázs', 'Hot stone masszázs 60 perc', 15000),
(13, 'Arc kezelés', 'Hidratáló és revitalizáló arckezelés', 10000),
(14, 'Testkezelés', 'B?rradírozás és hidratáló kezelés', 11000),
(15, 'Kerékpár bérlés', 'Kerékpár bérlés napi díj', 4000),
(16, 'Elektromos kerékpár bérlés', 'E-bike bérlés napi díj', 8000),
(17, 'E-roller bérlés', 'Elektromos roller bérlés óradíj', 2500);

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `room_number` smallint(5) UNSIGNED NOT NULL,
  `room_type` varchar(30) NOT NULL,
  `floorspace` tinyint(3) UNSIGNED NOT NULL,
  `bed_type` varchar(20) NOT NULL,
  `has_balcony` tinyint(1) NOT NULL,
  `max_adults` tinyint(3) UNSIGNED NOT NULL,
  `extras` text DEFAULT NULL,
  `status` enum('available','occupied','dont_disturb','needs_cleaning','cleaning','under_maintenence','unavailable') DEFAULT NULL,
  `price_per_night` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`room_number`, `room_type`, `floorspace`, `bed_type`, `has_balcony`, `max_adults`, `extras`, `status`, `price_per_night`) VALUES
(101, 'STANDARD', 18, 'queen', 0, 2, 'street view', 'available', 22000),
(102, 'STANDARD', 20, 'twin', 0, 2, NULL, 'occupied', 21000),
(103, 'STANDARD', 22, 'queen', 1, 2, 'balcony', 'needs_cleaning', 24000),
(201, 'DELUXE', 28, 'kingsize', 1, 3, 'panorama view', 'available', 38000),
(202, 'DELUXE', 30, 'kingsize', 1, 3, 'panorama view, minibar', 'occupied', 42000),
(203, 'DELUXE', 27, 'queen', 1, 2, 'balcony, city view', 'cleaning', 36000),
(301, 'SUITE', 45, 'kingsize', 1, 4, 'jacuzzi, panorama view', 'available', 65000),
(302, 'SUITE', 50, 'kingsize', 1, 4, 'jacuzzi, minibar, balcony', 'dont_disturb', 72000),
(303, 'SUITE', 48, 'kingsize', 1, 5, 'panorama view, kitchen', 'occupied', 70000),
(401, 'STANDARD', 19, 'single', 0, 1, NULL, 'available', 18000),
(402, 'DELUXE', 32, 'kingsize', 1, 3, 'balcony, minibar', 'unavailable', 41000),
(403, 'SUITE', 55, 'kingsize', 1, 5, 'jacuzzi, kitchen, panorama view', 'needs_cleaning', 80000);

-- --------------------------------------------------------

--
-- Table structure for table `servicebookings`
--

CREATE TABLE `servicebookings` (
  `booking_id` int(11) NOT NULL,
  `service_id` int(11) NOT NULL,
  `timestamp` datetime NOT NULL DEFAULT current_timestamp(),
  `quantity` int(11) NOT NULL CHECK (`quantity` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `servicebookings`
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

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_bookings_room` (`room_number`),
  ADD KEY `fk_bookings_guest1` (`guest_id1`),
  ADD KEY `fk_bookings_guest2` (`guest_id2`),
  ADD KEY `fk_bookings_guest3` (`guest_id3`),
  ADD KEY `fk_bookings_guest4` (`guest_id4`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `tax_number` (`tax_number`),
  ADD KEY `idx_employees_name` (`lname`,`fname`);

--
-- Indexes for table `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`id_card_number`);

--
-- Indexes for table `guestservices`
--
ALTER TABLE `guestservices`
  ADD PRIMARY KEY (`service_id`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`room_number`);

--
-- Indexes for table `servicebookings`
--
ALTER TABLE `servicebookings`
  ADD PRIMARY KEY (`booking_id`,`service_id`,`timestamp`),
  ADD KEY `fk_servicebookings_service` (`service_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bookings`
--
ALTER TABLE `bookings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `guestservices`
--
ALTER TABLE `guestservices`
  MODIFY `service_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bookings`
--
ALTER TABLE `bookings`
  ADD CONSTRAINT `fk_bookings_guest1` FOREIGN KEY (`guest_id1`) REFERENCES `guests` (`id_card_number`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_bookings_guest2` FOREIGN KEY (`guest_id2`) REFERENCES `guests` (`id_card_number`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_bookings_guest3` FOREIGN KEY (`guest_id3`) REFERENCES `guests` (`id_card_number`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_bookings_guest4` FOREIGN KEY (`guest_id4`) REFERENCES `guests` (`id_card_number`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_bookings_room` FOREIGN KEY (`room_number`) REFERENCES `rooms` (`room_number`) ON UPDATE CASCADE;

--
-- Constraints for table `servicebookings`
--
ALTER TABLE `servicebookings`
  ADD CONSTRAINT `fk_servicebookings_booking` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_servicebookings_service` FOREIGN KEY (`service_id`) REFERENCES `guestservices` (`service_id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
