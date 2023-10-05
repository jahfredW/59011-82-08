<?php 

// fucntio gestion du where

function handleConditions(?array $conditions, string $sql)
{
    
    // Si le tableau de conditions est vide, on retourne la requête
    if(count($conditions) == 0){
        return $sql;
    } 
    // sinon on construit les conditions 
    else {
        $index = 0;
        foreach ($conditions as $key => $value)
        {
            // controles des types de value 
            // si tableau : 
            if(gettype($value) == 'array')
            {
                // gestion du 'in'
                handleIn($key, $value, $sql);
            } else {
                 // récupération de la première lettre : 
                $firstLetter = substr($value, 0,1);
            
                if (in_array($firstLetter, ['>', '<', '=', '!=']))
                {
                    // function des destions des égalités, inégalités 
                    $sql = handleEgality($key, $value, $firstLetter, $sql);
                }
                else if (strpos($value, "%"))
                {
                    
                    $sql = handleLike($key, $value, $sql);
                }
                else if (strpos($value, "->"))
                {
                    
                    // function de gestion des between. 
                    
                } else {
                    // cas d'une recherche simple 
                    $sql .= $key. " = ". "'" . $value . "'";
                }

            }
            // Si une condition suit, alors on ajoute un "*AND"
            if($index < count($conditions) - 1)
            {
                $sql.= " AND ";
            }
            // incrémentation de l'index 
            $index ++;
        }
    }
    return $sql;
}

/**
 * Function de gestion du cas des in 
 *
 * @param string $key la clé = nom de colonne
 * @param string $value = le tableau passé en paramètre 
 * @param string $sql : la chaine de caractères sql. 
 * @return string $ql : la chaine requête sql. 
 */
function handleIn($key, string $value, string $sql)
{
    $sql .= $key . " IN (". $value. ")";
    return $sql;
}


/**
 * Fonction de gestion du cas des égalités  - inégalités 
 *
 * @param string $key
 * @param string $firstLetter : la première lettre 
 * @param string $sql la requête sql 
 * @return string $sql la chaine de caractères sql. 
 */
function handleEgality($key, $value,  string $firstLetter, string $sql)
{
       
    $sql.= $key. " " . str_split($value)[0]. " ". substr($value, 1);
        
    return $sql;
}



function handleLike(string $key, string $value, string $sql)
{
    // recherche  du nombre de % 
    substr_count($value, "%");


    // recherche de la position des / du like  
}


// test 

