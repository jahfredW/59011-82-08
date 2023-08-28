<?php 



function passageEnCaisse(){
    $totalPrice = 0;
    $articles = 0;

    do{
        $price = readline("saisissez voter prix : ");
        if($price < 0)
        {
            echo "prix négatif" .PHP_EOL;
        }
        else {
            $totalPrice += $price;
            $articles += 1;
        }
        
    
    }while($price != 0);

    printArticles($totalPrice, $articles);
    checkMonnaie($totalPrice);
}


function checkMonnaie($totalPrice)
{
    $dix = 0;
    $cinq = 0;
    $un = 0;

    // boucle des billets de 10 
    while($totalPrice >= 10)
    {
        $totalPrice = $totalPrice - 10;
        $dix += 1;
    }

    if($totalPrice >= 5)
    {
        $totalPrice -= 5;
        $cinq += 1;
    }
    

    // boucle des billets de 10 
    while($totalPrice > 0)
    {
        $totalPrice = $totalPrice - 1;
        $un += 1;
    }

    

    printTicket($dix, $cinq, $un);
    
}

function printTicket($dix, $cinq, $un)
{
    echo " dix :  ".  $dix . PHP_EOL; 
    echo " cinq :  ".  $cinq . PHP_EOL; 
    echo " un :  ".  $un . PHP_EOL; 
}


function printArticles($totalPrice, $articles)
{
    echo "nombre d'articles : ". $articles. PHP_EOL; 
    echo "votre somme est : ". $totalPrice. PHP_EOL; 
    
}

passageEnCaisse();