<?php 

function factorielle($n)
{
    if($n <= 1)
    {
        return 1;
    }
    return $n * factorielle($n - 1);
}

echo factorielle(10);