<?php 

require './TriangleRectangle.class.php';

class Pyramide extends TriangleRectangle
{

    /*****************Attributs***************** */
    private $_width;

    /*****************Accesseurs***************** */
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
        return 2 * parent::getPerimeter() + 3 * $this->getWidth();
    }

    public function getVolume()
    {
        var_dump(parent::getArea());
        return parent::getArea() * $this->getWidth();
    }

    private function display()
    {
        $output = "";
        $output .= "Height:" . $this->getHeight() . "\n";
        $output .= "Width:" . $this->getWidth() . "\n";
        $output .= "Perimetre:" . $this->getPerimeter() . " cm" . "\n";
        $output .= "Volume:" . $this->getVolume() . " cm3" . "\n";

        return $output;
    }

    


}

$py = new Pyramide(["height" =>3, "width" => 3, "base" => 2 ]);
echo $py;