-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Jún 26. 12:56
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
-- Tábla szerkezet ehhez a táblához `guests`
--

CREATE TABLE `guests` (
  `id` int(11) NOT NULL,
  `email` varchar(64) NOT NULL,
  `id_card_number` varchar(20) DEFAULT NULL,
  `fname` varchar(50) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `date_of_birth` date DEFAULT NULL,
  `country` varchar(50) NOT NULL,
  `zip_code` varchar(10) NOT NULL,
  `city` varchar(40) NOT NULL,
  `street` varchar(50) NOT NULL,
  `car_plate_number` varchar(10) DEFAULT NULL,
  `total_nights` int(11) DEFAULT 0,
  `loyalty_level` int(11) GENERATED ALWAYS AS (least(floor(`total_nights` / 5),10)) STORED
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `guests`
--

INSERT INTO `guests` (`id`, `email`, `id_card_number`, `fname`, `lname`, `date_of_birth`, `country`, `zip_code`, `city`, `street`, `car_plate_number`, `total_nights`) VALUES
(1, 'kovacs.bence2015@gmail.com', 'ID100001', 'Bence', 'Kovács', '2015-06-12', 'Hungary', '', '', 'Budapest, Váci út 12.', NULL, 0),
(2, 'szabo.anna.debrecen@freemail.hu', 'ID100002', 'Anna', 'Szabó', '1990-03-25', 'Hungary', '', '', 'Debrecen, Kossuth tér 5.', 'ABC123', 2),
(3, 'john.smith85@outlook.com', 'ID100003', 'John', 'Smith', '1985-11-02', 'United Kingdom', '', '', 'London, Baker Street 221B', NULL, 3),
(4, 'emma.j.ny@icloud.com', 'ID100004', 'Emma', 'Johnson', '2018-09-14', 'United States', '', '', 'New York, 5th Avenue 10.', NULL, 0),
(5, 'luca.rossi2001@libero.it', 'ID100005', 'Luca', 'Rossi', '2001-07-30', 'Italy', '', '', 'Rome, Via Milano 45.', 'XYZ789', 1),
(6, 'noah.muller78@t-online.de', 'ID100006', 'Noah', 'Müller', '1978-01-19', 'Germany', '', '', 'Berlin, Alexanderplatz 3.', 'BER456', 4),
(7, 'mia.novak.sk@atlas.sk', 'ID100007', 'Mia', 'Novák', '2012-12-05', 'Slovakia', '', '', 'Bratislava, Main Street 8.', NULL, 0),
(8, 'nagy.david95@gmail.com', 'ID100008', 'David', 'Nagy', '1995-05-21', 'Hungary', '', '', 'Szeged, Tisza Lajos krt. 22.', 'SZG234', 2),
(9, 'sophie.dubois.paris@orange.fr', 'ID100009', 'Sophie', 'Dubois', '1988-08-17', 'France', '', '', 'Paris, Rue de Rivoli 15.', NULL, 3),
(10, 'horvath.matej.2010@citromail.hu', 'ID100010', 'Matej', 'Horváth', '2010-04-11', 'Hungary', '', '', 'Győr, Baross út 9.', NULL, 1),
(11, 'oliver.brown.manchester@yahoo.co.uk', 'ID100011', 'Oliver', 'Brown', '2003-02-09', 'United Kingdom', '', '', 'Manchester, King St 44.', 'UK1234', 1),
(12, 'isabella.garcia92@hotmail.es', 'ID100012', 'Isabella', 'Garcia', '1992-10-28', 'Spain', '', '', 'Madrid, Gran Via 18.', 'ESP567', 2),
(13, 'toth.levente80@gmail.com', 'ID100013', 'Levente', 'Tóth', '1980-06-06', 'Hungary', '', '', 'Pécs, Király utca 33.', NULL, 5),
(14, 'ella.williams2016@aol.com', 'ID100014', 'Ella', 'Williams', '2016-01-03', 'United States', '', '', 'Los Angeles, Sunset Blvd 77.', NULL, 0),
(15, 'varga.daniel.miskolc@freemail.hu', 'ID100015', 'Dániel', 'Varga', '1999-09-09', 'Hungary', '', '', 'Miskolc, Széchenyi utca 1.', 'MIS999', 2),
(16, 'szekeres.nora89@gmail.com', 'ID100321', 'Nóra', 'Szekeres', '1989-07-01', 'Hungary', '', '', 'Győr, Bajcsi Zs. utca 12.', NULL, 0),
(18, 'ntoth.gbam@gmail.com', NULL, 'Norbert', 'Tóth', NULL, 'HU', '2310', 'Szigetszentmiklós', 'Nyomdász utca 8', NULL, 0),
(19, 'norbert.toth83@gmail.com', NULL, 'Norbert', 'Tóth', '1983-09-23', 'HU', '1135', 'Budapest', 'Béke tér  1.', '', 6);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`) USING BTREE,
  ADD UNIQUE KEY `id_card_number` (`id_card_number`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `guests`
--
ALTER TABLE `guests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
