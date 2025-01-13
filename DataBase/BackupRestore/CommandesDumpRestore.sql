-- Commande Dump
docker exec -i db mysqldump -u root -proot db_shootMeUp > E:\PROJETS\Year2\P_ShootMeUp\ShootMeUp\DataBase\BackupRestore\db_shootMeUp_dump.sql

-- Comande Restore
docker exec -i db mysql -u root -proot db_shootMeUp < E:\PROJETS\Year2\P_ShootMeUp\ShootMeUp\DataBase\BackupRestore\db_shootMeUp_dump.sql

-- Commandes sans chemins absolu
-- dump
mysqldump -u [username] -p db_spaceinvaders > db_spaceinvaders_backup.sql

-- Restore
mysql -u [username] -p db_spaceinvaders < db_spaceinvaders_backup.sql