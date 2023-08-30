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
 * Selectionne un mot en fonction du niveau de difficulté choisi.
 * @param int $level : niveau de difficulté.
 * @return string : retourne un mot choisi en fonction du niveau de difficulté. 
 */
function wordSelect($level)
{}



// Gestion de la logique métier




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
 * Défini si le jeu doit s'arrêter 
 *
 * @param array $wordArray : tableau contenant le mot du jeu.
 * @param integer $attempts : nombre d'essais restants 
 * @return bool : status de la boucle de jeu 
 */
function gameStatus(array $wordArray, int $attempts)
{}


// Gestion de l'affichage  
/**
 * Permet l'affichage du tableau contenant les lettres 
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

/**
 * Demande à l'utlisateur d'entrer une lettre. 
 *
 * @param string $letter : Lettre donnée par un jour 
 * @return string : retroune la lettre entrée par l'utilisateur. 
 */
function inputLetter(string $letter)
{}

