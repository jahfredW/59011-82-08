<?php

class Rectangle
{

    /*****************Attributs***************** */
    private float $_longueur = 0;
    private float $_largeur = 0 ;

    /*****************Accesseurs***************** */
    public function getLongueur()
    {
        return $this->_longueur;
    }

    public function setLongueur($longueur)
    {
        $this->_longueur = $longueur;
    }

    public function getLargeur()
    {
        return $this->_largeur;
    }

    public function setLargeur($largeur)
    {
        $this->_largeur = $largeur;
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
        return $this->afficherRectangle();
        
    }

    /**
     * retourne le périmétre 
     *
     * @return float perimètre du rectangle. 
     */
    public function perimetre()
    {
        return $this->getLargeur() * 2 +  $this->getLongueur() * 2;
    }

    /**
     * Calcul de l'aire 
     * @return float aire du rectangle
     */
    public function aire()
    {
        return $this->getLargeur() * $this->getLongueur();
    }

    /**
     * Vérifie si la figure géométrique est un carré 
     *
     * @return void
     */
    private function estCarre()
    {
        return $this->getLargeur() == $this->getLongueur();
    }

    public function afficherRectangle()
    {
        $output = "";
        $output .= "Longueur:" . $this->getLongueur() . "\n";
        $output .= "Largeur:" . $this->getLargeur() . "\n";
        $output .= "Perimetre:" . $this->perimetre() . "\n";
        $output .= "Aire:" . $this->aire() . "\n";
        $output .= $this->estCarre() ? "C'est un carré" : "Ce n'est pas un carré";

        return $output;
    }

   
}

$rectangle = new Rectangle(["longueur" => 3, "largeur" => 3]);
echo $rectangle;

