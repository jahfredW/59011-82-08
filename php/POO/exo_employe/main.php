<?php 

function chargerClasse($classe)
{
require $classe. ".class.php";
}
spl_autoload_register("chargerClasse");




// private $_nom;
// private $_adresse;
// private $_postal;
// private $_ville;
// private $_resto;
#region liste agences
$agence1 = new Agence(["nom" => "AGII", "adresse" => "Lille", "postal" => 59000, "ville" => "Lille", "resto" => true]);
$agence2 = new Agence(["nom" => "CAPGEGEMI", "adresse" => "Paris", "postal" => 75000, "ville" => "Paris", "resto" => false]);


#region liste employes
$employe1 = [
    "nom" => "gruwe",
    "prenom" => "fred",
    "date_embauche" => "10-01-2022",
    "fonction" => "dev",
    "salaire" => 10,
    "service" => "dev",
    "agence" => $agence1
];

$employe2 = [
    "nom" => "dupont",
    "prenom" => "marie",
    "date_embauche" => "15-03-2021",
    "fonction" => "designer",
    "salaire" => 12,
    "service" => "design",
    "agence" => $agence2
];

$employe3 = [
    "nom" => "legrand",
    "prenom" => "pierre",
    "date_embauche" => "22-06-2020",
    "fonction" => "chef de projet",
    "salaire" => 15,
    "service" => "management",
    "agence" => $agence1
];

$employe4 = [
    "nom" => "petit",
    "prenom" => "sophie",
    "date_embauche" => "03-09-2023",
    "fonction" => "dev",
    "salaire" => 11,
    "service" => "dev",
    "agence" => $agence2
];

$employe5 = [
    "nom" => "martin",
    "prenom" => "lucas",
    "date_embauche" => "08-12-2021",
    "fonction" => "marketing",
    "salaire" => 13,
    "service" => "marketing",
    "agence" => $agence1
];
#endregion



$employe_liste = [$employe1, $employe2, $employe3, $employe4, $employe5];
$liste_objets = [];

$employeTest = new Employe($employe5);

foreach ($employe_liste as $employe){
    $employe = new Employe($employe);
    if($employe->versement()){
        echo $employe->calculPrime() . "K euros" . PHP_EOL;
    }
}

// print_r(Employe::$employe_liste);

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



Employe::display(sort_employes(Employe::$employe_liste));
Employe::display(Employe::calculCout(Employe::$employe_liste));
