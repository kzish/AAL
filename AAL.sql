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

-- Dumping data for table aal.aspnetuserroles: ~1 rows (approximately)
DELETE FROM `aspnetuserroles`;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
	('3d06ddd9-db24-4964-9558-118f6aefa8e9', '9ab2c05a-be24-40ae-9d65-51637eb08e9f');
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

-- Dumping data for table aal.aspnetusers: ~1 rows (approximately)
DELETE FROM `aspnetusers`;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
	('3d06ddd9-db24-4964-9558-118f6aefa8e9', 'admin@rubiem.com', 'ADMIN@RUBIEM.COM', 'admin@rubiem.com', 'ADMIN@RUBIEM.COM', b'0', 'AQAAAAEAACcQAAAAEIRwBO2ED2KVo8JkNnjZiTCjdz82imkUU1XCdBK8mrELChRn3nUkCy8odlnswX9hRQ==', '2P47NVOAU5L4GHAREB2LJ2EOBMCUSIVG', '4637232d-748a-46b7-ab0a-ba869e12cdb8', NULL, b'0', b'0', NULL, b'1', 0);
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_aspnet_user_available_times: ~0 rows (approximately)
DELETE FROM `m_aspnet_user_available_times`;
/*!40000 ALTER TABLE `m_aspnet_user_available_times` DISABLE KEYS */;
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
  CONSTRAINT `FK_m_aspnet_user_languages_e_language_levels` FOREIGN KEY (`language_id_fk`) REFERENCES `e_language_levels` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_m_aspnet_user_languages_m_languages` FOREIGN KEY (`language_level_id_fk`) REFERENCES `m_languages` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_aspnet_user_languages: ~0 rows (approximately)
DELETE FROM `m_aspnet_user_languages`;
/*!40000 ALTER TABLE `m_aspnet_user_languages` DISABLE KEYS */;
/*!40000 ALTER TABLE `m_aspnet_user_languages` ENABLE KEYS */;

-- Dumping structure for table aal.m_countries
CREATE TABLE IF NOT EXISTS `m_countries` (
  `country_iso` char(2) NOT NULL,
  `country_iso3` char(3) DEFAULT NULL,
  `calling_code` int(11) NOT NULL,
  `country_name` varchar(100) NOT NULL,
  PRIMARY KEY (`country_iso`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_countries: ~245 rows (approximately)
DELETE FROM `m_countries`;
/*!40000 ALTER TABLE `m_countries` DISABLE KEYS */;
INSERT INTO `m_countries` (`country_iso`, `country_iso3`, `calling_code`, `country_name`) VALUES
	('AC', 'ACS', 247, 'Ascension Island'),
	('AD', 'AND', 376, 'Andorra'),
	('AE', 'ARE', 971, 'United Arab Emirates'),
	('AF', 'AFG', 93, 'Afghanistan'),
	('AG', 'ATG', 1, 'Antigua and Barbuda'),
	('AI', 'AIA', 1, 'Anguilla'),
	('AL', 'ALB', 355, 'Albania'),
	('AM', 'ARM', 374, 'Armenia'),
	('AO', 'AGO', 244, 'Angola'),
	('AR', 'ARG', 54, 'Argentina'),
	('AS', 'ASM', 1, 'American Samoa'),
	('AT', 'AUT', 43, 'Austria'),
	('AU', 'AUS', 61, 'Australia'),
	('AW', 'ABW', 297, 'Aruba'),
	('AX', 'ALA', 358, 'Åland Islands'),
	('AZ', 'AZE', 994, 'Azerbaijan'),
	('BA', 'BIH', 387, 'Bosnia and Herzegovina'),
	('BB', 'BRB', 1, 'Barbados'),
	('BD', 'BGD', 880, 'Bangladesh'),
	('BE', 'BEL', 32, 'Belgium'),
	('BF', 'BFA', 226, 'Burkina Faso'),
	('BG', 'BGR', 359, 'Bulgaria'),
	('BH', 'BHR', 973, 'Bahrain'),
	('BI', 'BDI', 257, 'Burundi'),
	('BJ', 'BEN', 229, 'Benin'),
	('BL', 'BLM', 590, 'Saint Barthélemy'),
	('BM', 'BMU', 1, 'Bermuda'),
	('BN', 'BRN', 673, 'Brunei'),
	('BO', 'BOL', 591, 'Bolivia'),
	('BQ', 'BES', 599, 'Bonaire, Sint Eustatius and Saba'),
	('BR', 'BRA', 55, 'Brazil'),
	('BS', 'BHS', 1, 'Bahamas'),
	('BT', 'BTN', 975, 'Bhutan'),
	('BW', 'BWA', 267, 'Botswana'),
	('BY', 'BLR', 375, 'Belarus'),
	('BZ', 'BLZ', 501, 'Belize'),
	('CA', 'CAN', 1, 'Canada'),
	('CC', 'CCK', 61, 'Cocos Islands'),
	('CD', 'COD', 243, 'The Democratic Republic Of Congo'),
	('CF', 'CAF', 236, 'Central African Republic'),
	('CG', 'COG', 242, 'Congo'),
	('CH', 'CHE', 41, 'Switzerland'),
	('CI', 'CIV', 225, 'Côte d\'Ivoire'),
	('CK', 'COK', 682, 'Cook Islands'),
	('CL', 'CHL', 56, 'Chile'),
	('CM', 'CMR', 237, 'Cameroon'),
	('CN', 'CHN', 86, 'China'),
	('CO', 'COL', 57, 'Colombia'),
	('CR', 'CRI', 506, 'Costa Rica'),
	('CU', 'CUB', 53, 'Cuba'),
	('CV', 'CPV', 238, 'Cape Verde'),
	('CW', 'CUW', 599, 'Curaçao'),
	('CX', 'CXR', 61, 'Christmas Island'),
	('CY', 'CYP', 357, 'Cyprus'),
	('CZ', 'CZE', 420, 'Czech Republic'),
	('DE', 'DEU', 49, 'Germany'),
	('DJ', 'DJI', 253, 'Djibouti'),
	('DK', 'DNK', 45, 'Denmark'),
	('DM', 'DMA', 1, 'Dominica'),
	('DO', 'DOM', 1, 'Dominican Republic'),
	('DZ', 'DZA', 213, 'Algeria'),
	('EC', 'ECU', 593, 'Ecuador'),
	('EE', 'EST', 372, 'Estonia'),
	('EG', 'EGY', 20, 'Egypt'),
	('EH', 'ESH', 212, 'Western Sahara'),
	('ER', 'ERI', 291, 'Eritrea'),
	('ES', 'ESP', 34, 'Spain'),
	('ET', 'ETH', 251, 'Ethiopia'),
	('FI', 'FIN', 358, 'Finland'),
	('FJ', 'FJI', 679, 'Fiji'),
	('FK', 'FLK', 500, 'Falkland Islands'),
	('FM', 'FSM', 691, 'Micronesia'),
	('FO', 'FRO', 298, 'Faroe Islands'),
	('FR', 'FRA', 33, 'France'),
	('GA', 'GAB', 241, 'Gabon'),
	('GB', 'GBR', 44, 'United Kingdom'),
	('GD', 'GRD', 1, 'Grenada'),
	('GE', 'GEO', 995, 'Georgia'),
	('GF', 'GUF', 594, 'French Guiana'),
	('GG', 'GGY', 44, 'Guernsey'),
	('GH', 'GHA', 233, 'Ghana'),
	('GI', 'GIB', 350, 'Gibraltar'),
	('GL', 'GRL', 299, 'Greenland'),
	('GM', 'GMB', 220, 'Gambia'),
	('GN', 'GIN', 224, 'Guinea'),
	('GP', 'GLP', 590, 'Guadeloupe'),
	('GQ', 'GNQ', 240, 'Equatorial Guinea'),
	('GR', 'GRC', 30, 'Greece'),
	('GT', 'GTM', 502, 'Guatemala'),
	('GU', 'GUM', 1, 'Guam'),
	('GW', 'GNB', 245, 'Guinea-Bissau'),
	('GY', 'GUY', 592, 'Guyana'),
	('HK', 'HKG', 852, 'Hong Kong'),
	('HN', 'HND', 504, 'Honduras'),
	('HR', 'HRV', 385, 'Croatia'),
	('HT', 'HTI', 509, 'Haiti'),
	('HU', 'HUN', 36, 'Hungary'),
	('ID', 'IDN', 62, 'Indonesia'),
	('IE', 'IRL', 353, 'Ireland'),
	('IL', 'ISR', 972, 'Israel'),
	('IM', 'IMN', 44, 'Isle Of Man'),
	('IN', 'IND', 91, 'India'),
	('IO', 'IOT', 246, 'British Indian Ocean Territory'),
	('IQ', 'IRQ', 964, 'Iraq'),
	('IR', 'IRN', 98, 'Iran'),
	('IS', 'ISL', 354, 'Iceland'),
	('IT', 'ITA', 39, 'Italy'),
	('JE', 'JEY', 44, 'Jersey'),
	('JM', 'JAM', 1, 'Jamaica'),
	('JO', 'JOR', 962, 'Jordan'),
	('JP', 'JPN', 81, 'Japan'),
	('KE', 'KEN', 254, 'Kenya'),
	('KG', 'KGZ', 996, 'Kyrgyzstan'),
	('KH', 'KHM', 855, 'Cambodia'),
	('KI', 'KIR', 686, 'Kiribati'),
	('KM', 'COM', 269, 'Comoros'),
	('KN', 'KNA', 1, 'Saint Kitts And Nevis'),
	('KP', 'PRK', 850, 'North Korea'),
	('KR', 'KOR', 82, 'South Korea'),
	('KW', 'KWT', 965, 'Kuwait'),
	('KY', 'CYM', 1, 'Cayman Islands'),
	('KZ', 'KAZ', 7, 'Kazakhstan'),
	('LA', 'LAO', 856, 'Laos'),
	('LB', 'LBN', 961, 'Lebanon'),
	('LC', 'LCA', 1, 'Saint Lucia'),
	('LI', 'LIE', 423, 'Liechtenstein'),
	('LK', 'LKA', 94, 'Sri Lanka'),
	('LR', 'LBR', 231, 'Liberia'),
	('LS', 'LSO', 266, 'Lesotho'),
	('LT', 'LTU', 370, 'Lithuania'),
	('LU', 'LUX', 352, 'Luxembourg'),
	('LV', 'LVA', 371, 'Latvia'),
	('LY', 'LBY', 218, 'Libya'),
	('MA', 'MAR', 212, 'Morocco'),
	('MC', 'MCO', 377, 'Monaco'),
	('MD', 'MDA', 373, 'Moldova'),
	('ME', 'MNE', 382, 'Montenegro'),
	('MF', 'MAF', 590, 'Saint Martin'),
	('MG', 'MDG', 261, 'Madagascar'),
	('MH', 'MHL', 692, 'Marshall Islands'),
	('MK', 'MKD', 389, 'Macedonia'),
	('ML', 'MLI', 223, 'Mali'),
	('MM', 'MMR', 95, 'Myanmar'),
	('MN', 'MNG', 976, 'Mongolia'),
	('MO', 'MAC', 853, 'Macao'),
	('MP', 'MNP', 1, 'Northern Mariana Islands'),
	('MQ', 'MTQ', 596, 'Martinique'),
	('MR', 'MRT', 222, 'Mauritania'),
	('MS', 'MSR', 1, 'Montserrat'),
	('MT', 'MLT', 356, 'Malta'),
	('MU', 'MUS', 230, 'Mauritius'),
	('MV', 'MDV', 960, 'Maldives'),
	('MW', 'MWI', 265, 'Malawi'),
	('MX', 'MEX', 52, 'Mexico'),
	('MY', 'MYS', 60, 'Malaysia'),
	('MZ', 'MOZ', 258, 'Mozambique'),
	('NA', 'NAM', 264, 'Namibia'),
	('NC', 'NCL', 687, 'New Caledonia'),
	('NE', 'NER', 227, 'Niger'),
	('NF', 'NFK', 672, 'Norfolk Island'),
	('NG', 'NGA', 234, 'Nigeria'),
	('NI', 'NIC', 505, 'Nicaragua'),
	('NL', 'NLD', 31, 'Netherlands'),
	('NO', 'NOR', 47, 'Norway'),
	('NP', 'NPL', 977, 'Nepal'),
	('NR', 'NRU', 674, 'Nauru'),
	('NU', 'NIU', 683, 'Niue'),
	('NZ', 'NZL', 64, 'New Zealand'),
	('OM', 'OMN', 968, 'Oman'),
	('PA', 'PAN', 507, 'Panama'),
	('PE', 'PER', 51, 'Peru'),
	('PF', 'PYF', 689, 'French Polynesia'),
	('PG', 'PNG', 675, 'Papua New Guinea'),
	('PH', 'PHL', 63, 'Philippines'),
	('PK', 'PAK', 92, 'Pakistan'),
	('PL', 'POL', 48, 'Poland'),
	('PM', 'SPM', 508, 'Saint Pierre And Miquelon'),
	('PR', 'PRI', 1, 'Puerto Rico'),
	('PS', 'PSE', 970, 'Palestine'),
	('PT', 'PRT', 351, 'Portugal'),
	('PW', 'PLW', 680, 'Palau'),
	('PY', 'PRY', 595, 'Paraguay'),
	('QA', 'QAT', 974, 'Qatar'),
	('RE', 'REU', 262, 'Reunion'),
	('RO', 'ROU', 40, 'Romania'),
	('RS', 'SRB', 381, 'Serbia'),
	('RU', 'RUS', 7, 'Russia'),
	('RW', 'RWA', 250, 'Rwanda'),
	('SA', 'SAU', 966, 'Saudi Arabia'),
	('SB', 'SLB', 677, 'Solomon Islands'),
	('SC', 'SYC', 248, 'Seychelles'),
	('SD', 'SDN', 249, 'Sudan'),
	('SE', 'SWE', 46, 'Sweden'),
	('SG', 'SGP', 65, 'Singapore'),
	('SH', 'SHN', 290, 'Saint Helena'),
	('SI', 'SVN', 386, 'Slovenia'),
	('SJ', 'SJM', 47, 'Svalbard And Jan Mayen'),
	('SK', 'SVK', 421, 'Slovakia'),
	('SL', 'SLE', 232, 'Sierra Leone'),
	('SM', 'SMR', 378, 'San Marino'),
	('SN', 'SEN', 221, 'Senegal'),
	('SO', 'SOM', 252, 'Somalia'),
	('SR', 'SUR', 597, 'Suriname'),
	('SS', 'SSD', 211, 'South Sudan'),
	('ST', 'STP', 239, 'Sao Tome And Principe'),
	('SV', 'SLV', 503, 'El Salvador'),
	('SX', 'SXM', 1, 'Sint Maarten (Dutch part)'),
	('SY', 'SYR', 963, 'Syria'),
	('SZ', 'SWZ', 268, 'Swaziland'),
	('TA', '', 290, 'Tristan da Cunha'),
	('TC', 'TCA', 1, 'Turks And Caicos Islands'),
	('TD', 'TCD', 235, 'Chad'),
	('TG', 'TGO', 228, 'Togo'),
	('TH', 'THA', 66, 'Thailand'),
	('TJ', 'TJK', 992, 'Tajikistan'),
	('TK', 'TKL', 690, 'Tokelau'),
	('TL', 'TLS', 670, 'Timor-Leste'),
	('TM', 'TKM', 993, 'Turkmenistan'),
	('TN', 'TUN', 216, 'Tunisia'),
	('TO', 'TON', 676, 'Tonga'),
	('TR', 'TUR', 90, 'Turkey'),
	('TT', 'TTO', 1, 'Trinidad and Tobago'),
	('TV', 'TUV', 688, 'Tuvalu'),
	('TW', 'TWN', 886, 'Taiwan'),
	('TZ', 'TZA', 255, 'Tanzania'),
	('UA', 'UKR', 380, 'Ukraine'),
	('UG', 'UGA', 256, 'Uganda'),
	('US', 'USA', 1, 'United States'),
	('UY', 'URY', 598, 'Uruguay'),
	('UZ', 'UZB', 998, 'Uzbekistan'),
	('VA', 'VAT', 39, 'Vatican'),
	('VC', 'VCT', 1, 'Saint Vincent And The Grenadines'),
	('VE', 'VEN', 58, 'Venezuela'),
	('VG', 'VGB', 1, 'British Virgin Islands'),
	('VI', 'VIR', 1, 'U.S. Virgin Islands'),
	('VN', 'VNM', 84, 'Vietnam'),
	('VU', 'VUT', 678, 'Vanuatu'),
	('WF', 'WLF', 681, 'Wallis And Futuna'),
	('WS', 'WSM', 685, 'Samoa'),
	('XK', 'KOS', 383, 'Kosovo'),
	('YE', 'YEM', 967, 'Yemen'),
	('YT', 'MYT', 262, 'Mayotte'),
	('ZA', 'ZAF', 27, 'South Africa'),
	('ZM', 'ZMB', 260, 'Zambia'),
	('ZW', 'ZWE', 263, 'Zimbabwe');
/*!40000 ALTER TABLE `m_countries` ENABLE KEYS */;

-- Dumping structure for table aal.m_languages
CREATE TABLE IF NOT EXISTS `m_languages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `language_name` char(50) NOT NULL,
  `iso` char(2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=136 DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_languages: ~135 rows (approximately)
DELETE FROM `m_languages`;
/*!40000 ALTER TABLE `m_languages` DISABLE KEYS */;
INSERT INTO `m_languages` (`id`, `language_name`, `iso`) VALUES
	(1, 'English', 'en'),
	(2, 'Afar', 'aa'),
	(3, 'Abkhazian', 'ab'),
	(4, 'Afrikaans', 'af'),
	(5, 'Amharic', 'am'),
	(6, 'Arabic', 'ar'),
	(7, 'Assamese', 'as'),
	(8, 'Aymara', 'ay'),
	(9, 'Azerbaijani', 'az'),
	(10, 'Bashkir', 'ba'),
	(11, 'Belarusian', 'be'),
	(12, 'Bulgarian', 'bg'),
	(13, 'Bihari', 'bh'),
	(14, 'Bislama', 'bi'),
	(15, 'Bengali/Bangla', 'bn'),
	(16, 'Tibetan', 'bo'),
	(17, 'Breton', 'br'),
	(18, 'Catalan', 'ca'),
	(19, 'Corsican', 'co'),
	(20, 'Czech', 'cs'),
	(21, 'Welsh', 'cy'),
	(22, 'Danish', 'da'),
	(23, 'German', 'de'),
	(24, 'Bhutani', 'dz'),
	(25, 'Greek', 'el'),
	(26, 'Esperanto', 'eo'),
	(27, 'Spanish', 'es'),
	(28, 'Estonian', 'et'),
	(29, 'Basque', 'eu'),
	(30, 'Persian', 'fa'),
	(31, 'Finnish', 'fi'),
	(32, 'Fiji', 'fj'),
	(33, 'Faeroese', 'fo'),
	(34, 'French', 'fr'),
	(35, 'Frisian', 'fy'),
	(36, 'Irish', 'ga'),
	(37, 'Scots/Gaelic', 'gd'),
	(38, 'Galician', 'gl'),
	(39, 'Guarani', 'gn'),
	(40, 'Gujarati', 'gu'),
	(41, 'Hausa', 'ha'),
	(42, 'Hindi', 'hi'),
	(43, 'Croatian', 'hr'),
	(44, 'Hungarian', 'hu'),
	(45, 'Armenian', 'hy'),
	(46, 'Interlingua', 'ia'),
	(47, 'Interlingue', 'ie'),
	(48, 'Inupiak', 'ik'),
	(49, 'Indonesian', 'in'),
	(50, 'Icelandic', 'is'),
	(51, 'Italian', 'it'),
	(52, 'Hebrew', 'iw'),
	(53, 'Japanese', 'ja'),
	(54, 'Yiddish', 'ji'),
	(55, 'Javanese', 'jw'),
	(56, 'Georgian', 'ka'),
	(57, 'Kazakh', 'kk'),
	(58, 'Greenlandic', 'kl'),
	(59, 'Cambodian', 'km'),
	(60, 'Kannada', 'kn'),
	(61, 'Korean', 'ko'),
	(62, 'Kashmiri', 'ks'),
	(63, 'Kurdish', 'ku'),
	(64, 'Kirghiz', 'ky'),
	(65, 'Latin', 'la'),
	(66, 'Lingala', 'ln'),
	(67, 'Laothian', 'lo'),
	(68, 'Lithuanian', 'lt'),
	(69, 'Latvian/Lettish', 'lv'),
	(70, 'Malagasy', 'mg'),
	(71, 'Maori', 'mi'),
	(72, 'Macedonian', 'mk'),
	(73, 'Malayalam', 'ml'),
	(74, 'Mongolian', 'mn'),
	(75, 'Moldavian', 'mo'),
	(76, 'Marathi', 'mr'),
	(77, 'Malay', 'ms'),
	(78, 'Maltese', 'mt'),
	(79, 'Burmese', 'my'),
	(80, 'Nauru', 'na'),
	(81, 'Nepali', 'ne'),
	(82, 'Dutch', 'nl'),
	(83, 'Norwegian', 'no'),
	(84, 'Occitan', 'oc'),
	(85, '(Afan)/Oromoor/Oriya', 'om'),
	(86, 'Punjabi', 'pa'),
	(87, 'Polish', 'pl'),
	(88, 'Pashto/Pushto', 'ps'),
	(89, 'Portuguese', 'pt'),
	(90, 'Quechua', 'qu'),
	(91, 'Rhaeto-Romance', 'rm'),
	(92, 'Kirundi', 'rn'),
	(93, 'Romanian', 'ro'),
	(94, 'Russian', 'ru'),
	(95, 'Kinyarwanda', 'rw'),
	(96, 'Sanskrit', 'sa'),
	(97, 'Sindhi', 'sd'),
	(98, 'Sangro', 'sg'),
	(99, 'Serbo-Croatian', 'sh'),
	(100, 'Singhalese', 'si'),
	(101, 'Slovak', 'sk'),
	(102, 'Slovenian', 'sl'),
	(103, 'Samoan', 'sm'),
	(104, 'Shona', 'sn'),
	(105, 'Somali', 'so'),
	(106, 'Albanian', 'sq'),
	(107, 'Serbian', 'sr'),
	(108, 'Siswati', 'ss'),
	(109, 'Sesotho', 'st'),
	(110, 'Sundanese', 'su'),
	(111, 'Swedish', 'sv'),
	(112, 'Swahili', 'sw'),
	(113, 'Tamil', 'ta'),
	(114, 'Telugu', 'te'),
	(115, 'Tajik', 'tg'),
	(116, 'Thai', 'th'),
	(117, 'Tigrinya', 'ti'),
	(118, 'Turkmen', 'tk'),
	(119, 'Tagalog', 'tl'),
	(120, 'Setswana', 'tn'),
	(121, 'Tonga', 'to'),
	(122, 'Turkish', 'tr'),
	(123, 'Tsonga', 'ts'),
	(124, 'Tatar', 'tt'),
	(125, 'Twi', 'tw'),
	(126, 'Ukrainian', 'uk'),
	(127, 'Urdu', 'ur'),
	(128, 'Uzbek', 'uz'),
	(129, 'Vietnamese', 'vi'),
	(130, 'Volapuk', 'vo'),
	(131, 'Wolof', 'wo'),
	(132, 'Xhosa', 'xh'),
	(133, 'Yoruba', 'yo'),
	(134, 'Chinese', 'zh'),
	(135, 'Zulu', 'zu');
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_moodle_user: ~0 rows (approximately)
DELETE FROM `m_moodle_user`;
/*!40000 ALTER TABLE `m_moodle_user` DISABLE KEYS */;
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

-- Dumping data for table aal.m_tutor: ~0 rows (approximately)
DELETE FROM `m_tutor`;
/*!40000 ALTER TABLE `m_tutor` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table aal.m_tutor_courses: ~0 rows (approximately)
DELETE FROM `m_tutor_courses`;
/*!40000 ALTER TABLE `m_tutor_courses` DISABLE KEYS */;
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

-- Dumping data for table aal.__efmigrationshistory: ~1 rows (approximately)
DELETE FROM `__efmigrationshistory`;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20211224084822_CreateIdentitySchema', '5.0.13');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
