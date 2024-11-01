-- Gere les comptes des joueurs
CREATE ROLE 'accountManager';

-- Sauvegarde et affiche les scores
CREATE ROLE 'scoreManager';

-- Recupere les informations de configuration du niveau
CREATE ROLE 'levelManager';

-- Creation des utilisateurs
CREATE USER 'd'@'localhost' IDENTIFIED BY 'd';
CREATE USER 'e'@'localhost' IDENTIFIED BY 'e';
CREATE USER 't'@'localhost' IDENTIFIED BY 't';

-- Donner les roles aux utilisateurs
GRANT 'accountManager' TO 'd'@'localhost';
GRANT 'scoreManager' TO 'e'@'localhost';
GRANT 'levelManager' TO 't'@'localhost';

-- Peut lire, créer et supprimer des comptes utilisateurs
GRANT SELECT, INSERT, DELETE, UPDATE ON t_user TO 'accountManager';

-- Peut lire et ajouter des scores
GRANT SELECT, INSERT ON t_score TO 'scoreManager';

-- Pour recuperer le nom du joueur
GRANT SELECT ON t_user TO 'scoreManager';

-- Peut lire toutes les informations de configuration
GRANT SELECT ON t_obstacle TO 'levelManager';
GRANT SELECT ON t_level TO 'levelManager';
GRANT SELECT ON t_apparaître TO 'levelManager';
GRANT SELECT ON t_ennemi TO 'levelManager';

-- Recharger les privilèges
FLUSH PRIVILEGES;