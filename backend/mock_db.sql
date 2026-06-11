-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Jún 11. 14:06
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
  `id` varchar(12) NOT NULL,
  `room_number` smallint(5) UNSIGNED DEFAULT NULL,
  `room_type` enum('standard','deluxe','suite','') NOT NULL,
  `guest1_id` int(11) NOT NULL,
  `beginning_of_stay` date NOT NULL,
  `end_of_stay` date NOT NULL CHECK (`end_of_stay` > `beginning_of_stay`),
  `checkin` datetime DEFAULT NULL,
  `checkout` datetime DEFAULT NULL,
  `guest2_id` int(11) DEFAULT NULL,
  `guest3_id` int(11) DEFAULT NULL,
  `guest4_id` int(11) DEFAULT NULL,
  `catering_level` enum('breakfast','halfboard','fullboard','') NOT NULL DEFAULT 'breakfast',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `bookings`
--

INSERT INTO `bookings` (`id`, `room_number`, `room_type`, `guest1_id`, `beginning_of_stay`, `end_of_stay`, `checkin`, `checkout`, `guest2_id`, `guest3_id`, `guest4_id`, `catering_level`, `created_at`) VALUES
('1', 101, '', 8, '2026-04-01', '2026-04-03', '2026-04-01 14:10:00', '2026-04-03 10:05:00', 1, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('10', 402, 'suite', 16, '2026-05-20', '2026-05-24', '2026-05-20 12:45:00', '0000-00-00 00:00:00', NULL, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('11', 401, 'suite', 1, '2026-05-22', '2026-05-26', NULL, NULL, NULL, NULL, NULL, 'halfboard', '2026-05-28 11:37:01'),
('12', 403, 'suite', 2, '2026-05-22', '2026-05-24', NULL, NULL, NULL, NULL, NULL, 'fullboard', '2026-05-28 11:37:01'),
('15', 303, 'deluxe', 17, '2026-05-22', '2026-05-24', NULL, NULL, NULL, NULL, NULL, 'halfboard', '2026-05-28 11:37:01'),
('2', 102, '', 7, '2026-04-02', '2026-04-04', '2026-04-02 13:30:00', '2026-04-04 09:00:00', NULL, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('20', 201, 'deluxe', 18, '2026-05-26', '2026-05-28', NULL, NULL, NULL, NULL, NULL, 'halfboard', '2026-05-28 11:37:01'),
('21', 302, 'deluxe', 19, '2026-05-26', '2026-05-30', '2026-05-27 08:36:57', '2026-05-28 08:36:57', NULL, NULL, NULL, 'fullboard', '2026-05-28 11:37:01'),
('3', 201, '', 3, '2026-04-03', '2026-04-05', '2026-04-03 15:00:00', '2026-04-05 11:00:00', 9, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('4', 202, '', 2, '2026-04-04', '2026-04-06', '2026-04-04 14:45:00', '2026-04-06 10:30:00', NULL, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('5', 103, '', 4, '2026-04-05', '2026-04-08', '2026-04-05 13:15:00', '2026-04-08 10:00:00', NULL, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('6', 301, '', 6, '2026-04-06', '2026-04-09', '2026-04-06 14:20:00', '2026-04-09 10:10:00', 5, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('7', 302, '', 11, '2026-04-07', '2026-04-09', '2026-04-07 15:10:00', '2026-04-09 11:20:00', 10, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('8', 203, '', 15, '2026-04-08', '2026-04-10', '2026-04-08 13:50:00', '2026-04-10 10:00:00', 12, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('9', 303, 'deluxe', 13, '2026-04-09', '2026-04-11', '2026-04-09 14:30:00', '2026-04-11 11:00:00', 14, NULL, NULL, 'breakfast', '2026-05-28 11:37:01'),
('HE-2026-194A', 303, 'deluxe', 18, '2026-05-28', '2026-05-30', NULL, NULL, NULL, NULL, NULL, 'halfboard', '2026-05-28 11:37:01'),
('HE-2026-194V', 102, 'standard', 19, '2026-05-29', '2026-06-04', NULL, NULL, NULL, NULL, NULL, 'halfboard', '2026-05-29 05:40:29'),
('HE-2026-UCT4', 403, 'suite', 19, '2026-06-03', '2026-06-12', NULL, NULL, NULL, NULL, NULL, 'fullboard', '2026-06-03 09:53:43');

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
-- Tábla szerkezet ehhez a táblához `food_and_beverage`
--

CREATE TABLE `food_and_beverage` (
  `id` int(11) NOT NULL,
  `category` enum('breakfast','starter','soup','main_course','dessert','hot_drink','soft_drink','alcoholic_drink') NOT NULL,
  `name_hu` varchar(50) NOT NULL,
  `description_hu` text NOT NULL,
  `name_en` varchar(50) NOT NULL,
  `description_en` text NOT NULL,
  `price` int(11) NOT NULL,
  `measure` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `food_and_beverage`
--

INSERT INTO `food_and_beverage` (`id`, `category`, `name_hu`, `description_hu`, `name_en`, `description_en`, `price`, `measure`) VALUES
(1, 'breakfast', 'Croissant vajjal és lekvárral', 'Frissen sütött vajas croissant házi lekvárral.', 'Butter Croissant with Jam', 'Freshly baked butter croissant served with homemade jam.', 2900, '1 adag'),
(2, 'breakfast', 'Pain au chocolat', 'Francia csokoládés leveles péksütemény.', 'Pain au Chocolat', 'French chocolate-filled pastry.', 3200, '1 adag'),
(3, 'breakfast', 'Amerikai reggeli', 'Tükörtojás, bacon, kolbász, pirítós és saláta.', 'American Breakfast', 'Eggs, bacon, sausage, toast and salad.', 6900, '1 adag'),
(4, 'breakfast', 'Kontinentális reggeli', 'Pékáru, vaj, lekvár, sonka és sajt.', 'Continental Breakfast', 'Pastries, butter, jam, ham and cheese.', 5900, '1 adag'),
(5, 'breakfast', 'Füstölt lazacos bagel', 'Krémsajt, lazac és kapribogyó.', 'Smoked Salmon Bagel', 'Cream cheese, smoked salmon and capers.', 5900, '1 adag'),
(6, 'breakfast', 'Avokádós pirítós', 'Kovászos kenyér avokádókrémmel.', 'Avocado Toast', 'Sourdough toast with avocado cream.', 4900, '1 adag'),
(7, 'breakfast', 'Eggs Benedict', 'Buggyantott tojás hollandi mártással.', 'Eggs Benedict', 'Poached eggs with hollandaise sauce.', 5900, '1 adag'),
(8, 'breakfast', 'Rántotta három tojásból', 'Friss tojásból készített rántotta.', 'Three-Egg Scramble', 'Freshly prepared scrambled eggs.', 3900, '1 adag'),
(9, 'breakfast', 'Omlett sonkával és sajttal', 'Klasszikus omlett sonkával és sajttal.', 'Ham and Cheese Omelette', 'Classic omelette with ham and cheese.', 4500, '1 adag'),
(10, 'breakfast', 'Granola joghurttal', 'Házi granola görög joghurttal.', 'Granola with Yogurt', 'Homemade granola with Greek yogurt.', 3900, '1 adag'),
(11, 'starter', 'Marhatatár', 'Kézzel vágott marhahús briós pirítóssal.', 'Beef Tartare', 'Hand-cut beef tartare with brioche toast.', 6900, '180 g'),
(12, 'starter', 'Füstölt lazac', 'Hidegen füstölt lazac citrusos salátával.', 'Smoked Salmon', 'Cold smoked salmon with citrus salad.', 6200, '150 g'),
(13, 'starter', 'Burrata', 'Krémes burrata paradicsomokkal.', 'Burrata', 'Creamy burrata with tomatoes.', 5400, '200 g'),
(14, 'starter', 'Kacsamáj terrine', 'Házi készítésű terrine brióssal.', 'Duck Liver Terrine', 'Homemade duck liver terrine with brioche.', 6900, '160 g'),
(15, 'starter', 'Garnéla koktél', 'Koktélrák citrusos mártással.', 'Shrimp Cocktail', 'Shrimps with citrus dressing.', 6500, '180 g'),
(16, 'starter', 'Tonhal tataki', 'Enyhén pirított tonhal szezámmal.', 'Tuna Tataki', 'Lightly seared tuna with sesame.', 7200, '160 g'),
(17, 'starter', 'Carpaccio', 'Vékonyra szeletelt marhahús parmezánnal.', 'Beef Carpaccio', 'Thinly sliced beef with parmesan.', 6500, '160 g'),
(18, 'starter', 'Kecskesajt saláta', 'Sült kecskesajt vegyes salátával.', 'Goat Cheese Salad', 'Warm goat cheese with mixed greens.', 4900, '220 g'),
(19, 'starter', 'Caesar saláta csirkével', 'Római saláta grillezett csirkével.', 'Chicken Caesar Salad', 'Romaine lettuce with grilled chicken.', 5900, '300 g'),
(20, 'starter', 'Caesar saláta garnélával', 'Római saláta garnélával.', 'Shrimp Caesar Salad', 'Romaine lettuce with shrimp.', 6900, '300 g'),
(21, 'soup', 'Marhahúsleves', 'Házi marhahúsleves metélttel.', 'Beef Consommé', 'Traditional beef consommé with noodles.', 3500, '300 ml'),
(22, 'soup', 'Sütőtökkrémleves', 'Pirított tökmaggal.', 'Pumpkin Cream Soup', 'Pumpkin cream soup with toasted seeds.', 3900, '300 ml'),
(23, 'soup', 'Szarvasgombás burgonyakrémleves', 'Fekete szarvasgomba olajjal.', 'Truffle Potato Soup', 'Potato cream soup with truffle oil.', 3900, '300 ml'),
(24, 'soup', 'Halászlé', 'Magyar halászlé filézett hallal.', 'Hungarian Fish Soup', 'Traditional Hungarian fish soup.', 4900, '350 ml'),
(25, 'soup', 'Paradicsomleves', 'Bazsalikommal és parmezánnal.', 'Tomato Soup', 'Tomato soup with basil and parmesan.', 3500, '300 ml'),
(26, 'main_course', 'Csirkemell supreme', 'Ropogós bőrös csirkemell burgonyapürével.', 'Chicken Supreme', 'Crispy skin chicken breast with mashed potatoes.', 7900, '1 adag'),
(27, 'main_course', 'Kacsamell', 'Roséra sült kacsamell zellerpürével.', 'Duck Breast', 'Medium roasted duck breast with celery purée.', 9900, '1 adag'),
(28, 'main_course', 'Bélszín steak 200g', 'Prémium marhabélszín grillezett zöldségekkel.', 'Beef Tenderloin Steak 200g', 'Premium beef tenderloin with vegetables.', 14900, '1 adag'),
(29, 'main_course', 'Rib-eye steak 300g', 'Márványozott marhahús steak.', 'Rib-Eye Steak 300g', 'Marbled rib-eye steak.', 17900, '1 adag'),
(30, 'main_course', 'Wiener schnitzel', 'Borjú bécsi szelet petrezselymes burgonyával.', 'Wiener Schnitzel', 'Veal schnitzel with parsley potatoes.', 9900, '1 adag'),
(31, 'main_course', 'Lazacfilé', 'Spárgával és citromos vajjal.', 'Salmon Fillet', 'Salmon fillet with asparagus.', 10900, '1 adag'),
(32, 'main_course', 'Fogasfilé', 'Sült fogasfilé zöldséges rizottóval.', 'Pike Perch Fillet', 'Roasted pike perch with risotto.', 9900, '1 adag'),
(33, 'main_course', 'Tonhal steak', 'Grillezett tonhal steak salátával.', 'Tuna Steak', 'Grilled tuna steak with salad.', 12900, '1 adag'),
(34, 'main_course', 'Sertésszűz', 'Sertésszűz érlelt jus-vel.', 'Pork Tenderloin', 'Pork tenderloin with rich jus.', 7900, '1 adag'),
(35, 'main_course', 'Báránygerinc', 'Rozmaringos báránygerinc.', 'Rack of Lamb', 'Rosemary rack of lamb.', 13900, '1 adag'),
(36, 'dessert', 'Csokoládé fondant', 'Vanília fagylalttal.', 'Chocolate Fondant', 'Chocolate fondant with vanilla ice cream.', 3900, '180 g'),
(37, 'dessert', 'Crème brûlée', 'Klasszikus francia desszert.', 'Crème Brûlée', 'Classic French dessert.', 3500, '150 g'),
(38, 'dessert', 'New York sajttorta', 'Bogyós gyümölcsökkel.', 'New York Cheesecake', 'Cheesecake with berries.', 3600, '180 g'),
(39, 'dessert', 'Tiramisu', 'Mascarponés olasz desszert.', 'Tiramisu', 'Italian mascarpone dessert.', 3500, '180 g'),
(40, 'dessert', 'Somlói galuska', 'Tradicionális magyar desszert.', 'Somlói Sponge Cake', 'Traditional Hungarian dessert.', 3200, '220 g'),
(41, 'hot_drink', 'Espresso', 'Prémium arabica kávé.', 'Espresso', 'Premium arabica coffee.', 1200, '30 ml'),
(42, 'hot_drink', 'Dupla espresso', 'Kétszeres adag espresso.', 'Double Espresso', 'Double shot espresso.', 1800, '60 ml'),
(43, 'hot_drink', 'Americano', 'Espresso forró vízzel.', 'Americano', 'Espresso with hot water.', 1600, '180 ml'),
(44, 'hot_drink', 'Cappuccino', 'Espresso tejhabbal.', 'Cappuccino', 'Espresso with milk foam.', 1900, '250 ml'),
(45, 'hot_drink', 'Caffè Latte', 'Krémes tejeskávé.', 'Caffè Latte', 'Creamy milk coffee.', 2200, '300 ml'),
(46, 'soft_drink', 'Coca-Cola', 'Klasszikus szénsavas üdítőital.', 'Coca-Cola', 'Classic carbonated soft drink.', 1400, '330 ml'),
(47, 'soft_drink', 'Coca-Cola Zero', 'Cukormentes üdítőital.', 'Coca-Cola Zero', 'Sugar-free soft drink.', 1400, '330 ml'),
(48, 'soft_drink', 'Sprite', 'Citrom-lime ízű üdítőital.', 'Sprite', 'Lemon-lime soft drink.', 1400, '330 ml'),
(49, 'soft_drink', 'Fanta Narancs', 'Narancs ízű üdítőital.', 'Fanta Orange', 'Orange flavored soft drink.', 1400, '330 ml'),
(50, 'soft_drink', 'Házi limonádé', 'Frissen facsart citromléből készítve.', 'Homemade Lemonade', 'Prepared with freshly squeezed lemons.', 1900, '400 ml'),
(51, 'alcoholic_drink', 'Sauvignon Blanc', 'Prémium magyar fehérbor pohárra.', 'Sauvignon Blanc', 'Premium Hungarian white wine by the glass.', 2600, '150 ml'),
(52, 'alcoholic_drink', 'Chardonnay', 'Hordós érlelésű fehérbor.', 'Chardonnay', 'Barrel-aged white wine.', 2800, '150 ml'),
(53, 'alcoholic_drink', 'Rosé Cuvée', 'Friss gyümölcsös rosé.', 'Rosé Cuvée', 'Fresh fruity rosé wine.', 2500, '150 ml'),
(54, 'alcoholic_drink', 'Pinot Noir', 'Elegáns vörösbor.', 'Pinot Noir', 'Elegant red wine.', 3200, '150 ml'),
(55, 'alcoholic_drink', 'Cabernet Sauvignon', 'Testes vörösbor.', 'Cabernet Sauvignon', 'Full-bodied red wine.', 3400, '150 ml'),
(56, 'alcoholic_drink', 'Negroni', 'Gin, Campari és vörös vermut.', 'Negroni', 'Gin, Campari and sweet vermouth.', 4200, '150 ml'),
(57, 'alcoholic_drink', 'Old Fashioned', 'Bourbon whiskey, cukor és bitter.', 'Old Fashioned', 'Bourbon whiskey, sugar and bitters.', 4500, '120 ml'),
(58, 'alcoholic_drink', 'Espresso Martini', 'Vodka, kávélikőr és espresso.', 'Espresso Martini', 'Vodka, coffee liqueur and espresso.', 4600, '180 ml'),
(59, 'alcoholic_drink', 'Mojito', 'Rum, lime, menta és szóda.', 'Mojito', 'Rum, lime, mint and soda.', 3900, '250 ml'),
(60, 'alcoholic_drink', 'Aperol Spritz', 'Aperol, prosecco és szóda.', 'Aperol Spritz', 'Aperol, prosecco and soda.', 4200, '250 ml');

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
(17, 'nrbrt@nrbrt-codes.hu', NULL, 'Norbert', 'Tóth', NULL, 'HU', '1135', 'Budapest', 'Béke tér 1.', NULL, 0),
(18, 'ntoth.gbam@gmail.com', NULL, 'Norbert', 'Tóth', NULL, 'HU', '2310', 'Szigetszentmiklós', 'Nyomdász utca 8', NULL, 0),
(19, 'norbert.toth83@gmail.com', NULL, 'Norbert', 'Tóth', '1983-09-23', 'HU', '9072', 'Nagyszentjános', 'Galagonya u. 16', 'REP437', 6);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `refresh_tokens`
--

CREATE TABLE `refresh_tokens` (
  `id` int(11) NOT NULL,
  `guest_id` int(11) NOT NULL,
  `token_id` varchar(255) NOT NULL,
  `expires_at` datetime NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `refresh_tokens`
--

INSERT INTO `refresh_tokens` (`id`, `guest_id`, `token_id`, `expires_at`, `created_at`) VALUES
(2, 19, 'b8f99a03fea64b4c2b25756254795e8c', '2026-06-17 10:12:21', '2026-06-10 08:12:21'),
(9, 19, '8fd981d75a3f2f640fc1ad169e64344b', '2026-06-18 09:00:20', '2026-06-11 07:00:20'),
(10, 19, 'a391668060227d7a8d2b64d8aa6468e8', '2026-06-18 10:23:55', '2026-06-11 08:23:55'),
(12, 19, 'bafb83c2e3b41fef9fa9390956a5991d', '2026-06-18 13:14:54', '2026-06-11 11:14:54');

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
(102, 'standard', 20, 'twin', 1, 'city', 2, '', 'occupied', 21000),
(103, 'standard', 22, 'queen', 1, 'garden', 2, '', 'needs_cleaning', 24000),
(201, 'deluxe', 28, 'kingsize', 1, 'garden', 3, '', 'available', 38000),
(202, 'deluxe', 30, 'kingsize', 1, 'city', 3, '', 'occupied', 42000),
(203, 'deluxe', 27, 'queen', 1, 'panorama', 2, '', 'cleaning', 36000),
(301, 'standard', 28, 'twin', 0, 'garden', 2, '', 'available', 34500),
(302, 'deluxe', 32, 'kingsize', 1, 'garden', 2, 'jacuzzi', 'dont_disturb', 42000),
(303, 'deluxe', 27, 'kingsize', 1, 'city', 2, '', 'occupied', 29900),
(401, 'suite', 50, 'kingsize', 1, 'panorama', 3, 'jacuzzi', 'available', 76000),
(402, 'suite', 50, 'kingsize', 1, 'panorama', 3, 'kitchen', 'unavailable', 76000),
(403, 'suite', 55, 'kingsize', 1, 'panorama', 4, 'jacuzzi, kitchen', 'needs_cleaning', 62000);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `servicebookings`
--

CREATE TABLE `servicebookings` (
  `id` int(11) NOT NULL,
  `booking_id` varchar(12) NOT NULL,
  `service_id` int(11) NOT NULL,
  `requested_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `quantity` int(11) UNSIGNED NOT NULL,
  `status` enum('created','pending','completed','deleted') NOT NULL DEFAULT 'created',
  `price_at_booking` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- A tábla adatainak kiíratása `servicebookings`
--

INSERT INTO `servicebookings` (`id`, `booking_id`, `service_id`, `requested_at`, `updated_at`, `quantity`, `status`, `price_at_booking`) VALUES
(1, '1', 1, '2026-04-01 15:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(2, '1', 6, '2026-04-01 19:30:00', '2026-05-28 12:46:14', 2, 'completed', 0),
(3, '2', 2, '2026-04-02 10:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(4, '2', 3, '2026-04-02 09:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(5, '3', 4, '2026-04-03 08:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(6, '3', 6, '2026-04-03 20:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(7, '4', 11, '2026-04-04 14:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(8, '4', 12, '2026-04-04 16:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(9, '4', 13, '2026-04-04 17:30:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(10, '5', 5, '2026-04-05 11:00:00', '2026-05-28 12:46:14', 2, 'completed', 0),
(11, '5', 7, '2026-04-05 13:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(12, '6', 8, '2026-04-06 18:00:00', '2026-05-28 12:46:14', 3, 'completed', 0),
(13, '6', 9, '2026-04-06 14:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(14, '6', 10, '2026-04-06 14:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(15, '7', 1, '2026-04-07 15:30:00', '2026-05-28 12:46:14', 2, 'completed', 0),
(16, '7', 14, '2026-04-07 17:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(17, '8', 15, '2026-04-08 09:00:00', '2026-05-28 12:46:14', 2, 'completed', 0),
(18, '8', 17, '2026-04-08 10:30:00', '2026-05-28 12:46:14', 2, 'completed', 0),
(19, '9', 6, '2026-04-09 20:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(20, '9', 11, '2026-04-09 18:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(21, '9', 12, '2026-04-09 16:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(22, '10', 3, '2026-04-10 08:00:00', '2026-05-28 12:46:14', 1, 'completed', 0),
(23, '10', 6, '2026-04-10 19:00:00', '2026-05-28 12:46:14', 2, 'completed', 0),
(24, '10', 16, '2026-04-10 09:00:00', '2026-05-28 12:45:16', 1, 'completed', 0),
(25, 'HE-2026-UCT4', 3, '2026-06-09 10:39:21', '2026-06-11 10:11:51', 1, 'completed', 10000),
(33, 'HE-2026-UCT4', 4, '2026-06-11 09:52:17', '2026-06-11 09:52:17', 1, 'created', 15000);

--
-- Eseményindítók `servicebookings`
--
DELIMITER $$
CREATE TRIGGER `before_servicebookings_insert` BEFORE INSERT ON `servicebookings` FOR EACH ROW BEGIN
    SET NEW.price_at_booking = (
        SELECT price 
        FROM services 
        WHERE id = NEW.service_id
    );
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `services`
--

CREATE TABLE `services` (
  `id` int(11) NOT NULL,
  `name_hu` varchar(50) NOT NULL,
  `description_hu` mediumtext DEFAULT NULL,
  `price` int(11) UNSIGNED NOT NULL,
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
-- A tábla indexei `food_and_beverage`
--
ALTER TABLE `food_and_beverage`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`) USING BTREE,
  ADD UNIQUE KEY `id_card_number` (`id_card_number`);

--
-- A tábla indexei `refresh_tokens`
--
ALTER TABLE `refresh_tokens`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `token_id` (`token_id`),
  ADD KEY `token_id_2` (`token_id`),
  ADD KEY `guest_id` (`guest_id`);

--
-- A tábla indexei `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`room_number`);

--
-- A tábla indexei `servicebookings`
--
ALTER TABLE `servicebookings`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_servicebookings_service` (`service_id`),
  ADD KEY `fk_booking_id` (`booking_id`);

--
-- A tábla indexei `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `employees`
--
ALTER TABLE `employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `food_and_beverage`
--
ALTER TABLE `food_and_beverage`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT a táblához `guests`
--
ALTER TABLE `guests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT a táblához `refresh_tokens`
--
ALTER TABLE `refresh_tokens`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT a táblához `servicebookings`
--
ALTER TABLE `servicebookings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

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
-- Megkötések a táblához `refresh_tokens`
--
ALTER TABLE `refresh_tokens`
  ADD CONSTRAINT `refresh_tokens_ibfk_1` FOREIGN KEY (`guest_id`) REFERENCES `guests` (`id`) ON DELETE CASCADE;

--
-- Megkötések a táblához `servicebookings`
--
ALTER TABLE `servicebookings`
  ADD CONSTRAINT `fk_booking_id` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`),
  ADD CONSTRAINT `fk_service_id` FOREIGN KEY (`service_id`) REFERENCES `services` (`id`),
  ADD CONSTRAINT `fk_servicebookings_service` FOREIGN KEY (`service_id`) REFERENCES `services` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
