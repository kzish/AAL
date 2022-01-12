-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.33 - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table aal.aspnetroleclaims
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(450) CHARACTER SET utf8 NOT NULL,
  `ClaimType` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `ClaimValue` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.aspnetroleclaims: ~0 rows (approximately)
DELETE FROM `aspnetroleclaims`;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;

-- Dumping structure for table aal.aspnetroles
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(450) CHARACTER SET utf8 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `ConcurrencyStamp` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.aspnetroles: ~3 rows (approximately)
DELETE FROM `aspnetroles`;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
	('9ab2c05a-be24-40ae-9d65-51637eb08e9f', 'admin', 'ADMIN', '5f89e15e-ece1-467e-9aa5-8e2dcdba009d'),
	('b015545e-f467-4eb8-9810-eef6bccd6339', 'tutor', 'TUTOR', 'ca9c8746-6485-4f95-8135-4b129c1353a4'),
	('d52dd68d-44c0-45ca-9b64-56f70aa22a58', 'student', 'STUDENT', '89f8d6c6-f8e9-4c0e-82ac-bb5af3f6a33e');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;

-- Dumping structure for table aal.aspnetuserclaims
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(450) CHARACTER SET utf8 NOT NULL,
  `ClaimType` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `ClaimValue` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.aspnetuserclaims: ~0 rows (approximately)
DELETE FROM `aspnetuserclaims`;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;

-- Dumping structure for table aal.aspnetuserlogins
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8 NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8 NOT NULL,
  `ProviderDisplayName` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `UserId` varchar(450) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.aspnetuserlogins: ~0 rows (approximately)
DELETE FROM `aspnetuserlogins`;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;

-- Dumping structure for table aal.aspnetuserroles
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(450) CHARACTER SET utf8 NOT NULL,
  `RoleId` varchar(450) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.aspnetuserroles: ~6 rows (approximately)
DELETE FROM `aspnetuserroles`;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
	('3d06ddd9-db24-4964-9558-118f6aefa8e9', '9ab2c05a-be24-40ae-9d65-51637eb08e9f'),
	('06e8e670-f82a-4ee3-a83d-d48164ae87ef', 'b015545e-f467-4eb8-9810-eef6bccd6339'),
	('07ad2d78-89be-4917-90ab-101de14355ad', 'b015545e-f467-4eb8-9810-eef6bccd6339'),
	('1de25b58-9d4d-4d0b-a87b-40ae43fc14bd', 'b015545e-f467-4eb8-9810-eef6bccd6339'),
	('48bdd129-3f4f-4f7a-a270-ace918105092', 'b015545e-f467-4eb8-9810-eef6bccd6339'),
	('7ed9ab9a-cd12-4753-8a7a-00caf127a6ac', 'b015545e-f467-4eb8-9810-eef6bccd6339');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;

-- Dumping structure for table aal.aspnetusers
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(450) CHARACTER SET utf8 NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `SecurityStamp` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `ConcurrencyStamp` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `PhoneNumber` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.aspnetusers: ~5 rows (approximately)
DELETE FROM `aspnetusers`;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
	('06e8e670-f82a-4ee3-a83d-d48164ae87ef', 'asher@gmail.com', 'ASHER@GMAIL.COM', 'asher@gmail.com', 'ASHER@GMAIL.COM', b'0', 'AQAAAAEAACcQAAAAEBSpTz+4EQLBESRi81c1oDYrmH05oQaj6rXnFH897E6F3ESp5RW0spAmUGaNFMvp5A==', 'CZRYZDITSXFMFYGK66RJEWYF55VXZ2D6', '4ad4856d-6700-4803-9f2f-1564ffc1c423', NULL, b'0', b'0', NULL, b'1', 0),
	('07ad2d78-89be-4917-90ab-101de14355ad', 'kzish@gmail.com', 'KZISH@GMAIL.COM', 'kzish@gmail.com', 'KZISH@GMAIL.COM', b'0', 'AQAAAAEAACcQAAAAENcoDDi52n1G/OvlNDr4IJnsesDAS5/4BGLvHiSalfz542Oi7U7Xcbmsa0zvXoWHPg==', 'V4MVAIJR2EWUHSRQBYVMJR7YH5WEMEEE', 'd611a210-a233-4933-929c-1163884ab0ef', NULL, b'0', b'0', NULL, b'1', 0),
	('1de25b58-9d4d-4d0b-a87b-40ae43fc14bd', 'taps@gmail.com', 'TAPS@GMAIL.COM', 'taps@gmail.com', 'TAPS@GMAIL.COM', b'0', 'AQAAAAEAACcQAAAAEOym2Ise9DH5GFU0mwmKHnYh1kU3M1OjMYvqJUZTjCtr4sJI3wdhRcJZ/qNan8XhNg==', '5P65IADWL3XQJUSDQPBCVKHJG6L2HRD4', '87ca4e96-6053-40bd-a61d-9ea76cbb4999', NULL, b'0', b'0', NULL, b'1', 0),
	('3d06ddd9-db24-4964-9558-118f6aefa8e9', 'admin@rubiem.com', 'ADMIN@RUBIEM.COM', 'admin@rubiem.com', 'ADMIN@RUBIEM.COM', b'0', 'AQAAAAEAACcQAAAAEIRwBO2ED2KVo8JkNnjZiTCjdz82imkUU1XCdBK8mrELChRn3nUkCy8odlnswX9hRQ==', '2P47NVOAU5L4GHAREB2LJ2EOBMCUSIVG', '4637232d-748a-46b7-ab0a-ba869e12cdb8', NULL, b'0', b'0', NULL, b'1', 0),
	('7ed9ab9a-cd12-4753-8a7a-00caf127a6ac', 'tino@gmail.com', 'TINO@GMAIL.COM', 'tino@gmail.com', 'TINO@GMAIL.COM', b'0', 'AQAAAAEAACcQAAAAEC3UM2a+J1Njkjaa/Yiw8gZMZ1poEION/diGzW7O0atAdLW6KW0YxwolkTWL/umh7A==', 'Z2GBGPRQKHIWCUCF76QHVO4ZXDBGUQZS', 'bb9055d1-b2c8-4bae-a250-d509deb3df69', NULL, b'0', b'0', NULL, b'1', 0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;

-- Dumping structure for table aal.aspnetusertokens
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(450) CHARACTER SET utf8 NOT NULL,
  `LoginProvider` varchar(128) CHARACTER SET utf8 NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8 NOT NULL,
  `Value` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.aspnetusertokens: ~0 rows (approximately)
DELETE FROM `aspnetusertokens`;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;

-- Dumping structure for table aal.e_language_levels
CREATE TABLE IF NOT EXISTS `e_language_levels` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `language_level` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table aal.e_language_levels: ~3 rows (approximately)
DELETE FROM `e_language_levels`;
/*!40000 ALTER TABLE `e_language_levels` DISABLE KEYS */;
INSERT INTO `e_language_levels` (`id`, `language_level`) VALUES
	(1, 'Beginner'),
	(2, 'Intermediate'),
	(3, 'Advanced');
/*!40000 ALTER TABLE `e_language_levels` ENABLE KEYS */;

-- Dumping structure for table aal.e_time_periods
CREATE TABLE IF NOT EXISTS `e_time_periods` (
  `id` varchar(50) NOT NULL,
  `time_period` varchar(50) DEFAULT NULL,
  `title` varchar(50) DEFAULT NULL,
  `sequence` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.e_time_periods: ~8 rows (approximately)
DELETE FROM `e_time_periods`;
/*!40000 ALTER TABLE `e_time_periods` DISABLE KEYS */;
INSERT INTO `e_time_periods` (`id`, `time_period`, `title`, `sequence`) VALUES
	('afternoon', '12-15', 'Afternoon', 2),
	('evening', '18-21', 'Evening', 5),
	('late_afternoon', '15-18', 'Late Afternoon', 4),
	('late_evening', '21-24', 'Late Evening', 6),
	('late_morning', '9-12', 'Late Morning', 1),
	('late_night', '3-6', 'Late Night', 8),
	('morning', '6-9', 'Morning', 0),
	('night', '0-3', 'Night', 7);
/*!40000 ALTER TABLE `e_time_periods` ENABLE KEYS */;

-- Dumping structure for table aal.m_aspnet_user_available_times
CREATE TABLE IF NOT EXISTS `m_aspnet_user_available_times` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `aspnet_user_id` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `weekday` varchar(50) DEFAULT NULL,
  `time_period` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_m_aspnet_user_available_times_AspNetUsers` (`aspnet_user_id`),
  CONSTRAINT `FK_m_aspnet_user_available_times_AspNetUsers` FOREIGN KEY (`aspnet_user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_aspnet_user_available_times: ~2 rows (approximately)
DELETE FROM `m_aspnet_user_available_times`;
/*!40000 ALTER TABLE `m_aspnet_user_available_times` DISABLE KEYS */;
INSERT INTO `m_aspnet_user_available_times` (`id`, `aspnet_user_id`, `weekday`, `time_period`) VALUES
	(5, '07ad2d78-89be-4917-90ab-101de14355ad', 'Sunday', 'late_morning'),
	(6, '07ad2d78-89be-4917-90ab-101de14355ad', 'Sunday', 'evening');
/*!40000 ALTER TABLE `m_aspnet_user_available_times` ENABLE KEYS */;

-- Dumping structure for table aal.m_aspnet_user_languages
CREATE TABLE IF NOT EXISTS `m_aspnet_user_languages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `aspnet_user_id_fk` varchar(450) CHARACTER SET utf8 NOT NULL,
  `language_id_fk` int(11) NOT NULL,
  `language_level_id_fk` int(11) NOT NULL COMMENT 'join the tutor and the languages that he speaks together with the proficiency level',
  PRIMARY KEY (`id`),
  KEY `FK_m_aspnet_user_languages_AspNetUsers` (`aspnet_user_id_fk`),
  KEY `FK_m_aspnet_user_languages_e_language_levels` (`language_id_fk`),
  KEY `FK_m_aspnet_user_languages_m_languages` (`language_level_id_fk`),
  CONSTRAINT `FK_m_aspnet_user_languages_AspNetUsers` FOREIGN KEY (`aspnet_user_id_fk`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_m_aspnet_user_languages_e_language_levels` FOREIGN KEY (`language_level_id_fk`) REFERENCES `e_language_levels` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_m_aspnet_user_languages_m_languages_2` FOREIGN KEY (`language_id_fk`) REFERENCES `m_languages` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_aspnet_user_languages: ~3 rows (approximately)
DELETE FROM `m_aspnet_user_languages`;
/*!40000 ALTER TABLE `m_aspnet_user_languages` DISABLE KEYS */;
INSERT INTO `m_aspnet_user_languages` (`id`, `aspnet_user_id_fk`, `language_id_fk`, `language_level_id_fk`) VALUES
	(37, '07ad2d78-89be-4917-90ab-101de14355ad', 94, 3),
	(38, '07ad2d78-89be-4917-90ab-101de14355ad', 34, 2),
	(39, '07ad2d78-89be-4917-90ab-101de14355ad', 1, 1);
/*!40000 ALTER TABLE `m_aspnet_user_languages` ENABLE KEYS */;

-- Dumping structure for table aal.m_countries
CREATE TABLE IF NOT EXISTS `m_countries` (
  `country_iso` char(2) NOT NULL,
  `country_iso3` char(3) DEFAULT NULL,
  `calling_code` int(11) NOT NULL,
  `country_name` varchar(100) NOT NULL,
  `value` char(2) NOT NULL,
  PRIMARY KEY (`country_iso`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_countries: ~245 rows (approximately)
DELETE FROM `m_countries`;
/*!40000 ALTER TABLE `m_countries` DISABLE KEYS */;
INSERT INTO `m_countries` (`country_iso`, `country_iso3`, `calling_code`, `country_name`, `value`) VALUES
	('AC', 'ACS', 247, 'Ascension Island', 'AC'),
	('AD', 'AND', 376, 'Andorra', 'AD'),
	('AE', 'ARE', 971, 'United Arab Emirates', 'AE'),
	('AF', 'AFG', 93, 'Afghanistan', 'AF'),
	('AG', 'ATG', 1, 'Antigua and Barbuda', 'AG'),
	('AI', 'AIA', 1, 'Anguilla', 'AI'),
	('AL', 'ALB', 355, 'Albania', 'AL'),
	('AM', 'ARM', 374, 'Armenia', 'AM'),
	('AO', 'AGO', 244, 'Angola', 'AO'),
	('AR', 'ARG', 54, 'Argentina', 'AR'),
	('AS', 'ASM', 1, 'American Samoa', 'AS'),
	('AT', 'AUT', 43, 'Austria', 'AT'),
	('AU', 'AUS', 61, 'Australia', 'AU'),
	('AW', 'ABW', 297, 'Aruba', 'AW'),
	('AX', 'ALA', 358, 'Åland Islands', 'AX'),
	('AZ', 'AZE', 994, 'Azerbaijan', 'AZ'),
	('BA', 'BIH', 387, 'Bosnia and Herzegovina', 'BA'),
	('BB', 'BRB', 1, 'Barbados', 'BB'),
	('BD', 'BGD', 880, 'Bangladesh', 'BD'),
	('BE', 'BEL', 32, 'Belgium', 'BE'),
	('BF', 'BFA', 226, 'Burkina Faso', 'BF'),
	('BG', 'BGR', 359, 'Bulgaria', 'BG'),
	('BH', 'BHR', 973, 'Bahrain', 'BH'),
	('BI', 'BDI', 257, 'Burundi', 'BI'),
	('BJ', 'BEN', 229, 'Benin', 'BJ'),
	('BL', 'BLM', 590, 'Saint Barthélemy', 'BL'),
	('BM', 'BMU', 1, 'Bermuda', 'BM'),
	('BN', 'BRN', 673, 'Brunei', 'BN'),
	('BO', 'BOL', 591, 'Bolivia', 'BO'),
	('BQ', 'BES', 599, 'Bonaire, Sint Eustatius and Saba', 'BQ'),
	('BR', 'BRA', 55, 'Brazil', 'BR'),
	('BS', 'BHS', 1, 'Bahamas', 'BS'),
	('BT', 'BTN', 975, 'Bhutan', 'BT'),
	('BW', 'BWA', 267, 'Botswana', 'BW'),
	('BY', 'BLR', 375, 'Belarus', 'BY'),
	('BZ', 'BLZ', 501, 'Belize', 'BZ'),
	('CA', 'CAN', 1, 'Canada', 'CA'),
	('CC', 'CCK', 61, 'Cocos Islands', 'CC'),
	('CD', 'COD', 243, 'The Democratic Republic Of Congo', 'CD'),
	('CF', 'CAF', 236, 'Central African Republic', 'CF'),
	('CG', 'COG', 242, 'Congo', 'CG'),
	('CH', 'CHE', 41, 'Switzerland', 'CH'),
	('CI', 'CIV', 225, 'Côte d\'Ivoire', 'CI'),
	('CK', 'COK', 682, 'Cook Islands', 'CK'),
	('CL', 'CHL', 56, 'Chile', 'CL'),
	('CM', 'CMR', 237, 'Cameroon', 'CM'),
	('CN', 'CHN', 86, 'China', 'CN'),
	('CO', 'COL', 57, 'Colombia', 'CO'),
	('CR', 'CRI', 506, 'Costa Rica', 'CR'),
	('CU', 'CUB', 53, 'Cuba', 'CU'),
	('CV', 'CPV', 238, 'Cape Verde', 'CV'),
	('CW', 'CUW', 599, 'Curaçao', 'CW'),
	('CX', 'CXR', 61, 'Christmas Island', 'CX'),
	('CY', 'CYP', 357, 'Cyprus', 'CY'),
	('CZ', 'CZE', 420, 'Czech Republic', 'CZ'),
	('DE', 'DEU', 49, 'Germany', 'DE'),
	('DJ', 'DJI', 253, 'Djibouti', 'DJ'),
	('DK', 'DNK', 45, 'Denmark', 'DK'),
	('DM', 'DMA', 1, 'Dominica', 'DM'),
	('DO', 'DOM', 1, 'Dominican Republic', 'DO'),
	('DZ', 'DZA', 213, 'Algeria', 'DZ'),
	('EC', 'ECU', 593, 'Ecuador', 'EC'),
	('EE', 'EST', 372, 'Estonia', 'EE'),
	('EG', 'EGY', 20, 'Egypt', 'EG'),
	('EH', 'ESH', 212, 'Western Sahara', 'EH'),
	('ER', 'ERI', 291, 'Eritrea', 'ER'),
	('ES', 'ESP', 34, 'Spain', 'ES'),
	('ET', 'ETH', 251, 'Ethiopia', 'ET'),
	('FI', 'FIN', 358, 'Finland', 'FI'),
	('FJ', 'FJI', 679, 'Fiji', 'FJ'),
	('FK', 'FLK', 500, 'Falkland Islands', 'FK'),
	('FM', 'FSM', 691, 'Micronesia', 'FM'),
	('FO', 'FRO', 298, 'Faroe Islands', 'FO'),
	('FR', 'FRA', 33, 'France', 'FR'),
	('GA', 'GAB', 241, 'Gabon', 'GA'),
	('GB', 'GBR', 44, 'United Kingdom', 'GB'),
	('GD', 'GRD', 1, 'Grenada', 'GD'),
	('GE', 'GEO', 995, 'Georgia', 'GE'),
	('GF', 'GUF', 594, 'French Guiana', 'GF'),
	('GG', 'GGY', 44, 'Guernsey', 'GG'),
	('GH', 'GHA', 233, 'Ghana', 'GH'),
	('GI', 'GIB', 350, 'Gibraltar', 'GI'),
	('GL', 'GRL', 299, 'Greenland', 'GL'),
	('GM', 'GMB', 220, 'Gambia', 'GM'),
	('GN', 'GIN', 224, 'Guinea', 'GN'),
	('GP', 'GLP', 590, 'Guadeloupe', 'GP'),
	('GQ', 'GNQ', 240, 'Equatorial Guinea', 'GQ'),
	('GR', 'GRC', 30, 'Greece', 'GR'),
	('GT', 'GTM', 502, 'Guatemala', 'GT'),
	('GU', 'GUM', 1, 'Guam', 'GU'),
	('GW', 'GNB', 245, 'Guinea-Bissau', 'GW'),
	('GY', 'GUY', 592, 'Guyana', 'GY'),
	('HK', 'HKG', 852, 'Hong Kong', 'HK'),
	('HN', 'HND', 504, 'Honduras', 'HN'),
	('HR', 'HRV', 385, 'Croatia', 'HR'),
	('HT', 'HTI', 509, 'Haiti', 'HT'),
	('HU', 'HUN', 36, 'Hungary', 'HU'),
	('ID', 'IDN', 62, 'Indonesia', 'ID'),
	('IE', 'IRL', 353, 'Ireland', 'IE'),
	('IL', 'ISR', 972, 'Israel', 'IL'),
	('IM', 'IMN', 44, 'Isle Of Man', 'IM'),
	('IN', 'IND', 91, 'India', 'IN'),
	('IO', 'IOT', 246, 'British Indian Ocean Territory', 'IO'),
	('IQ', 'IRQ', 964, 'Iraq', 'IQ'),
	('IR', 'IRN', 98, 'Iran', 'IR'),
	('IS', 'ISL', 354, 'Iceland', 'IS'),
	('IT', 'ITA', 39, 'Italy', 'IT'),
	('JE', 'JEY', 44, 'Jersey', 'JE'),
	('JM', 'JAM', 1, 'Jamaica', 'JM'),
	('JO', 'JOR', 962, 'Jordan', 'JO'),
	('JP', 'JPN', 81, 'Japan', 'JP'),
	('KE', 'KEN', 254, 'Kenya', 'KE'),
	('KG', 'KGZ', 996, 'Kyrgyzstan', 'KG'),
	('KH', 'KHM', 855, 'Cambodia', 'KH'),
	('KI', 'KIR', 686, 'Kiribati', 'KI'),
	('KM', 'COM', 269, 'Comoros', 'KM'),
	('KN', 'KNA', 1, 'Saint Kitts And Nevis', 'KN'),
	('KP', 'PRK', 850, 'North Korea', 'KP'),
	('KR', 'KOR', 82, 'South Korea', 'KR'),
	('KW', 'KWT', 965, 'Kuwait', 'KW'),
	('KY', 'CYM', 1, 'Cayman Islands', 'KY'),
	('KZ', 'KAZ', 7, 'Kazakhstan', 'KZ'),
	('LA', 'LAO', 856, 'Laos', 'LA'),
	('LB', 'LBN', 961, 'Lebanon', 'LB'),
	('LC', 'LCA', 1, 'Saint Lucia', 'LC'),
	('LI', 'LIE', 423, 'Liechtenstein', 'LI'),
	('LK', 'LKA', 94, 'Sri Lanka', 'LK'),
	('LR', 'LBR', 231, 'Liberia', 'LR'),
	('LS', 'LSO', 266, 'Lesotho', 'LS'),
	('LT', 'LTU', 370, 'Lithuania', 'LT'),
	('LU', 'LUX', 352, 'Luxembourg', 'LU'),
	('LV', 'LVA', 371, 'Latvia', 'LV'),
	('LY', 'LBY', 218, 'Libya', 'LY'),
	('MA', 'MAR', 212, 'Morocco', 'MA'),
	('MC', 'MCO', 377, 'Monaco', 'MC'),
	('MD', 'MDA', 373, 'Moldova', 'MD'),
	('ME', 'MNE', 382, 'Montenegro', 'ME'),
	('MF', 'MAF', 590, 'Saint Martin', 'MF'),
	('MG', 'MDG', 261, 'Madagascar', 'MG'),
	('MH', 'MHL', 692, 'Marshall Islands', 'MH'),
	('MK', 'MKD', 389, 'Macedonia', 'MK'),
	('ML', 'MLI', 223, 'Mali', 'ML'),
	('MM', 'MMR', 95, 'Myanmar', 'MM'),
	('MN', 'MNG', 976, 'Mongolia', 'MN'),
	('MO', 'MAC', 853, 'Macao', 'MO'),
	('MP', 'MNP', 1, 'Northern Mariana Islands', 'MP'),
	('MQ', 'MTQ', 596, 'Martinique', 'MQ'),
	('MR', 'MRT', 222, 'Mauritania', 'MR'),
	('MS', 'MSR', 1, 'Montserrat', 'MS'),
	('MT', 'MLT', 356, 'Malta', 'MT'),
	('MU', 'MUS', 230, 'Mauritius', 'MU'),
	('MV', 'MDV', 960, 'Maldives', 'MV'),
	('MW', 'MWI', 265, 'Malawi', 'MW'),
	('MX', 'MEX', 52, 'Mexico', 'MX'),
	('MY', 'MYS', 60, 'Malaysia', 'MY'),
	('MZ', 'MOZ', 258, 'Mozambique', 'MZ'),
	('NA', 'NAM', 264, 'Namibia', 'NA'),
	('NC', 'NCL', 687, 'New Caledonia', 'NC'),
	('NE', 'NER', 227, 'Niger', 'NE'),
	('NF', 'NFK', 672, 'Norfolk Island', 'NF'),
	('NG', 'NGA', 234, 'Nigeria', 'NG'),
	('NI', 'NIC', 505, 'Nicaragua', 'NI'),
	('NL', 'NLD', 31, 'Netherlands', 'NL'),
	('NO', 'NOR', 47, 'Norway', 'NO'),
	('NP', 'NPL', 977, 'Nepal', 'NP'),
	('NR', 'NRU', 674, 'Nauru', 'NR'),
	('NU', 'NIU', 683, 'Niue', 'NU'),
	('NZ', 'NZL', 64, 'New Zealand', 'NZ'),
	('OM', 'OMN', 968, 'Oman', 'OM'),
	('PA', 'PAN', 507, 'Panama', 'PA'),
	('PE', 'PER', 51, 'Peru', 'PE'),
	('PF', 'PYF', 689, 'French Polynesia', 'PF'),
	('PG', 'PNG', 675, 'Papua New Guinea', 'PG'),
	('PH', 'PHL', 63, 'Philippines', 'PH'),
	('PK', 'PAK', 92, 'Pakistan', 'PK'),
	('PL', 'POL', 48, 'Poland', 'PL'),
	('PM', 'SPM', 508, 'Saint Pierre And Miquelon', 'PM'),
	('PR', 'PRI', 1, 'Puerto Rico', 'PR'),
	('PS', 'PSE', 970, 'Palestine', 'PS'),
	('PT', 'PRT', 351, 'Portugal', 'PT'),
	('PW', 'PLW', 680, 'Palau', 'PW'),
	('PY', 'PRY', 595, 'Paraguay', 'PY'),
	('QA', 'QAT', 974, 'Qatar', 'QA'),
	('RE', 'REU', 262, 'Reunion', 'RE'),
	('RO', 'ROU', 40, 'Romania', 'RO'),
	('RS', 'SRB', 381, 'Serbia', 'RS'),
	('RU', 'RUS', 7, 'Russia', 'RU'),
	('RW', 'RWA', 250, 'Rwanda', 'RW'),
	('SA', 'SAU', 966, 'Saudi Arabia', 'SA'),
	('SB', 'SLB', 677, 'Solomon Islands', 'SB'),
	('SC', 'SYC', 248, 'Seychelles', 'SC'),
	('SD', 'SDN', 249, 'Sudan', 'SD'),
	('SE', 'SWE', 46, 'Sweden', 'SE'),
	('SG', 'SGP', 65, 'Singapore', 'SG'),
	('SH', 'SHN', 290, 'Saint Helena', 'SH'),
	('SI', 'SVN', 386, 'Slovenia', 'SI'),
	('SJ', 'SJM', 47, 'Svalbard And Jan Mayen', 'SJ'),
	('SK', 'SVK', 421, 'Slovakia', 'SK'),
	('SL', 'SLE', 232, 'Sierra Leone', 'SL'),
	('SM', 'SMR', 378, 'San Marino', 'SM'),
	('SN', 'SEN', 221, 'Senegal', 'SN'),
	('SO', 'SOM', 252, 'Somalia', 'SO'),
	('SR', 'SUR', 597, 'Suriname', 'SR'),
	('SS', 'SSD', 211, 'South Sudan', 'SS'),
	('ST', 'STP', 239, 'Sao Tome And Principe', 'ST'),
	('SV', 'SLV', 503, 'El Salvador', 'SV'),
	('SX', 'SXM', 1, 'Sint Maarten (Dutch part)', 'SX'),
	('SY', 'SYR', 963, 'Syria', 'SY'),
	('SZ', 'SWZ', 268, 'Swaziland', 'SZ'),
	('TA', '', 290, 'Tristan da Cunha', 'TA'),
	('TC', 'TCA', 1, 'Turks And Caicos Islands', 'TC'),
	('TD', 'TCD', 235, 'Chad', 'TD'),
	('TG', 'TGO', 228, 'Togo', 'TG'),
	('TH', 'THA', 66, 'Thailand', 'TH'),
	('TJ', 'TJK', 992, 'Tajikistan', 'TJ'),
	('TK', 'TKL', 690, 'Tokelau', 'TK'),
	('TL', 'TLS', 670, 'Timor-Leste', 'TL'),
	('TM', 'TKM', 993, 'Turkmenistan', 'TM'),
	('TN', 'TUN', 216, 'Tunisia', 'TN'),
	('TO', 'TON', 676, 'Tonga', 'TO'),
	('TR', 'TUR', 90, 'Turkey', 'TR'),
	('TT', 'TTO', 1, 'Trinidad and Tobago', 'TT'),
	('TV', 'TUV', 688, 'Tuvalu', 'TV'),
	('TW', 'TWN', 886, 'Taiwan', 'TW'),
	('TZ', 'TZA', 255, 'Tanzania', 'TZ'),
	('UA', 'UKR', 380, 'Ukraine', 'UA'),
	('UG', 'UGA', 256, 'Uganda', 'UG'),
	('US', 'USA', 1, 'United States', 'US'),
	('UY', 'URY', 598, 'Uruguay', 'UY'),
	('UZ', 'UZB', 998, 'Uzbekistan', 'UZ'),
	('VA', 'VAT', 39, 'Vatican', 'VA'),
	('VC', 'VCT', 1, 'Saint Vincent And The Grenadines', 'VC'),
	('VE', 'VEN', 58, 'Venezuela', 'VE'),
	('VG', 'VGB', 1, 'British Virgin Islands', 'VG'),
	('VI', 'VIR', 1, 'U.S. Virgin Islands', 'VI'),
	('VN', 'VNM', 84, 'Vietnam', 'VN'),
	('VU', 'VUT', 678, 'Vanuatu', 'VU'),
	('WF', 'WLF', 681, 'Wallis And Futuna', 'WF'),
	('WS', 'WSM', 685, 'Samoa', 'WS'),
	('XK', 'KOS', 383, 'Kosovo', 'XK'),
	('YE', 'YEM', 967, 'Yemen', 'YE'),
	('YT', 'MYT', 262, 'Mayotte', 'YT'),
	('ZA', 'ZAF', 27, 'South Africa', 'ZA'),
	('ZM', 'ZMB', 260, 'Zambia', 'ZM'),
	('ZW', 'ZWE', 263, 'Zimbabwe', 'ZW');
/*!40000 ALTER TABLE `m_countries` ENABLE KEYS */;

-- Dumping structure for table aal.m_languages
CREATE TABLE IF NOT EXISTS `m_languages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `language_name` char(50) NOT NULL,
  `iso` char(2) DEFAULT NULL,
  `value` char(2) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=136 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- Dumping data for table aal.m_languages: ~135 rows (approximately)
DELETE FROM `m_languages`;
/*!40000 ALTER TABLE `m_languages` DISABLE KEYS */;
INSERT INTO `m_languages` (`id`, `language_name`, `iso`, `value`) VALUES
	(1, 'English', 'en', 'en'),
	(2, 'Afar', 'aa', 'aa'),
	(3, 'Abkhazian', 'ab', 'ab'),
	(4, 'Afrikaans', 'af', 'af'),
	(5, 'Amharic', 'am', 'am'),
	(6, 'Arabic', 'ar', 'ar'),
	(7, 'Assamese', 'as', 'as'),
	(8, 'Aymara', 'ay', 'ay'),
	(9, 'Azerbaijani', 'az', 'az'),
	(10, 'Bashkir', 'ba', 'ba'),
	(11, 'Belarusian', 'be', 'be'),
	(12, 'Bulgarian', 'bg', 'bg'),
	(13, 'Bihari', 'bh', 'bh'),
	(14, 'Bislama', 'bi', 'bi'),
	(15, 'Bengali/Bangla', 'bn', 'bn'),
	(16, 'Tibetan', 'bo', 'bo'),
	(17, 'Breton', 'br', 'br'),
	(18, 'Catalan', 'ca', 'ca'),
	(19, 'Corsican', 'co', 'co'),
	(20, 'Czech', 'cs', 'cs'),
	(21, 'Welsh', 'cy', 'cy'),
	(22, 'Danish', 'da', 'da'),
	(23, 'German', 'de', 'de'),
	(24, 'Bhutani', 'dz', 'dz'),
	(25, 'Greek', 'el', 'el'),
	(26, 'Esperanto', 'eo', 'eo'),
	(27, 'Spanish', 'es', 'es'),
	(28, 'Estonian', 'et', 'et'),
	(29, 'Basque', 'eu', 'eu'),
	(30, 'Persian', 'fa', 'fa'),
	(31, 'Finnish', 'fi', 'fi'),
	(32, 'Fiji', 'fj', 'fj'),
	(33, 'Faeroese', 'fo', 'fo'),
	(34, 'French', 'fr', 'fr'),
	(35, 'Frisian', 'fy', 'fy'),
	(36, 'Irish', 'ga', 'ga'),
	(37, 'Scots/Gaelic', 'gd', 'gd'),
	(38, 'Galician', 'gl', 'gl'),
	(39, 'Guarani', 'gn', 'gn'),
	(40, 'Gujarati', 'gu', 'gu'),
	(41, 'Hausa', 'ha', 'ha'),
	(42, 'Hindi', 'hi', 'hi'),
	(43, 'Croatian', 'hr', 'hr'),
	(44, 'Hungarian', 'hu', 'hu'),
	(45, 'Armenian', 'hy', 'hy'),
	(46, 'Interlingua', 'ia', 'ia'),
	(47, 'Interlingue', 'ie', 'ie'),
	(48, 'Inupiak', 'ik', 'ik'),
	(49, 'Indonesian', 'in', 'in'),
	(50, 'Icelandic', 'is', 'is'),
	(51, 'Italian', 'it', 'it'),
	(52, 'Hebrew', 'iw', 'iw'),
	(53, 'Japanese', 'ja', 'ja'),
	(54, 'Yiddish', 'ji', 'ji'),
	(55, 'Javanese', 'jw', 'jw'),
	(56, 'Georgian', 'ka', 'ka'),
	(57, 'Kazakh', 'kk', 'kk'),
	(58, 'Greenlandic', 'kl', 'kl'),
	(59, 'Cambodian', 'km', 'km'),
	(60, 'Kannada', 'kn', 'kn'),
	(61, 'Korean', 'ko', 'ko'),
	(62, 'Kashmiri', 'ks', 'ks'),
	(63, 'Kurdish', 'ku', 'ku'),
	(64, 'Kirghiz', 'ky', 'ky'),
	(65, 'Latin', 'la', 'la'),
	(66, 'Lingala', 'ln', 'ln'),
	(67, 'Laothian', 'lo', 'lo'),
	(68, 'Lithuanian', 'lt', 'lt'),
	(69, 'Latvian/Lettish', 'lv', 'lv'),
	(70, 'Malagasy', 'mg', 'mg'),
	(71, 'Maori', 'mi', 'mi'),
	(72, 'Macedonian', 'mk', 'mk'),
	(73, 'Malayalam', 'ml', 'ml'),
	(74, 'Mongolian', 'mn', 'mn'),
	(75, 'Moldavian', 'mo', 'mo'),
	(76, 'Marathi', 'mr', 'mr'),
	(77, 'Malay', 'ms', 'ms'),
	(78, 'Maltese', 'mt', 'mt'),
	(79, 'Burmese', 'my', 'my'),
	(80, 'Nauru', 'na', 'na'),
	(81, 'Nepali', 'ne', 'ne'),
	(82, 'Dutch', 'nl', 'nl'),
	(83, 'Norwegian', 'no', 'no'),
	(84, 'Occitan', 'oc', 'oc'),
	(85, '(Afan)/Oromoor/Oriya', 'om', 'om'),
	(86, 'Punjabi', 'pa', 'pa'),
	(87, 'Polish', 'pl', 'pl'),
	(88, 'Pashto/Pushto', 'ps', 'ps'),
	(89, 'Portuguese', 'pt', 'pt'),
	(90, 'Quechua', 'qu', 'qu'),
	(91, 'Rhaeto-Romance', 'rm', 'rm'),
	(92, 'Kirundi', 'rn', 'rn'),
	(93, 'Romanian', 'ro', 'ro'),
	(94, 'Russian', 'ru', 'ru'),
	(95, 'Kinyarwanda', 'rw', 'rw'),
	(96, 'Sanskrit', 'sa', 'sa'),
	(97, 'Sindhi', 'sd', 'sd'),
	(98, 'Sangro', 'sg', 'sg'),
	(99, 'Serbo-Croatian', 'sh', 'sh'),
	(100, 'Singhalese', 'si', 'si'),
	(101, 'Slovak', 'sk', 'sk'),
	(102, 'Slovenian', 'sl', 'sl'),
	(103, 'Samoan', 'sm', 'sm'),
	(104, 'Shona', 'sn', 'sn'),
	(105, 'Somali', 'so', 'so'),
	(106, 'Albanian', 'sq', 'sq'),
	(107, 'Serbian', 'sr', 'sr'),
	(108, 'Siswati', 'ss', 'ss'),
	(109, 'Sesotho', 'st', 'st'),
	(110, 'Sundanese', 'su', 'su'),
	(111, 'Swedish', 'sv', 'sv'),
	(112, 'Swahili', 'sw', 'sw'),
	(113, 'Tamil', 'ta', 'ta'),
	(114, 'Telugu', 'te', 'te'),
	(115, 'Tajik', 'tg', 'tg'),
	(116, 'Thai', 'th', 'th'),
	(117, 'Tigrinya', 'ti', 'ti'),
	(118, 'Turkmen', 'tk', 'tk'),
	(119, 'Tagalog', 'tl', 'tl'),
	(120, 'Setswana', 'tn', 'tn'),
	(121, 'Tonga', 'to', 'to'),
	(122, 'Turkish', 'tr', 'tr'),
	(123, 'Tsonga', 'ts', 'ts'),
	(124, 'Tatar', 'tt', 'tt'),
	(125, 'Twi', 'tw', 'tw'),
	(126, 'Ukrainian', 'uk', 'uk'),
	(127, 'Urdu', 'ur', 'ur'),
	(128, 'Uzbek', 'uz', 'uz'),
	(129, 'Vietnamese', 'vi', 'vi'),
	(130, 'Volapuk', 'vo', 'vo'),
	(131, 'Wolof', 'wo', 'wo'),
	(132, 'Xhosa', 'xh', 'xh'),
	(133, 'Yoruba', 'yo', 'yo'),
	(134, 'Chinese', 'zh', 'zh'),
	(135, 'Zulu', 'zu', 'zu');
/*!40000 ALTER TABLE `m_languages` ENABLE KEYS */;

-- Dumping structure for table aal.m_moodle_user
CREATE TABLE IF NOT EXISTS `m_moodle_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `aspnet_user_id` varchar(450) CHARACTER SET utf8 NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `surname` varchar(50) NOT NULL,
  `moodle_id` int(11) DEFAULT NULL,
  `password` longtext,
  `email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_m_moodle_user_aspnetusers` (`aspnet_user_id`),
  CONSTRAINT `FK_m_moodle_user_aspnetusers` FOREIGN KEY (`aspnet_user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_moodle_user: ~4 rows (approximately)
DELETE FROM `m_moodle_user`;
/*!40000 ALTER TABLE `m_moodle_user` DISABLE KEYS */;
INSERT INTO `m_moodle_user` (`id`, `aspnet_user_id`, `firstname`, `surname`, `moodle_id`, `password`, `email`) VALUES
	(6, '48bdd129-3f4f-4f7a-a270-ace918105092', 'kudzai', 'zishumba', 10, 'Password@123', 'kzish@gmail.com'),
	(8, '07ad2d78-89be-4917-90ab-101de14355ad', 'kudzai', 'zishumba', 12, 'Password@123', 'kzish@gmail.com'),
	(9, '7ed9ab9a-cd12-4753-8a7a-00caf127a6ac', 'tino', 'nyamukondiwa', 13, 'Password@123', 'tino@gmail.com'),
	(10, '1de25b58-9d4d-4d0b-a87b-40ae43fc14bd', 'tapiwa', 'nyams', 14, 'Password@123', 'taps@gmail.com'),
	(11, '06e8e670-f82a-4ee3-a83d-d48164ae87ef', 'asher', 'nyamzi', 15, 'Password@123', 'asher@gmail.com');
/*!40000 ALTER TABLE `m_moodle_user` ENABLE KEYS */;

-- Dumping structure for table aal.m_tutor
CREATE TABLE IF NOT EXISTS `m_tutor` (
  `aspnet_user_id` varchar(450) CHARACTER SET utf8 NOT NULL,
  `firstname` varchar(50) DEFAULT NULL,
  `surname` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `image_url` longtext,
  `coutry_iso` varchar(5) DEFAULT NULL,
  `about` longtext,
  `active` tinyint(4) NOT NULL,
  PRIMARY KEY (`aspnet_user_id`),
  CONSTRAINT `FK_m_tutor_aspnetusers` FOREIGN KEY (`aspnet_user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_tutor: ~4 rows (approximately)
DELETE FROM `m_tutor`;
/*!40000 ALTER TABLE `m_tutor` DISABLE KEYS */;
INSERT INTO `m_tutor` (`aspnet_user_id`, `firstname`, `surname`, `email`, `image_url`, `coutry_iso`, `about`, `active`) VALUES
	('06e8e670-f82a-4ee3-a83d-d48164ae87ef', 'asher', 'nyamzi', 'asher@gmail.com', NULL, NULL, NULL, 1),
	('07ad2d78-89be-4917-90ab-101de14355ad', 'kudzai', 'zishumba', 'kzish@gmail.com', 'ae03a87f-3892-4ec7-95a5-bb10e9c90746..png', 'ZW', 'this is my about people', 1),
	('1de25b58-9d4d-4d0b-a87b-40ae43fc14bd', 'tapiwa', 'nyams', 'taps@gmail.com', NULL, NULL, NULL, 1),
	('48bdd129-3f4f-4f7a-a270-ace918105092', 'kudzai', 'zishumba', 'kzish@gmail.com', NULL, NULL, NULL, 0),
	('7ed9ab9a-cd12-4753-8a7a-00caf127a6ac', 'tino', 'nyamukondiwa', 'tino@gmail.com', NULL, NULL, NULL, 1);
/*!40000 ALTER TABLE `m_tutor` ENABLE KEYS */;

-- Dumping structure for table aal.m_tutor_courses
CREATE TABLE IF NOT EXISTS `m_tutor_courses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `aspnet_user_id` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  `title` varchar(150) DEFAULT NULL,
  `description` longtext,
  `duration` varchar(50) DEFAULT NULL,
  `moodle_course_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_m_tutor_courses_aspnetusers` (`aspnet_user_id`),
  CONSTRAINT `FK_m_tutor_courses_aspnetusers` FOREIGN KEY (`aspnet_user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_tutor_courses: ~0 rows (approximately)
DELETE FROM `m_tutor_courses`;
/*!40000 ALTER TABLE `m_tutor_courses` DISABLE KEYS */;
INSERT INTO `m_tutor_courses` (`id`, `aspnet_user_id`, `title`, `description`, `duration`, `moodle_course_id`) VALUES
	(1, '07ad2d78-89be-4917-90ab-101de14355ad', 'test course edited - kzish@gmail.com', 'description of this course', '13 weeks', 2);
/*!40000 ALTER TABLE `m_tutor_courses` ENABLE KEYS */;

-- Dumping structure for table aal.m_tutor_education
CREATE TABLE IF NOT EXISTS `m_tutor_education` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `aspnet_user_id` varchar(450) CHARACTER SET utf8 NOT NULL,
  `date_from` datetime(3) DEFAULT NULL,
  `date_to` datetime(3) DEFAULT NULL,
  `insitute_or_university` varchar(150) DEFAULT NULL,
  `diploma_or_degree` varchar(150) DEFAULT NULL,
  `verified` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_m_tutor_education_aspnetusers` (`aspnet_user_id`),
  CONSTRAINT `FK_m_tutor_education_aspnetusers` FOREIGN KEY (`aspnet_user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_tutor_education: ~0 rows (approximately)
DELETE FROM `m_tutor_education`;
/*!40000 ALTER TABLE `m_tutor_education` DISABLE KEYS */;
/*!40000 ALTER TABLE `m_tutor_education` ENABLE KEYS */;

-- Dumping structure for table aal.m_tutor_languages
CREATE TABLE IF NOT EXISTS `m_tutor_languages` (
  `id` int(11) NOT NULL,
  `aspnet_user_id` varchar(450) CHARACTER SET utf8 NOT NULL,
  `language_id` int(11) NOT NULL,
  `language_level_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_m_tutor_languages_aspnetusers` (`aspnet_user_id`),
  KEY `FK_m_tutor_languages_m_languages` (`language_id`),
  KEY `FK_m_tutor_languages_e_language_levels` (`language_level_id`),
  CONSTRAINT `FK_m_tutor_languages_aspnetusers` FOREIGN KEY (`aspnet_user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_m_tutor_languages_e_language_levels` FOREIGN KEY (`language_level_id`) REFERENCES `e_language_levels` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_m_tutor_languages_m_languages` FOREIGN KEY (`language_id`) REFERENCES `m_languages` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_tutor_languages: ~0 rows (approximately)
DELETE FROM `m_tutor_languages`;
/*!40000 ALTER TABLE `m_tutor_languages` DISABLE KEYS */;
/*!40000 ALTER TABLE `m_tutor_languages` ENABLE KEYS */;

-- Dumping structure for table aal.m_tutor_rating
CREATE TABLE IF NOT EXISTS `m_tutor_rating` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tutor_aspnet_id_fk` varchar(450) CHARACTER SET utf8 NOT NULL,
  `five_star_rating` int(11) DEFAULT NULL,
  `four_star_rating` int(11) DEFAULT NULL,
  `three_star_rating` int(11) DEFAULT NULL,
  `two_star_rating` int(11) DEFAULT NULL,
  `one_star_rating` int(11) DEFAULT NULL,
  `rators_id_nfk` varchar(450) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_m_tutor_rating_aspnetusers` (`tutor_aspnet_id_fk`),
  CONSTRAINT `FK_m_tutor_rating_aspnetusers` FOREIGN KEY (`tutor_aspnet_id_fk`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_tutor_rating: ~0 rows (approximately)
DELETE FROM `m_tutor_rating`;
/*!40000 ALTER TABLE `m_tutor_rating` DISABLE KEYS */;
/*!40000 ALTER TABLE `m_tutor_rating` ENABLE KEYS */;

-- Dumping structure for table aal.m_tutor_work_experience
CREATE TABLE IF NOT EXISTS `m_tutor_work_experience` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `aspnet_user_id` varchar(450) CHARACTER SET utf8 NOT NULL,
  `date_from` datetime(3) DEFAULT NULL,
  `date_to` datetime(3) DEFAULT NULL,
  `organization` varchar(150) DEFAULT NULL,
  `roles` longtext,
  PRIMARY KEY (`id`),
  KEY `FK_m_tutor_work_experience_aspnetusers` (`aspnet_user_id`),
  CONSTRAINT `FK_m_tutor_work_experience_aspnetusers` FOREIGN KEY (`aspnet_user_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_tutor_work_experience: ~0 rows (approximately)
DELETE FROM `m_tutor_work_experience`;
/*!40000 ALTER TABLE `m_tutor_work_experience` DISABLE KEYS */;
/*!40000 ALTER TABLE `m_tutor_work_experience` ENABLE KEYS */;

-- Dumping structure for table aal.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table aal.__efmigrationshistory: ~0 rows (approximately)
DELETE FROM `__efmigrationshistory`;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20211224084822_CreateIdentitySchema', '5.0.13');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
