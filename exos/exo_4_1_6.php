<?php 

/**
 * Undocumented function
 *
 * @return void
 */
function search(array $tab, int $value) : array
{
    // tester s'il s'agit d'un tableau à simple ou 2 dimensions : 
    foreach($tab as $v)
    {
        if(is_array($v)){
            $dimension = true;
        }
    }


    // Si 2d : on recherche sur chaque sous tableau 
    if($dimension){
        $findList = [];
        for($index = 0; $index < count($tab); $index++){
            for($index2 = 0; $index2 < count($tab[$index]); $index2++){
                if($tab[$index][$index2] == $value){
                    array_push($findList,["x" => $index, "y" => $index2]);
                }
        }
    }
    }
    // Si non on cherche sur un tableau à une seule dimension : 
    else 
    {
        $findList = [];
        for($index = 0; $index < count($tab); $index++){
            if($tab[$index] == $value){
                array_push($findList,["index" => $index]);
            }
        }
    }
    
    return $findList;
}

$tab = [[1,3,4], [7,4,9], [8, 3 ,4]];
$tab2 = [1,2,3,4];

