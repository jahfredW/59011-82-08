<?php

function ChargerClasse($classe)
{
    if(file_exists("./" . $classe . ".class.php"))
    require "./" . $classe . ".class.php";
    else if (file_exists("./Controllers/".$classe.".class.php"))
    require "./Controllers/".$classe.".class.php";
    else if (file_exists("./Models/".$classe.".class.php"))
    require "./Models/".$classe.".class.php";
    else if (file_exists("./Entities/".$classe.".class.php"))
    require "./Entities/".$classe.".class.php";
}
spl_autoload_register("ChargerClasse");

// connexion localhost 
$dsn = "mysql:host=localhost;dbname=test;charset=utf8";

// conexion docker 
$dsn2 = "mysql:host=db;dbname=test;charset=utf8";

$pdo = DbConnect::getInstance(null);

Manager::select("personne",[],['nom' => 'fred', "prenom" => "gruwe"], [], "3;", false);






// // getAllUsers
// print_r(Manager::getAll($pdo, "User"));

// // getOneUser By name 
// print_r(Manager::findById($pdo, "User", "gruwe", "nom"));

// Manager::create($pdo, ['nom' => 'gr', 'prenom' => 'fred'], "User");
