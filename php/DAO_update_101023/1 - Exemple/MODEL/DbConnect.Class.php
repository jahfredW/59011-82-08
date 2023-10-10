<?php
class DbConnect{
    private static $_db;

    public static function getDb()
    {
        return self::$_db;
    }

    public static function init()
    {
        

        try {
            self::$_db =new PDO ("mysql:host=" . Parametres::getHost() . ";port=" . Parametres::getPort() . ";dbname=" . Parametres::getDbName() . ";charset=utf8" ,Parametres::getUsername(),Parametres::getPassword());
            genelog(get_class() . "-" . __FUNCTION__ , "initialisation de la base de donnée", false);
            
        } catch (Exception $e) {
            $errorMessage = $e->getMessage();
            // Enregistrez l'erreur dans un fichier de journal
        
            // Écrire le message d'erreur dans le fichier de journal
            try {
                genelog(get_class() . "-" . __FUNCTION__, $errorMessage,true);
            } catch (\Exception $e) {
                echo $e->getMessage();
            }
            
            
        }
    }
}

