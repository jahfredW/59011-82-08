"use strict";
document.addEventListener('click', (e) => {
    e.preventDefault();
    let target = e.target;
    if (target instanceof HTMLImageElement) {
        console.log("ici");
        target.classList.add('rotate-img');
        setTimeout(rotateImg(target), 2000);
    }
});
const rotateImg = (target) => {
    target.classList.remove('rotate-img');
};
