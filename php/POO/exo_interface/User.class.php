<?php

class User
{

    /*****************Attributs***************** */
    protected $_username;

    /*****************Accesseurs***************** */
    public function getUsername()
    {
        return $this->_username;
    }

    public function setUsername(string $username)
    {
        $this->_username = $username;
    }
    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
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
    public function __toString()
    {
        return $this->getUsername() . ": " . ($this->isReading() ? "reading" : "not reading");
    }

    public function isReading()
    {
        return random_int(0,1) == 1 ? true : false;
    }


}