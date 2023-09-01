<?php
/**
 * initialise les paramètres du jeu
 *
 * @return array Tableau associatif qui retourne toute les variables d'initialisation
 */
function init(){
    $level = saisirDifficulte();
    $nbJoueur = saisirNbJoueur();
    $vies = saisirNbVies();
    $word = determinerMotAChercher();

    return array(
        'level' => $level,
        'nbJoueur' => $nbJoueur,
        'vies' => $vies,
        'word' => $word
    );

}

/**
 * Demande le niveau de difficulté à l'utilisateur
 *
 * @return int niveau de difficulte
 */
function saisirDifficulte(){
    do
    {
        $level = readline("choissez un niveau de difficulté : ( entre 1 et 3 ) ? ") ;
    }
    while ($level < 1 || $level > 3 && ( preg_match('/^[\d]+$/', $level)));

    return $level;
    
} // 1 

/**
 * Demande le nombre de joueur
 *
 * @return int nombre de joueurs
 */
function saisirNbJoueur(){
    do
    {
        $nbJoueur = readline("choissez un nombre de joueurs : ( entre 1 et 3) ? " );
    }
    while ($nbJoueur < 1 || $nbJoueur > 3 && ( preg_match('/^[\d]+$/', $nbJoueur)));
    return $nbJoueur;
} // 1 

/**
 * Demande le nombre de vie aux joueur
 *
 * @return int nombre de vie
 */
function saisirNbVies(){
    do
    {
        $nbVie = readline("choissez un nombre de vie : ( entre 1 et 3 ? "  ) ;
    }
    while ($nbVie < 1 || $nbVie > 3 && ( preg_match('/^[\d]+$/', $nbVie)));
    return $nbVie;
} // 1 

/**
 * Choisi au hasard un mot dans une liste
 *
 * @return string mot qui doit être trouvé par les joueurs
 */
function determinerMotAChercher(){
    $wordListe = ["hello", "world"];
    $random = random_int(0, count($wordListe) - 1);
    $word = $wordListe[$random];
    return $word;


} // 1 

function jeu($motAChercher,$difficulte,$nbJoueur,$nbVie){
    $current_player = 1; 
    $motAChercherTab = coderMot($motAChercher, $difficulte);
    afficherMotCode($motAChercherTab);
    $playerToPlay = joueurSuivant($nbJoueur, $current_player);
    $lettre = saisirLettre($playerToPlay);
    verifierLettre($lettre, $motAChercherTab, $motAChercher, $difficulte, "");
}

/**
 * Construit un tableau du mot en fonction de la difficulté
 *
 * @param string $mot Mot à chercher
 * @param integer $difficulte Difficulté de la partie indiquée
 * @return array Le tableau du mot
 */
function coderMot(string $mot, int $difficulte){

    // conversion du mot en tableau
    $motTab = str_split($mot);

    // liste aléatoire
    $numbers = range(0, count($motTab) - 1);
    shuffle($numbers);

    // trouve une lettre en fonction du niveau
    for($index = 0; $index < $difficulte; $index++){
        $randomIndex = $numbers[count($numbers) - 1];
        $letterTab[] = $motTab[$randomIndex];
        array_pop($numbers);

    }
    
    // reconstruction du tableau 
    $motTab =  array_map( function($lettre) use($motTab, $letterTab) {
        if(!in_array($lettre, $letterTab)){
            $lettre = "_";
        }
        return $lettre;
    }, $motTab);

    return $motTab;

} // 2 

/**
 * Affiche le mot codé
 *
 * @param array $motCode Tableau du mot codé
 * @return void
 */
function afficherMotCode(array $motCode){
    for ($i = 0; $i < count($motCode); $i++){
        echo $motCode[$i] . " ";
    }
    echo PHP_EOL;
} // 2 

/**
 * Permet de décider qui va jouer
 *
 * @param integer $nbJoueur Le nombre de joueur
 * @param integer $joueurEnCours Le joueur qui vient de jouer
 * @return int l'id du joueur en cours
 */
function joueurSuivant(int $nbJoueur, int $joueurEnCours){
    if($joueurEnCours == $nbJoueur ){
        $joueurEnCours = 1;
    } else {
        $joueurEnCours++;
    }
    return $joueurEnCours;
} // 2 

/**
 * Permet au joueur en cours de proposer une lettre
 *
 * @param integer $joueurEnCours Celui qui doit jouer
 * @return string La lettre ayant été proposée
 */
function saisirLettre(int $joueurEnCours){
    do
    {
        echo "joueur : " . $joueurEnCours. "\n";
        $lettre = readline("choisissez une lettre : ");
    }
    while (preg_match('/^[a-zA-Z]+$/', $lettre) == 0);

    return strtolower($lettre);
} // 2 

/**
 * Vérifie si la lettre fait partie du mot ou pas
 *
 * @param string $lettre La lettre entrée par le joueur
 * @param array $motCode La partie du mot que le joueur connait
 * @param string $mot Le mot que le joueur doit trouvé
 * @param int $difficulte La difficulte de la partie
 * @param string $propositions Les lettre déjà proposées
 * @return void
 */
function verifierLettre(string $lettre, array $motCode, string $mot, int $difficulte, string $propositions){
    
    if(estCorrecte($lettre, $motCode, $mot))
    {
        var_dump("verifier");
        $motCode = ajouterLettre($lettre, $motCode, $difficulte);
        print_r($motCode);

    }
    
    
} // 2 

/**
 * Vérifie si la lettre est correcte et pas encore ajoutée
 *
 * @param string $lettre
 * @param array $motcode
 * @param string $mot
 * @return bool
 */
function estCorrecte(string $lettre, array $motcode, string $mot){
    $isFind = false;
   
    if(strpos($mot, $lettre) != false){
      
        $isFind = true;
    
    var_dump("là");
    
}
return $isFind;
} // 1 

/**
 * Ajoute la lettre au mot codé en fonction du niveau de difficulté
 *
 * @param string $lettre
 * 
 * 
 * @param array $motcode
 * @param string $mot
 * @param integer $difficulte
 * @return array Le mot codé
 */
function ajouterLettre(string $lettre, array $motCode, string $mot, int $difficulte = 1){
    // chercher la position de la lettre : 
    $letterIndex = strpos($lettre, $mot);
    $motCode[$letterIndex] = $lettre;

    return $motCode;


} // 1 

/**
 * Clear la console et réaffiche le jeu dans l'état actuel
 *
 * @param integer $nbVie
 * @param array $motCode
 * @param integer $joueurEnCours
 * @param string $propositions
 * @return void
 */
function affichageGlobal(int $nbVie, array $motCode, int $joueurEnCours, string $propositions){} // 1 

/**
 * Affiche le nombre de vie restante + pendu ?
 *
 * @param integer $nbVie
 * @return void
 */
function affichageVie(int $nbVie){} // 1 

/**
 * Undocumented function
 *
 * @param array $motCode
 * @return int Etat de la partie (0 -1 1
 * 0 = en cours
 * -1 = perdu
 * 1 = gagne
 * */
function estGagne(array $motCode){} // 1 

/**
 * Conclu le jeu Gagné ou Perdu
 *
 * @param boolean $resultat
 * @return void
 */
function conclusion($resultat){} // 1 


$statusGameTab = init();
$word = $statusGameTab['word']; 
$level = $statusGameTab['level']; 
$nbJoueurs = $statusGameTab['nbJoueur']; 
$vies = $statusGameTab['vies']; 

jeu($word, $level, $nbJoueurs, $vies);



