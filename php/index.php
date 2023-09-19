<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="dist\style.css" />"
    <title>Document</title>
</head>
<body>
    <div class="container">
    <?php 
        require './formulaires/classes.php';

        
        $formulaire = new Formulaire(1);
        $formulaire->inputHtmlBuilder("firstName", "text");
        $formulaire->inputHtmlBuilder("lastname", "text");
        $formulaire->inputHtmlBuilder("password", "password");
        $formulaire->inputHtmlBuilder("reset", "reset");
        $formulaire->formHtmlBuilder("soumettre");
        echo $formulaire;


    ?>
    </div>
    
    <script type="text/javascript" src="verifForm.js"></script>
</body>
</html>

