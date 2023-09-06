import { SquareContainer, GamePad, Rect } from './classes/classes.js';
// Instanciation des éléments 
const squareContainer = new SquareContainer();
const gamePad = new GamePad();
// récupération des éléments HTML correspondants à la classe
const squareElement = squareContainer.getBlob().getHtmlElement();
const squareContainerElement = squareContainer.getHtmlElement();
const directionButtons = gamePad.getHtmlElement();
let colorTab = ['red', 'green', 'blue', 'yellow', 'purple'];
let x = 100;
let vInit = 1;
let accel = 1;
let timer = 3000;
function executeInterval() {
    let i = Math.floor(Math.random() * 5);
    const rect = new Rect();
    rect.build(squareContainer);
    rect.display(x, colorTab[i]);
    vInit = Math.floor(Math.random() * 10) / 10 + 1;
    accel = Math.floor(Math.random() * 10) / 100;
    rect.move(vInit, accel);
    x = Math.floor(Math.random() * 1000) + 1;
    timer -= 100;
    if (timer <= 100) {
        timer = 100;
    }
    setTimeout(executeInterval, timer);
}
executeInterval();
// Button Events
directionButtons.forEach(button => {
    if (button instanceof HTMLElement) {
        button.addEventListener('click', (e) => squareContainer.getBlob().moveSquare(e, button, squareElement, squareContainerElement));
    }
});
// Global Events
document.addEventListener('keydown', (e) => squareContainer.getBlob().moveSquare(e, null, squareElement, squareContainerElement));
document.addEventListener('mousedown', (e) => squareContainer.getBlob().moveSquare(e, null, squareElement, squareContainerElement));
document.addEventListener('mousemove', (e) => squareContainer.getBlob().moveSquare(e, null, squareElement, squareContainerElement));
document.addEventListener('mouseup', (e) => squareContainer.getBlob().moveSquare(e, null, squareElement, squareContainerElement));
