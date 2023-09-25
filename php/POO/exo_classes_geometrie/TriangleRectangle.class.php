<?php 

require "./ICalculDimensionInterface.class.php";

class TriangleRectangle implements ICalculDimensionInterface
{

    /*****************Attributs***************** */
    private $_base;
    private $_height;

    /*****************Accesseurs***************** */
    public function getBase()
    {
        return $this->_base;
    }

    public function setBase(float $base)
    {
        $this->_base = $base;
    }

    
    public function getHeight()
    {
        return $this->_height;
    }

    public function setHeight($height)
    {
        $this->_height = $height;
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
    public function toString()
    {
        return $this->display();
    }

    public function getPerimeter()
    {
        $hyp = sqrt(pow($this->getHeight(), 2) + pow($this->getBase(), 2));
        return $this->getHeight() + $this->getBase() + $hyp;
    }

    public function getArea()
    {
        return ($this->getBase() * $this->getHeight()) / 2;
    }

    private function display()
    {
        $output = "";
        $output .= "Base:" . $this->getBase() . "\n";
        $output .= "Hauteur:" . $this->getHeight() . "\n";
        $output .= "Perimetre:" . $this->getPerimeter() . "\n";
        $output .= "Aire:" . $this->getArea() . "\n";

        return $output;
    }

    



}