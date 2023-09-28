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

    public function attaque($player, $debug) : void
    {
        $scoreJoueur = Game::lanceDe();
        $scoreMonstre = Game::lanceDe();
        if($debug){
            echo "le montre attaque : " . $scoreMonstre . "joueur  " . $scoreJoueur . PHP_EOL;
        } 
        // attauqe normale 
        if($scoreJoueur < $scoreMonstre)
        {
            //  l'attaque du monstre réussi, le joueur subi des dégats  
            $player->subirDegats(10, $debug);
        }

        // attaque avec le sort magique 
        $scoreMagique = Game::lanceDe();
        if($scoreMagique != 6){
            $player->subirDegats($scoreMagique * 5, $debug);
        }
              
           
    }


}