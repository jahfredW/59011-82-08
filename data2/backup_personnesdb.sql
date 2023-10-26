-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: personnesdb
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
-- Table structure for table `personnes`
--

DROP TABLE IF EXISTS `personnes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personnes` (
  `idPersonne` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `adresse` varchar(100) DEFAULT NULL,
  `ville` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idPersonne`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personnes`
--

LOCK TABLES `personnes` WRITE;
/*!40000 ALTER TABLE `personnes` DISABLE KEYS */;
INSERT INTO `personnes` VALUES (3,'Gruw','fre',NULL,NULL),(4,'Gruw','fre',NULL,NULL),(5,'Gruw','fre',NULL,NULL),(6,'Gruw','fre',NULL,NULL),(7,'Gruw','fre',NULL,NULL),(8,'Gruw','fre',NULL,NULL),(9,'Gruw','fre',NULL,NULL),(10,'Gruw','fre',NULL,NULL),(11,'Gruw','fre',NULL,NULL),(12,'Gruw','fre',NULL,NULL),(13,'Gruw','fre',NULL,NULL),(14,'Gruw','fre',NULL,NULL),(15,'Gruw','fre',NULL,NULL),(16,'Gruw','fre',NULL,NULL),(17,'Gruw','fre',NULL,NULL),(18,'Gruw','fre',NULL,NULL),(19,'Gruw','fre',NULL,NULL),(20,'Gruw','fre',NULL,NULL),(21,'Gruw','fre',NULL,NULL),(22,'Gruw','fre',NULL,NULL),(23,'Gruw','fre',NULL,NULL),(24,'Gruw','fre',NULL,NULL),(25,'Gruw','fre',NULL,NULL),(26,'Gruw','fre',NULL,NULL),(27,'Gruw','fre',NULL,NULL),(28,'Gruw','fre',NULL,NULL),(29,'Gruw','fre',NULL,NULL),(30,'Gruw','fre',NULL,NULL),(31,'Gruw','fre',NULL,NULL),(32,'Gruw','fre',NULL,NULL),(33,'Gruw','fre',NULL,NULL),(34,'Gruw','fre',NULL,NULL),(35,'Gruw','fre',NULL,NULL),(36,'Gruw','fre',NULL,NULL),(37,'Gruw','fre',NULL,NULL),(38,'Gruw','fre',NULL,NULL),(39,'Gruw','fre',NULL,NULL),(40,'Gruw','fre',NULL,NULL),(41,'Gruw','fre',NULL,NULL),(42,'Gruw','fre',NULL,NULL),(43,'Gruw','fre',NULL,NULL),(44,'Gruw','fre',NULL,NULL),(45,'Gruw','fre',NULL,NULL),(46,'Gruw','fre',NULL,NULL),(47,'Gruw','fre',NULL,NULL);
/*!40000 ALTER TABLE `personnes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Adria Miles','mauris.elit.dictum@hotmail.ca'),(2,'Isabella Figueroa','duis.elementum@icloud.couk'),(3,'Megan Black','nunc@protonmail.com'),(4,'Neville Larson','massa.integer@protonmail.com'),(5,'Timothy Dawson','ut.quam@yahoo.edu'),(6,'Burke Morton','donec.nibh@icloud.couk'),(7,'Kirk Ferguson','tellus@protonmail.net'),(8,'Meghan Hinton','ipsum.suspendisse@aol.edu'),(9,'Samuel Sexton','tincidunt@outlook.edu'),(10,'Porter Gallagher','faucibus.orci@google.org'),(11,'Brian Mcknight','quis.massa@outlook.org'),(12,'Castor Benton','mus@outlook.net'),(13,'Brady Mays','magna.a@protonmail.net'),(14,'Hilel Mendez','nascetur.ridiculus.mus@outlook.org'),(15,'Olivia Gallagher','etiam.bibendum@yahoo.couk'),(16,'Coby Wheeler','ac@google.com'),(17,'Rachel Contreras','donec.nibh@hotmail.couk'),(18,'Randall English','ut@aol.net'),(19,'Maxine Weber','dignissim.lacus.aliquam@protonmail.ca'),(20,'Leroy Howell','imperdiet.ornare@yahoo.edu');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
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
