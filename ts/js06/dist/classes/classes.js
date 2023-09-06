export class SquareContainer {
    constructor(square = new Square(), coords = { x: 0, y: 0 }, dimensions = { width: 50, height: 50 }, htmlElement = document.querySelector('.container__square')) {
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
}
export class Square {
    constructor(coords = { x: 0, y: 0 }, dimensions = { width: Square.DEFAULT_WIDTH, height: Square.DEFAULT_HEIGHT }, htmlElement = document.querySelector('[data-object="square"]')) {
        this.coords = coords;
        this.dimensions = dimensions;
        this.htmlElement = htmlElement;
    }
    getCoords() {
        return this.coords;
    }
    getHtmlElement() {
        return this.htmlElement;
    }
}
Square.DEFAULT_WIDTH = 50;
Square.DEFAULT_HEIGHT = 50;
let container = new SquareContainer();
console.log(container.getSquareCoords());
