// Tic Tac Toe AI with Minimax Algorithm
// The Coding Train / Daniel Shiffman
// https://thecodingtrain.com/CodingChallenges/154-tic-tac-toe-minimax.html
// https://youtu.be/I64-UTORVfU
// https://editor.p5js.org/codingtrain/sketches/0zyUhZdJD

function bestMove() {
    // AI to make its turn
    let bestScore = -Infinity;
    let move;
    for (let i = 0; i < 3; i++) {
      for (let j = 0; j < 3; j++) {
        // Check si le spot est diponible
        if (board[i][j] == '') {
          board[i][j] = ai;
          // récupération du score de la position grace à la méthode minimax
          let score = minimax(board, 0, false);
          // annulation du déplacement pour ne pas altérer le jeu 
          board[i][j] = '';
          // SI le score est maximal, alors il devient le meilleur score, 
          // Et la position la meilleur. 
          if (score > bestScore) {
            bestScore = score;
            move = { i, j };
          }
        }
      }
    }
    // déplace de l'IA vers cette position
    board[move.i][move.j] = ai;
    // changement du tout de jeu 
    currentPlayer = human;
  }
  

  // tableau des scores 

  let scores = {
    X: 10,
    O: -10,
    tie: 0
  };
  
  function minimax(board, depth, isMaximizing) {
    let result = checkWinner();
    if (result !== null) {
      return scores[result];
    }
  
    if (isMaximizing) {
      let bestScore = -Infinity;
      for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
          // Is the spot available?
          if (board[i][j] == '') {
            board[i][j] = ai;
            let score = minimax(board, depth + 1, false);
            board[i][j] = '';
            bestScore = max(score, bestScore);
          }
        }
      }
      return bestScore;
    } else {
      let bestScore = Infinity;
      for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
          // Is the spot available?
          if (board[i][j] == '') {
            board[i][j] = human;
            let score = minimax(board, depth + 1, true);
            board[i][j] = '';
            bestScore = min(score, bestScore);
          }
        }
      }
      return bestScore;
    }
  }




  