@echo off

cd U:\59011-82-08\scripts\openChrome

if errorlevel 1 (
    echo Erreur : Impossible de changer de repertoire.
    exit /b 1
)

start chrome 


echo Toutes les operations ont ete effectuees avec succès.

exit /b 0