<?php

$dsn = 'mysql:host=localhost;dbname=exercice3;charset=utf8mb4';
$username = "root";
$password = "";

try {
    $connexion = new PDO($dsn, $username, $password, array(

        \PDO::ATTR_EMULATE_PREPARES => false,
    
        \PDO::ATTR_ERRMODE => \PDO::ERRMODE_EXCEPTION
    
    ));
    echo "connexion réussi";
} catch (PDOException $e) {
    echo $e->getMessage();
    die();
}

// insert into avoir_note 

$array_value = [[1,7,10],
[2,7,8],
[3,7,5],
[4,7,9], 
[17,3,15]];

foreach ($array_value as $value){
    $stmt = $connexion->prepare("INSERT INTO `avoir_note`(`idEtudiant`, `idEpreuve`, `note`) VALUES (:idEtudiant,:idEpreuve,:note)");
    $stmt->bindValue(':idEtudiant',$value[0]);
    $stmt->bindValue(':idEpreuve',$value[1]);
    $stmt->bindValue(':note',$value[2]);
    $stmt->execute();

}






