<?php

function chargerClasse($classe)
{
require $classe. ".class.php";
}
spl_autoload_register("chargerClasse");

// connexion localhost 
$dsn = "mysql:host=localhost;dbname=test;charset=utf8";

// conexion docker 
$dsn2 = "mysql:host=db;dbname=test;charset=utf8";

$pdo = DbConnect::getInstance(["dsn" => $dsn, "user" => "root", "password" => ""]);


// // getAllUsers
// print_r(Manager::getAll($pdo, "User"));

// // getOneUser By name 
print_r(Manager::getOne($pdo, "User", "gruwe", "nom"));

// Manager::create($pdo, ['nom' => 'gr', 'prenom' => 'fred'], "User");
