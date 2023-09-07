
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
    static DEFAULT_WIDTH : number = 50;
    static DEFAULT_HEIGHT : number = 50;
    protected coords : squareCoords = { x : 0, y : 0 };
    protected dimensions : squareDimensions = { width : Shape.DEFAULT_WIDTH, height : Shape.DEFAULT_HEIGHT};
}


export class Bullet implements IhtmlElementInterface  {

    constructor(private coords : { x : number, y : number} = { x : 0, y : 0}, 
        private dimensions : { width : number, height : number} = { width : 5, height : 5 },
        private htmlElement : HTMLElement = document.querySelector<HTMLElement>('.bullet')!) {
          
    }

    // Contruction de la bullet en html
    build(container: HTMLElement): void {
        this.htmlElement = document.createElement("div");
        this.htmlElement.classList.add("bullet");
        container.appendChild(this.htmlElement);
    }

    getHtmlElement(): HTMLElement {
        return this.htmlElement;
    }

    setCoord(x : number, y : number) : void {
        this.coords.x = x ;
        this.coords.y = y ;
    }

    display(){
        let vInit = 1;
        let lastime : number | null = null;
        const animate = (time : number) =>  {
            if(lastime !== null){
                const deltaTime = time - lastime;
                this.coords.y -= vInit * (deltaTime / 100);

                if(this.coords.y < 0){
                    this.htmlElement.classList.add("off");
                    this.htmlElement.remove();
                }
                
                this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
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
export class Rect extends Shape implements IShapeBuilderInterface {
  private htmlElement!: HTMLElement;
  constructor() {
    super();    
  }

  // Contruction du rectangle
  build(container: SquareContainer): void {
    let containerElt = container.getHtmlElement();
    this.htmlElement = document.createElement("div");
    this.coords.x = 100;
    this.coords.y = 0;
    containerElt.appendChild(this.htmlElement);
  }

  // affichage du rectangle en utlisant les propriétés CSS 
  display(x: number, color: string): void {
    this.htmlElement.style.setProperty("--x-position", `${x}px`);
    this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
    this.htmlElement.style.setProperty("--color", `${color}`);
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
        private htmlElement : HTMLElement = document.querySelector('[data-object="square"]')!,
        private bulletContainer : Bullet[] = [] // tableau d'objets bullets
        
    ){  
        super();
        // this.bullet = new Bullet(super.coords);  
        this.animateSquare();
    }
    

    shoot(squareContainer : HTMLElement) : void {
        let bullet = new Bullet();
        bullet.build(squareContainer)
        bullet.setCoord(this.getCoords().x, this.getCoords().y);
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
    animateSquare = (): void => {
        let lastTime: number | null = null;
        let totalTime = 0;
      
        const animate = (time: number) => {
          if (lastTime !== null) {
            const deltaTime = time - lastTime;
            totalTime += deltaTime;
      
            if (totalTime >= 1000) {
              // Faites la commutation toutes les 1000 millisecondes (1 seconde)
              if (this.htmlElement.classList.contains('square')) {
                this.htmlElement.classList.remove('square');
                this.htmlElement.classList.add('circle');
              } else {
                this.htmlElement.classList.remove('circle');
                this.htmlElement.classList.add('square');
              }
      
              // Réinitialiser totalTime pour le prochain intervalle
              totalTime = 0;
            }
          }
      
          lastTime = time;
      
          // Planifiez la prochaine itération
          requestAnimationFrame(animate);
        };
      
        // Lancez l'animation
        requestAnimationFrame(animate);
      };
      
      

    moveSquare(e :  Event, button: HTMLElement | null,  square: HTMLElement | null, squareContainerElement: HTMLElement)  : void {
        
            if(square instanceof HTMLElement) {

                // mise à jour des positions du Blob ET de son tir Bullet 
                    let posX = square.offsetLeft;
                    let posY = square.offsetTop;
                    // let bulletX = this.bullet.getHtmlElement().offsetLeft;
                    // let bulletY = this.bullet.getHtmlElement().offsetTop;
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
                        case " ":
                            console.log("touche espace pressée")
                            this.shoot(squareContainerElement);  
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

    