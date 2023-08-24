<?php 


/**
 * Undocumented function
 *
 * @return void
 */
function getCat(){
    // demande age. 
    $age = readline("Age ?");

    // tableau categories
    $catArray = ["poussin", "Pupille", "Minime", "cadet"];

    if( $age >= 6 && $age < 8){
        $cat = $catArray[0];
    } 
    elseif($age >= 8 && $age < 10){
        $cat = $catArray[1];
    }
    elseif($age >= 10 && $age < 12){
        $cat = $catArray[2];
    }
    else {
        $cat = $catArray[3];
    } 

    echo "Vous êtes" . $cat;
}

getCat();