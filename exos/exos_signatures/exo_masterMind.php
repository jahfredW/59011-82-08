<?php 

/**
 * Retourne un tableau contenant les lettres en communs 
 *
 * @param array  $tabInput : liste des lettres proposées par le joueur 
 * @param array $tabOutput : liste des lettres à chercher 
 * @return array : tableau de lettres en communs 
 */
function searchCommonLetter($tabInput, $tabOutput)
{

}

/**
 * recherche le nombre de lettre en commun dans les deux listes
 * Mise à jour du commonArray avec le nombre de lettres 
 *
 * @param array $commonArray
 * @param array $tabOutput
 * @return array : la liste des lettres en communs avec leurs nombres
 */
function searchLetterPosition($commonArray, $tabOutput)
{

}

/**
 * Recherche du nombre de lettres dans la liste à chercher 
 *
 * @param string $letter : la lettre à chercher
 * @param array $tabOutput : le tableau représentant le pattern à chercher 
 * @return int le nombre d'occurence de la lettre dans la liste à chercher 
 */
function searchLetterIterationOutputArray(string $letter, array $tabInput)
{

}


/**
 * Recherche du nombre de lettres dans la liste des lettres proposées par le joueur 
 *
 * @param string $letter : la lettre à chercher
 * @param array $tabOutput : le tableau représentant la liste de l'utilisateur
 * @return int le nombre d'occurence de la lettre dans la liste donnée par le joueur 
 */
function searchLetterIterationInputArray(string $letter, array $tabInput)
{

}

/**
 * Contruction d'un tableau associatif contenant les lettres en communs, 
 * leurs positions et leurs nombres dans les listes
 *
 * @param array $commonList : liste des lettres en communs
 * @param integer $letterIterationInput : le nombre d'occurence de la lettre dans la liste des lettres propos
 * @param integer $letterIterationOutput : le nombre d'occurence de la lettre dans la liste à chercher 
 * @param integer $letterPosition : la position des lettres dans le liste 
 * @return array : Le tableau correspondant
 */
function buildLetterSearchArray(array $commonList, int $letterIterationInput, int $letterIterationOutput, int $letterPosition )
{

}

/**
 * Chercher si la lettre porposée par le joueur est dans la liste des lettres à chercher
 *
 * @param string $letter : lettre à chercher 
 * @param array $outputList : la liste des lettres à chercher 
 * @return boolean : true : la lettre est dans la liste à chercher, false : la lettre n'est pas dans la liste
 */
function isInFindList($letter, array $outputList)
{

}

/**
 * Compare, pour une lettre donnée, le nombre d'occurence dans la liste à chercher  
 * et dans la liste des lettres communes 
 *
 * @param array $communList
 * @param array $inputTab
 * @param string $letter
 * @return boolean : true : il y a plus de lettres dans la liste ouput, false : il y a moins de lettres dans la liste ouput
 */
function compareLetters(array $communList , array $inputTab, string $letter)
{

}

/**
 * Enlève une lettre de la liste des lettres en commun 
 *
 * @param array $commonList
 * @param string $letter
 * @return array : la liste des lettres en communs sans la lettre en question
 */
function popLetter(array $commonList, string $letter)
{

}