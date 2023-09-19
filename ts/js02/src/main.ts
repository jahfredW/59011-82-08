const body = document.querySelector('body') as HTMLElement;
const lines = document.querySelector('#lineNumber') as HTMLInputElement;
const form = document.querySelector('form') as HTMLFormElement;
const tab = document.createElement('div') as HTMLDivElement;
let globalLineNumbers : number = 0;


// Construction du tableau 

form.addEventListener('submit', (e : Event) => {
   e.preventDefault();
   const lineNumbers: number = parseInt(lines.value);

   // Tableau 
   
   tab.classList.add('tab');

   // ligne du total 
   const totalLine = document.createElement('div');
   totalLine.classList.add('total-line');

    // création input du total 
    const totalInput = document.createElement('input');
    totalInput.disabled = true;
    

    // création input du total 
    const totalLabel = document.createElement('label');
    totalLabel.innerHTML= 'Total';

    totalLine.appendChild(totalLabel);
    totalLine.appendChild(totalInput);


    
    for (let i = 0; i < lineNumbers; i++) {
         // création d'une ligne
    const line = document.createElement('div');

    // création de la div quantité 
    const quantityDiv = document.createElement('div');
    quantityDiv.classList.add('quantity');

    // création du label quantity
    const quantityLabel = document.createElement('label');
    quantityLabel.textContent = 'Quantité :';

    // création de input quantity: 
    const quantityInput = document.createElement('input');
    quantityInput.setAttribute('type', 'number');
    quantityInput.setAttribute('min', '1');
    quantityInput.setAttribute('max', '100');
    quantityInput.setAttribute('value', '1');

    // création de la div prix unitaire
    const unitPriceDiv = document.createElement('div');
    unitPriceDiv.classList.add('unitPrice');

    // création du label prix untitaire
    const unitPriceLabel = document.createElement('label');
    unitPriceLabel.textContent = 'Prix unitaire:';

    // création de input prix unitaire: 
    const unitPriceInput = document.createElement('input');
    unitPriceInput.setAttribute('type', 'number');
    unitPriceInput.setAttribute('min', '1');
    unitPriceInput.setAttribute('max', '100');
    unitPriceInput.setAttribute('value', '1');

    // création de la div prix 
    const priceDiv = document.createElement('div');
    priceDiv.classList.add('price');

    // création du label prix 
    const priceLabel = document.createElement('label');
    priceLabel.textContent = 'Prix total:';

    // création de input prix : 
    const priceInput = document.createElement('input');
    priceInput.setAttribute('type', 'number');
    priceInput.setAttribute('min', '1');
    priceInput.setAttribute('max', '100');
    priceInput.setAttribute('value', '1');
    priceInput.disabled = true;



    // ajout de l'input et du lable à la div quantité : 
    quantityDiv.appendChild(quantityLabel);
    quantityDiv.appendChild(quantityInput);

     // ajout de l'input et du lable à la div prix unit : 
    unitPriceDiv.appendChild(unitPriceLabel);
    unitPriceDiv.appendChild(unitPriceInput);

    // ajout de l'input et du lable à la div prix : 
    priceDiv.appendChild(priceLabel);
    priceDiv.appendChild(priceInput);
    
    // ajout de la quantityDiv au tableau :
    line.appendChild(quantityDiv)
    line.appendChild(unitPriceDiv);
    line.appendChild(priceDiv);
    line.classList.add('line', 'line-wrapper');
    line.id = i.toString();
    tab.appendChild(line);
    body.appendChild(tab);

  
    line.addEventListener('input', (e : Event) => {
        e.preventDefault();
        const children = line.querySelectorAll('input');
        const total = parseFloat(children[1].value) * parseFloat(children[0].value)
        children[2].value = total.toString();

         // Calculer la somme totale de toutes les lignes
        const allLines = document.querySelectorAll('.line'); // ou utiliser une classe plus spécifique si nécessaire
        let grandTotal = 0;
        allLines.forEach((lineElement) => {
        const inputs = lineElement.querySelectorAll('input');
            grandTotal += parseFloat(inputs[2].value);
            console.log(grandTotal);
      
        totalInput.value = grandTotal.toString();
    
    });
    });
    }
    tab.appendChild(totalLine);

})





    





