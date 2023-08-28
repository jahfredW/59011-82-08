@echo on

cd U:\59011-82-08\scripts\script
if errorlevel 1 (
    echo Erreur : Impossible de changer de repertoire.
    exit /b 1
)

git add .
if errorlevel 1 (
    echo Erreur : git add a échoué.
    exit /b 1
)

git commit -m "Commit automatique"
if errorlevel 1 (
    echo Erreur : git commit a échoué.
    exit /b 1
)

git push origin master
if errorlevel 1 (
    echo Erreur : git push a échoué.
    exit /b 1
)

echo Toutes les operations ont ete effectuees avec succes.
exit /b 0
