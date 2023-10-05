<?php   

require "./utils.php";

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

    // fonction select 
    public static function select(string $entity, ?array $colonnes = null, ? array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug=false)
    {
        $db = DbConnect::getInstance(null);
        $sql = "SELECT ";
        // test si $colonnes n'est pas vide :
        if(count($colonnes) > 0)
        {
            $sql.= implode(", ", $colonnes);
           
        } 
        
        // test si $conditions n'est pas vide :
        else {
            // récupération de tous les attributs de l'objets : 
            $p = new Personne();
            $sql .= $p->toString();
     
        }

        $sql.= " FROM $entity WHERE ";
       
        // test si $conditions n'est pas vide
        $sql = handleConditions($conditions, $sql);
       

        // test si $orderBy n'est pas vide
        if(count($orderBy) > 0)
        {
            $sql.= " ORDER BY ";
            $sql.= implode(", ", $orderBy);
        }
        // test si $limit n'est pas vide
        if($limit != "")
        {
            $sql.= " LIMIT ". $limit;
        }

        // if($debug)
        // {
        //     echo $sql;
        // }
        var_dump($sql);die();
        
        // on requête en base de données 
        $stmt = $db->getPdo()->query(
            $sql
        );

       
        // var_dump($stmt->fetch(PDO::FETCH_ASSOC)); die();
        // fetch 
        $datas = $stmt->fetch(PDO::FETCH_ASSOC);


        // passages des datas à l'objet 
        $p = new Personne($datas);

        // verification de l'objet 
        // echo $p;
       
        
        
         

    } 



    public static function findById(DBConnect $connexion,  string $entity,  string $name, string $columnName)
    {
        $sql = "SELECT * from user where :columnName = :name";
        $stmt = $connexion->getPdo()->prepare($sql);
        $stmt->bindValue(':name', strtolower($name));
        $stmt->bindValue(':columnName', strtolower($columnName));
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
        
        return $result;
    }

    // 

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

