<?php 

/**
 * Classe permettant de trier des tableaux
 * @attributs : $tableau 
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
    
    /**
     * Méthode de tri de base, peut prendre un flag en paramètre. 
     *
     * @param [type] $flag choix : SORT_REGULAR, SORT_STRING, SORT_LOCALE_STRING, SORT_NUMERIC
     * @return void
     */
    public function basicSort($flag = null): void
    {
        try {
            sort($this->tableau, $flag);
        } catch (Exception $e) {
            echo $e->getMessage();
        }
        
    }
}

/**
 * Permet de construire et d'afficher un tableau 
 */
class ArrayBuilder2d
{
    private int $width;
    private int $heigth; 
    private array $myTab;


    public function __construct(int $width, int $heigth)
    {
        $this->width = $width;
        $this->heigth = $heigth;
        $this->myTab = [];
        $this->build();
    }

    /**
     * méthode de construction du tableau 
     *
     * @return void
     */
    private function build(): void
    {
        for ($i = 0; $i < $this->width; $i++) {
            for ($j = 0; $j < $this->heigth; $j++) {
                $this->myTab[$i][$j] = [ "x" => $j, "y" => $i];
            }
        }
    }

    public function lazyPrint() : void
    {
        $letterY = 65;
        $letterX = 65;
        for($y = 0; $y < $this->heigth; $y++) {
            echo PHP_EOL;
            echo " --------------------------------------------------------------";
            echo PHP_EOL;
            echo chr($letterY);
            $letterY += 1;
            for($x = 0; $x < $this->width; $x++) {
                $line = $this->myTab[$y][$x]["y"]. " ". $this->myTab[$y][$x]["x"];
                if($x == 0 ){
                    echo " | ";
                }
                echo $line . " | ";
            }
            
    }
    echo PHP_EOL;
    echo " --------------------------------------------------------------";
}


}


$tab = new ArrayBuilder2d(10, 10);
$tab->lazyPrint();

// $tab = ["hello",4,5,7,6];

// $sort = new TrierTableau($tab);
// $sort->basicSort(TEST);
// $sort->printTableau();