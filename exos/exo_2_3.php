<?php 

/**
 * Undocumented function
 *
 * @return void
 */
function macron() : void
{
    $age = readline('age ? ');
    $sexe = readline('sexe? ');

    $isTaxed  = true; // bool : défini si un Zorg sera taxé 

    if(($age < 21 ) || ($age > 35 && $sexe == 'femme'))
    {
        $isTaxed = false;
    }

    echo $isTaxed ? 'taxé !' : 'non taxé! ';
}

macron();

//corection 


// if (($genre == "M" && $age > 20) || ($genre == "F" && ($age > 17 && $age < 36)));