<?php

/**
 * Undocumented function
 *
 * @param string $invite
 * @param boolean $positif
 * @return void
 */
function demanderEntier(string $invite, bool $positif = false) : int
{
    do 
    {
        $number = readline($invite);
    }
    while(!preg_match('/^(-)?[\d]+$/', $number) || ($positif && $number < 0));

    return $number;
}


/**
 * Fonction qui permet de construire un tableau 
 *
 * @return array
 */
function construireTableau() : array
{
    do
    {
        $number = demanderEntier('Veuillez saisir un nombre : ', false);
        $tab[] = $number;
    }
    while($number != 0);
    array_pop($tab);

    return $tab;
}

$tab = construireTableau();
print_r($tab);
