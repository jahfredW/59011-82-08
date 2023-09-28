<?php 

class Player
{

    /*****************Attributs***************** */
    private $_life;
    private $_score;

    #region /*****************Accesseurs***************** */
    public function getLife()
    {
        return $this->_life;
    }

    public function setLife($life)
    {
        $this->_life = $life;
    }

    
    public function getScore()
    {
        return $this->_score;
    }

    public function setScore(int $score)
    {
        $this->_score = $score;
    }
    #endregion
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        $this->setLife(50);
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

    /**
     * vérifie si le joueur est vivant
     *
     * @return boolean
     */
    public function EstVivant() : bool
    {
        return $this->getLife() > 0;
    }


    public function attaque($monster) : void
    {
        $scoreJoueur = Game::lanceDe();
        $scoreMonstre = Game::lanceDe();

        echo "mon hero attaque : " . $scoreJoueur . "monstre  " . $scoreMonstre . PHP_EOL;

        $score = $this->getScore();

        if($scoreJoueur >= $scoreMonstre)
        {
            echo "***                                hero gagne" . PHP_EOL;
            //  monstre tué, on incrémente le score du tué de 1 si monsre facile ou 2 si difficile 
            if($monster instanceof EasyMonster){
                $this->setScore($score += 1);
            } else {
                $this->setScore($score += 2);
            }
            // on défini le status is_alive du monstre sur false
            $monster->setIsAlive(false);
    }}

    public function subirDegats($degats) : void
    {
        $life = $this->getLife();
      
        // déclenchement du bouclier 
        $protection = Game::lanceDe();
        if($protection > 2 )
        {
            $life -= $degats;
            $this->setLife($life);
            // remise des degats à 0 si degats < 0 
            if($life < 0){
                $life = 0;
            }
        }
    

        echo "hero subi des degats : " . $degats . " , reste " . $this->getLife() . PHP_EOL;
    }
}





