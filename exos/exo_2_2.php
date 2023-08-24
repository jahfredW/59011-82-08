<?php

/**
 * Undocumented function
 *
 * @param [int] $Tutu
 * @param [int] $Toto
 * @param [string] $Tata
 * @return int
 */
function toto(int $Tutu, int $Toto, string $Tata)
{
    $Tutu > $Toto + 4 || $Tata === "OK" ? $Tutu += 1 : $Tutu -= 1;

    return $Tutu;
}

function inverse(int $Tutu, int $Toto, string $Tata)
{
    $Tutu <= $Toto + 4 && $Tata != "OK" ? $Tutu += 1 : $Tutu -= 1;

    return $Tutu;
}