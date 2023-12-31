// Shape : classe abstraite qui permet de servir de base pour construire les éléments 
export class Shape {
    static DEFAULT_WIDTH = 50;
    static DEFAULT_HEIGHT = 50;
    coords = { x: 250, y: 430 };
    dimensions = { width: Shape.DEFAULT_WIDTH, height: Shape.DEFAULT_HEIGHT };
    htmlElement;
}
export class Bullet {
    coords;
    dimensions;
    htmlElement;
    constructor(coords = { x: 0, y: 0 }, dimensions = { width: 5, height: 5 }, htmlElement = document.querySelector('.bullet')) {
        this.coords = coords;
        this.dimensions = dimensions;
        this.htmlElement = htmlElement;
    }
    // Contruction de la bullet en html
    build(container) {
        this.htmlElement = document.createElement("img");
        this.htmlElement.classList.add("bullet");
        this.htmlElement.src = " ../../assets/plane/missile.png";
        this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
        this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);
        container.appendChild(this.htmlElement);
    }
    getHtmlElement() {
        return this.htmlElement;
    }
    setCoord(x, y) {
        this.coords.x = x;
        this.coords.y = y;
    }
    getCoord() {
        return { "x": this.coords.x, "y": this.coords.y };
    }
    display() {
        let vInit = 1;
        let lastime = null;
        const animate = (time) => {
            if (lastime !== null) {
                const deltaTime = time - lastime;
                this.coords.y -= vInit * (deltaTime);
                if (this.coords.y < 0) {
                    this.htmlElement.classList.add("off");
                    this.htmlElement.remove();
                }
                this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
                this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);
            }
            lastime = time;
            requestAnimationFrame(animate);
        };
        requestAnimationFrame(animate);
    }
}
/**
 * classe rectangle : classe abstraite qui permet de servir de base pour construire les rectangles,
 * en leur ajouter la classe 'rect' définie dans le fichier input.scss
 */
export class Ship extends Shape {
    static allShips = [];
    constructor() {
        super();
        Ship.allShips.push(this);
    }
    // Contruction du rectangle
    build(container) {
        let containerElt = container.getHtmlElement();
        this.htmlElement = document.createElement("img");
        this.htmlElement.src = " ../../assets/cruiser/ship.png";
        this.coords.x = 100;
        this.coords.y = 0;
        containerElt.appendChild(this.htmlElement);
    }
    // affichage du rectangle en utlisant les propriétés CSS 
    display() {
        let x = Math.floor(Math.random() * 1000) + 1;
        this.htmlElement.style.setProperty("--x-position", `${x}px`);
        this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
        this.htmlElement.classList.add("rect");
    }
    // récupération de l'élement html correspondant à ce rectangle
    getHtmlElement() {
        return this.htmlElement;
    }
    move(deltaTime = 0) {
        let acceleration = 1;
        let vInit = 1;
        // Utilisez deltaTime pour rendre l'animation indépendante du taux de rafraîchissement
        this.coords.y += vInit * acceleration * (deltaTime / 100);
        // Appliquez les limites
        if (this.coords.y >= 430) {
            this.coords.y = 430;
            acceleration *= -1;
            this.htmlElement.classList.add("off");
            this.htmlElement.remove();
        }
        else if (this.coords.y <= 0) {
            this.coords.y = 0;
            acceleration *= -1;
        }
        // Mettez à jour la propriété CSS
        this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
    }
}
export class Cruiser extends Ship {
    // Contruction du rectangle
    constructor() {
        super();
    }
    // Surcharge de la méthode build
    build(container) {
        let containerElt = container.getHtmlElement();
        this.htmlElement = document.createElement("img");
        this.htmlElement.src = " ../../assets/cruiser/ship.png";
        this.coords.x = 100;
        this.coords.y = 0;
        containerElt.appendChild(this.htmlElement);
    }
}
export class Submarine extends Ship {
    constructor() {
        super();
    }
    // Surcharge de la méthode build
    build(container) {
        let containerElt = container.getHtmlElement();
        this.htmlElement = document.createElement("img");
        this.htmlElement.src = " ../../assets/submarine/ship.png";
        this.coords.x = 100;
        this.coords.y = 0;
        containerElt.appendChild(this.htmlElement);
    }
}
export class ShipFactory {
    shipOrder(ship_type, container) {
        let ship = this.shipCreate(ship_type);
        ship.build(container);
        ship.display();
        ship.move();
    }
}
export class ConcreteEnnemyShipFactory extends ShipFactory {
    shipCreate(ship_type) {
        if (ship_type === "cruiser") {
            return new Cruiser();
        }
        else if (ship_type === "submarine") {
            return new Submarine();
        }
        else {
            throw new Error("ship type not found");
        }
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
    bulletContainer;
    static DEFAULT_WIDTH = 50;
    static DEFAULT_HEIGHT = 50;
    static isDragging = false;
    static startX = 0;
    static startY = 0;
    static initialX = 0;
    static initialY = 0;
    constructor(bulletContainer = [] // tableau d'objets bullets
    ) {
        super();
        this.bulletContainer = bulletContainer;
        // this.bullet = new Bullet(super.coords);  
        this.htmlElement = document.createElement('img');
        // this.animateSquare();
    }
    display(posX, posY) {
        this.htmlElement.style.setProperty("--x-position", `${posX}px`);
        this.htmlElement.style.setProperty("--y-position", `${posY}px`);
    }
    build(container) {
        this.htmlElement.classList.add("square");
        this.htmlElement.src = "../../assets/plane/plane.png";
        this.htmlElement.style.setProperty("--x-position", `${this.coords.x}px`);
        this.htmlElement.style.setProperty("--y-position", `${this.coords.y}px`);
        container.getHtmlElement().appendChild(this.htmlElement);
    }
    shoot(squareContainer) {
        let bullet = new Bullet();
        bullet.setCoord(this.coords.x, this.coords.y); // Définir les coordonnées avant de construire
        console.log(bullet.getCoord());
        bullet.build(squareContainer);
        this.bulletContainer.push(bullet);
        bullet.display();
    }
    getCoords() {
        return this.coords;
    }
    getHtmlElement() {
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
    moveSquare(e, button, squareContainerElement) {
        // mise à jour des positions du Blob ET de son tir Bullet 
        // let posX = this.htmlElement.offsetLeft;
        // let posY = this.htmlElement.offsetTop;
        if (e instanceof MouseEvent) {
            e.preventDefault();
            if (button) {
                switch (button.getAttribute('data-button')) {
                    case "right":
                        this.coords.x += 10;
                        break;
                    case "left":
                        this.coords.x -= 10;
                        break;
                    case "down":
                        this.coords.y += 10;
                        break;
                    case "up":
                        this.coords.y -= 10;
                        break;
                }
            }
            else {
                // if (e.type === 'mousedown') {
                //     // Blob.isDragging = true;
                //     // Blob.startX = e.clientX;
                //     // Blob.startY = e.clientY;
                //     // Blob.initialX = this.coords.x;
                //     // Blob.initialY = this.coords.y;
                // }
                if (e.type === 'mousemove') { // &Blob.isDragging
                    const dx = e.clientX - this.coords.x;
                    const dy = e.clientY - this.coords.y;
                    console.log(dx, dy);
                    this.coords.x = this.coords.x + dx;
                    this.coords.y = this.coords.y + dy;
                }
                if (e.type === 'mousedown') {
                    this.shoot(squareContainerElement);
                }
            }
        }
        else if (e instanceof KeyboardEvent) {
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
        this.coords.y = Math.min(Math.max(this.coords.y, 0), containerHeigth - 50); // Peut-être utiliser containerHeight ici ?
        // Applique les nouvelles positions
        this.htmlElement.style.left = `${this.coords.x}px`;
        this.htmlElement.style.top = `${this.coords.y}px`;
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
export class SpawnManager {
    squareContainer;
    lastTime = 0;
    accumulatedTime = 0;
    nextSpawnTime = {};
    shipSpawnRate = {
        'cruiser': 10000,
        'submarine': 6000,
        // Ajoutez d'autres types de bateaux ici
    };
    shipTypes = ['cruiser', 'submarine'];
    constructor(squareContainer) {
        this.squareContainer = squareContainer;
        for (const shipType of this.shipTypes) {
            this.nextSpawnTime[shipType] = this.shipSpawnRate[shipType];
        }
    }
    update(timestamp) {
        const deltaTime = timestamp - this.lastTime;
        this.lastTime = timestamp;
        this.accumulatedTime += deltaTime;
        for (const shipType of this.shipTypes) {
            this.nextSpawnTime[shipType] -= deltaTime;
            if (this.nextSpawnTime[shipType] <= 0) {
                console.log("Spawning", shipType);
                this.nextSpawnTime[shipType] = this.shipSpawnRate[shipType];
                const shipFactory = new ConcreteEnnemyShipFactory();
                let ship = shipFactory.shipOrder(shipType, this.squareContainer);
            }
        }
    }
}
