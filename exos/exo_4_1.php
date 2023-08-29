<?php

/**
 * Undocumented class
 */
class builder
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
 * Construction tableau 
 */
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
        asort(self::$numbersTab);
        print_r(self::$numbersTab);
    }

    /**
     * Invite utilisateur avec vérification entier 
     * et choix de l'invite
     *
     * @return void
     */
    public static function saisirEntier($positif, $inviteChoix): void
    {
        $inviteListe = [
            1 => "Entrez un nombre positif :" 
        ];
    }
}

// SimpleArrayBuilder::buildTab();
// SimpleArrayBuilder::printTab();
// SimpleArrayBuilder::sortTab();


////////////////////

// tableau contenant les invite utilisateurs
$inviteTab = [
    "1" => "1 : Entrez une largeur : ",
    "2" => "2 : Entrez une hauteur : ",
    "3" => "3 : Entrez un nombre entier positif : ",
];

$tabHauteur = [];
$tabLargeur = [];
$tabInteger = [];
/**
 * Construction tableau 
 */
function creerTableau() : array
{
    
    global $inviteTab;
    global $tabHauteur;
    global $tabLargeur;
    global $tabInteger;

    do
    {   
        
        foreach($inviteTab as $invite)
        {
            echo $invite. PHP_EOL;
        }
    
        $typeInvite = readline("quelle type d'invite voulez vous saisir : ");

        do
        {   
            $number = saisirEntier($typeInvite);
            $number != 0 && $typeInvite == "1"  ? $tabLargeur[] = $number : null;
            $number != 0 && $typeInvite == "2"  ? $tabHauteur[] = $number : null;
            $number != 0 && $typeInvite == "3"  ? $tabInteger[] = $number : null;
        } while($number != 0);
    
    } while ($typeInvite > 0 || !preg_match("/^[\d]+$/", $typeInvite));
    

    
    return [$tabLargeur, $tabHauteur, $tabInteger];
}

/**
 * Vérification de la saisie utilisateur
 * Si l'input est bien un nombre entier
 *
 * @return integer
 */
function saisirEntier($typeInvite) : int
{
    global $inviteTab;
    
    if (!in_array($typeInvite, array_keys($inviteTab))){
        return 0;
    }

    do
    {   
        $number = readline($inviteTab[$typeInvite]);
        
    } while ($number < 0 || !preg_match("/^[\d]+$/", $number));

    return $number;
}

$tab = creerTableau();
print_r($tab);