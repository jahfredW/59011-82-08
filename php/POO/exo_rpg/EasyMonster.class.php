<?php 

class EasyMonster
{

    /*****************Attributs***************** */
    private $_isAlive;

    /*****************Accesseurs***************** */
    public function getIsAlive()
    {
        return $this->_isAlive;
    }

    public function setIsAlive(bool $isAlive)
    {
        $this->_isAlive = $isAlive;
    }
    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        $this->setIsAlive(true);
        echo "c'est un monstre Facile" . PHP_EOL;
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

    public function attaque($player) : void
    {
        
        $scoreJoueur = Game::lanceDe();
        $scoreMonstre = Game::lanceDe();



        echo "le montre attaque : " . $scoreMonstre . "joueur  " . $scoreJoueur . PHP_EOL;
        if($scoreJoueur < $scoreMonstre)
        {
            //  l'attaque du monstre réussi, le joueur subi des dégats  
            $player->subirDegats(10);
        }
              
           
    }


}