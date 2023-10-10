<?php 

/**
 * Fais le café
 *
 * @param string $path
 * @param string $errorMessage
 * @param bool $isError
 * @return void
 */
function  genelog(string $file, string $message, bool $isError)
{
    $dateUTC = new DateTime('now');

    // Ajoutez 2 heures
    $dateUTC->add(new DateInterval('PT2H'));
    // Format de la date et de l'heure UTC avec le décalage ajouté
    $date_format = $dateUTC->format('Y-m-d H:i:s');

    // création du fichier de log
    $logFile = fopen(__DIR__ . "/../LOG/" . $file . '.log', "a"); 

    // écriture des logs dans le fichiers 
    fwrite($logFile, $date_format . " :" . ($isError ? "!ERROR! " : '') . $message . PHP_EOL);

    //fermeture du fichier.
    fclose($logFile);
}


