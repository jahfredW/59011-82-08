<?php

require './formulaires/classes.php';


$formulaire = new Formulaire(1);
$formulaire->inputHtmlBuilder("text", "name");
$formulaire->formHtmlBuilder("soumettre");
echo $formulaire;
