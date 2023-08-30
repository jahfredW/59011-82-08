<?php 

// Gestion de l'initialisation  

/**
 * Initialisation du jeu : nombre de joueurs et niveau de difficulté.
 *
 * @param integer $players : nombre de joueurs.
 * @param integer $level : niveau de difficulté.
 * @return void
 */
function initGame(int $players = 1, int $level = 1)
{}

/**
 * Edition d'un joueur : score et nom du joueur. 
 *
 * @param string $name : nom du joueur 
 * @param integer $score : score du joueur
 * @return void
 */
function setUpPlayer(string $name = "player_test", int $score = 0)
{}

/**
 * Undocumented function
 * @param int $level : niveau de difficulté.
 * @return string : retourne un mot choisi en fonction du niveau de difficulté. 
 */
function wordSelect($level)
{}



// Gestion de la logique métier

/**
 * Undocumented function
 *
 * @param string $letter : Lettre donnée par un jour 
 * @return void
 */
function inputLetter(string $letter)
{}


/**
 * Construit un array contenant les lettres du mot choisi. 
 *
 * @param string $word
 * @return array : retourne un array contenant les lettres du mot choisi. 
 */
function wordArrayBuilder($word)
{}

/**
 * Met à jour l'état d'une cellule ( lettre découverte ou non)
 *
 * @param string $letter
 * @param array $wordArray
 * @return array : retourne le nouveau tableau mis à jour. 
 */
function wordArrayUpdate(string $letter, array $wordArray)
{}

/**
 * Undocumented function
 *
 * @param array $wordArray : tableau contenant le mot du jeu.
 * @param integer $attempts : nombre d'essais restants 
 * @return bool : status de la boucle de jeu 
 */
function gameStatus(array $wordArray, int $attempts)
{}


// Gestion de l'affichage  
/**
 * Permet l'affichage des lettres 
 *
 * @param array $view : la liste des lettres 
 * @return void
 */
function displayLetters( array $view = [])
{}

/**
 * Affiche le dessin de pendu 
 *
 * @param int $attempts : nombre d'essais consommés 
 * @return void
 */
function displayPendu($attempts)
{}

