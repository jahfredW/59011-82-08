import { SquareContainer, GamePad, Blob, SpawnManager, Ship } from './classes/classes.js';
// Instanciation des éléments 
const squareContainer = new SquareContainer();
const gamePad = new GamePad();
const blob = new Blob();
blob.build(squareContainer);
// récupération des éléments HTML correspondants à la classe
const blobElement = blob.getHtmlElement();
const squareContainerElement = squareContainer.getHtmlElement();
const directionButtons = gamePad.getHtmlElement();
let lastTime = 0;
let accumulatedTime = 0;
const shipSpawnRate = 2000;
let spawnManager = new SpawnManager(squareContainer);
function gameLoop(timestamp) {
    let deltaTime = timestamp - lastTime;
    lastTime = timestamp;
    spawnManager.update(timestamp);
    for (const ship of Ship.allShips) {
        ship.move(deltaTime);
    }
    // Mettez ici le code pour créer des bateaux, etc.
    // Vous pouvez utiliser deltaTime pour ajuster le timing
    requestAnimationFrame(gameLoop);
}
requestAnimationFrame(gameLoop);
// let colorTab = ['cruiser'];
// let x  = 100;
// let vInit = 1;
// let accel = 1;
// let timer = 5000;
// function executeInterval() {
//     // rect.build(squareContainer);
//     // rect.display(x, colorTab[i]);
//     // squareContainer.addShape(rect);
//     // vInit = Math.floor(Math.random() * 10) / 10 + 1;
//     // accel = Math.floor(Math.random() * 10) / 100;
//     // rect.move(vInit, accel);
//     // x = Math.floor(Math.random() * 1000) + 1;
//     setTimeout(executeInterval, timer);
// }
// executeInterval();
// Button Events
directionButtons.forEach(button => {
    if (button instanceof HTMLElement) {
        button.addEventListener('click', (e) => blob.moveSquare(e, button, squareContainerElement));
    }
});
// Global Events
document.addEventListener('keyup', (e) => blob.moveSquare(e, null, squareContainerElement));
document.addEventListener('mousedown', (e) => blob.moveSquare(e, null, squareContainerElement));
document.addEventListener('mousemove', (e) => blob.moveSquare(e, null, squareContainerElement));
document.addEventListener('mouseup', (e) => blob.moveSquare(e, null, squareContainerElement));
