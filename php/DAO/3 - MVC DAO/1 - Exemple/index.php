<?php

function ChargerClasse($classe)
{
    if (file_exists("./CONTROLLER/".$classe.".Class.php"))
    require "./CONTROLLER/".$classe.".Class.php";
    else if (file_exists("./MODEL/".$classe.".Class.php"))
    require "./MODEL/".$classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

DbConnect::init();
// $perso = new Personnes(["idPersonne"=>1,"nom"=>"dupond2","prenom"=>"toto"]);
// PersonnesManager::add($perso);
// $perso = new Personnes();
// $perso->setIdPersonne(1);
// $perso->setNom("durand");
// PersonnesManager::update($perso);
// PersonnesManager::delete($perso);
// PersonnesManager::findById(2);
// $tab = ["idPersonne"=>1,"nom"=>"dupond2","prenom"=>"toto"];
// echo json_encode($tab);
var_dump(DAO::select("Personnes",[],null,["nom"=>true,"prenom"=>false],"2,3",true));