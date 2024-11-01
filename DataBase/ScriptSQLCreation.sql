-- Creation DataBase
CREATE DATABASE db_shootMeUp;
USE db_shootMeUp;

-- Creation des tables
CREATE TABLE t_level(
   level_id INT AUTO_INCREMENT,
   maximumScore INT NOT NULL,
   levelDificulty INT NOT NULL,
   levelName VARCHAR(50) NOT NULL,
   PRIMARY KEY(level_id)
);

CREATE TABLE t_ennemi(
   enemi_id INT AUTO_INCREMENT,
   life INT NOT NULL,
   appearance BOOLEAN,
   image TEXT NOT NULL,
   PRIMARY KEY(enemi_id)
);

CREATE TABLE t_obstacle(
   obstacle_id INT AUTO_INCREMENT,
   positionX VARCHAR(50) NOT NULL,
   positionY VARCHAR(50),
   height INT NOT NULL,
   width INT,
   PRIMARY KEY(obstacle_id)
);

CREATE TABLE t_user(
   user_id INT AUTO_INCREMENT,
   name VARCHAR(50) NOT NULL,
   password VARCHAR(50),
   PRIMARY KEY(user_id)
);

CREATE TABLE t_ammo(
   ammo_id INT AUTO_INCREMENT,
   height INT,
   width VARCHAR(50),
   speed DECIMAL(15,2),
   damage DECIMAL(15,2),
   image VARCHAR(50),
   PRIMARY KEY(ammo_id)
);

CREATE TABLE t_spaceship(
   spaceship_id INT AUTO_INCREMENT,
   speed DECIMAL(15,2) NOT NULL,
   height INT NOT NULL,
   width INT NOT NULL,
   image VARCHAR(50),
   level_id_FK INT NOT NULL,
   PRIMARY KEY(spaceship_id),
   FOREIGN KEY(level_id_FK) REFERENCES t_level(level_id)
);

CREATE TABLE t_score(
   score_id INT AUTO_INCREMENT,
   score INT NOT NULL,
   level_id_FK INT NOT NULL,
   user_id_FK INT NOT NULL,
   PRIMARY KEY(score_id),
   FOREIGN KEY(level_id_FK) REFERENCES t_level(level_id),
   FOREIGN KEY(user_id_FK) REFERENCES t_user(user_id)
);

CREATE TABLE t_apparaître(
   level_id_FK INT,
   enemi_id_FK INT,
   PRIMARY KEY(level_id_FK, enemi_id_FK),
   FOREIGN KEY(level_id_FK) REFERENCES t_level(level_id),
   FOREIGN KEY(enemi_id_FK) REFERENCES t_ennemi(enemi_id)
);

CREATE TABLE t_descendre(
   level_id_FK INT,
   obstacle_id_FK INT,
   PRIMARY KEY(level_id_FK, obstacle_id_FK),
   FOREIGN KEY(level_id_FK) REFERENCES t_level(level_id),
   FOREIGN KEY(obstacle_id_FK) REFERENCES t_obstacle(obstacle_id)
);

CREATE TABLE t_jouer(
   spaceship_id_FK INT,
   user_id_FK INT,
   PRIMARY KEY(spaceship_id_FK, user_id_FK),
   FOREIGN KEY(spaceship_id_FK) REFERENCES t_spaceship(spaceship_id),
   FOREIGN KEY(user_id_FK) REFERENCES t_user(user_id)
);

CREATE TABLE t_utiliser(
   spaceship_id_FK INT,
   ammo_id_FK INT,
   PRIMARY KEY(spaceship_id_FK, ammo_id_FK),
   FOREIGN KEY(spaceship_id_FK) REFERENCES t_spaceship(spaceship_id),
   FOREIGN KEY(ammo_id_FK) REFERENCES t_ammo(ammo_id)
);

CREATE TABLE t_avoir(
   enemi_id_FK INT,
   ammo_id_FK INT,
   PRIMARY KEY(enemi_id_FK, ammo_id_FK),
   FOREIGN KEY(enemi_id_FK) REFERENCES t_ennemi(enemi_id),
   FOREIGN KEY(ammo_id_FK) REFERENCES t_ammo(ammo_id)
);

-- Index Scores
CREATE INDEX idx_score ON t_score (score);