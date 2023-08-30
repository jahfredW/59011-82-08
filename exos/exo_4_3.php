<?php 

/**
 * Fonction récursive factorielle.
 *
 * @param int $n : number to check
 * @return int
 */
function factorielle($n)
{
    if($n <= 1)
    {
        return 1;
    }
    return $n * factorielle($n - 1);
}

echo factorielle(5);

// 5 *      fac(4)
// 5 * | 4    *    fac(3) |
// 5 *   4 *    | 3 *    fac(2) |
// 5 *   4 *      3 * | 2 * fac(1) |
// 5 *   4 *      3 *   2 * | 1 |
