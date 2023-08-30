<?php 

function afficherTableauDeuxD ($tableau){
        $tre = dessinerTre(sizeof($tableau[0]));
        
        echo "$tre\n|     |";
        for($i=0;$i< sizeof($tableau[0]);$i++){
            echo str_pad(chr(65+$i), 5," ",STR_PAD_BOTH)."|";
        }
        echo "\n$tre";
        
        for($i=0;$i< sizeof($tableau);$i++){
            echo"\n|".str_pad(($i+1), 5," ",STR_PAD_BOTH)."|";
            for($j=0;$j< sizeof($tableau[$i]);$j++){
                echo str_pad($tableau[$i][$j], 5," ",STR_PAD_BOTH)."|";
            }
            echo"\n$tre"; 
        }
    }