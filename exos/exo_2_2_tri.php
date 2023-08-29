<?php 

/**
 * Classe permettant de trier des tableaux
 */
class TrierTableau
{
    private $tableau;

    public function __construct($tableau)
    {
        $this->tableau = $tableau;
    }

    /**
     * Tri un tableau en utilisant usort
     * Ordre croissant 
     *
     * @return void
     */
    public function sortByUsortUp() : void
    {
        usort($this->tableau, function( $a, $b) { return $a <=> $b; });
    }

    /**
     * Tri un tableau en utilisant usort
     * Ordre décroissant 
     *
     * @return void
     */
    public function sortByUsortDown() : void
    {
        usort($this->tableau, function( $a, $b) { return $b <=> $a; });
    }
    /**
     * Affiche le tableau 
     *
     * @return void
     */
    public function printTableau() : void
    {
        foreach ($this->tableau as $key => $value) {
            echo $key. " => ". $value. PHP_EOL;
        }
    }
}

$tab = [2,4,5,7,6];

$sort = new TrierTableau($tab);
$sort->sortByUsortDown();
$sort->printTableau();