"use strict";
const button = document.querySelector('button');
const dessertListe = document.querySelector('ul');
document.addEventListener('click', (e) => {
    let target = e.target;
    if (target.tagName === 'BUTTON') {
        console.log(target);
        let userInput = prompt('Entrez un dessert');
        // création d'une puce pour un dessert 
        const dessertPuce = document.createElement('li');
        dessertPuce.classList.add('dessert');
        if (userInput) {
            dessertPuce.innerText = userInput;
            dessertListe.appendChild(dessertPuce);
        }
    }
    else if (target.tagName === 'LI') {
        if (confirm('Voulez-vous vraiment supprimer cet dessert?')) {
            target.remove();
        }
    }
});
