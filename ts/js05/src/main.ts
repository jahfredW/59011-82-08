document.addEventListener('click', (e) => {
    e.preventDefault();
    let target  = e.target as HTMLElement;

    if(target instanceof HTMLImageElement){
        console.log("ici");
    target.classList.add('rotate-img');
    setTimeout( rotateImg(target), 2000)
    }
})

const rotateImg : Function = (target : HTMLElement) : void => {
    target.classList.remove('rotate-img');
}