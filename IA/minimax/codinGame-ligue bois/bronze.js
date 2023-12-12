class MotherBoard{
    constructor(){
        this.grids = [];
        this.builder();
    }

    builder(){
        for (let i = 0; i < 3; i++){
            let line = [];
            for ( let j = 0; j < 3; j++ ){
                line.push( new Board())
            }
            this.grids.push( line );
        }
    }
}



class Board{
    constructor(){
        this.grid = [];
        this.cell = "";
        this.builder();
    }

    builder(){
        for( let i = 0; i < 3 ; i++){
            let line = [];
            for( let j = 0; j < 3; j++){
                line.push("");
            }
            this.grid.push( line);
        }
    }

}


let motherBoard = new MotherBoard();

console.log( motherBoard);


