const button  = document.querySelector('button') as HTMLButtonElement;
const dessertListe = document.querySelector('ul') as HTMLElement;

document.addEventListener('click', (e : Event) => {
    let target = e.target as HTMLElement;

    // gestion du bouton 
    if (target.tagName === 'BUTTON') {
        console.log(target);
        let userInput = prompt('Entrez un dessert')
        
        // création d'une puce pour un dessert 
        const dessertPuce = document.createElement('li') as HTMLElement;
        dessertPuce.classList.add('dessert');
        if(userInput){
            dessertPuce.innerText = userInput;
            dessertListe.appendChild(dessertPuce);
        }
    
        // gestion de la suppression de liste 
    } else if (target.tagName === 'LI') {
        if(confirm('Voulez-vous vraiment supprimer cet dessert?')){
            target.remove();
        }
    }

    
});