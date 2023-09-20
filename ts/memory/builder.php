<?php

/**
 * construction mélange de nombres dans un tableau 
 *
 * @param integer $cardNumber
 * @param integer $cardPerLine
 * @return void
 */
function arrayMix(int $cardNumber)
{
    $array = [];
    for ($i = 0; $i < $cardNumber; $i++){
        $array[] = $i;
    }
    // mélange les éléments du tableau 
    shuffle($array);
    print_r($array);

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
    for($i = 0; $i < count($array); $i++){
        if($i % 2 == 0 && $i != 0){
            array_push($newArray, $subArray);
            $subArray = [];
        } 
        $subArray[] = $array[$i];
        
    }
    return $newArray;
}



$arrayCards = arraybuilder(20);


