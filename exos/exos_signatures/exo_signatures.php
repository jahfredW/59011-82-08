<?php 

// SIGNATURE PUISSANCE 4 

/**
 * Schéma global
 * 
 * 1 - Initialisation des variables de jeu : liées aux joueurs et à la grille de jeu
 * 2 - Définition des conditions de victoires : nombre de tours et jetons à aligner
 * 3 - Positonnement des jetons. changement d'état des cellules 
 * 4 - Vérification si un joueur a gagné 
 * 5 - Changement de tour d'un joueur
 */


/**
 * Function d'initialisation des joueurs  
 * @param int $players :  nombre de joueurs 
 * @param int $player_name : nom joueur 
 * @param int $player_token ! type de jeton utilisé par le joueur 
 * @return void
 */
function initPlayers($players, $player_name, $player_token) {
}

/**   
 * Fonction de construction de la grille de jeu 
 * @param int $largeur :  largeur de la grille 
 * @param int $hauteur :  hauteur de la grille
 * @return array : retourne le tableau de la grille de jeu 
 */
function initGrid($largeur, $hauteur) {
}

/**
 * Met à jour la grille de jeu aevec l'état de la cellule 
 * Est appelée dans changeCellState()
 *
 * @param array $grid
 * @return void
 */
function updateGrid($grid) {

}
/** 
 * Conditions pour gagner
 * @param int $turnNumber : nombre de tours maximal 
 * @param int $winAlign : nombre de jetons à aligner pour gagner 
 */
function winConditions($turnNumber, $winAlign) {
}

/**   
 * Changement d'état d'une cellule 
 * @param int $indice : indice correspondant au numéro du joueur 
 * @param int $x : abscisse de le cellule 
 * @param int $y : ordonnée de la cellule  
 * @return void
 */
function changeCellState($indice, $x, $y) {
}

/** 
 * Logique d'affichage de la cellule 
 * @indice : indice correspondant au numéro du joueur 
 * @param int $x : abscisse de la cellule 
 * @param int $y : ordonnée de la cellule  
 * @param array gridGame : grid game
 *
 *
 */
function cellDisplay($indice, $x, $y, $gridGame) {
}

/**
 * Vérification de la victoire d'un joueur 
 * @param int $indice : indice correspondant au numéro du joueur
 * @param int $x : abscisse de le cellule
 * @param int $y : ordonnée de la cellule
 * @return void
 */
function checkWinner($indice, $x, $y){
}

/**  
 * Vérification du tour du jour 
 * @param int $indice : indice correspondant au numéro du joueur
 * @return int : indice du joueur qui a le tour courant 
 */
function checkTurn($indice) {
}

/** 
 * Fonction qui copie les n valeurs de l'intervale [i, i + n - 1] de la liste X aux positions 
 * [j, j + n - 1] de la liste Y et RESPECTIVEMENT. 
 * La copie doit s'arrêter au caoù on atteint la fin d'une liste avant d'avoir copié n éléments.
 * @param int $n : nombre d'éléments à copier = longueur de la liste 
 * @param array $A : array A 
 * @param array $B : array B 
 * @param int $i : indice de position dans la liste A 
 * @param int $j : indice de position dans la liste B 
 * @param int $n : nombre d'éléments à copier
 */
function listeCopy(array $A, array $B = null, int $i = 0, int $j = 0, $n = 0) {
    // parcours de la liste A avec indice de départ défini et indice de fin
    // 1 - cas d'erreur : indice départ < 0 ou > taille de la liste
    // 2 - indice de fin < indice de départ ou indice de fin > taille de la liste 
    // 3 - indice
    // sinon on peut boucler : 
    // (count(liste) - 1) - $index -> longueur de la liste restante à ne pas dépasser 
    $numbersA = [];
    if($i < 0 || $i > count($A) - 1 || $n > (count($A) - 1) - $i || 0 <= 1 - $n){
        return "valeur impossible";
    }
    for($index = $i; $index <= $n; $index++) {
        // sauvegarde des valeurs dans un nouveau tabeau
        echo $A[$index];
        $numbersA = $A[$index];

    }

    // 
}

listeCopy([1, 2, 3, 4, 5, 6], [], 1, 0, 2 );