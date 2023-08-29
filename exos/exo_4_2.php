<?php 

$tab = [
    "1" => 1,
    "2" => 2,
    "3" => 3
];

/**
 * Fonction de recherche d'une valeur dans un tableau
 * Retourne la clé si trouvée, "not found" sinon. 
 *
 * @param [type] $tab
 * @param [type] $val
 * @return void
 */
function search($tab, $val)
{
    foreach($tab as $key => $value)
    {
        if($value == $val) {
            return $key;
        }
    }
    return "not found";
    }


echo search($tab, 2);