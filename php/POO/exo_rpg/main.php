<?php

function chargerClasse($classe)
{
require $classe. ".class.php";
}
spl_autoload_register("chargerClasse");

// main

// instanciation des joueurs : 
$hero = new Player();
// echo "points de vie: " . $hero->getLife() . PHP_EOL;


function startGame(Object $hero, bool $debug){
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

    
    
    // vérification si le monstre est en Vie : 
    do {

        // le héro attaque le monstre : 
        $hero->attaque($monster, $debug);
       
        // le monstre attaque le joueur : 
        $monster->attaque($hero, $debug);
       
    }  while($monster->getIsAlive() && $hero->getLife() > 0);
}

echo "Score : " . $hero->getScore() . PHP_EOL;
echo "Tu as tué " . $hero::$easy . " monstres faciles et " . $hero::$hard . " monstres difficiles." . PHP_EOL;  

}

startGame($hero, false);


