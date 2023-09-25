<?php 

require './ICalculDimensionInterface.class.php';

class Rectangle implements ICalculDimensionInterface
{

    /*****************Attributs***************** */
    private $_height;
    private $_width;

    /*****************Accesseurs***************** */

    public function getHeight()
    {
        return $this->_height;
    }

    public function setHeight(float $height)
    {
        $this->_height = $height;
    }

    public function getWidth()
    {
        return $this->_width;
    }

    public function setWidth(float $width)
    {
        $this->_width = $width;
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
        return 2 * ($this->getHeight() + $this->getWidth());
    }

    public function getArea()
    {
        return $this->getWidth() * $this->getHeight();
    }

    public function isSquare()
    {
        return $this->getWidth() == $this->getHeight();
    }

    private function display()
    {
        $output = "";
        $output .= "Height:" . $this->getHeight() . "\n";
        $output .= "Width:" . $this->getWidth() . "\n";
        $output .= "Perimetre:" . $this->getPerimeter() . "\n";
        $output .= "Aire:" . $this->getArea() . "\n";
        $output .= $this->isSquare() ? "C'est un carré" : "Ce n'est pas un carré";

        return $output;
    }


}


// public function getPerimeter();
// public function getArea();
// public function isSquare();
// public function display();