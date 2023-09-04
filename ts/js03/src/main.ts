


const pColorChange : (e : MouseEvent) => void = ( e : MouseEvent) : void => {
    const target = e.target as HTMLElement;
    if(target instanceof HTMLParagraphElement){
        console.log('paragraph clicked');

        // Cas où le paragraphe n'a pa de class
        if(target.className == '.red'){
            target.classList.add('.blue')
            target.classList.remove('.red')
        } else if(target.className == '.blue'){
            target.classList.add('.red')
            target.classList.remove('.blue')
        } else {
            target.classList.add('.red')
        }
    }
}

document.addEventListener('click', pColorChange)