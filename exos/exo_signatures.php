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
function listeCopy($A, $B, $i, $j, $n) {
}

