<?php
class DAO
{
    /**
     * Méthode select 
     *
     * @param object $entity : entité concernée 
     * @param string $table
     * @param array|null $colonnes sélection des colonnes -> tableau associatif
     * @param array|null $conditions sélection des conditions -> tableau associatif
     * @param array|null $orderBy tableau associatif
     * @param string|null $limit limit -> mettre chaine de carartère avec 2 int et virgule pour offset
     * @param boolean|null $debug activation du mode debug
     * @return void
     */
    public static function select(string $table, ?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
    {
        // verif : On converti en str et on check si présence d'un point virgule. 
        $verif = $table . json_encode($colonnes) . json_encode($conditions) . json_encode($orderBy) . $limit;
        if (!strpos($verif, ";"))
        {
            // le nom de la classe
            $classe = ucfirst($table);
            
            $liste = [];
            // connexion à la base de donnée
            $db = DbConnect::getDb();
            $requete = "SELECT ";

            // méthode setColonnes pour gérer les colonnes 
            $requete .= self::setColonnes($colonnes, $classe);
            $requete .= " FROM " . $table;
            $requete .= self::setConditions($conditions);
            $requete .= self::setOrderBy($orderBy, $requete);
            $requete .= $limit != null ? " LIMIT " . $limit : "";
            if ($debug)
            {
                var_dump($requete);
            }

            $req = $db->prepare($requete);
            $req->execute();
            while ($donnees = $req->fetch(PDO::FETCH_ASSOC))
            {
                $liste[] = new $classe($donnees);
            }
            $req->closeCursor();
            return count($liste) > 0 ? $liste : false;
        }
        return false;
    }

    private static function setColonnes(?array $colonnes, string $classe)
    {
        if ($colonnes != null)
        {
            return implode(', ', $colonnes);
        }

        return implode(", ",self::getProperties($classe));
    }

    private static function getProperties(string $classe)
    {
        // Instanciatin de la classe
        $obj = new $classe();

        // récupération des propriétés de la classe
        $properties = (new ReflectionClass($obj))->getProperties();

        $propertiesListe = [];
        // création de la liste des propriétés
        foreach($properties as $property)
        {
            $propertiesListe[] = substr($property->getName(), 1);
        }
        
        return $propertiesListe;
    }

    private static function setConditions(?array $conditions)
    {
        $requete = "";
        if ($conditions != null)
        {
            $requete = " WHERE ";
            foreach ($conditions as $key => $value)
            {
                // var_dump( strpos($value, "<" )!==false || strpos($value, ">")!==false);
                if (is_array($value))
                {
                    $requete .= $key . " IN ('" . implode("','", $value) . "')";
                }
                elseif ($value == "")
                {
                    $requete .= $key . " IS NULL";
                }
                elseif (strpos($value, "->"))
                {
                    $value = str_replace("->", ' AND ', $value);
                    $requete .= $key . " BETWEEN " . $value;
                }
                elseif (strpos($value, "<") !== false || strpos($value, ">") !== false)
                {
                    $requete .= $key . $value;
                }
                elseif (strpos($value, "!") !== false)
                {
                    $requete .= $key . "!=" . substr($value, 1);
                }
                elseif (strpos($value, "%") !== false)
                {
                    $requete .= $key . " LIKE '" . $value . "'";
                }
                else
                {
                    $requete .= $key . " = '" . $value . "'";
                }

                $requete .= " AND ";
            }
            $requete = substr($requete, 0, -4);

        }
        return $requete;
    }

    private static function setOrderBy(?array $orderBy = null)
    {
        $retour = '';
        if ($orderBy != null)
        {
            $retour = ' ORDER BY ';
            foreach ($orderBy as $key => $value)
            {
                $retour .= $key . ' ' . ($value ? "" : ' DESC ') . ', ';
            }
            $retour = substr($retour, 0, -2);
        }
        return $retour;
    }

    public static function add(string $table, ?array $values = null, ?bool $debug = false)
    {
    


    $verif = $table . json_encode($values);
    if (!strpos($verif, ";"))
    {
        // le nom de la classe
        $classe = ucfirst($table);
        
        
        $requete = "INSERT INTO ";

        // méthode setColonnes pour gérer les colonnes 
        $requete .= $classe . " ( ";
        $requete .= self::setAttributs($values, $classe);

        $requete .= " ) ";

        $requete .= " VALUES ";

        $props = self::setValues($values, $classe);

        $requete .= self::buildStr($props);

      
        self::bindValues($props, $requete, $values);


        if ($debug)
        {
            var_dump($requete);
        }

        
    }
    return false;
    }


    private static function setAttributs(?array $values) : string
    {
        if ($values != null)
        {
            return implode(', ', array_keys($values));
        }
        return false;
    }

    private static function setValues(array $values)
    {

        // on récupère les propriétés seules passée en paramètre
        $props = array_map(function($key) {
            return $key .':' . $key;
        }, array_keys($values));
        
        
        return $props;

    }

    private static function buildStr(array $props)
    {

        $props = implode(', ', array_map(function($key) {
            return $key;
        }, array_values($props)));
       
        return $props ;
        
    }

    private static function bindValues(?array $props, string $requete, array $values)
    {
        

        $db = DbConnect::getDb();
        $query = $db->prepare($requete);

        foreach ($props as $value)
        {   
            
            if(isset($values[substr($value, 1)])){
                $query->bindValue($value, $values[substr($value, 1)]);
                // var_dump(":". $key, $values[$key]);
            }
          
        }

        
        $query->execute();
        // while ($donnees = $req->fetch(PDO::FETCH_ASSOC))
        // {
        //     $liste[] = new $classe($donnees);
        // }
        $query->closeCursor();
        //return count($liste) > 0 ? $liste : false;
    }

    public static function update(string $table,?array $values = null, ?bool $debug = false)
    {
        // récupérer le tableau ! 
        $verif = $table . json_encode($values);
        if (!strpos($verif, ";"))
        {
            // le nom de la classe
            $classe = ucfirst($table);
            
            $requete = "UPDATE ";

            // méthode setColonnes pour gérer les colonnes 
            $requete .= $classe . " SET ";

            $requete .= implode(", ", self::setValues($values));

            $requete .= " WHERE " . self::setValues($values)[0];

            // fermieture de la requete
            $requete .= ";";

            // bind des params 
            $query = self::bindValuesUpdate($requete);

            // execution de la requete 
            self::execute($query);
    
            if ($debug)
            {
                var_dump($requete);
            }

            
        }
        return false;
    }
    
   

    // crée un tableau global avec les conditions et les valeurs de l'input
    public static function mergeInput(array $conditions, array $values)
    {
        return array_merge($conditions, $values);
    }

    // permet de binder les params et d'éxécuter la requete
    private static function bindValuesUpdate(string $requete, array $conditionsMap = null)
    {
        
        $db = DbConnect::getDb();
        $query = $db->prepare($requete);

        if($globalInput)
        {
            foreach ($globalInput as $key => $value){   
            $query->bindValue(":" . $key, $value);  

            return $query;
        }
        } else {
            foreach ($conditionsMap as $key => $value){   
            $query->bindValue(":". $key, $value);
        }
    }
        

        return $query;
        
        
    }

    private static function execute($query)
    {
        $query->execute();
        // while ($donnees = $req->fetch(PDO::FETCH_ASSOC))
        // {
        //     $liste[] = new $classe($donnees);
        // }
        $query->closeCursor();
        //return count($liste) > 0 ? $liste : false;
    }

    public static function delete(string $table, array $conditions, bool $debug)
    {
        $verif = $table . json_encode($conditions);
        if (!strpos($verif, ";"))
        {
            // le nom de la classe
            $classe = ucfirst($table);

            $requete = "DELETE FROM ";

            // méthode setColonnes pour gérer les colonnes 
            $requete .= $classe . " WHERE ";

            // 
            $conditionsMap = self::setCond($conditions);

            $requete .= self::buildStr($conditionsMap);

            // fermeture de la requete
            $requete .= ";";


            // bind des params 
            $query = self::bindValuesUpdate($requete, null,  $conditions);

            // execution de la requete 
            self::execute($query);
    
            if ($debug)
            {
                var_dump($requete);
            }

            
        }
        return false;
    }

}




