<?php 

class Parametres
{

    /*****************Attributs***************** */
    private static $_config;
    /*****************Accesseurs***************** */
    public static function getConfig()
    {
        return self::$_config;
    }

    /*****************Autres Méthodes***************** */
    

    public static function init()
    {
       
        // récupération du fichier de config : 
        try {
            self::$_config = json_decode(file_get_contents('config.json'), true);
            if(!self::$_config)
            {
                genelog(get_class(). "-". __FUNCTION__, "erreur lors du chargement du fichier", true);
            } else {
                genelog(get_class(). "-". __FUNCTION__, "export fichier réussi", false);
            }
            
        } catch (\Exception $e) {
          echo $e->getMessage();
        }
        
     
    } 

    public static function getHost()
    {
        return self::$_config['host'];
    }

    public static function getPort()
    {
        return self::$_config['host'];
    }

    public static function getDbName()
    {
        return self::$_config['dbname'];
    }

    public static function getUsername()
    {
        return self::$_config['username'];
    }

    public static function getPassword()
    {
        return self::$_config['password'];
    }
    
    public static function buildParamString()
    {
        return "mysql:host=" . self::getHost(). ";port=" . self::getPort() . ";dbname=" . self::getDbName() . ";charset=utf8";
    }
    
}
