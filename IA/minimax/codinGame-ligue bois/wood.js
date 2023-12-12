/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

// Construction du plateau de jeu : 

/**
 * tableau des scores
 */
let scores = {
    X : 10,
    O : -10, 
    tie: 0,
}
let gridGame = [];

let danger = false;
let userOuputX = 0;
let userOuputY = 0;

// for(let row = 0; row < 3; row ++ ){
//     let line = [];
//     for ( let col = 0; col < 3; col ++){
//         let cell = {
//             "isNeutral" : true,
//             "isOpponent" : false,
//          };
//         line.push(cell)
//     }
//     gridGame.push(line);
// }

// construction du jeu 
let board = [
    ['', '', ''],
    ['', '', ''],
    ['', '', '']
]

let ai = 'X';
let opponent = 'O';
let currentPlayer = ai;

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
     board[row][col] = '';
    }
    

    // board[userOutputY][userOutputX] = 'X';

    // mise à jour de la board avec la position de l'adversaire
    if (opponentRow != -1 && opponentCol != -1 ){
        board[opponentRow][opponentCol] = "O";
    }

    
    let move = bestMove(board)


    board[move.i][move.j] = 'X';
    
 
    console.log(`${move.i} ${move.j}`)

}




/**
 * Function minimax 
 * permet d'établir un score sur les positions
 */
 function minimax(board, depth, isMaximizing) {
  let result = checkWinner(board);

  if (result !== null) {
      return scores[result];
  }

  if (isMaximizing) {
      let bestScore = -Infinity;
      for (let i = 0; i < 3; i++) {
          for (let j = 0; j < 3; j++) {
              if (board[i][j] == '') {
                  board[i][j] = ai;
                  let score = minimax(board, depth + 1, false);
                  board[i][j] = '';
                  bestScore = Math.max(score, bestScore);
              }
          }
      }
      return bestScore;
  } else {
      let bestScore = Infinity;
      for (let i = 0; i < 3; i++) {
          for (let j = 0; j < 3; j++) {
              if (board[i][j] == '') {
                  board[i][j] = opponent;
                  let score = minimax(board, depth + 1, true);
                  board[i][j] = '';
                  bestScore = Math.min(score, bestScore);
              }
          }
      }
      return bestScore;
  }
}


function bestMove(board) {
  let bestScore = -Infinity;
  let move = { i: -1, j: -1 };

  for (let i = 0; i < 3; i++) {
      for (let j = 0; j < 3; j++) {
          if (board[i][j] == '') {
              board[i][j] = ai;
              let score = minimax(board, 0, false);
              board[i][j] = '';

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
        if( equal3(board[index][0], board[index][1], board[index][2])){
            winner = board[index][0];
            
        }
    }
    
    // recherche horizontakle
    for ( let index = 0; index < 3; index ++){
        if(equal3(board[0][index],board[1][index], board[2][index] )){
            winner = board[0][index];
            
        }
    }

    // diagonale
    if ( equal3(board[0][0], board[1][1], board[2][2])){
        winner = board[0][0];
        
    }

    if ( equal3(board[2][0], board[1][1], board[0][2])){
        winner = board[2][0];
    }

    let openSpots = 0;
    for (let i = 0; i < 3; i++) {
      for (let j = 0; j < 3; j++) {
        if (board[i][j] == '') {
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

