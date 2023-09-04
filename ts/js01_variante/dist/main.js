"use strict";
// création de la nouvelle image : 
const imageOn = document.createElement('img');
imageOn.id = "on";
imageOn.src = "../assets/on.png";
// création de la nouvelle image : 
const imageOff = document.createElement('img');
imageOff.id = "off";
imageOff.src = "../assets/off.png";
const imgContainer = document.querySelector('.img-container');
imgContainer.appendChild(imageOff);
const imageShow = (e) => {
    e.preventDefault();
    const target = e.target;
    if (target.id == "off") {
        imgContainer.removeChild(imageOff);
        imgContainer.appendChild(imageOn);
    }
    else if (target.id == "on") {
        imgContainer.removeChild(imageOn);
        imgContainer.appendChild(imageOff);
    }
};
document.addEventListener('click', imageShow);
