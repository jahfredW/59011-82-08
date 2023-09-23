class Cell
{
    constructor(id, x, y){
        this.id = id;
        this.x = x;
        this.y = y;
        this.state = "";
        
    }

    // vérifie si une cellule peut bouger
    globalCheck(grid) {
        this.checkWin(grid);
        // récupération des cellules à coté, et au dessus - dessous
        // recherche de la cellule vide : si dans juste à coté de la cellule courante, alors ok
        let currentCell = this;
        let emptyCell = grid.cellTab.find(cell => cell.state == 0);

        // récupération 


        console.log("current", currentCell);
        console.log("empty", emptyCell);
        console.log('tableau', grid.cellTab);

        // on compare les coordonnées : 
        if ((emptyCell.x == this.x && Math.abs(emptyCell.y - this.y) == 1) 
           || (emptyCell.y == this.y && Math.abs(emptyCell.x - this.x) == 1)){
                this.switch(emptyCell);
        }
    }

    //permutation des cellules : 
    switch(emptyCell) {
        
        let tempState = this.state; // Egalement échanger les states
        
        // permuation des data-cells
        let currentCellDiv = document.getElementById("cell-" + this.id);
        currentCellDiv.setAttribute('data-cell', emptyCell.state);

        let emptyCellDiv = document.getElementById("cell-" + emptyCell.id);
        emptyCellDiv.setAttribute('data-cell', tempState);
        
        // permutation des states
        this.state = emptyCell.state; // Egalement échanger les states
        emptyCell.state = tempState; // Egalement échanger les states

        // permtutation des innerHtml
        [currentCellDiv.innerHTML, emptyCellDiv.innerHTML] = [emptyCellDiv.innerHTML, currentCellDiv.innerHTML];
    }

    displayWin(){
        // on remove les listeners 
        console.log("ici");
        let cellsHtml = document.querySelectorAll(".cell");
        if (cellsHtml){
            cellsHtml.forEach( element => {
                element.removeEventListener("click", () => this.globalCheck(grid));
            });
        }
    }

    /**
     * vérifie si le joueur a gagné
     * @param {array} grid 
     */
    checkWin(grid){
       let isSorted = this.isSorted(grid.cellTab, "state");
       
       if(isSorted){
          this.displayWin()
       }
    }
    /**
     * Permet de savoir si un taleau est trié 
     * @param { array } array 
     * @param { property} property 
     * @returns { boolean } // indique si le tableau est trié ou nom. 
     */
    isSorted(array, property){
        for( let index = 0; index < array.length - 1; index ++ ){
            console.log(array[index + 1][property])
            if(array[index + 1][property] < array[index][property]){
                return false;
            }
        }
        return true;
    }

    // représentation html de la cellule
    cellHTMLDisplay(grid){
        let cellHtml = document.createElement("div");
        // Dans la méthode cellHTMLDisplay(grid)
        cellHtml.setAttribute("id", "cell-" + this.id);

        cellHtml.setAttribute("data-cell", this.state);
        cellHtml.setAttribute("class", "cell");

        // ajout d'un eventListener 

        cellHtml.addEventListener("click", () => this.globalCheck(grid))
        if( this.state != 0){
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
        // ids.sort(() => Math.random() - 0.5);
        console.log(ids);
        // ré attribution des ids 
        this.cellTab.forEach( (cell, index) => {
            cell.state = ids[index];
        }  )
        // let randomStateNumber = Math.floor(Math.random() * (this.cellTab.length + 1));
        // this.cellTab[randomStateNumber].state = "empty";

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
grid.gridHTMLDisplay();




