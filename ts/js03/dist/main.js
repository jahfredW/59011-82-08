"use strict";
const pColorChange = (e) => {
    const target = e.target;
    if (target instanceof HTMLParagraphElement) {
        console.log('paragraph clicked');
        if (target.className == 'red') {
            target.classList.add('green');
            target.classList.remove('red');
        }
        else if (target.className == 'green') {
            target.classList.add('blue');
            target.classList.remove('green');
        }
        else {
            target.classList.add('red');
        }
        // Cas où le paragraphe n'a pa de class
    }
};
const hColorNotify = (e) => {
    e.stopPropagation();
    const target = e.target;
    const bType = target.tagName;
    console.log(bType);
    if (target instanceof HTMLHeadingElement) {
        console.log('heading clicked');
        hColorChangeV2(target, bType);
    }
};
const hColorChange = (target) => {
    const allTitles = document.querySelectorAll('.title');
    allTitles.forEach((title) => {
        if (title.classList.contains('red')) {
            title.classList.add('green');
            title.classList.remove('red');
        }
        else if (title.classList.contains('green')) {
            title.classList.add('blue');
            title.classList.remove('green');
        }
        else if (title.classList.contains('blue')) {
            title.classList.add('red');
            title.classList.remove('blue');
        }
        else {
            title.classList.add('red');
        }
    });
};
const hColorChangeV2 = (target, baliseType) => {
    // const allTitles : NodeListOf<HTMLElement> = document.querySelectorAll('.title');
    const typeTitles = document.querySelectorAll(baliseType);
    typeTitles.forEach((title) => {
        if (title.classList.contains('red')) {
            title.classList.add('green');
            title.classList.remove('red');
        }
        else if (title.classList.contains('green')) {
            title.classList.add('blue');
            title.classList.remove('green');
        }
        else if (title.classList.contains('blue')) {
            title.classList.add('red');
            title.classList.remove('blue');
        }
        else {
            title.classList.add('red');
        }
    });
};
document.addEventListener('click', pColorChange);
document.addEventListener('click', hColorNotify);
