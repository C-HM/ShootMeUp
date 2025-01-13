USE db_shootMeUp;

-- Insert examples for t_level
INSERT INTO t_level (maximumScore, levelDificulty, levelName) VALUES (1000, 1, 'Beginner');
INSERT INTO t_level (maximumScore, levelDificulty, levelName) VALUES (5000, 2, 'Intermediate');
INSERT INTO t_level (maximumScore, levelDificulty, levelName) VALUES (10000, 3, 'Advanced');

-- Insert examples for t_enemy
INSERT INTO t_enemy (life, appearance, image) VALUES (100, TRUE, 'enemy1.png');
INSERT INTO t_enemy (life, appearance, image) VALUES (200, FALSE, 'enemy2.png');
INSERT INTO t_enemy (life, appearance, image) VALUES (300, TRUE, 'enemy3.png');

-- Insert examples for t_obstacle
INSERT INTO t_obstacle (positionX, positionY, height, width) VALUES (100, 200, 50, 30);
INSERT INTO t_obstacle (positionX, positionY, height, width) VALUES (150, 250, 70, 40);
INSERT INTO t_obstacle (positionX, positionY, height, width) VALUES (200, 300, 60, 35);

-- Insert examples for t_user
INSERT INTO t_user (name, password) VALUES ('admin', 'password');
INSERT INTO t_user (name, password) VALUES ('Timothé', 'password123');
INSERT INTO t_user (name, password) VALUES ('Dwight', 'secret456');
INSERT INTO t_user (name, password) VALUES ('Edward', 'pass789');

-- Insert examples for t_ammotype
INSERT INTO t_ammotype (height, width, speed, damage, image) VALUES (5, 5, 1.5, 10, 'ammo1.png');
INSERT INTO t_ammotype (height, width, speed, damage, image) VALUES (6, 6, 1.8, 15, 'ammo2.png');
INSERT INTO t_ammotype (height, width, speed, damage, image) VALUES (8, 4, 2.0, 8.5, 'ammo3.png');

-- Insert examples for t_spaceship
INSERT INTO t_spaceship (speed, height, width, image) VALUES (1.5, 40, 60, 'spaceship1.png');
INSERT INTO t_spaceship (speed, height, width, image) VALUES (2.0, 50, 70, 'spaceship2.png');
INSERT INTO t_spaceship (speed, height, width, image) VALUES (2.5, 45, 65, 'spaceship3.png');

-- Insert examples for t_score
INSERT INTO t_score (score, level_fk, user_fk) VALUES (1000, 1, 1);
INSERT INTO t_score (score, level_fk, user_fk) VALUES (2000, 2, 2);
INSERT INTO t_score (score, level_fk, user_fk) VALUES (9800, 3, 3);

-- Insert examples for t_appearing
INSERT INTO t_appearing (level_fk, enemy_fk) VALUES (1, 1);
INSERT INTO t_appearing (level_fk, enemy_fk) VALUES (2, 2);
INSERT INTO t_appearing (level_fk, enemy_fk) VALUES (3, 3);

-- Insert examples for t_spawning
INSERT INTO t_spawning (level_fk, obstacle_fk) VALUES (1, 1);
INSERT INTO t_spawning (level_fk, obstacle_fk) VALUES (2, 2);
INSERT INTO t_spawning (level_fk, obstacle_fk) VALUES (3, 3);

-- Insert examples for t_using
INSERT INTO t_using (spaceship_fk, ammotype_fk) VALUES (1, 1);
INSERT INTO t_using (spaceship_fk, ammotype_fk) VALUES (2, 2);
INSERT INTO t_using (spaceship_fk, ammotype_fk) VALUES (3, 3);

-- Insert examples for t_owning
INSERT INTO t_owning (enemy_fk, ammotype_fk) VALUES (1, 1);
INSERT INTO t_owning (enemy_fk, ammotype_fk) VALUES (2, 2);
INSERT INTO t_owning (enemy_fk, ammotype_fk) VALUES (3, 3);
