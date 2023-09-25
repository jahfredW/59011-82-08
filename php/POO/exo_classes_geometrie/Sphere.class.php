<?php 

require "Cercle.class.php";

class Sphere extends Cercle
{

    /*****************Attributs***************** */

    /*****************Accesseurs***************** */
  
    
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
        return $this->roundResult(4 * parent::getPerimeter());
    }
    
    private function roundResult($result)
    {
        return round($result, 2);
    }

    public function getVolume()
    {
        return $this->roundResult(1/3 * parent::getArea() * ($this->getDiameter() / 2));
    }


    private function display()
    {
        $output = "";
        $output .= "Perimetre:" . $this->getPerimeter() . " cm" . "\n";
        $output .= "Volume:" . $this->getVolume() . " cm3" . "\n";


        return $output;
    }
}

$s = new Sphere(["diameter" => 5]);
echo $s;



