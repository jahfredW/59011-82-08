/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

// Construction du plateau de jeu : 

class Board{
    static instanceCount = 0

    constructor(){
        Board.instanceCount += 1
        this.grid = [];
        this.id = `Grid_${Board.instanceCount}`;
        this.isDisabled = false;
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


class MotherBoard{
    constructor(){
        this.grids = [];
        this.builder();
    }

    builder(){
        for (let i = 0; i < 3; i++){
            let line = [];
            for ( let j = 0; j < 3; j++ ){
                let board = new Board();
                line.push( board)
            }
            this.grids.push( line );
        }
    }
}

// construction de la motherBoard
let motherBoard = new MotherBoard();

let currentGrid = null;


/**
 * tableau des scores
 */
 let scores = {
    X : 10,
    O : -10, 
    tie: 0,
}

let gameTurn = 1;



let gridGame = [];

let danger = false;
let userOuputX = 0;
let userOuputY = 0;

        

let ai = 'X';
let opponent = 'O';
let currentPlayer = ai;


/**
 * Méthode de remplissage de la board 
 * @param {Array} motherBoard 
 * @param {int} row 
 * @param {int} col 
 */
 function fillInBoard(motherBoard, row, col, currentPlayer){
    let xGrid = col != 0 ? Math.ceil(col / 3) - 1 : Math.ceil(col / 3);
    let yGrid = row != 0 ? Math.ceil(row / 3) - 1 : Math.ceil(row / 3);

    let xInCurrentGrid = col % 3;
    let yInCurrentGrid = row % 3;

    // récupération de la current grid
    let currentGrid = motherBoard.grids[yGrid][xGrid]

    // alimentation de la current Grid 
    currentGrid.grid[yInCurrentGrid][xInCurrentGrid] = currentPlayer;

  

}

/**
 * Méthode de remplissage de la board 
 * @param {Array} motherBoard 
 * @param {int} row 
 * @param {int} col 
 */
 function findGrid(motherBoard, row, col){

    console.error("Col", col)
    console.error("Row", row)
    let xGrid = col % 3
    let yGrid = row % 3

    console.error("xGrid", xGrid)
    console.error("yGrid", yGrid)
    // récupération de la current grid
    let currentGrid = motherBoard.grids[yGrid][xGrid]

    if (currentGrid.Disabled){
        // recherche d'une sous-grille disponible
        for ( let item of motherBoard){
            if( !item.isDisabled){
                currentGrid = item.grid;
                break;
            }
        }
    }


    console.error("CurrentGridInFinGRid :", currentGrid)
    return currentGrid;

}

let lastPlayerRow = -1;
let lastPlayerCol = -1;

// game loop
while (true) {

    var inputs = readline().split(' ');
    // x du joueur au tour précédent
    const opponentRow = parseInt(inputs[0]);
    // y du joueur au tour précédent
    const opponentCol = parseInt(inputs[1]);
 
    
    // coordonnées où l'on peut jouer 
    const validActionCount = parseInt(readline());
    for (let i = 0; i < validActionCount; i++) {
        var inputs = readline().split(' ');
        const row = parseInt(inputs[0]);
        const col = parseInt(inputs[1]);
       
        // alimentation de la liste des bonnes actions


        // Ici il va falloir utiliser des méthodes pour mettre en relation la board 
        // avec les classes motherBoard et Board
        fillInBoard(motherBoard, row, col, "")
    }
    

    // board[userOutputY][userOutputX] = 'X';

    // mise à jour de la board avec la position de l'adversaire
    if (opponentRow != -1 && opponentCol != -1 ){
        fillInBoard(motherBoard, opponentRow, opponentCol, opponent)
    }

    // init de la première grid
    if(gameTurn == 1){
        currentGrid = motherBoard.grids[0][0];
     
    } else {
        // if(gameTurn % 2 != 0 ){
        //     console.error("joueur", lastPlayerRow, lastPlayerCol)
        //     currentGrid = findGrid(motherBoard, lastPlayerRow, lastPlayerCol)
        // } else {
        //    console.error("opponent", opponentRow, opponentCol)
        //    currentGrid = findGrid(motherBoard, opponentRow, opponentCol);
        // }
        currentGrid = findGrid(motherBoard, opponentRow, opponentCol);
    }


    let move = bestMove(currentGrid)

    // reconvertir derrière 
    let globalMove = convertMove(move, currentGrid);




    fillInBoard(motherBoard, globalMove.i, globalMove.j, ai)

    // localisation de la grid dans laquelle jouer 

    lastPlayerRow = globalMove.j;
    lastPlayerCol = globalMove.i;
    
    gameTurn += 1;
    

    // debug du tableau global 
    for (let item of motherBoard.grids){
        console.error(item.id);
    }


    
    console.log(`${globalMove.j} ${globalMove.i}`)

    

}


/**
 * 
 */
function convertMove(move, currentGrid){

    let newCoord = {}

    switch(currentGrid.id){
        case 'Grid_1':
            newCoord.i = move.i;
            newCoord.j = move.j;
            break;
        case 'Grid_2':
            newCoord.i = move.i + 3;
            newCoord.j = move.j;
            break;
        case 'Grid_3':
            newCoord.i = move.i + 6;
            newCoord.j = move.j;
            break;
        case 'Grid_4':
            newCoord.i = move.i;
            newCoord.j = move.j + 3;
            break;
        case 'Grid_5':
            newCoord.i = move.i + 3;
            newCoord.j = move.j + 3;
            break;
        case 'Grid_6':
            newCoord.i = move.i + 6;
            newCoord.j = move.j + 3;
            break;
        case 'Grid_7':
            newCoord.i = move.i;
            newCoord.j = move.j + 6;
            break;
        case 'Grid_8':
            newCoord.i = move.i + 3;
            newCoord.j = move.j + 6;
            break;
        case 'Grid_9':
            newCoord.i = move.i + 6;
            newCoord.j = move.j + 6;
            break;
    }

    return newCoord;
}






/**
 * Function minimax 
 * permet d'établir un score sur les positions
 */
 function minimax(board, depth, isMaximizing) {
  let result = checkWinner(board);

  if (result !== null) {
      board.isDisabled = true;
      return scores[result];
  }

  if (isMaximizing) {
      let bestScore = -Infinity;
      for (let i = 0; i < 3; i++) {
          for (let j = 0; j < 3; j++) {
            
              if (board.grid[i][j] == '') {
                  board.grid[i][j] = ai;
                  let score = minimax(board, depth + 1, false);
                  board.grid[i][j] = '';
                  bestScore = Math.max(score, bestScore);
              }
          }
      }
      return bestScore;
  } else {
      let bestScore = Infinity;
      for (let i = 0; i < 3; i++) {
          for (let j = 0; j < 3; j++) {
              if (board.grid[i][j] == '') {
                  board.grid[i][j] = opponent;
                  let score = minimax(board, depth + 1, true);
                  board.grid[i][j] = '';
                  bestScore = Math.min(score, bestScore);
              }
          }
      }
      return bestScore;
  }
}

/**
 * calcul du meilleur mouvement à effectuer 
 */
function bestMove(board) {
  let bestScore = -Infinity;
  let move = { i: -1, j: -1 };

  for (let i = 0; i < 3; i++) {
      for (let j = 0; j < 3; j++) {
          if (board.grid[i][j] == '') {
              board.grid[i][j] = ai;
              let score = minimax(board, 0, true);
              board.grid[i][j] = '';

              if (score > bestScore) {
                  bestScore = score;
                  move = { i, j };
              }
          }
      }
  }

  return move;
}





function equal3(a, b, c){
    return a == b && b == c && a != '';
}


function checkWinner(board)
{
    let winner = null;

    // recherche verticale
    for ( let index = 0; index < 3; index++){
        if( equal3(board.grid[index][0], board.grid[index][1], board.grid[index][2])){
            winner = board.grid[index][0];
            
        }
    }
    
    // recherche horizontakle
    for ( let index = 0; index < 3; index ++){
        if(equal3(board.grid[0][index],board.grid[1][index], board.grid[2][index] )){
            winner = board.grid[0][index];
            
        }
    }

    // diagonale
    if ( equal3(board.grid[0][0], board.grid[1][1], board.grid[2][2])){
        winner = board.grid[0][0];
        
    }

    if ( equal3(board.grid[2][0], board.grid[1][1], board.grid[0][2])){
        winner = board.grid[2][0];
    }

    let openSpots = 0;
    for (let i = 0; i < 3; i++) {
      for (let j = 0; j < 3; j++) {
        if (board.grid[i][j] == '') {
          openSpots++;
        }
      }
    }
  
    if (winner == null && openSpots == 0) {
      return 'tie';
    } else {
      return winner;
    }

}

