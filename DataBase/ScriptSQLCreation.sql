-- Creation DataBase
CREATE DATABASE db_shootMeUp;
USE db_shootMeUp;

-- Creation des tables
CREATE TABLE t_spaceship(
   spaceship_id INT AUTO_INCREMENT,
   speed DECIMAL(15,2) NOT NULL,
   height INT NOT NULL,
   width INT NOT NULL,
   image VARCHAR(50),
   PRIMARY KEY(spaceship_id)
);

CREATE TABLE t_level(
   level_id INT AUTO_INCREMENT,
   maximumScore INT NOT NULL,
   levelDificulty INT NOT NULL,
   levelName VARCHAR(50) NOT NULL,
   PRIMARY KEY(level_id)
);

CREATE TABLE t_enemy(
   enemy_id INT AUTO_INCREMENT,
   life INT NOT NULL,
   appearance BOOLEAN,
   image TEXT NOT NULL,
   PRIMARY KEY(enemy_id)
);

CREATE TABLE t_obstacle(
   obstacle_id INT AUTO_INCREMENT,
   positionX INT NOT NULL,
   positionY INT,
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

CREATE TABLE t_ammotype(
   ammotype_id INT AUTO_INCREMENT,
   height INT,
   width INT,
   speed DECIMAL(15,2),
   damage DECIMAL(15,2),
   image VARCHAR(50),
   PRIMARY KEY(ammotype_id)
);

CREATE TABLE t_score(
   score_id INT AUTO_INCREMENT,
   score INT NOT NULL,
   level_fk INT NOT NULL,
   user_fk INT NOT NULL,
   PRIMARY KEY(score_id),
   FOREIGN KEY(level_fk) REFERENCES t_level(level_id),
   FOREIGN KEY(user_fk) REFERENCES t_user(user_id)
);

CREATE TABLE t_appearing(
   level_fk INT,
   enemy_fk INT,
   PRIMARY KEY(level_fk, enemy_fk),
   FOREIGN KEY(level_fk) REFERENCES t_level(level_id),
   FOREIGN KEY(enemy_fk) REFERENCES t_enemy(enemy_id)
);

CREATE TABLE t_spawning(
   level_fk INT,
   obstacle_fk INT,
   PRIMARY KEY(level_fk, obstacle_fk),
   FOREIGN KEY(level_fk) REFERENCES t_level(level_id),
   FOREIGN KEY(obstacle_fk) REFERENCES t_obstacle(obstacle_id)
);

CREATE TABLE playing(
   spaceship_fk INT,
   level_fk INT,
   PRIMARY KEY(spaceship_fk, level_fk),
   FOREIGN KEY(spaceship_fk) REFERENCES t_spaceship(spaceship_id),
   FOREIGN KEY(level_fk) REFERENCES t_level(level_id)
);

CREATE TABLE t_using(
   spaceship_fk INT,
   ammotype_fk INT,
   PRIMARY KEY(spaceship_fk, ammotype_fk),
   FOREIGN KEY(spaceship_fk) REFERENCES t_spaceship(spaceship_id),
   FOREIGN KEY(ammotype_fk) REFERENCES t_ammotype(ammotype_id)
);

CREATE TABLE t_owning(
   enemy_fk INT,
   ammotype_fk INT,
   PRIMARY KEY(enemy_fk, ammotype_fk),
   FOREIGN KEY(enemy_fk) REFERENCES t_enemy(enemy_id),
   FOREIGN KEY(ammotype_fk) REFERENCES t_ammotype(ammotype_id)
);


-- Index Scores
CREATE INDEX idx_score ON t_score (score);