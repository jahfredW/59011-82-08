// création de la nouvelle image : 
const imageOn = document.createElement('img') as HTMLImageElement;
imageOn.id = "on";
imageOn.src = "../assets/on.png";

// création de la nouvelle image : 
const imageOff = document.createElement('img') as HTMLImageElement;
imageOff.id = "off";
imageOff.src = "../assets/off.png";

const  imgContainer= document.querySelector('.img-container') as HTMLBodyElement;
imgContainer.appendChild(imageOff);

const imageShow = (e : Event) => {
    e.preventDefault();
    const target = e.target as HTMLImageElement;
    
    if(target.id == "off" ){
        imgContainer.removeChild(imageOff);
        imgContainer.appendChild(imageOn);
    } else if(target.id == "on"){
        imgContainer.removeChild(imageOn);
        imgContainer.appendChild(imageOff);

}
}
document.addEventListener('click', imageShow)

