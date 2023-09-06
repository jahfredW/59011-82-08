
/**
 * Interface pour les coordonnées de base du container. 
 */
interface ContainerCoords {
    x : number,
    y : number
}

/**
 * Interface pour les dimensiosn de base du container 
 */
interface ContainerDimensions {
    width : number,
    height : number
}

/**
 * Interface coordonnées du carré 
 */
interface squareCoords {
    x : number,
    y : number
}

/**
 * interface dimensions du carré 
 */
interface squareDimensions {
    width : number,
    height : number
}


export class SquareContainer<T> {
    constructor( 
        private  square : Square = new Square(),
        private coords : ContainerCoords = {x:0,y:0},
        private dimensions: ContainerDimensions = {width:50,height:50},
        private htmlElement : HTMLElement = document.querySelector('.container__square')!
        ) {
     
        }

    getCoords() : ContainerCoords {
        return this.coords;
    }

    getSquareCoords() : squareCoords {
        return this.square.getCoords();
    }

    setCoords(coords : ContainerCoords) : this {
        this.coords.x = coords.x;
        this.coords.y = coords.y;
        return this;
    }
    getHtmlElement() : HTMLElement {
        return this.htmlElement;
    }
}


export class Square {
    static readonly DEFAULT_WIDTH = 50;
    static readonly DEFAULT_HEIGHT = 50;

    constructor(
        private coords : squareCoords = { x : 0, y : 0 },
        private dimensions : squareDimensions = { width : Square.DEFAULT_WIDTH, height : Square.DEFAULT_HEIGHT},
        private htmlElement : HTMLElement = document.querySelector('[data-object="square"]')!
    ){
        
    }
    
    getCoords() : squareCoords {
        return this.coords;
    }

    getHtmlElement() : HTMLElement {
        return this.htmlElement;
    }
    
}

let container = new SquareContainer()
console.log(container.getSquareCoords());