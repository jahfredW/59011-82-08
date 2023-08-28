<?php 

$tab = [
    "1" => 1,
    "2" => 2,
    "3" => 3
];


function search($tab, $val)
{
    foreach($tab as $key => $value)
    {
        if($value == $val) {
            return $key;
        }
    }
    return "not found";
    }


echo search($tab, 2);