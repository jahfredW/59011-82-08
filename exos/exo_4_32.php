<?php 

function spell($text)
{
    if(strlen($text) == 0)
    {
        return;
    };
    echo $text[0] . PHP_EOL;
    $text = substr($text, 1);

    return spell($text);
}

spell('hello');

