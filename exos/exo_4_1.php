<?php

/**
 * Undocumented class
 */
class build
{

    private array $array;
    private int $width;
    private int $height;

    public function __construct($width = 5, $height = 5)
    {
        $this->width = $width;
        $this->height = $height;
        $this->array = [];
        $this->init();
    }

    /**
     * Constuction du plateau
     *
     * @return void
     */
    private function init(): void
    {
        $lineNumbers = 1;
        $letter = 0;
        for ($x = 0; $x <= $this->width * 2; $x++) {
            $line = [];
            for ($j = 0; $j <= $this->height * 2; $j++) {
                if ($x % 2 == 0 && $x != 0) {
                    if ($j % 2 == 0) {
                        $line[$j] = '|';
                    } else {
                        $line[$j] =  '-';
                    }
                } else {
                    if ($x == 0) {
                        if ($j % 2 != 0) {
                            $line[$j] = chr(65 + $letter);
                            $letter++;
                        } else {
                            $line[$j] = '|';
                        }
                    } else {
                        if ($j % 2 == 0) {
                            $line[$j] = '|';
                        } else {
                            $line[$j] =  $lineNumbers;
                            $lineNumbers++;
                        }
                    }
                }
            }
            $this->array[$x] = $line;
        }
    }

    /**
     * Impression du plateau
     *
     * @return void
     */
    public function printArray(): void
    {
        print_r($this->array);
    }

    /**
     * Recherche d'un chiffre dans le tableau 
     *
     * @param [type] $value
     * @return array
     */
    public function searchValue($value): void
    {
        for ($x = 0; $x <= $this->width * 2; $x++) {
            for ($j = 0; $j <= $this->height * 2; $j++) {

                if ($this->array[$x][$j] == $value) {
                    echo "x : " . ceil($j / 2) . PHP_EOL;
                    echo "y : " . ceil($x / 2) . PHP_EOL;
                }
            }
        }
    }
}

// Interface utilisateur
class Menu
{
    public static $lines = 0;
    public static $columns = 0;

    public static function buildTab(): void
    {
        do {
            self::$lines = readline("nombre de lignes : ");
            self::$columns = readline("nombre de colonnes : ");
        } while (self::$lines <= 0 && self::$columns <= 0 && !preg_match("/^[\d]+$/", self::$columns) && !preg_match("/^[\d]+$/", self::$lines));
    }
}


// print_r($plateau->searchValue(8));

// Menu::buildTab();
// echo Menu::$lines . PHP_EOL;
// echo Menu::$columns . PHP_EOL;
// $plateau = new build(Menu::$lines, Menu::$columns);
// $plateau->printArray();

/**
 * Gestion du tableau à une dimension
 */
class SimpleArray
{
    private array $array;

    public function __construct(array $array = [])
    {

    }
}


class SimpleArrayBuilder
{
    public static $numbersTab = [];
    

    public static function buildTab(): void
    {
 
            do
            {
                $number = readline("Entrez un entier : ");
                if($number != 0 && preg_match("/^[\d]+$/", $number))
                self::$numbersTab[] = $number;
            }
            while($number != 0);
            
   
    }

    public static function printTab(): void
    {
        print_r(self::$numbersTab);
    }

    public static function sortTab(): void
    {
        sort(self::$numbersTab);
        print_r(self::$numbersTab);
    }
}

SimpleArrayBuilder::buildTab();
SimpleArrayBuilder::printTab();
SimpleArrayBuilder::sortTab();