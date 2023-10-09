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

    public static function add(string $table, ?array $colonnes = null, ?array $values = null, ?bool $debug = false)
    {
    // verif : On converti en str et on check si présence d'un point virgule. 




    // public static function add(Personnes $p)
    // {
    //     $db = DbConnect::getDb();
    //     $query = $db->prepare("INSERT INTO Personnes (nom,prenom,adresse,ville) VALUES (:nom,:prenom,:adresse,:ville)");
    //     $query->bindValue(":nom", $p->getNom());
    //     $query->bindValue(":prenom", $p->getPrenom());
    //     $query->bindValue(":adresse", $p->getAdresse());
    //     $query->bindValue(":ville", $p->getVille());
    //     $query->execute();
    // }


    $verif = $table . json_encode($colonnes) . json_encode($values);
    if (!strpos($verif, ";"))
    {
        // le nom de la classe
        $classe = ucfirst($table);
        
        $liste = [];
        // connexion à la base de donnée
        
        $requete = "INSERT INTO ";

        // méthode setColonnes pour gérer les colonnes 
        $requete .= $classe . " ( ";
        $requete .= self::setColonnes($colonnes, $classe);

        $requete .= " ) ";

        $requete .= " VALUES ";

        $props = self::setValues($colonnes, $classe);

        $requete .= self::buildStr($props);


        self::bindValues($props, $requete, $values);


 
        if ($debug)
        {
            var_dump($requete);
        }

        
    }
    return false;
    }

    private static function setValues(array $colonnes, ?string $classe) : array 
    {
        // récupération des propriétés de la classe
        $properties = self::getProperties($classe);
        

        // cas où les colonnes sot vides 
        // pour chaque propriété on ajoutes les :devant : 
        $props = "";

        if(count($colonnes) == 0)
        {
            $props = $properties;
        } else 
        {
            // on récupère les propriétés seules passée en paramètres

            // var_dump($properties);
            // var_dump($colonnes); die();
            $props = array_intersect_key(array_values($colonnes), $properties);
            

            // var_dump($props); die();
        }
        
        foreach($props as $key => $value)
        {
            $props[$key] = ":". $value;
        }

        // var_dump($props);die();
        return $props;

        
    }

    private static function buildStr(array $props)
    {
        $requete = "( ";
            foreach ($props as $property)
            {
                $requete.= $property. ", ";
            }
            $requete = substr($requete, 0, -2);

            $requete .= " )";

            return $requete;
    }

    private static function bindValues(?array $props, string $requete, array $values)
    {
        
        if(count($values) != count($props) || count($values) == 0 )
        {
            return false;
        }

        $db = DbConnect::getDb();
        $query = $db->prepare($requete);

        $req = $db->prepare($requete);
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


}




