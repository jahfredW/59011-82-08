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
        $this->width = $width + 1;
        $this->heigth = $heigth + 1;
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
                $this->myTab[$i][$j] = [ "x" => $j , "y" => $i , "value"=> null];
            }
        }
    }

    /**
     * Méthode de recherche d'une valeur dans le tableau
     *
     * @param integer $x abscisse de la valeur
     * @param integer $y ordonnée de la valeur
     * @return array
     */
    public function arraySearch(int $x, int $y) : array
    {
        return $this->myTab[$y][$x];
    }

    /**
     * Permet de rensigner une case du tableau en lui passant une valeur. 
     *
     * @param [array] $coord : les coordonnées du point
     * @param [int] $value : la valeur à mettre dans le tableau
     * @return void
     */
    public function addArrayValue(array $coord, int $value): void
    {
        $this->myTab[$coord["y"] + 1][$coord["x"] + 1]["value"] = $value;
    }

    /**
     * Affiche le tableau  le tableau 
     *
     * @return void
     */
    public function lazyPrint() : void
    {
   
    // $interlines  = str_repeat("------", $this->width);
    // $letterX = 65;
    // $Y = 1;
    // echo $interlines . PHP_EOL;
    // for($y = 0; $y < $this->heigth; $y++) {
    //     for($x = 0; $x < $this->width; $x++) {
    //         if( $y == 0 && $x > 0){
    //             echo str_pad(chr($letterX), 2, " ", STR_PAD_LEFT). "  | "; 
    //             $letterX += 1;
    //         } elseif( $y > 0 && $x == 0){
    //             echo str_pad(strval($Y), 2, "_", STR_PAD_LEFT). "  | "; 
    //             $Y += 1;
    //         }
    //         else {
    //             echo str_pad($this->myTab[$y][$x]["value"], 2). "  | ";
    //         }
            
    //     }
    //     echo PHP_EOL;
    //     echo $interlines . PHP_EOL;
    // }

    $interlines = str_repeat("-----", $this->width);
    $letterX = 65;
    $Y = 1;
    echo $interlines. PHP_EOL;
    // affichage de l'entête : 
    echo "    | ";
    for($index = 1 ; $index < $this->width; $index++) {
        echo chr($letterX). "  | "; 
        $letterX += 1;
    }
    echo PHP_EOL;
    echo $interlines. PHP_EOL;
     for($y = 0; $y < $this->heigth; $y++) {
        // affichage des entête de ligne : 
        echo str_pad(strval($y + 1), 2, "_", STR_PAD_LEFT). "  | "; 
        for($x = 0; $x < $this->width - 1; $x++) {
            // affichage des valeurs : 
            echo str_pad($this->myTab[$y][$x]["value"], 1). "  | ";
            }
            echo PHP_EOL;
            echo $interlines . PHP_EOL;
        }
        
    }
}



$tab = new ArrayBuilder2d(10, 10);
$tab->addArrayValue([ "x" => 0, "y" => 0], 1);
$tab->lazyPrint();

// $tab = ["hello",4,5,7,6];

// $sort = new TrierTableau($tab);
// $sort->basicSort(TEST);
// $sort->printTableau();