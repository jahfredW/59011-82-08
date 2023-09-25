import IShipInterface from "./IShipInterface";
import SquareContainer from "./SquareContainer";


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

/**
 * classe rectangle : classe abstraite qui permet de servir de base pour construire les rectangles,
 * en leur ajouter la classe 'rect' définie dans le fichier input.scss
 */
export default class Ship  implements IShipInterface {
    static allShips : Ship[] = [];

  constructor(
        protected coords : squareCoords = { x : 250, y : 430 },
        protected htmlElement : HTMLImageElement = document.querySelector<HTMLImageElement>('.rect')!,
        protected dimensions : squareDimensions = { width : 5, height : 5},
  ) {
     
    console.log("this before pushing", this);  // Debugging line
    SquareContainer.shipList.push(this);
    console.log("SquareContainer after pushing", SquareContainer.shipList);  // Debugging line
  }

  // Contruction du rectangle
  build(container: SquareContainer): void {
    let containerElt = container.getHtmlElement();
    this.htmlElement = document.createElement("img");
    
    this.htmlElement.src=  " ../../assets/cruiser/ship.png";
    this.coords.x =  Math.floor(Math.random() * 1000) + 1; ;
    this.coords.y = 0;

    this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
    this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);

    containerElt.appendChild(this.htmlElement);

           
    this.dimensions.width = this.htmlElement.offsetWidth;
    this.dimensions.height = this.htmlElement.offsetHeight;

  }

  getCoordX() : number {
    return this.coords.x;
  }

  getCoordY() : number {
    return this.coords.y;
  }

  getWidth() : number {
    return this.dimensions.width;
  }

  getHeight() : number {
    return this.dimensions.height;
  }

  // affichage du rectangle en utlisant les propriétés CSS 
  display(): void {
    this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);
    this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
    this.htmlElement.classList.add("rect");
    
  }

  // récupération de l'élement html correspondant à ce rectangle
  getHtmlElement(): HTMLElement {
    return this.htmlElement;
  }

  move(deltaTime: number = 0): void {
    let acceleration = 1;
    let vInit = 1;

    // Utilisez deltaTime pour rendre l'animation indépendante du taux de rafraîchissement
    this.coords.y += vInit * acceleration * (deltaTime / 10);

    // Appliquez les limites
    // if (this.coords.y >= 430) {
    //     this.coords.y = 430;
    //     acceleration *= -1;
    //     this.htmlElement.classList.add("off");
    //     this.htmlElement.remove();
    // } else if (this.coords.y <= 0) {
    //     this.coords.y = 0;
    //     acceleration *= -1;
    // }

    // Mettez à jour la propriété CSS
    this.htmlElement.style.setProperty(
        "--y-position",
        `${this.coords.y}px`
    );

  }
}