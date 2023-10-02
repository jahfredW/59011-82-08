<?php   

class Manager
{
    // get All 
    public static function getAll($connexion, $entity)
    {
        $sql = "SELECT * from :entity";
        $stmt = $connexion->getPdo()->prepare($sql);
        $stmt->bindValue(':entity', $entity);
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
        
        return $result;
    }


    public static function getOne(DBConnect $connexion,  string $entity,  string $name, string $columnName)
    {
        $sql = "SELECT * from user where :columnName = :name";
        $stmt = $connexion->getPdo()->prepare($sql);
        $stmt->bindValue(':name', strtolower($name));
        $stmt->bindValue(':columnName', strtolower($columnName));
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
        
        return $result;
    }

    // create 
    public static function create(DbConnect $connexion, array $arrayParams,  string $entity)
    {
        // chaine de caractère des clés
        $keyChar = "";
        // chaine de caractère des valeurs à binder 
        $bindChar = "";
        // index d'itération
        $index = 0;

        // traitement des paramètres    
        foreach($arrayParams as $params => $values)
        {
            // on contruit la chaine de caractères pour les clés
            $keyChar .= $params;
            if($index != count($arrayParams) - 1)
            {
                $keyChar .= ", ";
            }
            $bindChar .= ":" . $params;
            if($index != count($arrayParams) - 1)
            {
                $bindChar .= ", ";
            }
            $index += 1;
        }

        // requete SQL 
        $sql = "INSERT INTO $entity ($keyChar) values ($bindChar)";

        // statement 
        $stmt = $connexion->getPdo()->prepare($sql);
        // $stmt->bindValue(':entity', $entity);

        foreach($arrayParams as $params => $values)
        {
            $stmt->bindValue(":" . $params, $values);
        }

        // $stmt->bindValue(":user", $entity);
        $stmt->execute();

    }



    // read simple


// insertion simple 
// $sql = "INSERT INTO Users (PersonID, LastName, FirstName, Address, City) VALUES (1, 'John', 'david', 'zededzed', 'zdezdee')";


 
}

