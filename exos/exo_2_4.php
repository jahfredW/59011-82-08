<?php

$total = 100;

$score = 12.5;
$scoresCandidats = [25, 50, 30];
$status = "";
$balolotageFavorable = false;


// test si il est élu : 
if( $score > 49){
    $status = "élu";
} 
// si non élu , deux cas : ballotage ou echec 
elseif ($score <= 12.5)
{
    $status = "non élu";
}
// cas de ballotage 
else {
    // vérifier si ballotage favorable :
    foreach($scoresCandidats as $scoreCandidat)
    {
        if($score >= $scoreCandidat)
        {
            $status = "ballotage favorable";
        }
    }
    // vérifier si ballotage defavorable :  
    // vérifier si un candidat est victorieux : 
    // vérifier si égalité de ballotage / 
}



// // vérifier que la participation 

// // si score candidat > 100 - 12.5, alors élu 
// if ($score > 51) {
//     $status = "elu";
//     // conditiond de ballotage 
// } elseif ($score >= 12.5) {
//     foreach ($scoresCandidats as $scoreCandidat) {
//         if($scoreCandidat <= 50)
//         {
//             if ($score <= $scoreCandidat)
//             {
//                 var_dump('ici');
//                 $status = "non favori";
//             } else {
//                 $status = "favori";
//             }
                
//         } else {
//                 $status = "loser";
//                 break;
//             }
//         }
        
//     }
// else {
//     $status = "loser";
// }

// echo $status;



