<?php 

class DbConnect
{

    /*****************Attributs***************** */
    public static $_instance = [];

    /*****************Accesseurs***************** */

    
    /*****************Constructeur***************** */

    private function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        $this->_instance = new PDO($options["dsn"], $options["user"], $options["password"], $options["driver_options"] = NULL);
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value)
        {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable([$this, $methode])) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }

    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
    {
        return "";
    }

    // instanciation de l'objet selon le design pattern Singleton
    public function getInstance()
    {
        if (!self::$_instance){
            try {
                $db = new DbConnect(["dsn" => "bd", "user" => "fred", "password" => "admin"]);
                self::$_instance = $db;
            } catch (\Exception $e) {
                echo "Error: ".$e->getMessage();
            }
            
            
        }
    }

    
}