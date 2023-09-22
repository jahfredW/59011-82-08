let clickCount = 0;
let imagesArray = [];
let attemps = 0;


/**
 * fonction qui ajoute une photo de couverture pour chaque image 
 */
function addRectoImage(){
    let images = document.querySelectorAll("[data-image]");
    images.forEach((image, index) => {
        let newDiv = document.createElement("img");
        newDiv.classList.add("recto");  // ajouter une classe pour la nouvelle div
        newDiv.classList.add("on");  // ajouter une classe pour la nouvelle div
        newDiv.src = "./assets/plage.jpg"; 
        newDiv.setAttribute("data-cover", index ); // ajouter le contenu HTML dans la nouvelle div
        image.parentNode.appendChild(newDiv);  // ajoute la nouvelle div comme enfant de la div parente
    });
    console.log(images);
}

/**
 * retournement des cartes toutes les deux tours 
 */
function reset(e){
    e.preventDefault();
    disableClickOnImages();
    // Si les sources des images correspondent : 
    if (checkImage(imagesArray[0], imagesArray[1])){

        let image1 = imagesArray[1];
        let image2 = imagesArray[0];
        console.log(image1, image2);
        // on ajoute la classe discover aux images 
        image1.classList.add("discover");
        image2.classList.add("discover");

        setTimeout( () => {
            image1.classList.add('fade-out');
            image2.classList.add('fade-out');
        }, 2000)
        // ajout d'un transition 
        // on retire du DOM l'élement de couverture correspondant 
        image1.nextElementSibling.remove();
        image2.nextElementSibling.remove();

    }
    // récupération de toutes les images : 
    let images = document.querySelectorAll("[data-image]");
    // récupération de toutes les covers : 
    let covers = document.querySelectorAll("[data-cover]");
    // réinitisaliation après 2 secondes si les images n'ont pas été découvertes :) 
    setTimeout( () => {
        images.forEach( image => {
            if (!image.classList.contains("discover")){
                image.classList.add("off");
            }
        });
        covers.forEach( cover => { 
            if (!cover.classList.contains("discover")){
                cover.classList.remove("off");
            }
        });
        enableClickOnImages();
        imagesArray = [];
        attemps += 1;
    }, 2000)

}


/**
 * fonction de retrounement d'une image : 
 * @param {event} e 
 */
function swipeImage(e){
 
    // Si la photo est une photo de couverture, alors on peut cliquer dessus 
    if(e.target.hasAttribute("data-cover")){

        let imageId = e.target.getAttribute("data-cover");
        let image = document.querySelector(`[data-image="${imageId}"]`);
      
        // alimentation de l'array contenant la pair d'images selectionnée
        imagesArray.push(image);

        // incrémentation du compteur de click 
        clickCount += 1;

        // si le compteur de click est un chiffre pair, alors on utilise la fonction reset 
        if(clickCount % 2 == 0 && clickCount != 0){
            console.log(clickCount);
            console.log('reset');
            reset(e);
        }

        // si la couverture contient la classe off, alors on la rend visible
        // on rend l'image correspondante invisible
        if(e.target.classList.contains("off")){
            e.target.classList.remove("off");

            // on la rend invisible
            image.classList.add("off");
        } else {
            
            // sion on rend la couverture invisible
            e.target.classList.add("off");
            
            // et l'image visible 
            image.classList.remove("off");
       
        }

    // pour tous les autersa cas on evite la propagation 
    } else {
        // on desactive le clique : 
        e.preventDefault();
        return;

    }

    
   
    
}

/**
 * Check si la source de l'image 1 et égale à l'image 2 
 * @param {} imageSrc1 
 * @param {*} imageSrc2 
 * @returns boolean
 */
function checkImage(image1, image2){
    // si les sources des images et la même, alors on renvoie true : 
    if(image1.src === image2.src){
        return true;
    } 
    // de base false est renvoyé 
    return false; 
}

function checkWin(){
    const imagesWithoutDiscover = document.querySelectorAll('img:not(.discover)');
    console.log(imagesWithoutDiscover);
    if(imagesWithoutDiscover.length === 0){
        console.log('partie gagnée');
        let winDiv = document.querySelector('.win');
        winDiv.classList.remove('off');
        let attempsSpan = document.querySelector('h2 span');
        attempsSpan.innerHTML = attemps;
        disableClickOnImages();
    }
}

// fonction de call back pour l'eventListenr
function handleImageClick(event) {
    event.preventDefault();
    event.stopPropagation();
  }

function disableClickOnImages() {
    const allImages = document.querySelectorAll('img');
    allImages.forEach((img) => {
      img.addEventListener('click', handleImageClick);
    });
  }

function enableClickOnImages() {
    const allImages = document.querySelectorAll('img');
    allImages.forEach((img) => {
      img.removeEventListener('click',  handleImageClick);
    });
  }

// Ajotu d'une photo de couverture pour chaque image. 
addRectoImage();



// " GAME LOOP "   
document.addEventListener("click", (e) => {
    e.preventDefault();
    e.stopPropagation();

    swipeImage(e);
    checkWin();
    
})


