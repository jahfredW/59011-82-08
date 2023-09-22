<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <title>memory</title>
</head>
<body>
    <div>
        <?php 
        require "./builder.php"; 
            userInterface();
         ?>
    </div>
    <div class="img-global-container">
        <?php
        $arrayCards = arrayMix(10);
        $arrayGroup = arrayBuilder($arrayCards);
        // itération sur le nombre de card est display 
        foreach($arrayGroup[1] as $value){
            cardDisplay($value['cardId'], $value['src']);
        }
        ?>
    </div>
    <div class="win off">
        <h2>Bravo, partie gagnée !! Essais : <span> </span></h2>
        <h2>Bien joué brandon !</h2>
    </div>
<script src="main.js"></script>   
</body>
</html>