<?php 

function chargerClasse($classe)
{
require $classe. ".class.php";
}
spl_autoload_register("chargerClasse");

$employe = new Employe(["nom" => "gruwe", "prenom" => "fred", "date_embauche" => "10-01-2022", "fonction" => "dev", "salaire" => 10, "service" => "dev"]);
$employe->calculPrime();



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