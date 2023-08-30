<?php 

// SIGNATURE PUISSANCE 4 

/**
 * Function d'initialisation des joueurs  
 * @param int $players :  nombre de joueurs 
 * @param int $player_name : nom joueur 
 * @param int $player_token ! type de jeton utilisé par le joueur 
 * @return void
 */
function init_players($players, $player_name, $player_token) {
}


/**   
 * Fonction de construction de la grille de jeu 
 * @param int $largeur :  largeur de la grille 
 * @param int $hauteur :  hauteur de la grille
 * @return array : retourne le tableau de la grille de jeu 
*/
function init_grid($largeur, $hauteur) {
}

/**   
 * Changement d'état d'une cellule 
 * @param int $indice : indice correspondant au numéro du joueur 
 * @param int $x : abscisse de le cellule 
 * @param int $y : ordonnée de la cellule  
 * @return void
 */
function change_cell_state($indice, $x, $y) {
}

/**
 * Vérification de la victoire d'un joueur 
 * @param int $indice : indice correspondant au numéro du joueur
 * @param int $x : abscisse de le cellule
 * @param int $y : ordonnée de la cellule
 * @return void
*/
function check_winner($indice, $x, $y){
}

/**  
 * Vérification du tour du jour 
 * @param int $indice : indice correspondant au numéro du joueur
 * @return int : indice du joueur qui a le tour courant 
 */
function check_turn($indice) {
}