<?php

class Voiture
{

    /*****************Attributs***************** */
    private $_couleur = "";
    private $_marque = "";
    private $_modele = "";
    private $_km = 0;
    private $_motorisation = "Diesel";

    /*****************Accesseurs***************** */

    public function getCouleur()
    {
        return $this->_couleur;
    }

    public function setCouleur($couleur)
    {
        $this->_couleur = $couleur;
    }

    public function getMarque()
    {
        return $this->_marque;
    }

    public function setMarque($marque)
    {
        $this->_marque = $marque;
    }

    public function getModele()
    {
        return $this->_modele;
    }

    public function setModele($modele)
    {
        $this->_modele = $modele;
    }

    public function getKm()
    {
        return $this->_km;
    }

    public function setKm($km)
    {
        $this->_km = $km;
    }

    public function getMotorisation()
    {
        return $this->_motorisation;
    }

    public function setMotorisation($motorisation)
    {
        $this->_motorisation = $motorisation;
    }

    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoie vrai si le tableau est vide
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
        return " Cette voiture est un " . $this->getModele() . " de la marque " 
        . $this->getMarque() . " de couleur " . $this->getCouleur() . " de motorisation " . $this->getMotorisation()
        . " avec " . $this->getKm() . " km";
    }

    /**
     * Mise à jour des kilomètres
     *
     * @param integer $nb_km
     * @return void
     */
    public function rouler(int $nb_km)
    {
        // récupérattion du nombre de kilomètres
        $km = $this->getKm();
        // incrémentation et mise à jour du nombre de kilomètres. 
        $this->setKm($km + $nb_km);
    }
 
}

// main 

$vehicule1 = new Voiture(["couleur" => "rouge", "marque" => "Citroen", "modele" => "kadjar"]);
$vehicule2 = new Voiture(["couleur" => "rouge", "marque" => "Citroen", "modele" => "c4", "km" => 10000]);
$vehicule2->rouler(40);

