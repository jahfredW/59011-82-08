
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


export class SquareContainer<T> {
    constructor( 
        private  square : Square,
        private coords : ContainerCoords,
        private dimensions: ContainerDimensions
        ) {
            this.square = new Square(0, 0, 50, 50); // Initialisation ici
        this.coords = { x: 0, y: 0 };  // Initialisation ici
        this.dimensions = { width: 100, height: 100 };
        }

    init() : void {
        this.square = new Square(0, 0, 50, 50);
        this.coords = { x : 0, y : 0}
    }

    getCoords() : ContainerCoords {
        if(this.coords){
            return this.coords;
        }
    }
}


export class Square {
    constructor(
        private x: number,
        private y: number,
        private width: number,
        private height: number,
    ){}
}

let container = new SquareContainer()