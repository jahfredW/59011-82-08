"use strict";
let currentX = 0; // Pour garder la trace de la position actuelle en X
let currentY = 0; // Pour garder la trace de la position actuelle en Y
const square = document.querySelector('[data-object="square"]');
const squareContainer = document.querySelector('.container__square');
const directionButtons = document.querySelectorAll('[data-button]');
console.log(directionButtons);
setTimeout(() => {
    square?.classList.add('circle');
}, 2000);
// fonction d'animation du Blob ;) ;) 
const animateSquare = () => {
    if (square?.classList.contains('square')) {
        square?.classList.remove('square');
        square?.classList.add('circle');
    }
    else {
        square?.classList.remove('circle');
        square?.classList.add('square');
    }
};
let isDragging = false;
let startX = 0, startY = 0; // coordonnées du point de départ
let initialX = 0, initialY = 0; // positions initiales de la div
// Cela supprime la nécessité d'utiliser setTimeout
// car setInterval fera tout le travail
setInterval(animateSquare, 1000);
const moveSquare = (e, button, square) => {
    if (square instanceof HTMLElement) {
        let posX = square.offsetLeft;
        let posY = square.offsetTop;
        if (button) {
            if (e instanceof MouseEvent) {
                switch (button.getAttribute('data-button')) {
                    case "right":
                        posX += 10;
                        square.style.setProperty('--x-position', `${posX}px`);
                        break;
                    case "left":
                        posX -= 10;
                        square.style.setProperty('--x-position', `${posX}px`);
                        break;
                    case "down":
                        posY += 10;
                        square.style.setProperty('--y-position', `${posY}px`);
                        break;
                    case "up":
                        posY -= 10;
                        square.style.setProperty('--y-position', `${posY}px`);
                        break;
                    default:
                        console.log('default');
                }
            }
        }
        else {
            if (e instanceof KeyboardEvent) {
                switch (e.key) {
                    case "ArrowRight":
                        posX += 10;
                        square.style.setProperty('--x-position', `${posX}px`);
                        break;
                    case "ArrowLeft":
                        posX -= 10;
                        square.style.setProperty('--x-position', `${posX}px`);
                        break;
                    case "ArrowDown":
                        posY += 10;
                        square.style.setProperty('--y-position', `${posY}px`);
                        break;
                    case "ArrowUp":
                        posY -= 10;
                        square.style.setProperty('--y-position', `${posY}px`);
                        break;
                    default:
                        console.log('default');
                        return;
                }
            }
            else if (e instanceof MouseEvent) {
                if (square) {
                    if (e.type === 'mousedown') {
                        isDragging = true;
                        startX = e.clientX;
                        startY = e.clientY;
                        initialX = square.offsetLeft;
                        initialY = square.offsetTop;
                    }
                    if (isDragging) {
                        if (e.type === 'mousemove') {
                            const dx = e.clientX - startX;
                            const dy = e.clientY - startY;
                            square.style.left = (initialX + dx) + "px";
                            square.style.top = (initialY + dy) + "px";
                        }
                    }
                    if (e.type === 'mouseup') {
                        isDragging = false;
                    }
                }
            }
        }
        // récupération de la largeur du conteneur 
        let containerWidth = squareContainer?.getBoundingClientRect().width;
        if (containerWidth) {
            console.log("containerWidth", containerWidth);
            if (posX < 0) {
                posX = 0;
            }
            else if (posX > containerWidth - 50) {
                posX = containerWidth - 50;
            }
            if (posY < 0) {
                posY = 0;
            }
            else if (posY > 450) {
                {
                    posY = 450;
                }
            }
            square.style.setProperty('--x-position', `${posX}px`);
            square.style.setProperty('--y-position', `${posY}px`);
        }
    }
};
directionButtons.forEach(button => {
    if (button instanceof HTMLElement) {
        if (square) {
            button.addEventListener('click', (e) => moveSquare(e, button, square));
        }
    }
});
document.addEventListener('keydown', (e) => moveSquare(e, null, square));
document.addEventListener('mousedown', (e) => moveSquare(e, null, square));
document.addEventListener('mousemove', (e) => moveSquare(e, null, square));
document.addEventListener('mouseup', (e) => moveSquare(e, null, square));
