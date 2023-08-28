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
    private function init() : void
    {
        $lineNumbers = 1;
        $letter = 0;
        for($x = 0; $x <= $this->width * 2; $x++){
        $line = [];
        for($j = 0; $j <= $this->height * 2; $j++){
            if($x % 2 == 0 && $x != 0)
            {
                if($j % 2 == 0)
                {
                    $line[$j] = '|';
                } else  {
                    $line[$j] =  '-';
                }
                
            } 
            else 
            {
                if($x == 0){
                    if($j % 2 != 0){
                        $line[$j] = chr(65 + $letter) ;
                        $letter ++;
                    } else {
                        $line[$j] = '|';
                    }
                    
                } else {
                    if($j % 2 == 0)
                    {
                        $line[$j] = '|';
                    } 
                    else  {
                        $line[$j] =  $lineNumbers;
                        $lineNumbers ++;
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
    public function printArray() : void
    {
        print_r($this->array);
    }

    /**
     * Recherche d'un chiffre dans le tableau 
     *
     * @param [type] $value
     * @return array
     */
    public function searchValue($value) : void
    {
        for($x = 0; $x <= $this->width * 2; $x++)
        {
            for($j = 0; $j <= $this->height * 2; $j++)
            {
               
                if($this->array[$x][$j] == $value)
                {
                    echo "x : " . ceil($j / 2) . PHP_EOL;
                    echo "y : " . ceil($x / 2) . PHP_EOL;
                }
                
            }
        }
    }
}


$plateau = new build(5, 5);
print_r($plateau->searchValue(8));