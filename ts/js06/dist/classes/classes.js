// Shape : classe abstraite qui permet de servir de base pour construire les éléments 
export class Shape {
    coords = { x: 0, y: 0 };
    dimensions = { width: Blob.DEFAULT_WIDTH, height: Blob.DEFAULT_HEIGHT };
}
/**
 * classe rectangle : classe abstraite qui permet de servir de base pour construire les rectangles,
 * en leur ajouter la classe 'rect' définie dans le fichier input.scss
 */
export class Rect extends Shape {
    htmlElement;
    constructor() {
        super();
    }
    build(container) {
        let containerElt = container.getHtmlElement();
        this.htmlElement = document.createElement('div');
        this.coords.x = 100;
        this.coords.y = 0;
        containerElt.appendChild(this.htmlElement);
    }
    display(x, color) {
        this.htmlElement.style.setProperty('--x-position', `${x}px`);
        this.htmlElement.style.setProperty('--y-position', `${this.coords.y}px`);
        this.htmlElement.style.setProperty('--color', `${color}`);
        this.htmlElement.classList.add('rect');
    }
    getHtmlElement() {
        return this.htmlElement;
    }
    move(vInit = 1, accel = 0) {
        let acceleration = 1;
        let ratio = 1;
        setInterval(() => {
            this.coords.y += (vInit * acceleration);
            acceleration += accel;
            this.htmlElement.style.setProperty('--y-position', `${this.coords.y}px`);
            if (this.coords.y >= 430) {
                this.coords.y = 430;
                acceleration *= -1;
                this.htmlElement.classList.add('off');
            }
            else if (this.coords.y <= 0) {
                this.coords.y = 0;
                acceleration *= -1;
                // ratio = 1;
            }
        }, 100);
    }
}
export class SquareContainer {
    shapes;
    square;
    coords;
    dimensions;
    htmlElement;
    constructor(shapes = [], square = new Blob(), coords = { x: 0, y: 0 }, dimensions = { width: 50, height: 50 }, htmlElement = document.querySelector('.container__square')) {
        this.shapes = shapes;
        this.square = square;
        this.coords = coords;
        this.dimensions = dimensions;
        this.htmlElement = htmlElement;
    }
    getCoords() {
        return this.coords;
    }
    getSquareCoords() {
        return this.square.getCoords();
    }
    setCoords(coords) {
        this.coords.x = coords.x;
        this.coords.y = coords.y;
        return this;
    }
    getHtmlElement() {
        return this.htmlElement;
    }
    getBlob() {
        return this.square;
    }
    addShape(shape) {
        this.shapes.push(shape);
    }
    getShapes() {
        return this.shapes;
    }
}
export class Blob extends Shape {
    htmlElement;
    static DEFAULT_WIDTH = 50;
    static DEFAULT_HEIGHT = 50;
    static isDragging = false;
    static startX = 0;
    static startY = 0;
    static initialX = 0;
    static initialY = 0;
    constructor(htmlElement = document.querySelector('[data-object="square"]')) {
        super();
        this.htmlElement = htmlElement;
        this.animateSquare();
    }
    getCoords() {
        return this.coords;
    }
    getHtmlElement() {
        return this.htmlElement;
    }
    // fonction fléchée -> 
    animateSquare = () => {
        setInterval(() => {
            if (this.htmlElement.classList.contains('square')) {
                this.htmlElement.classList.remove('square');
                this.htmlElement.classList.add('circle');
            }
            else {
                this.htmlElement.classList.remove('circle');
                this.htmlElement.classList.add('square');
            }
        }, 1000);
    };
    moveSquare(e, button, square, squareContainerElement) {
        if (square instanceof HTMLElement) {
            let posX = square.offsetLeft;
            let posY = square.offsetTop;
            if (e instanceof MouseEvent) {
                if (button) {
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
                else {
                    if (e.type === 'mousedown') {
                        Blob.isDragging = true;
                        Blob.startX = e.clientX;
                        Blob.startY = e.clientY;
                        Blob.initialX = posX;
                        Blob.initialY = posY;
                    }
                    if (e.type === 'mousemove' && Blob.isDragging) {
                        const dx = e.clientX - Blob.startX;
                        const dy = e.clientY - Blob.startY;
                        posX = Blob.initialX + dx;
                        posY = Blob.initialY + dy;
                    }
                    if (e.type === 'mouseup') {
                        Blob.isDragging = false;
                    }
                }
            }
            else if (e instanceof KeyboardEvent) {
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
            }
            // Limite les positions à l'intérieur du conteneur
            let containerWidth = squareContainerElement?.getBoundingClientRect().width || 0;
            let containerHeigth = squareContainerElement?.getBoundingClientRect().height || 0;
            posX = Math.min(Math.max(posX, 0), containerWidth - 50);
            posY = Math.min(Math.max(posY, 0), containerHeigth - 50); // Peut-être utiliser containerHeight ici ?
            // Applique les nouvelles positions
            square.style.left = `${posX}px`;
            square.style.top = `${posY}px`;
        }
    }
}
export class GamePad {
    htmlElement;
    constructor(htmlElement = document.querySelectorAll('[data-button]')) {
        this.htmlElement = htmlElement;
    }
    getHtmlElement() {
        return this.htmlElement;
    }
}
