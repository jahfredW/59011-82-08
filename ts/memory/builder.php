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
        $array[] = ["cardId" => $i];
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
    // Sous tableau
    $subArray = [];
    // Src dynamique
    $srcIndex = 0;
    // on bocule sur le array et on crée des sous groupes de tableau 
    for($i = 0; $i < count($array); $i++){
        if($i % 2 == 0 && $i != 0){
            array_push($newArray, $subArray);
            $subArray = [];
            $srcIndex += 1;
        } 
        // attribution du même src pour le même groupe d'images 
        $subArray[] = $array[$i];
        $array[$i]['src'] = $srcIndex + 1;

       
    
    }
    // on trie le tableau initial, par cardId. 
    usort($array, function($a, $b) {
        return $a['cardId'] <=> $b['cardId'];
    });

    
    return [$newArray, $array];
}

/**
 * Function qui affiche les cards 
 *
 * @param [int] $cardId : id de la card
 * @param [srting] $src : source de la card 
 * @return void
 */
function cardDisplay($cardId, $src)
{
    echo "<div class=\"img-box \"><img src=\"assets/$src.jpg\" data-image=\"$cardId\" class=\"off\" /></div>";
}



