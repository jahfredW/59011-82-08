<?php 

require './ICalculDimensionInterface.class.php';

class Cercle implements ICalculDimensionInterface
{

    /*****************Attributs***************** */
    private $_diameter;

    /*****************Accesseurs***************** */

    public function getDiameter()
    {
        return $this->_diameter;
    }

    public function setDiameter(float $diameter)
    {
        $this->_diameter = $diameter;
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
        return $this->display();
    }

    public function getPerimeter()
    {
        return pi() * $this->getDiameter();
    }

    public function getArea()
    {
        return pi() * pow($this->getDiameter() / 2, 2);
    }


    private function display()
    {
        $output = "";
        $output .= "Perimetre:" . $this->getPerimeter() . "\n";
        $output .= "Aire:" . $this->getArea() . "\n";

        return $output;
    }


}

