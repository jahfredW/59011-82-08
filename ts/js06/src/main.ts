let isDragging = false;
let startX = 0, startY = 0;
let initialX = 0, initialY = 0;

import { Square, SquareContainer} from  '../dist/classes/classes.js'

const square = new Square();
const squareContainer = new SquareContainer();

let squareElement = square.getHtmlElement();
let squareContainerElement = squareContainer.getHtmlElement();

// const square = document.querySelector('[data-object="square"]') as HTMLElement;
// const squareContainer = document.querySelector('.container__square');
const directionButtons = document.querySelectorAll('[data-button]');

// Animate Square
const animateSquare = () => {
    if (squareElement.classList.contains('square')) {
        squareElement.classList.remove('square');
        squareElement.classList.add('circle');
    } else {
        squareElement.classList.remove('circle');
        squareElement.classList.add('square');
    }
};

// Animate Square every 1 second
setInterval(animateSquare, 1000);

// Move Square Function
const moveSquare = (e: Event, button: HTMLElement | null, square: HTMLElement | null) => {
    if (square instanceof HTMLElement) {
        let posX = square.offsetLeft;
        let posY = square.offsetTop;

        if (button) {
            // Handle button clicks
            if (e instanceof MouseEvent) {
                switch (button.getAttribute('data-button')) {
                    case "right":
                        posX += 10;
                        break;
                    case "left":
                        posX -= 10;
                        break;
                    case "down":
                        posY += 10;
                        break;
                    case "up":
                        posY -= 10;
                        break;
                }
            }
        } else if (e instanceof KeyboardEvent) {
            // Handle keyboard events
            switch (e.key) {
                case "ArrowRight":
                    posX += 10;
                    break;
                case "ArrowLeft":
                    posX -= 10;
                    break;
                case "ArrowDown":
                    posY += 10;
                    break;
                case "ArrowUp":
                    posY -= 10;
                    break;
            }
        } else if (e instanceof MouseEvent) {
            // Handle drag events
            if (e.type === 'mousedown') {
                isDragging = true;
                startX = e.clientX;
                startY = e.clientY;
                initialX = posX;
                initialY = posY;
            }
            if (e.type === 'mousemove' && isDragging) {
                const dx = e.clientX - startX;
                const dy = e.clientY - startY;
                posX = initialX + dx;
                posY = initialY + dy;
            }
            if (e.type === 'mouseup') {
                isDragging = false;
            }
        }

        // Clamp positions within container
        let containerWidth = squareContainerElement.getBoundingClientRect().width || 0;
        posX = Math.min(Math.max(posX, 0), containerWidth - 50);
        posY = Math.min(Math.max(posY, 0), 450);

        square.style.left = `${posX}px`;
        square.style.top = `${posY}px`;
    }
};

// Button Events
directionButtons.forEach(button => {
    if (button instanceof HTMLElement) {
        button.addEventListener('click', (e) => moveSquare(e, button, squareElement));
    }
});

// Global Events
document.addEventListener('keydown', (e) => moveSquare(e, null, squareElement));
document.addEventListener('mousedown', (e) => moveSquare(e, null, squareElement));
document.addEventListener('mousemove', (e) => moveSquare(e, null, squareElement));
document.addEventListener('mouseup', (e) => moveSquare(e, null, squareElement));
