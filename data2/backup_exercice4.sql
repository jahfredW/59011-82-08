-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: exercice4
-- ------------------------------------------------------
-- Server version	5.7.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `departement`
--

DROP TABLE IF EXISTS `departement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departement` (
  `nodep` int(11) NOT NULL AUTO_INCREMENT,
  `nomdep` varchar(25) NOT NULL,
  `ville` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`nodep`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departement`
--

LOCK TABLES `departement` WRITE;
/*!40000 ALTER TABLE `departement` DISABLE KEYS */;
INSERT INTO `departement` VALUES (10,'Formation','Formation'),(20,'Ingénierie','Ingénierie'),(30,'Industrie','Industrie'),(40,'Direction générale','Direction générale'),(41,'nord','Lille'),(42,'hfoe','zefzefze');
/*!40000 ALTER TABLE `departement` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `departement_log` BEFORE INSERT ON `departement` FOR EACH ROW call log_update("departement") */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `employe`
--

DROP TABLE IF EXISTS `employe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employe` (
  `noemp` int(11) NOT NULL AUTO_INCREMENT,
  `nomemp` varchar(25) NOT NULL,
  `datemb` date NOT NULL,
  `sala` decimal(15,2) DEFAULT NULL,
  `comm` decimal(15,2) DEFAULT NULL,
  `nodep` int(11) NOT NULL,
  `noemp_1` int(11) DEFAULT NULL,
  PRIMARY KEY (`noemp`),
  KEY `nodep` (`nodep`),
  KEY `noemp_1` (`noemp_1`),
  CONSTRAINT `employe_ibfk_1` FOREIGN KEY (`nodep`) REFERENCES `departement` (`nodep`),
  CONSTRAINT `employe_ibfk_2` FOREIGN KEY (`noemp_1`) REFERENCES `employe` (`noemp`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employe`
--

LOCK TABLES `employe` WRITE;
/*!40000 ALTER TABLE `employe` DISABLE KEYS */;
INSERT INTO `employe` VALUES (1,'Costanza','1994-10-19',1715.00,200.00,30,8),(2,'Mioche','1990-03-15',2200.00,1000.00,20,6),(3,'Durand','1996-04-18',3250.00,0.00,10,2),(4,'Xiong','1994-12-15',1150.00,200.00,30,5),(5,'Manoukian','1993-08-15',2530.00,500.00,30,11),(6,'Bourdais','2002-07-12',3550.00,850.00,40,15),(7,'Moreno','1999-05-05',1075.00,50.00,10,3),(8,'Perou','1995-07-05',2450.00,800.00,10,2),(9,'Bibaut','1993-06-07',2200.00,0.00,20,8),(10,'Manian','1996-10-18',1000.00,250.00,10,9),(11,'Colin','1992-07-05',2702.50,625.00,30,2),(12,'Coulon','2002-09-18',858.00,125.00,20,8),(13,'Roméo','2001-08-16',1025.00,1150.00,10,8),(14,'Solal','1992-02-15',1225.00,0.00,20,3),(15,'Bailly','1985-01-05',4275.00,2000.00,40,NULL),(16,'Jazarin','2001-07-05',875.00,0.00,10,2),(17,'Font','1990-08-04',1200.00,250.00,10,2),(18,'Servel','1998-12-02',1025.00,55.00,30,3);
/*!40000 ALTER TABLE `employe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fonction`
--

DROP TABLE IF EXISTS `fonction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fonction` (
  `Id_Fonction` int(11) NOT NULL AUTO_INCREMENT,
  `intitulé` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id_Fonction`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fonction`
--

LOCK TABLES `fonction` WRITE;
/*!40000 ALTER TABLE `fonction` DISABLE KEYS */;
INSERT INTO `fonction` VALUES (1,'psychologue'),(2,'directeur'),(3,'responsable'),(4,'vendeur'),(5,'assistant'),(6,'analyste'),(7,'ouvrier'),(8,'président'),(9,'chef de service');
/*!40000 ALTER TABLE `fonction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grade`
--

DROP TABLE IF EXISTS `grade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grade` (
  `nograde` int(11) NOT NULL AUTO_INCREMENT,
  `salmin` decimal(15,2) DEFAULT NULL,
  `salmax` decimal(15,2) DEFAULT NULL,
  PRIMARY KEY (`nograde`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grade`
--

LOCK TABLES `grade` WRITE;
/*!40000 ALTER TABLE `grade` DISABLE KEYS */;
INSERT INTO `grade` VALUES (1,0.00,1000.00),(2,1000.01,2000.00),(3,2000.01,3000.00),(4,3000.01,4000.00),(5,4000.01,5000.00),(6,5000.01,6000.00);
/*!40000 ALTER TABLE `grade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `histofonction`
--

DROP TABLE IF EXISTS `histofonction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `histofonction` (
  `Id_Histofonction` int(11) NOT NULL AUTO_INCREMENT,
  `date_nom` date DEFAULT NULL,
  `noemp` int(11) NOT NULL,
  `Id_Fonction` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Histofonction`),
  KEY `noemp` (`noemp`),
  KEY `Id_Fonction` (`Id_Fonction`),
  CONSTRAINT `histofonction_ibfk_1` FOREIGN KEY (`noemp`) REFERENCES `employe` (`noemp`),
  CONSTRAINT `histofonction_ibfk_2` FOREIGN KEY (`Id_Fonction`) REFERENCES `fonction` (`Id_Fonction`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `histofonction`
--

LOCK TABLES `histofonction` WRITE;
/*!40000 ALTER TABLE `histofonction` DISABLE KEYS */;
INSERT INTO `histofonction` VALUES (1,'1996-12-18',1,1),(2,'1990-03-15',2,3),(3,'1994-10-18',2,2),(4,'1996-04-18',3,4),(5,'1998-06-18',3,3),(6,'1994-12-15',4,4),(7,'1993-08-15',5,4),(8,'2002-07-12',6,2),(9,'1999-05-05',7,7),(10,'1995-07-05',8,4),(11,'1997-04-15',8,3),(12,'1999-10-18',8,2),(13,'1996-10-18',10,5),(14,'1992-07-05',11,4),(15,'1995-07-15',11,3),(16,'1999-05-19',11,6),(17,'2002-09-18',12,7),(18,'2001-08-16',13,7),(19,'2003-07-17',13,5),(21,'1996-12-18',1,1),(22,'1990-03-15',2,3),(23,'1994-10-18',2,2),(24,'1996-04-18',3,4),(25,'1998-06-18',3,3),(26,'1994-12-15',4,4),(27,'1993-08-15',5,4),(28,'2002-07-12',6,2),(29,'1999-05-05',7,7),(30,'1995-07-05',8,4),(31,'1997-04-15',8,3),(32,'1999-10-18',8,2),(33,'1996-10-18',10,5),(34,'1992-07-05',11,4),(35,'1995-07-15',11,3),(36,'1999-05-19',11,6),(37,'2002-09-18',12,7),(38,'2001-08-16',13,7),(39,'2003-07-17',13,5),(40,'1992-01-02',14,10),(41,'1985-01-05',15,2),(42,'1995-10-05',15,8),(43,'2001-07-05',16,7),(44,'1990-08-04',17,7),(45,'1998-12-02',18,7);
/*!40000 ALTER TABLE `histofonction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `intitule` varchar(255) DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
INSERT INTO `log` VALUES (1,'table',NULL),(2,NULL,NULL),(3,NULL,NULL),(4,NULL,NULL),(5,NULL,NULL),(6,'table',NULL),(7,'édefzef',NULL),(8,'departement',NULL),(9,'departement','2023-10-25');
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-26 16:56:18
