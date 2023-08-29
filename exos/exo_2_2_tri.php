<?php 

/**
 * Undocumented class
 */
class TrierTableau
{
    private $tableau;

    public function __construct($tableau)
    {
        $this->tableau = $tableau;
    }

    /**
     * Undocumented function
     *
     * @return void
     */
    public function sortByUsort()
    {
        usort($this->tableau, function( $a, $b) { return $a <=> $b; });
    }

    public function printTableau()
    {
        foreach ($this->tableau as $key => $value) {
            echo $key. " => ". $value. PHP_EOL;
        }
    }
}

$tab = [2,4,5,7,6];

$sort = new TrierTableau($tab);
$sort->sortByUsort();
$sort->printTableau();