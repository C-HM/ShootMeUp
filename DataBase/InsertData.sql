-- Insert examples for t_level
INSERT INTO t_level (maximumScore, levelDificulty, levelName) VALUES (1000, 1, 'Beginner');
INSERT INTO t_level (maximumScore, levelDificulty, levelName) VALUES (5000, 2, 'Intermediate');
INSERT INTO t_level (maximumScore, levelDificulty, levelName) VALUES (10000, 3, 'Advanced');

-- Insert examples for t_ennemi
INSERT INTO t_ennemi (life, appearance, image) VALUES (100, TRUE, 'enemy1.png');
INSERT INTO t_ennemi (life, appearance, image) VALUES (200, FALSE, 'enemy2.png');
INSERT INTO t_ennemi (life, appearance, image) VALUES (150, TRUE, 'enemy3.png');

-- Insert examples for t_obstacle
INSERT INTO t_obstacle (positionX, positionY, height, width) VALUES ('100px', '200px', 50, 30);
INSERT INTO t_obstacle (positionX, positionY, height, width) VALUES ('150px', '250px', 70, 40);
INSERT INTO t_obstacle (positionX, positionY, height, width) VALUES ('200px', '300px', 60, 35);

-- Insert examples for t_user
INSERT INTO t_user (name, password) VALUES ('Timothé', 'password123');
INSERT INTO t_user (name, password) VALUES ('Dwight', 'secret456');
INSERT INTO t_user (name, password) VALUES ('Edward', 'pass789');

-- Insert examples for t_ammo
INSERT INTO t_ammo (height, width, speed, damage, image) VALUES (10, '5px', 2.5, 10.5, 'ammo1.png');
INSERT INTO t_ammo (height, width, speed, damage, image) VALUES (12, '6px', 3.0, 12.0, 'ammo2.png');
INSERT INTO t_ammo (height, width, speed, damage, image) VALUES (8, '4px', 2.0, 8.5, 'ammo3.png');

-- Insert examples for t_spaceship
INSERT INTO t_spaceship (speed, height, width, image, level_id_FK) VALUES (1.5, 40, 60, 'spaceship1.png', 1);
INSERT INTO t_spaceship (speed, height, width, image, level_id_FK) VALUES (2.0, 50, 70, 'spaceship2.png', 2);
INSERT INTO t_spaceship (speed, height, width, image, level_id_FK) VALUES (2.5, 45, 65, 'spaceship3.png', 3);

-- Insert examples for t_score
INSERT INTO t_score (score, level_id_FK, user_id_FK) VALUES (950, 1, 1);
INSERT INTO t_score (score, level_id_FK, user_id_FK) VALUES (4500, 2, 2);
INSERT INTO t_score (score, level_id_FK, user_id_FK) VALUES (9800, 3, 3);

-- Insert examples for t_apparaître
INSERT INTO t_apparaître (level_id_FK, enemi_id_FK) VALUES (1, 1);
INSERT INTO t_apparaître (level_id_FK, enemi_id_FK) VALUES (2, 2);
INSERT INTO t_apparaître (level_id_FK, enemi_id_FK) VALUES (3, 3);

-- Insert examples for t_descendre
INSERT INTO t_descendre (level_id_FK, obstacle_id_FK) VALUES (1, 1);
INSERT INTO t_descendre (level_id_FK, obstacle_id_FK) VALUES (2, 2);
INSERT INTO t_descendre (level_id_FK, obstacle_id_FK) VALUES (3, 3);

-- Insert examples for t_jouer
INSERT INTO t_jouer (spaceship_id_FK, user_id_FK) VALUES (1, 1);
INSERT INTO t_jouer (spaceship_id_FK, user_id_FK) VALUES (2, 2);
INSERT INTO t_jouer (spaceship_id_FK, user_id_FK) VALUES (3, 3);

-- Insert examples for t_utiliser
INSERT INTO t_utiliser (spaceship_id_FK, ammo_id_FK) VALUES (1, 1);
INSERT INTO t_utiliser (spaceship_id_FK, ammo_id_FK) VALUES (2, 2);
INSERT INTO t_utiliser (spaceship_id_FK, ammo_id_FK) VALUES (3, 3);

-- Insert examples for t_avoir
INSERT INTO t_avoir (enemi_id_FK, ammo_id_FK) VALUES (1, 1);
INSERT INTO t_avoir (enemi_id_FK, ammo_id_FK) VALUES (2, 2);
INSERT INTO t_avoir (enemi_id_FK, ammo_id_FK) VALUES (3, 3);
