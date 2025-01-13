-- Edit: Admin
CREATE ROLE 'gameAdmin';

-- Gere les comptes des joueurs
CREATE ROLE 'player';

-- Sauvegarde et affiche les scores
CREATE ROLE 'gameManager';

-- Creation des utilisateurs
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'password';
CREATE USER 'Dwight'@'localhost' IDENTIFIED BY 'd';
CREATE USER 'Edward'@'localhost' IDENTIFIED BY 'e';
CREATE USER 'Timothe'@'localhost' IDENTIFIED BY 't';

-- Donner les roles aux utilisateurs
GRANT 'gameAdmin' TO 'admin'@'localhost';
GRANT 'player' TO 'd'@'localhost';
GRANT 'player' TO 't'@'localhost';
GRANT 'gameManager' TO 'e'@'localhost';

-- Peut lire, créer et supprimer des comptes utilisateurs
GRANT SELECT, UPDATE, INSERT, DELETE ON db_shootMeUp.* TO 'gameAdmin'@'localhost' WITH GRANT OPTION;

-- Peut lire et update les informations pour le joueur (nouvveau score par example)
GRANT SELECT, UPDATE, INSERT ON db_shootMeUp.t_level TO 'gameManager'@'localhost';

-- récupérer les informations Ennemis, obstacles
GRANT SELECT ON db_shootMeUp.t_obstacle TO 'gameManager'@'localhost';
GRANT SELECT ON db_shootMeUp.t_enemy TO 'gameManager'@'localhost';

-- Aucun privilege pour les joueurs
REVOKE ALL PRIVILEGES ON db_shootmeup.* FROM 'player'@'localhost';

-- Recharger les privilèges
FLUSH PRIVILEGES;