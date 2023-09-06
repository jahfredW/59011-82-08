
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

// interface pour la méthode de récupération de l'élément HTML
interface IhtmlElementInterface<T = HTMLElement | NodeListOf<HTMLElement>>{
    getHtmlElement(): T;
}

// interface builder, pour construire les différents shapes 
interface IShapeBuilderInterface {
    build(container : SquareContainer): void;
    display( x : number, color: string): void;
}

// Shape : classe abstraite qui permet de servir de base pour construire les éléments 
export abstract class Shape {
    protected coords : squareCoords = { x : 0, y : 0 };
    protected dimensions : squareDimensions = { width : Blob.DEFAULT_WIDTH, height : Blob.DEFAULT_HEIGHT};
}

/**
 * classe rectangle : classe abstraite qui permet de servir de base pour construire les rectangles,
 * en leur ajouter la classe 'rect' définie dans le fichier input.scss
 */
export class Rect extends Shape implements IShapeBuilderInterface {

    private htmlElement!: HTMLElement; 
    constructor() {
        super();

    }

    build(container : SquareContainer) : void {
        let containerElt = container.getHtmlElement();
        this.htmlElement = document.createElement('div');
        this.coords.x = 100;
        this.coords.y = 0;
        containerElt.appendChild(this.htmlElement);

    }

    display(x : number, color: string) : void {
        this.htmlElement.style.setProperty('--x-position', `${x}px`);
        this.htmlElement.style.setProperty('--y-position', `${this.coords.y}px`);
        this.htmlElement.style.setProperty('--color', `${color}`);
        this.htmlElement.classList.add('rect');
    }

    getHtmlElement() : HTMLElement {
        return this.htmlElement;
    }

    move(vInit : number = 1, accel: number = 0 ) : void {
        let acceleration = 1;
        let ratio = 1;
        setInterval( () => {
            this.coords.y += (vInit * acceleration);
            acceleration += accel;
            this.htmlElement.style.setProperty('--y-position', `${this.coords.y}px`);
            if(this.coords.y >= 430){
                this.coords.y = 430;
                acceleration *= -1
                this.htmlElement.classList.add('off');
            } else if(this.coords.y <= 0){
                this.coords.y = 0;
                acceleration *= -1
                
                // ratio = 1;
            }
        }, 100)
    }
}







export class SquareContainer implements IhtmlElementInterface {
    constructor( 
        private shapes : Shape[] = [],
        private square : Blob = new Blob(),
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

    getBlob() : Blob {
    return this.square
    }

    addShape(shape : Shape) : void {
        this.shapes.push(shape);
    }

    getShapes() : Shape[] {
        return this.shapes;
    }
    
}


export class Blob extends Shape implements IhtmlElementInterface  {
    static readonly DEFAULT_WIDTH = 50;
    static readonly DEFAULT_HEIGHT = 50;
    static isDragging = false;
    static startX = 0;
    static startY = 0;
    static initialX = 0; 
    static initialY = 0;


    constructor(
        private htmlElement : HTMLElement = document.querySelector('[data-object="square"]')!
        
    ){  
        super();
        this.animateSquare();
    }   
    
    getCoords() : squareCoords {
        return this.coords;
    }

    getHtmlElement() : HTMLElement {
        return this.htmlElement;
    }

    // fonction fléchée -> 
    animateSquare = () : void => {
        setInterval( () => {
            if (this.htmlElement.classList.contains('square')) {
                this.htmlElement.classList.remove('square');
                this.htmlElement.classList.add('circle');
            } else {
                this.htmlElement.classList.remove('circle');
                this.htmlElement.classList.add('square');
            }
        }, 1000)
        
    }

    moveSquare(e :  Event, button: HTMLElement | null,  square: HTMLElement | null, squareContainerElement: HTMLElement | null )  : void {
        
            if(square instanceof HTMLElement) {
              
                    let posX = square.offsetLeft;
                    let posY = square.offsetTop;
                    if (e instanceof MouseEvent) {
                        if(button){
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
                        } else {
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
                        
                } else if (e instanceof KeyboardEvent) {
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
                posY = Math.min(Math.max(posY, 0), containerHeigth - 50);  // Peut-être utiliser containerHeight ici ?

                // Applique les nouvelles positions
                square.style.left = `${posX}px`;
                square.style.top = `${posY}px`;
                
    }
    
}
}


export class GamePad implements IhtmlElementInterface{
    constructor(
        private htmlElement : NodeListOf<HTMLElement> = document.querySelectorAll<HTMLElement>('[data-button]')!
    ){}

    getHtmlElement() : NodeListOf<HTMLElement> { 
        return this.htmlElement;
    }

    

}

    