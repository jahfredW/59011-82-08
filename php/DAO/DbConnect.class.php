<?php 

class DbConnect
{

    /*****************Attributs***************** */
    public static $_instance = null;
    private $pdo = null;

    /*****************Accesseurs***************** */

    public function getPdo()
    {
        return $this->pdo;
    }

    public function setPdo($pdo)
    {
        $this->pdo = $pdo;
    }
    /*****************Constructeur***************** */

    private function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        $this->pdo = new PDO($options["dsn"], $options["user"], $options["password"], $options["driver_options"] = NULL);
        $this->pdo->setAttribute(\PDO::ATTR_ERRMODE, \PDO::ERRMODE_EXCEPTION);
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
    public static function getInstance($options)
    {
        if (self::$_instance == null){
            try {
                
                $db = new DbConnect($options);
                self::$_instance = $db;
                echo "connexion réussie";
            } catch (\Exception $e) {
                echo "Error: ".$e->getMessage();
            }  
        }
        return self::$_instance;
    }

    


}