<?php

function chargerClasse($classe)
{
require $classe. ".class.php";
}
spl_autoload_register("chargerClasse");

// main

// instanciation des joueurs : 

$hero = new Player();
echo "points de vie: " . $hero->getLife() . PHP_EOL;


// game Loop 
While($hero->getLife() > 0)
{
    // choix aléatoire d'un monstre 
    $random = random_int(0,1);
    switch($random)
    {
        case 0:
            $monster = new EasyMonster;
            break;
        case 1:
            $monster = new HardMonster;
            break;
    }

    // le héro attaque le monstre : 
    $hero->attaque($monster);
    
    // vérification si le monstre est en Vie : 
    if($monster->getIsAlive()){
       
        // le monstre attaque le joueur : 
        $monster->attaque($hero);
       
    }

    echo $hero->getLife() . PHP_EOL;
}