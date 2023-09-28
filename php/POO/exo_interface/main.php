<?php

function chargerClasse($classe)
{
require $classe. ".class.php";
}
spl_autoload_register("chargerClasse");

// create object user1 : 
$user1 = new AuthorEditor(["username" => "fred"]);
$user1->setAuthorPrivileges(["write text", "add punctuation"]);
$user1->setEditorPrivileges(["edit text", "edit punctuation"]);
echo $user1;