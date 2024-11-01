-- MySQL dump 10.13  Distrib 8.0.30, for Linux (x86_64)
--
-- Host: localhost    Database: db_shootMeUp
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `t_ammo`
--

DROP TABLE IF EXISTS `t_ammo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_ammo` (
  `ammo_id` int NOT NULL AUTO_INCREMENT,
  `height` int DEFAULT NULL,
  `width` varchar(50) DEFAULT NULL,
  `speed` decimal(15,2) DEFAULT NULL,
  `damage` decimal(15,2) DEFAULT NULL,
  `image` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ammo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_ammo`
--

LOCK TABLES `t_ammo` WRITE;
/*!40000 ALTER TABLE `t_ammo` DISABLE KEYS */;
INSERT INTO `t_ammo` VALUES (1,10,'5px',2.50,10.50,'ammo1.png'),(2,12,'6px',3.00,12.00,'ammo2.png'),(3,8,'4px',2.00,8.50,'ammo3.png');
/*!40000 ALTER TABLE `t_ammo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_apparaître`
--

DROP TABLE IF EXISTS `t_apparaître`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_apparaître` (
  `level_id_FK` int NOT NULL,
  `enemi_id_FK` int NOT NULL,
  PRIMARY KEY (`level_id_FK`,`enemi_id_FK`),
  KEY `enemi_id_FK` (`enemi_id_FK`),
  CONSTRAINT `t_apparaître_ibfk_1` FOREIGN KEY (`level_id_FK`) REFERENCES `t_level` (`level_id`),
  CONSTRAINT `t_apparaître_ibfk_2` FOREIGN KEY (`enemi_id_FK`) REFERENCES `t_ennemi` (`enemi_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_apparaître`
--

LOCK TABLES `t_apparaître` WRITE;
/*!40000 ALTER TABLE `t_apparaître` DISABLE KEYS */;
INSERT INTO `t_apparaître` VALUES (1,1),(2,2),(3,3);
/*!40000 ALTER TABLE `t_apparaître` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_avoir`
--

DROP TABLE IF EXISTS `t_avoir`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_avoir` (
  `enemi_id_FK` int NOT NULL,
  `ammo_id_FK` int NOT NULL,
  PRIMARY KEY (`enemi_id_FK`,`ammo_id_FK`),
  KEY `ammo_id_FK` (`ammo_id_FK`),
  CONSTRAINT `t_avoir_ibfk_1` FOREIGN KEY (`enemi_id_FK`) REFERENCES `t_ennemi` (`enemi_id`),
  CONSTRAINT `t_avoir_ibfk_2` FOREIGN KEY (`ammo_id_FK`) REFERENCES `t_ammo` (`ammo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_avoir`
--

LOCK TABLES `t_avoir` WRITE;
/*!40000 ALTER TABLE `t_avoir` DISABLE KEYS */;
INSERT INTO `t_avoir` VALUES (1,1),(2,2),(3,3);
/*!40000 ALTER TABLE `t_avoir` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_descendre`
--

DROP TABLE IF EXISTS `t_descendre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_descendre` (
  `level_id_FK` int NOT NULL,
  `obstacle_id_FK` int NOT NULL,
  PRIMARY KEY (`level_id_FK`,`obstacle_id_FK`),
  KEY `obstacle_id_FK` (`obstacle_id_FK`),
  CONSTRAINT `t_descendre_ibfk_1` FOREIGN KEY (`level_id_FK`) REFERENCES `t_level` (`level_id`),
  CONSTRAINT `t_descendre_ibfk_2` FOREIGN KEY (`obstacle_id_FK`) REFERENCES `t_obstacle` (`obstacle_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_descendre`
--

LOCK TABLES `t_descendre` WRITE;
/*!40000 ALTER TABLE `t_descendre` DISABLE KEYS */;
INSERT INTO `t_descendre` VALUES (1,1),(2,2),(3,3);
/*!40000 ALTER TABLE `t_descendre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_ennemi`
--

DROP TABLE IF EXISTS `t_ennemi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_ennemi` (
  `enemi_id` int NOT NULL AUTO_INCREMENT,
  `life` int NOT NULL,
  `appearance` tinyint(1) DEFAULT NULL,
  `image` text NOT NULL,
  PRIMARY KEY (`enemi_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_ennemi`
--

LOCK TABLES `t_ennemi` WRITE;
/*!40000 ALTER TABLE `t_ennemi` DISABLE KEYS */;
INSERT INTO `t_ennemi` VALUES (1,100,1,'enemy1.png'),(2,200,0,'enemy2.png'),(3,150,1,'enemy3.png');
/*!40000 ALTER TABLE `t_ennemi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_jouer`
--

DROP TABLE IF EXISTS `t_jouer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_jouer` (
  `spaceship_id_FK` int NOT NULL,
  `user_id_FK` int NOT NULL,
  PRIMARY KEY (`spaceship_id_FK`,`user_id_FK`),
  KEY `user_id_FK` (`user_id_FK`),
  CONSTRAINT `t_jouer_ibfk_1` FOREIGN KEY (`spaceship_id_FK`) REFERENCES `t_spaceship` (`spaceship_id`),
  CONSTRAINT `t_jouer_ibfk_2` FOREIGN KEY (`user_id_FK`) REFERENCES `t_user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_jouer`
--

LOCK TABLES `t_jouer` WRITE;
/*!40000 ALTER TABLE `t_jouer` DISABLE KEYS */;
INSERT INTO `t_jouer` VALUES (1,1),(2,2),(3,3);
/*!40000 ALTER TABLE `t_jouer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_level`
--

DROP TABLE IF EXISTS `t_level`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_level` (
  `level_id` int NOT NULL AUTO_INCREMENT,
  `maximumScore` int NOT NULL,
  `levelDificulty` int NOT NULL,
  `levelName` varchar(50) NOT NULL,
  PRIMARY KEY (`level_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_level`
--

LOCK TABLES `t_level` WRITE;
/*!40000 ALTER TABLE `t_level` DISABLE KEYS */;
INSERT INTO `t_level` VALUES (1,1000,1,'Beginner'),(2,5000,2,'Intermediate'),(3,10000,3,'Advanced');
/*!40000 ALTER TABLE `t_level` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_obstacle`
--

DROP TABLE IF EXISTS `t_obstacle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_obstacle` (
  `obstacle_id` int NOT NULL AUTO_INCREMENT,
  `positionX` varchar(50) NOT NULL,
  `positionY` varchar(50) DEFAULT NULL,
  `height` int NOT NULL,
  `width` int DEFAULT NULL,
  PRIMARY KEY (`obstacle_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_obstacle`
--

LOCK TABLES `t_obstacle` WRITE;
/*!40000 ALTER TABLE `t_obstacle` DISABLE KEYS */;
INSERT INTO `t_obstacle` VALUES (1,'100px','200px',50,30),(2,'150px','250px',70,40),(3,'200px','300px',60,35);
/*!40000 ALTER TABLE `t_obstacle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_score`
--

DROP TABLE IF EXISTS `t_score`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_score` (
  `score_id` int NOT NULL AUTO_INCREMENT,
  `score` int NOT NULL,
  `level_id_FK` int NOT NULL,
  `user_id_FK` int NOT NULL,
  PRIMARY KEY (`score_id`),
  KEY `level_id_FK` (`level_id_FK`),
  KEY `user_id_FK` (`user_id_FK`),
  KEY `idx_score` (`score`),
  CONSTRAINT `t_score_ibfk_1` FOREIGN KEY (`level_id_FK`) REFERENCES `t_level` (`level_id`),
  CONSTRAINT `t_score_ibfk_2` FOREIGN KEY (`user_id_FK`) REFERENCES `t_user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_score`
--

LOCK TABLES `t_score` WRITE;
/*!40000 ALTER TABLE `t_score` DISABLE KEYS */;
INSERT INTO `t_score` VALUES (1,950,1,1),(2,4500,2,2),(3,9800,3,3);
/*!40000 ALTER TABLE `t_score` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_spaceship`
--

DROP TABLE IF EXISTS `t_spaceship`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_spaceship` (
  `spaceship_id` int NOT NULL AUTO_INCREMENT,
  `speed` decimal(15,2) NOT NULL,
  `height` int NOT NULL,
  `width` int NOT NULL,
  `image` varchar(50) DEFAULT NULL,
  `level_id_FK` int NOT NULL,
  PRIMARY KEY (`spaceship_id`),
  KEY `level_id_FK` (`level_id_FK`),
  CONSTRAINT `t_spaceship_ibfk_1` FOREIGN KEY (`level_id_FK`) REFERENCES `t_level` (`level_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_spaceship`
--

LOCK TABLES `t_spaceship` WRITE;
/*!40000 ALTER TABLE `t_spaceship` DISABLE KEYS */;
INSERT INTO `t_spaceship` VALUES (1,1.50,40,60,'spaceship1.png',1),(2,2.00,50,70,'spaceship2.png',2),(3,2.50,45,65,'spaceship3.png',3);
/*!40000 ALTER TABLE `t_spaceship` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_user`
--

DROP TABLE IF EXISTS `t_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `password` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_user`
--

LOCK TABLES `t_user` WRITE;
/*!40000 ALTER TABLE `t_user` DISABLE KEYS */;
INSERT INTO `t_user` VALUES (1,'Timothé','password123'),(2,'Dwight','secret456'),(3,'Edward','pass789');
/*!40000 ALTER TABLE `t_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_utiliser`
--

DROP TABLE IF EXISTS `t_utiliser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_utiliser` (
  `spaceship_id_FK` int NOT NULL,
  `ammo_id_FK` int NOT NULL,
  PRIMARY KEY (`spaceship_id_FK`,`ammo_id_FK`),
  KEY `ammo_id_FK` (`ammo_id_FK`),
  CONSTRAINT `t_utiliser_ibfk_1` FOREIGN KEY (`spaceship_id_FK`) REFERENCES `t_spaceship` (`spaceship_id`),
  CONSTRAINT `t_utiliser_ibfk_2` FOREIGN KEY (`ammo_id_FK`) REFERENCES `t_ammo` (`ammo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_utiliser`
--

LOCK TABLES `t_utiliser` WRITE;
/*!40000 ALTER TABLE `t_utiliser` DISABLE KEYS */;
INSERT INTO `t_utiliser` VALUES (1,1),(2,2),(3,3);
/*!40000 ALTER TABLE `t_utiliser` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-30  8:09:18
