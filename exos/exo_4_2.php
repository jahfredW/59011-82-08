<?php 

$tab = [
    "un" => 1,
    "deux" => 2,
    "trois" => 3
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

/**
 * Undocumented function
 *
 * @param [type] $tab tableau dans lequel chercher
 * @param [type] $val valeur à chercher dans le tableau 
 * @return void
 */
function searchArraySearch($tab, $val)
{
    return gettype(array_search($val, $tab)) == "string" ? array_search($val, $tab) : "not found";
}

/**
 * Implémentation de la fonction de recherhche in-array
 * Renvoie l'index de la valeur ! 
 *
 * @param [type] $tab tableau dans lequel chercher 
 * @param [type] $val la valeur à rechercher 
 * @return void
 */
function searchInArray($tab, $val)
{
    return in_array($val, $tab);
}

echo searchInArray($tab, 2);

// méthode de tri la plus adaptée : 
// array-search car renvoie la clé si trouvée, "not found" sinon. 