"use strict";
document.addEventListener('click', (e) => {
    e.preventDefault();
    let target = e.target;
    if (target instanceof HTMLImageElement) {
        console.log("ici");
        if (!target.classList.contains('rotate-img')) {
            target.classList.remove('rotate-img-bis');
            target.classList.add('rotate-img');
            setTimeout(() => rotateImg(target), 2000);
        }
    }
});
const rotateImg = (target) => {
    target.classList.add('rotate-img-bis');
    target.classList.remove('rotate-img');
};
