<?php

$total = 100;

$score = 27;
$scoresCandidats = [14, 25, 25];
$status = "";
$balotageFavorable = false;

/**
 * vérifie le score du candidat est le meilleur
 * Revoie un tableau des valeurs supériereures au score du candidat
 */
function checkArray($scoresCandidats, $score){
    $filteredArray = array_filter($scoresCandidats, function($value) use ($score){
        return $value > $score;
    });
    return $filteredArray;
    }

/** 
 * Vérifie si un nombre >= à 50 est présent dans la tableau
 */
function checkLose($scoresCandidats){
    $flag = true;
    $loose = false;
    $index = 0;
    // foreach( $scoresCandidats as $scoreCandidat){
    //     if($scoreCandidat > 50){
    //         $loose = true;
    //     }
        
    // }
    while($flag && $index < count($scoresCandidats))
    {
        if($scoresCandidats[$index] > 50)
        {
            $loose = true;
            $flag = false;
        }

        $index ++;
    }
    return $loose;
}


// test si il est élu : 
if( $score > 50){
    $status = "élu";
} 
// cas non élu : score inférieur à 12.5 ou candidatq qui a plus de 50  
elseif ($score <= 12.5 || checkLose($scoresCandidats))
{
    $status = "non élu";
}
// cas de ballotage 
else {
    // vérifier si ballotage favorable :
    // égalité favorable
    if (in_array($score, $scoresCandidats)) {
        $status = "égalité de balotage favorable";
    }
    // premier de ballotage
    elseif(count(checkArray($scoresCandidats, $score)) == 0)
    {
        $status = "prem's";
    } 
    else 
    {
        
        $status = "balotage défavorable";
    }
    }


echo $status;

// correction 

// $score1 = readline("Score candidat n°1: ");
// $score2 = readline("Score candidat n°2: ");
// $score3 = readline("Score candidat n°3: ");
// $score4 = readline("Score candidat n°4: ");

// if ($score1 <12.5 || $score2 >50 || $score3 > 50 || $score4 > 50) echo "Le candidat numéro 1 a été battu";
// else if ($score1 > 50) echo "Le candidat numéro 1 est élu";
// else if ($score1 > $score2 && $score1 > $score3 && $score1 > $score4) echo "le candidat numéro 1 se trouve en ballotage favorable";
// else echo "le candidat numéro 1 se trouve en ballotage défavorable";

