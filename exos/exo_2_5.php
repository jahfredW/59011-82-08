<?php 

$accidents = 1;
$permis = 1;
$age = 26;
$fidelite = true;
$formule = 0;

$codeArray = [
    'bleu' => 3,
    'vert' => 2,
    'orange' => 1,
    'rouge' => 0,
    'refus' => -1
];

// points positifs et points négatifs


if($age > 24){
    $formule += 1;
}
if($permis > 1){
    $formule += 1;
}

$formule = $formule - $accidents;

if($fidelite && $formule > 0)
{
    $formule += 1;
}


echo $formule;

   


    
