<?php

function create($arrayParams)
    {
        $keyChar = "";
        $bindChar = "";
        // traitement des paramètres    
        foreach($arrayParams as $params => $values)
        {
            // on contruit la chaine de caractères pour les clés
            $keyChar .= $params . " ,";
            $bindChar .= ":" . $params . ",";
        }
        $sql = "INSET INTO :entity($keyChar) values ($bindChar)";
        $stmt = $db->prepare($sql);
        
        foreach($arrayParams as $params)
        {
            $stmt->bindValue(":" . $params, $params);
        }
        return $sql;
    }


    $tab = ['un' => 2, 'test' => 3];



echo create($tab);