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
          // positionnement de l'IA aux coordonnées
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
    // condition de sortie de la boucle récursive : un vainqueur 
    let result = checkWinner();
    if (result !== null) {
      return scores[result];
    }
    
    // tour de l'IA qui doit maximiser le score 
    if (isMaximizing) {
      // init du bestScore au minimal 
      let bestScore = -Infinity;
      // parcours de la grille 
      for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
          // Recherche si la cellule est disponible
          if (board[i][j] == '') {
            // Si disponible positionnement de l'IA 
            board[i][j] = ai;
            // utilisation de minimax qui renvoie le score de la current cellule
            let score = minimax(board, depth + 1, false);
            // Libération de la case 
            board[i][j] = '';
            // sauvegarde du meilleur score. 
            bestScore = max(score, bestScore);
          }
        }
      }
      // on retourne le meilleur score trouvé 
      return bestScore;
    } else {
      // init du bestScore au maximal  
      let bestScore = Infinity;
      for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
          // Is the spot available?
          if (board[i][j] == '') {
            // postionnement de l'humain 
            board[i][j] = human;
            let score = minimax(board, depth + 1, true);
            board[i][j] = '';
            // récupération et sauvegarde du score minimum 
            bestScore = min(score, bestScore);
          }
        }
      }
      // on retourne le score minimal 
      return bestScore;
    }
}




  