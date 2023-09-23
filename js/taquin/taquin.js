class Cell
{
    constructor(id, x, y){
        this.id = id;
        this.x = x;
        this.y = y;
        this.state = "";
        
    }

    // vérifie si une cellule peut bouger
    move(grid) {
        // récupération des cellules à coté, et au dessus - dessous
        // recherche de la cellule vide : si dans juste à coté de la cellule courante, alors ok
        let currentCell = this;
        let emptyCell = grid.cellTab.find(cell => cell.state == "empty");

        // récupération 


        console.log("current", currentCell);
        console.log("empty", emptyCell);
        console.log('tableau', grid.cellTab);

        // on compare les coordonnées : 
        if ((emptyCell.x == currentCell.x && Math.abs(emptyCell.y - currentCell.y) == 1) 
           || (emptyCell.y == currentCell.y && Math.abs(emptyCell.x - currentCell.x) == 1)){
                console.log('ici');
                this.switchPos(emptyCell);

                //mise à jour du data-image

                let emptyCellDiv = document.getElementById("cell-" + emptyCell.id);
                emptyCellDiv.setAttribute('data-cell', currentCell.state);

                let currentCellDiv = document.getElementById("cell-" + currentCell.id);
                currentCellDiv.setAttribute('data-cell', "empty");

                [currentCellDiv.innerHTML, emptyCellDiv.innerHTML] = [emptyCellDiv.innerHTML, currentCellDiv.innerHTML];

        }

        

       
    }

// // permutation des cellules : 
switchPos(emptyCell) {
    // let tempX = this.x;
    // let tempY = this.y;
    let tempState = this.state; // Egalement échanger les states
    
    // this.x = emptyCell.x;
    // this.y = emptyCell.y;
    this.state = emptyCell.state; // Egalement échanger les states
    
    // emptyCell.x = tempX;
    // emptyCell.y = tempY;
    emptyCell.state = tempState; // Egalement échanger les states
}



    // représentation html de la cellule
    cellHTMLDisplay(grid){
        let cellHtml = document.createElement("div");
        // Dans la méthode cellHTMLDisplay(grid)
        cellHtml.setAttribute("id", "cell-" + this.id);

        cellHtml.setAttribute("data-cell", this.state);
        cellHtml.setAttribute("class", "cell");

        // ajout d'un eventListener 

        cellHtml.addEventListener("click", () => this.move(grid))
        if( this.state != "empty"){
             cellHtml.innerHTML = this.state;
        }
       

        return cellHtml;
    }
}

class Grid
{
    static LENGTH = 3;
    constructor(){
        // tableau de cellules
        this.cellTab = [];
        this.length = Grid.length;
        this.gridBuilder();
    }

    // construcion d'un array 2D de cellules
    gridBuilder(){
        let cellIndex = 0;
        for (let line = 0; line < Grid.LENGTH; line ++){
            for (let column = 0; column < Grid.LENGTH; column++){
                let cell = new Cell(cellIndex, column, line);
                this.cellTab.push(cell);
                cellIndex += 1;
            }
        }

        // on mélange le tableau
        this.randomTab();
        
    }

    // trie le tableau de manière aléatoire 
    randomTab(){
        // récupération des ids avec la méthode map
        const ids = this.cellTab.map( cell => cell.id);
        console.log(ids);
        // tri des ids 
        ids.sort(() => Math.random() - 0.5);
        console.log(ids);
        // ré attribution des ids 
        this.cellTab.forEach( (cell, index) => {
            cell.state = ids[index];
        }  )
        let randomStateNumber = Math.floor(Math.random() * (this.cellTab.length + 1));
        this.cellTab[randomStateNumber].state = "empty";

    }

    // affichage du tableau html : 
    gridHTMLDisplay(){
        // on récupère l'élément container
        let containerHTML = document.querySelector('.container');
        // itération sur le tableau et affichage des div. 
        for( let cell of this.cellTab){
            containerHTML.appendChild(cell.cellHTMLDisplay(this));
        }

    }
}

let grid = new Grid();

console.log(grid.cellTab);

grid.gridHTMLDisplay();




