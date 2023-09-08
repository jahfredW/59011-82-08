
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


/**
 * Interface pour la construction des bateaux 
 */
interface IShipInterface {
    build(container : SquareContainer) : void;
    display(x : number) : void;
    move(vInit : number, accel : number) : void;
    getHtmlElement(): HTMLElement;
}


// Shape : classe abstraite qui permet de servir de base pour construire les éléments 
export abstract class Shape {
    static DEFAULT_WIDTH : number = 50;
    static DEFAULT_HEIGHT : number = 50;
    protected coords : squareCoords = { x : 250, y : 430 };
    protected dimensions : squareDimensions = { width : Shape.DEFAULT_WIDTH, height : Shape.DEFAULT_HEIGHT};
    protected htmlElement!: HTMLImageElement;
}


export class Bullet implements IhtmlElementInterface  {

    constructor(private coords : { x : number, y : number} = { x : 0, y : 0}, 
        private dimensions : { width : number, height : number} = { width : 5, height : 5 },
        private htmlElement : HTMLImageElement = document.querySelector<HTMLImageElement>('.bullet')!) {
          
    }

    // Contruction de la bullet en html
    build(container: HTMLElement): void {
        this.htmlElement = document.createElement("img");
        this.htmlElement.classList.add("bullet");
        this.htmlElement.src = " ../../assets/plane/missile.png"
        this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
        this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);
        container.appendChild(this.htmlElement);
    }

    getHtmlElement(): HTMLElement {
        return this.htmlElement;
    }

    setCoord(x : number, y : number) : void {
        this.coords.x = x ;
        this.coords.y = y ;
    }

    getCoord(){
        return { "x" : this.coords.x, "y" : this.coords.y }
    }

    display(){
        let vInit = 1;
        let lastime : number | null = null;
        const animate = (time : number) =>  {
            if(lastime !== null){
                const deltaTime = time - lastime;
                this.coords.y -= vInit * (deltaTime);

                if(this.coords.y < 0){
                    this.htmlElement.classList.add("off");
                    this.htmlElement.remove();
                }
                
                this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
                this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);
            }

            lastime = time;

            requestAnimationFrame(animate);
        }

        requestAnimationFrame(animate);
    }
}


/**
 * classe rectangle : classe abstraite qui permet de servir de base pour construire les rectangles,
 * en leur ajouter la classe 'rect' définie dans le fichier input.scss
 */
export class Ship extends Shape implements IShipInterface {

  constructor() {
    super();    
  }

  // Contruction du rectangle
  build(container: SquareContainer): void {
    let containerElt = container.getHtmlElement();
    this.htmlElement = document.createElement("img");
    this.htmlElement.src=  " ../../assets/cruiser/ship.png";
    this.coords.x = 100;
    this.coords.y = 0;
    containerElt.appendChild(this.htmlElement);
  }

  // affichage du rectangle en utlisant les propriétés CSS 
  display(): void {
    let x = Math.floor(Math.random() * 1000) + 1; 
    this.htmlElement.style.setProperty("--x-position", `${x}px`);
    this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
    this.htmlElement.classList.add("rect");
  }

  // récupération de l'élement html correspondant à ce rectangle
  getHtmlElement(): HTMLElement {
    return this.htmlElement;
  }

  move(vInit: number = 1, accel: number = 0): void {
    let acceleration = 1;
    let lastTime: number | null = null;

    const animate = (time: number) => {
      if (lastTime !== null) {
        // delta : temps entre le temps gobal et le deriet temps 
        const deltaTime = time - lastTime;

        // Utilisez deltaTime pour rendre l'animation indépendante du taux de rafraîchissement
        this.coords.y += vInit * acceleration * (deltaTime / 100);

        // Appliquez les limites
        if (this.coords.y >= 430) {
          this.coords.y = 430;
          acceleration *= -1;
          this.htmlElement.classList.add("off");
          this.htmlElement.remove();
        } else if (this.coords.y <= 0) {
          this.coords.y = 0;
          acceleration *= -1;
        }

        // Mettez à jour la propriété CSS
        this.htmlElement.style.setProperty(
          "--y-position",
          `${this.coords.y}px`
        );
      }

      lastTime = time;

      // Planifiez la prochaine itération
      requestAnimationFrame(animate);
    };

    // Lancez l'animation
    requestAnimationFrame(animate);
  }
}


export class Cruiser extends Ship {
    // Contruction du rectangle
    constructor(){
        super();
    }

    // Surcharge de la méthode build
    build(container: SquareContainer): void {
    let containerElt = container.getHtmlElement();
    this.htmlElement = document.createElement("img");
    this.htmlElement.src=  " ../../assets/cruiser/ship.png";
    this.coords.x = 100;
    this.coords.y = 0;
    containerElt.appendChild(this.htmlElement);    
    
  }
}

export abstract class ShipFactory {

    shipOrder(ship_type : string, container : SquareContainer){
        let ship = this.shipCreate(ship_type);
        ship.build(container);
        ship.display();
        ship.move();
    }

    abstract shipCreate(ship_type : string) : Ship
}


export class ConcreteEnnemyShipFactory extends ShipFactory {
    shipCreate(ship_type: string): Ship {
        if (ship_type === "cruiser") {
            return new Cruiser();
        } else {
            throw new Error("ship type not found");
        }
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
        
        private bulletContainer : Bullet[] = [] // tableau d'objets bullets
        
    ){  
        super();
        // this.bullet = new Bullet(super.coords);  
        this.htmlElement = document.createElement('img');
        // this.animateSquare();
    }
    

    display(posX : number, posY : number){
        this.htmlElement.style.setProperty("--x-position", `${posX}px`);
        this.htmlElement.style.setProperty("--y-position", `${posY}px`);
    }

    build(container : SquareContainer){
        this.htmlElement.classList.add("square");
        this.htmlElement.src = "../../assets/plane/plane.png"
        this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);
        this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
        container.getHtmlElement().appendChild(this.htmlElement);
        
    }

    shoot(squareContainer : HTMLElement) : void {
        let bullet = new Bullet();
        
        bullet.setCoord(this.coords.x, this.coords.y);  // Définir les coordonnées avant de construire
        console.log(bullet.getCoord());
        bullet.build(squareContainer);
        this.bulletContainer.push(bullet);
        bullet.display();
    }
    

    getCoords() : squareCoords {
        return this.coords;
    }

    getHtmlElement() : HTMLElement {
        return this.htmlElement;
    }

    // fonction fléchée -> 
    // animateSquare = (): void => {
    //     let lastTime: number | null = null;
    //     let totalTime = 0;
      
    //     const animate = (time: number) => {
    //       if (lastTime !== null) {
    //         const deltaTime = time - lastTime;
    //         totalTime += deltaTime;
      
    //         if (totalTime >= 1000) {
    //           // Faites la commutation toutes les 1000 millisecondes (1 seconde)
    //           if (this.htmlElement.classList.contains('square')) {
    //             this.htmlElement.classList.remove('square');
    //             this.htmlElement.classList.add('circle');
    //           } else {
    //             this.htmlElement.classList.remove('circle');
    //             this.htmlElement.classList.add('square');
    //           }
      
    //           // Réinitialiser totalTime pour le prochain intervalle
    //           totalTime = 0;
    //         }
    //       }
      
    //       lastTime = time;
      
    //       // Planifiez la prochaine itération
    //       requestAnimationFrame(animate);
    //     };
      
    //     // Lancez l'animation
    //     requestAnimationFrame(animate);
    //   };
      
      

    moveSquare(e :  Event, button: HTMLElement | null, squareContainerElement: HTMLElement)  : void {
       
                // mise à jour des positions du Blob ET de son tir Bullet 
                    // let posX = this.htmlElement.offsetLeft;
                    // let posY = this.htmlElement.offsetTop;
                    
                    if (e instanceof MouseEvent) {
                        e.preventDefault();
                        if(button){
                            switch (button.getAttribute('data-button')) {
                                case "right":
                                    this.coords.x += 10;
                                    
                                    break;
                                case "left":
                                    this.coords.x -= 10;
                                
                                    break;
                                case "down":
                                    this.coords.y+= 10;
                                
                                    break;
                                case "up":
                                    this.coords.y -= 10;
                                 
                                    break;
                        }
                        } else {
                            // if (e.type === 'mousedown') {
                            //     // Blob.isDragging = true;
                            //     // Blob.startX = e.clientX;
                            //     // Blob.startY = e.clientY;
                            //     // Blob.initialX = this.coords.x;
                            //     // Blob.initialY = this.coords.y;
                            // }
                            if (e.type === 'mousemove' ) {   // &Blob.isDragging
                                
                                const dx = e.clientX - this.coords.x;
                                const dy = e.clientY - this.coords.y;
                                console.log(dx, dy);
                                this.coords.x = this.coords.x + dx;
                                this.coords.y = this.coords.y + dy;
                            }
                            if (e.type === 'mousedown') {
                                this.shoot(squareContainerElement)
                            }
                        }
                        
                } else if (e instanceof KeyboardEvent) {
                    switch (e.key) {
                        case "ArrowRight":
                            console.log('roght');
                            this.coords.x += 10;
                            break;
                        case "ArrowLeft":
                      
                            this.coords.x -= 10;
                            break;
                        case "ArrowDown":
                     
                            this.coords.y += 10;
                            break;
                        case "ArrowUp":
                            this.coords.y -= 10;
                            break;
                        case " ":
                            this.shoot(squareContainerElement);  
                    }
           

                

                // this.display(posX, posY)
                
    }
    // Limite les positions à l'intérieur du conteneur
    let containerWidth = squareContainerElement?.getBoundingClientRect().width || 0;
    let containerHeigth = squareContainerElement?.getBoundingClientRect().height || 0;
    this.coords.x = Math.min(Math.max(this.coords.x, 0), containerWidth - 50);
    this.coords.y = Math.min(Math.max(this.coords.y, 0), containerHeigth - 50);  // Peut-être utiliser containerHeight ici ?
    

    
    // Applique les nouvelles positions
    this.htmlElement.style.left = `${this.coords.x}px`;
    this.htmlElement.style.top = `${this.coords.y}px`;
    
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

