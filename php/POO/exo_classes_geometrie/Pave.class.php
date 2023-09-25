<?php 

require "Rectangle.class.php";

class Pave extends Rectangle
{

    /*****************Attributs***************** */
    private $_base;

    /*****************Accesseurs***************** */
    public function getBase()
    {
        return $this->_base;
    }

    public function setBase(float $base)
    {
        $this->_base = $base;
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
        return 2 * parent::getPerimeter() + 4 * $this->getHeight();
    }

    public function getVolume()
    {
        return parent::getArea() + $this->getBase();
    }

    private function display()
    {
        $output = "";
        $output .= "Height:" . $this->getHeight() . "\n";
        $output .= "Width:" . $this->getWidth() . "\n";
        $output .= "Perimetre:" . $this->getPerimeter() . " cm" . "\n";
        $output .= "Volume:" . $this->getVolume() . " cm3" . "\n";

        $output .= $this->isSquare() ? "La base est carrée" : "La base en'est pas carrée";

        return $output;
    }


}



