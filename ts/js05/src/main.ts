document.addEventListener('click', (e) => {
    e.preventDefault();
    let target  = e.target as HTMLElement;

    if(target instanceof HTMLImageElement){
        console.log("ici");
        if(!target.classList.contains('rotate-img')){
            target.classList.remove('rotate-img-bis');
            target.classList.add('rotate-img');
            setTimeout( () => rotateImg(target), 2000)
        }
        
    }
})

const rotateImg : Function = (target : HTMLElement) : void => {
    target.classList.add('rotate-img-bis');
    target.classList.remove('rotate-img');
}