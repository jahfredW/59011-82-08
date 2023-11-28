-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 28 nov. 2023 à 15:49
-- Version du serveur : 5.7.36
-- Version de PHP : 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `npp`
--

-- --------------------------------------------------------

--
-- Structure de la table `address`
--

DROP TABLE IF EXISTS `address`;
CREATE TABLE IF NOT EXISTS `address` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `firstname` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `lastname` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `company` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `postal` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `city` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `country` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_D4E6F81A76ED395` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `address`
--

INSERT INTO `address` (`id`, `user_id`, `name`, `firstname`, `lastname`, `company`, `address`, `postal`, `city`, `country`, `phone`) VALUES
(1, 2, 'mon adresse', 'test', 'test', NULL, '40 rue du Sud', '59240', 'Dunkerque', 'France', NULL),
(2, 2, 'mon adresse 2', 'test', 'test', NULL, '40 rue du Sud', '59240', 'Dunkerque', 'France', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `album`
--

DROP TABLE IF EXISTS `album`;
CREATE TABLE IF NOT EXISTS `album` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category_id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL COMMENT '(DC2Type:datetime_immutable)',
  `cover_picture` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `morning` tinyint(1) NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_39986E4312469DE2` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `album`
--

INSERT INTO `album` (`id`, `category_id`, `name`, `created_at`, `cover_picture`, `morning`, `is_active`) VALUES
(47, 1, 'test', '2023-04-09 11:34:57', 'thumbnail_f32263258079de366ffd8319f2622ee9.jpg', 1, 0),
(48, 1, 'test', '2023-11-28 14:03:01', NULL, 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `category`
--

DROP TABLE IF EXISTS `category`;
CREATE TABLE IF NOT EXISTS `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL COMMENT '(DC2Type:datetime_immutable)',
  `updated_at` datetime DEFAULT NULL COMMENT '(DC2Type:datetime_immutable)',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `category`
--

INSERT INTO `category` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'surf', '2023-03-22 08:33:30', NULL),
(2, 'football', '2023-03-22 08:34:18', NULL),
(3, 'basket', '2023-03-22 08:34:27', NULL),
(4, 'windsurf', '2023-03-22 08:34:36', NULL),
(5, 'kitesurf', '2023-03-22 08:35:10', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `director`
--

DROP TABLE IF EXISTS `director`;
CREATE TABLE IF NOT EXISTS `director` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `last_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `first_name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `discounts`
--

DROP TABLE IF EXISTS `discounts`;
CREATE TABLE IF NOT EXISTS `discounts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `ReductionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Discounts_ReductionId` (`ReductionId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `discounts`
--

INSERT INTO `discounts` (`Id`, `Name`, `Description`, `ReductionId`) VALUES
(1, 'discount 12', 'zedz', 1),
(2, 'discount 2 ', 'fzefzf', 2);

-- --------------------------------------------------------

--
-- Structure de la table `doctrine_migration_versions`
--

DROP TABLE IF EXISTS `doctrine_migration_versions`;
CREATE TABLE IF NOT EXISTS `doctrine_migration_versions` (
  `version` varchar(191) COLLATE utf8_unicode_ci NOT NULL,
  `executed_at` datetime DEFAULT NULL,
  `execution_time` int(11) DEFAULT NULL,
  PRIMARY KEY (`version`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `doctrine_migration_versions`
--

INSERT INTO `doctrine_migration_versions` (`version`, `executed_at`, `execution_time`) VALUES
('DoctrineMigrations\\Version20230403162745', '2023-04-03 18:28:38', 141),
('DoctrineMigrations\\Version20230407064639', '2023-04-07 08:47:03', 149),
('DoctrineMigrations\\Version20230407065710', '2023-04-07 08:57:16', 421);

-- --------------------------------------------------------

--
-- Structure de la table `film`
--

DROP TABLE IF EXISTS `film`;
CREATE TABLE IF NOT EXISTS `film` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `director_id` int(11) DEFAULT NULL,
  `title` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `photo` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_8244BE22899FB366` (`director_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `order`
--

DROP TABLE IF EXISTS `order`;
CREATE TABLE IF NOT EXISTS `order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `created_at` datetime NOT NULL COMMENT '(DC2Type:datetime_immutable)',
  `status` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `stripe_id` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ReductionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_F5299398A76ED395` (`user_id`),
  KEY `IX_order_ReductionId` (`ReductionId`)
) ENGINE=InnoDB AUTO_INCREMENT=204 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `order`
--

INSERT INTO `order` (`id`, `created_at`, `status`, `is_active`, `user_id`, `stripe_id`, `ReductionId`) VALUES
(201, '2023-04-09 11:35:32', 'done', 0, 2, 'cs_test_a1lODaY2ds4av3kbtznGyFw5Fv2jJcJxZon13o08mjJt6GAEOBG2OkUdBa', 2),
(202, '2023-04-09 12:02:06', 'done', 0, 2, 'cs_test_a1xfSoEOpMUDTeNZAzMw3knqMGW5Fq0cr8bHC6RiPPZZO7hK6BFE4aaOF0', 2),
(203, '2023-04-09 12:03:18', 'done', 0, 2, 'cs_test_a1m05tZSKOC3XwwXavtH1DmvinbvkIdHbhcBoVN37BowxGTxRLGv7zDFv3', 1);

-- --------------------------------------------------------

--
-- Structure de la table `order_line`
--

DROP TABLE IF EXISTS `order_line`;
CREATE TABLE IF NOT EXISTS `order_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ordered_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` double NOT NULL,
  `total` double NOT NULL,
  `picture_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_9CE58EE1AA60395A` (`ordered_id`)
) ENGINE=InnoDB AUTO_INCREMENT=273 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `order_line`
--

INSERT INTO `order_line` (`id`, `ordered_id`, `quantity`, `price`, `total`, `picture_id`) VALUES
(270, 201, 1, 5, 5, 529),
(271, 202, 1, 5, 5, 530),
(272, 203, 1, 5, 5, 530);

-- --------------------------------------------------------

--
-- Structure de la table `photo`
--

DROP TABLE IF EXISTS `photo`;
CREATE TABLE IF NOT EXISTS `photo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL COMMENT '(DC2Type:datetime_immutable)',
  `is_active` tinyint(1) NOT NULL,
  `path` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `picture`
--

DROP TABLE IF EXISTS `picture`;
CREATE TABLE IF NOT EXISTS `picture` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `album_id` int(11) DEFAULT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `file_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL COMMENT '(DC2Type:datetime_immutable)',
  `is_active` tinyint(1) NOT NULL,
  `thumbnail` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IDX_16DB4F891137ABCF` (`album_id`)
) ENGINE=InnoDB AUTO_INCREMENT=541 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `picture`
--

INSERT INTO `picture` (`id`, `album_id`, `name`, `file_name`, `created_at`, `is_active`, `thumbnail`) VALUES
(529, 47, 'dsc_2637', 'f32263258079de366ffd8319f2622ee9.jpg', '2023-04-09 11:34:57', 0, 'thumbnail_f32263258079de366ffd8319f2622ee9.jpg'),
(530, 47, 'dsc_2639', '3f99e22428777460565a70e111eff67c.jpg', '2023-04-09 11:34:58', 0, 'thumbnail_3f99e22428777460565a70e111eff67c.jpg'),
(531, 47, 'dsc_2641', '2741540425cde0666808e15ab3bea502.jpg', '2023-04-09 11:34:59', 0, 'thumbnail_2741540425cde0666808e15ab3bea502.jpg'),
(532, 47, 'dsc_2646', '400f59e9d8312d08c65b116905d58adf.jpg', '2023-04-09 11:35:00', 0, 'thumbnail_400f59e9d8312d08c65b116905d58adf.jpg'),
(533, 47, 'dsc_2653', '376a1af03c221dc721807910cc7add43.jpg', '2023-04-09 11:35:01', 0, 'thumbnail_376a1af03c221dc721807910cc7add43.jpg'),
(534, 47, 'dsc_2661', 'a7e44551ac4b610e1161d8bd4b357917.jpg', '2023-04-09 11:35:02', 0, 'thumbnail_a7e44551ac4b610e1161d8bd4b357917.jpg'),
(535, 47, 'dsc_2664', '6cd4018dcc1b29dacd12f1f1ebdb95d3.jpg', '2023-04-09 11:35:03', 0, 'thumbnail_6cd4018dcc1b29dacd12f1f1ebdb95d3.jpg'),
(536, 47, 'dsc_2665', '0f1533b2d0fab8a92ccfaca6ea9eed12.jpg', '2023-04-09 11:35:04', 0, 'thumbnail_0f1533b2d0fab8a92ccfaca6ea9eed12.jpg'),
(537, 47, 'dsc_2674', '16aacf1b4b429de3c6eac1ab07f5c3e5.jpg', '2023-04-09 11:35:05', 0, 'thumbnail_16aacf1b4b429de3c6eac1ab07f5c3e5.jpg'),
(538, 47, 'dsc_2676', '322a4e33e6884173b848a9346b36b0a4.jpg', '2023-04-09 11:35:06', 0, 'thumbnail_322a4e33e6884173b848a9346b36b0a4.jpg'),
(539, 47, 'dsc_2680', 'bfe4cc0fe5b4ce3cbbe80ef08295daf5.jpg', '2023-04-09 11:35:07', 0, 'thumbnail_bfe4cc0fe5b4ce3cbbe80ef08295daf5.jpg'),
(540, 47, 'dsc_2685', '2dcdc529be7177d786273ab326981f4d.jpg', '2023-04-09 11:35:08', 0, 'thumbnail_2dcdc529be7177d786273ab326981f4d.jpg');

-- --------------------------------------------------------

--
-- Structure de la table `reductions`
--

DROP TABLE IF EXISTS `reductions`;
CREATE TABLE IF NOT EXISTS `reductions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `reductions`
--

INSERT INTO `reductions` (`Id`, `Name`) VALUES
(1, 'reduction 1'),
(2, 'reduction 2 ');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(180) COLLATE utf8mb4_unicode_ci NOT NULL,
  `roles` longtext COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '(DC2Type:json)',
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pseudo` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UNIQ_8D93D649E7927C74` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`id`, `email`, `roles`, `password`, `pseudo`) VALUES
(1, 'fred.gruwe@gmail.com', '[\"ROLE_ADMIN\"]', '$2y$13$UWW2hJbGu3PjQcmFsIl1kOmgnDwsG9bdLXpKvMTVpwnmRvh.7UnJO', 'admin'),
(2, 'test@test.com', '[]', '$2y$13$ucJnUlsa3HbP4MZIwq2Yo.TlIc8zKr84nqe7h1buPQqqQ2JH7N1vS', 'test'),
(3, 'test3@test3.com', '[]', '$2y$13$oQfk3BmMspQrmFQnjzv9P.6JA3Nb/QrY/5mEpbj6LsZtGsdHBN.Iq', 'test3'),
(4, 'test4@test4.com', '[]', '$2y$13$OubpOTtqHdV6StfcKFs1ruPKe5EueZNHro5jYSZeWvQ44o/Y0y43e', 'test4'),
(5, 'caca@caca.com', '[]', '$2y$13$hV5IEimXk9Zi3EVh0v2WTu66XB2irexrIHfDh/hxcSXFoJRieUcsO', 'caca'),
(9, 'caca3@caca.com', '[]', '$2y$13$dYpfL.c83MauzTaCTMMAreCzFCguoCBbj29.Ufi6MqUyCEw684wSy', 'caca3'),
(10, 'oihfozihe@auzhdoaiu.com', '[]', '$2y$13$sDQO.34kCaoq0JQafdc.funCpB/tmLzp3ehIBY8rdo/5j5T.53T1C', 'hdezoih');

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20231128150332_Discount', '7.0.14'),
('20231128150858_Discount2', '7.0.14'),
('20231128151555_Discount', '7.0.14');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `FK_D4E6F81A76ED395` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Contraintes pour la table `album`
--
ALTER TABLE `album`
  ADD CONSTRAINT `FK_39986E4312469DE2` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`);

--
-- Contraintes pour la table `discounts`
--
ALTER TABLE `discounts`
  ADD CONSTRAINT `FK_Discounts_Reductions_ReductionId` FOREIGN KEY (`ReductionId`) REFERENCES `reductions` (`Id`);

--
-- Contraintes pour la table `film`
--
ALTER TABLE `film`
  ADD CONSTRAINT `FK_8244BE22899FB366` FOREIGN KEY (`director_id`) REFERENCES `director` (`id`);

--
-- Contraintes pour la table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `FK_F5299398A76ED395` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `FK_order_Reductions_ReductionId` FOREIGN KEY (`ReductionId`) REFERENCES `reductions` (`Id`);

--
-- Contraintes pour la table `order_line`
--
ALTER TABLE `order_line`
  ADD CONSTRAINT `FK_9CE58EE1AA60395A` FOREIGN KEY (`ordered_id`) REFERENCES `order` (`id`);

--
-- Contraintes pour la table `picture`
--
ALTER TABLE `picture`
  ADD CONSTRAINT `FK_16DB4F891137ABCF` FOREIGN KEY (`album_id`) REFERENCES `album` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
