<?php

/**
 * construction mélange de nombres dans un tableau 
 *
 * @param integer $cardNumber
 * @param integer $cardPerLine
 * @return array
 */
function arrayMix(int $cardNumber)
{
    $array = [];
    for ($i = 0; $i < $cardNumber; $i++){
        $array[] = $i;
    }
    // mélange les éléments du tableau 
    shuffle($array);

    return $array;
}

/**
 * Génration de paires aléatoires pour le tableau 
 *
 * @param [type] $array
 * @return void
 */
function arrayBuilder($array)
{
    // Puis on construits les sous tableaux de paires. 
    $newArray = [];
    $subArray = [];
    $srcIndex = 0;
    for($i = 0; $i < count($array); $i++){
        if($i % 2 == 0 && $i != 0){
            array_push($newArray, $subArray);
            $subArray = [];
            $srcIndex += 1;
        } 
        // attribution du même src pour le même groupe d'images 
        $subArray[] = ['index' => $array[$i], 'src' => $srcIndex + 1 . ".png"];
    
    }
    return $newArray;
}

function cardDisplay($card, $arrayCards)
{
    foreach($arrayCards as $key => $pair){
        foreach($pair as $key => $value){
            foreach($value as $key => $v){
                echo $v;
            }
        }
    }
    echo "<div class=\"img-box\"><img src=\"\" id=\"$card\" /></div>";
}

$array = arrayMix(10);
$arrayCards = arraybuilder($array);
cardDisplay(5, $arrayCards);


print_r($arrayCards);
