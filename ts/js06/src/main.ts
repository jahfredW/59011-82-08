import { SquareContainer, GamePad, Rect, Blob } from './classes/classes';

// Instanciation des éléments 
const squareContainer = new SquareContainer();
const gamePad = new GamePad();
const blob = new Blob();
blob.build(squareContainer);

// récupération des éléments HTML correspondants à la classe
const blobElement = blob.getHtmlElement();
const squareContainerElement = squareContainer.getHtmlElement();
const directionButtons = gamePad.getHtmlElement();


let colorTab = ['red', 'green', 'blue', 'yellow', 'purple'];
let x  = 100;
let vInit = 1;
let accel = 1;

let timer = 3000;
function executeInterval() {
    let i = Math.floor(Math.random() * 5);
    const rect = new Rect();
    rect.build(squareContainer);
    rect.display(x, colorTab[i]);
    squareContainer.addShape(rect);
    vInit = Math.floor(Math.random() * 10) / 10 + 1;
    accel = Math.floor(Math.random() * 10) / 100;
    rect.move(vInit, accel);
    x = Math.floor(Math.random() * 1000) + 1;

    setTimeout(executeInterval, timer);
}

executeInterval();

// Button Events
directionButtons.forEach(button => {
    if (button instanceof HTMLElement) {
        button.addEventListener('click', (e) => blob.moveSquare(e, button, squareContainerElement));
    }
});

// Global Events
document.addEventListener('keydown', (e) => blob.moveSquare(e, null, squareContainerElement));
document.addEventListener('mousedown', (e) => blob.moveSquare(e, null, squareContainerElement));
document.addEventListener('mousemove', (e) => blob.moveSquare(e, null, squareContainerElement));
document.addEventListener('mouseup', (e) => blob.moveSquare(e, null, squareContainerElement));


