-- Adatbázis létrehozása és használata
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HotelDB')
BEGIN
    CREATE DATABASE HotelDB;
END
GO
USE HotelDB;
GO

-- --------------------------------------------------------
-- Table structure for table guests
-- --------------------------------------------------------
CREATE TABLE guests (
  id_card_number varchar(20) NOT NULL PRIMARY KEY,
  fname varchar(50) NOT NULL,
  lname varchar(50) NOT NULL,
  date_of_birth date NOT NULL,
  country varchar(50) DEFAULT NULL,
  address nvarchar(max) DEFAULT NULL,
  car_plate_number varchar(10) DEFAULT NULL,
  loyalty_level tinyint DEFAULT 0
);

-- --------------------------------------------------------
-- Table structure for table rooms
-- --------------------------------------------------------
CREATE TABLE rooms (
  room_number smallint NOT NULL PRIMARY KEY,
  room_type varchar(30) NOT NULL,
  floorspace tinyint NOT NULL,
  bed_type varchar(20) NOT NULL,
  has_balcony bit NOT NULL,
  max_adults tinyint NOT NULL,
  extras nvarchar(max) DEFAULT NULL,
  status varchar(20) CHECK (status IN ('available','occupied','dont_disturb','needs_cleaning','cleaning','under_maintenence','unavailable')),
  price_per_night int DEFAULT NULL
);

-- --------------------------------------------------------
-- Table structure for table bookings
-- --------------------------------------------------------
CREATE TABLE bookings (
  id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  room_number smallint DEFAULT NULL,
  guest_id1 varchar(20) NOT NULL,
  beginning_of_stay date NOT NULL,
  end_of_stay date NOT NULL,
  checkin datetime DEFAULT NULL,
  checkout datetime DEFAULT NULL,
  guest_id2 varchar(20) DEFAULT NULL,
  guest_id3 varchar(20) DEFAULT NULL,
  guest_id4 varchar(20) DEFAULT NULL,
  level_of_service varchar(20) DEFAULT NULL,
  CONSTRAINT chk_stay_dates CHECK (end_of_stay > beginning_of_stay),
  CONSTRAINT fk_bookings_room FOREIGN KEY (room_number) REFERENCES rooms (room_number) ON UPDATE CASCADE,
  CONSTRAINT fk_bookings_guest1 FOREIGN KEY (guest_id1) REFERENCES guests (id_card_number) ON UPDATE CASCADE
);

-- --------------------------------------------------------
-- Table structure for table guestservices
-- --------------------------------------------------------
CREATE TABLE guestservices (
  service_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  name varchar(50) NOT NULL,
  description nvarchar(max) DEFAULT NULL,
  price int NOT NULL
);

-- --------------------------------------------------------
-- Table structure for table servicebookings
-- --------------------------------------------------------
CREATE TABLE servicebookings (
  booking_id int NOT NULL,
  service_id int NOT NULL,
  timestamp datetime NOT NULL DEFAULT GETDATE(),
  quantity int NOT NULL CHECK (quantity > 0),
  PRIMARY KEY (booking_id, service_id, timestamp),
  CONSTRAINT fk_servicebookings_booking FOREIGN KEY (booking_id) REFERENCES bookings (id) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_servicebookings_service FOREIGN KEY (service_id) REFERENCES guestservices (service_id) ON UPDATE CASCADE
);

-- --------------------------------------------------------
-- Table structure for table employees
-- --------------------------------------------------------
CREATE TABLE employees (
  id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  fname nvarchar(30) NOT NULL,
  lname nvarchar(30) NOT NULL,
  tax_number varchar(20) NOT NULL UNIQUE,
  paid_holidays_left tinyint NOT NULL DEFAULT 0,
  address nvarchar(max) DEFAULT NULL,
  date_of_birth date DEFAULT NULL,
  date_of_hiring date NOT NULL,
  job_title varchar(50) DEFAULT NULL,
  salary int NOT NULL,
  created_at datetime NOT NULL DEFAULT GETDATE(),
  updated_at datetime NOT NULL DEFAULT GETDATE()
);
GO

-- ADATOK FELTÖLTÉSE (Példa a bookings-hoz)
INSERT INTO guests (id_card_number, fname, lname, date_of_birth, country, loyalty_level) VALUES
('ID100001', 'Bence', 'Kovács', '2015-06-12', 'Hungary', 0),
('ID100002', 'Anna', 'Szabó', '1990-03-25', 'Hungary', 2);

INSERT INTO rooms (room_number, room_type, floorspace, bed_type, has_balcony, max_adults, status, price_per_night) VALUES
(101, 'STANDARD', 18, 'queen', 0, 2, 'available', 22000);

INSERT INTO bookings (room_number, guest_id1, beginning_of_stay, end_of_stay, level_of_service) VALUES
(101, 'ID100002', '2026-04-01', '2026-04-03', 'standard');
GO

-- Triggerek (MS SQL Server szintaxis)
CREATE TRIGGER trg_booking_date_check ON bookings AFTER INSERT AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE beginning_of_stay < CAST(GETDATE() AS DATE))
    BEGIN
        RAISERROR ('beginning_of_stay cannot be in the past', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO