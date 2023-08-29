set -e

timestamp() {
  date +"at %H:%M:%S on %d/%m/%Y"
}

cd U:\59011-82-08 || { echo "Échec du changement de répertoire"; exit 1; }

# git add
if git add --all; then
  echo "Tous les fichiers ont été ajoutés"
else
  echo "git add a échoué"
  echo "Appuyer la touche <Entrée> pour quitter..."
  read touche 
  exit 1
fi

# verification de la connexion
echo "vérification de la connexion"
ping  www.github.com &> /dev/null  && git push  || echo "not connected"

# pull
git pull || { echo "git pull a échoué"; exit 1;}

# git commit
if git commit -am "Regular auto-commit $(timestamp)"; then
  echo "Commit réussi"
else
  echo "Appuyer la touche <Entrée> pour quitter..."
  read touche 
fi

# réalisation du push 
if git push; then
  echo "Push réussi"
  read touche 
else
  echo "Push non réalisé"
  echo "Appuyer la touche <Entrée> pour quitter..."
  read touche 
  exit 1



echo "Appuyer la touche <Entrée> pour qutter..."

read touche
case $touche in
*)	echo "Merci"
	;;
esac