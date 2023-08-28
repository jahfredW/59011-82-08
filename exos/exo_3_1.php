<?php 

$n = 10;

function somme($n)
{
    if($n === 0){
        return 1;
    }
    echo '+' . ($n - 1); 
    return  $n + somme($n - 1);
}

echo $n;
echo " = " . somme(10);