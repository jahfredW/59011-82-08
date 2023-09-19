

/**
 * Permet de changer la couleyr des paragraphes
 * @param e : MouseEvent : evt lié à la souris
 * @return : void ajoute ou supprime les classes en question
 */
const pColorChange : (e : MouseEvent) => void = ( e : MouseEvent) : void => {
    const target = e.target as HTMLElement;
    if(target instanceof HTMLParagraphElement){
        console.log('paragraph clicked');
        if(target.className == 'red'){
            target.classList.add('green');
            target.classList.remove('red');
        } else if(target.className == 'green'){
            target.classList.add('blue');
            target.classList.remove('green');
        } else {
            target.classList.add('red');
        }

        // Cas où le paragraphe n'a pa de class
    }
}


/**
 * Récupère le type de balise HTML cliqué
 * @param e : MouseEvent : evt lié à la souris 
 * @return void
 */
const hColorNotify : (e : MouseEvent) => void = ( e : MouseEvent) : void => {
    e.stopPropagation();
    const target = e.target as HTMLElement;
    const bType = target.tagName;
    console.log(bType);
    if(target instanceof HTMLHeadingElement){
        console.log('heading clicked');
        hColorChangeV2(target, bType);
}
}

/**
 * Pemret de changer la couleur des titres indépendemment de leur type
 *
 * @return : void 
 */
const hColorChange  = () : void => {
    const allTitles : NodeListOf<HTMLElement> = document.querySelectorAll('.title');
    allTitles.forEach((title) => {
        if(title.classList.contains('red')){
            title.classList.add('green');
            title.classList.remove('red');
        } else if(title.classList.contains('green')){
            title.classList.add('blue');
            title.classList.remove('green');
        } else  if(title.classList.contains('blue')){
            title.classList.add('red');
            title.classList.remove('blue');
        } else {
            title.classList.add('red');
        }
    })
}

/**
 * Change la couleur pour un titre de même type. 
 * 
 * @param target : L'élement HTML ciblé 
 * @param baliseType : la balise HTML 
 * @return void 
 */
const hColorChangeV2  = (target : HTMLElement, baliseType : string) : void => {
    // const allTitles : NodeListOf<HTMLElement> = document.querySelectorAll('.title');
    const typeTitles : NodeListOf<HTMLElement> = document.querySelectorAll(baliseType);
    typeTitles.forEach((title) => {
        if(title.classList.contains('red')){
            title.classList.add('green');
            title.classList.remove('red');
        } else if(title.classList.contains('green')){
            title.classList.add('blue');
            title.classList.remove('green');
        } else  if(title.classList.contains('blue')){
            title.classList.add('red');
            title.classList.remove('blue');
        } else {
            title.classList.add('red');
        }
    })
}

document.addEventListener('click', pColorChange);
document.addEventListener('click', hColorNotify);