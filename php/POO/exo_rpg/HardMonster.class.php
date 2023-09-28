<?php 

class HardMonster extends EasyMonster
{


    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        $this->setIsAlive(true);
        echo "C'est un montre difficile" . PHP_EOL;
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
        // attauqe normale 
        if($scoreJoueur < $scoreMonstre)
        {
            //  l'attaque du monstre réussi, le joueur subi des dégats  
            $player->subirDegats(10);
        }

        // attaque avec le sort magique 
        $scoreMagique = Game::lanceDe();
        if($scoreMagique != 6){
            $player->subirDegats($scoreMagique * 5);
        }
              
           
    }


}