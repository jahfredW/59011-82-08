<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php require "./builder.php"; 
    $arrayCards = arrayMix(20);
    
    // itération sur le nombre de card est display 
    foreach($arrayCards as $key => $value){
        cardDisplay($value);
    }
    
    
    
    ?>
    
</body>
</html>