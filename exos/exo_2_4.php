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
        if($scoresCandidats[$index] > 49)
        {
            $loose = true;
            $flag = false;
        }

        $index ++;
    }
    return $loose;
}


// test si il est élu : 
if( $score > 49){
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
    if (in_array($score, $scoresCandidats) && max($scoresCandidats) == $score) {
        $status = "égalité de balotage favorable";
    // égalité défavorable
    } elseif(in_array($score, $scoresCandidats) && max($scoresCandidats) != $score)
    {
        $status = "égalité de balotage defavorable";
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

