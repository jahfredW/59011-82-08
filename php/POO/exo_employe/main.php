<?php 

function chargerClasse($classe)
{
require $classe. ".class.php";
}
spl_autoload_register("chargerClasse");



$employe1 = [
    "nom" => "gruwe",
    "prenom" => "fred",
    "date_embauche" => "10-01-2022",
    "fonction" => "dev",
    "salaire" => 10,
    "service" => "dev"
];

$employe2 = [
    "nom" => "dupont",
    "prenom" => "marie",
    "date_embauche" => "15-03-2021",
    "fonction" => "designer",
    "salaire" => 12,
    "service" => "design"
];

$employe3 = [
    "nom" => "legrand",
    "prenom" => "pierre",
    "date_embauche" => "22-06-2020",
    "fonction" => "chef de projet",
    "salaire" => 15,
    "service" => "management"
];

$employe4 = [
    "nom" => "petit",
    "prenom" => "sophie",
    "date_embauche" => "03-09-2023",
    "fonction" => "dev",
    "salaire" => 11,
    "service" => "dev"
];

$employe5 = [
    "nom" => "martin",
    "prenom" => "lucas",
    "date_embauche" => "08-12-2021",
    "fonction" => "marketing",
    "salaire" => 13,
    "service" => "marketing"
];

$employe_liste = [$employe1, $employe2, $employe3, $employe4, $employe5];
$liste_objets = [];

$employeTest = new Employe($employe5);

foreach ($employe_liste as $employe){
    $employe = new Employe($employe);
    if($employe->versement()){
        echo $employe->calculPrime() . "K euros" . PHP_EOL;
    }
}

print_r(Employe::$employe_liste);

// méthode nombre d'employés : 
function nombre_employes(array $array)
{
    echo count(Employe::$employe_liste) . " employés" . PHP_EOL;
}

nombre_employes($liste_objets);

// méthode de tri des employéspar ordre alphabétique 
function sort_employes($liste_objets)
{
    usort($liste_objets, ["Employe", "compareToNom"]);

    return $liste_objets;
}

print_r(sort_employes($liste_objets));

$employeTest->display($employeTest->calculPrime());