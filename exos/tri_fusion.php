<?php 

/**
 * scinde le tableau en deux parties égales et 
 * Effectue de manière récursive son tri
 *
 * @param array $tab
 * @return array
 */
function triFusion(array $tab){
    if(count($tab) <= 1){
        return $tab;
    }
    $middle = floor(count($tab) / 2);
    $leftArray = array_slice($tab, 0, $middle);
    $rightArray = array_slice($tab, $middle);
    $leftArray = triFusion($leftArray);
    $rightArray = triFusion($rightArray);
    return fusion($leftArray, $rightArray);
    
}


/**
 * Undocumented function
 *
 * @param array $leftArray
 * @param array $rightArray
 * @return array retourne le tableau fusionné trié
 */
function fusion(array $leftArray, array $rightArray){
    $sortedTab = [];
    $leftIndex = 0;
    $rightIndex = 0;
    // parcours des deux tableaux
    while($leftIndex < count($leftArray) && $rightIndex < count($rightArray)){
        // Si la valeur du tableau de gauche < la valeur du tableau de droite
        // On ajoute la valeur du tableau de gauche dans le tableau fusionné
        // sinon on ajoute la valeur de droite. 
        if($leftArray[$leftIndex] <= $rightArray[$rightIndex]){
            $sortedTab[] = $leftArray[$leftIndex];
            $leftIndex++;
        }else{
            $sortedTab[] = $rightArray[$rightIndex];
            $rightIndex++;
        }
    }

    if ($leftIndex < count($leftArray)){
        $sortedTab = array_merge($sortedTab, array_slice($leftArray, $leftIndex));
    }

    // Fusionner les éléments restants dans $droite (si présents)
    if ($rightIndex < count($rightArray)) {
        $sortedTab = array_merge($sortedTab, array_slice($rightArray, $rightIndex));
    }
    
    return $sortedTab;
}


print_r(triFusion([4,7,1,9,2,5]));