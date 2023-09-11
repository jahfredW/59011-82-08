const form  = document.querySelector<HTMLFormElement>('form');




document.addEventListener('click', (e) => {
    let target = e.target;
    if(target instanceof Element) {
        if(target.tagName === "BUTTON"){
            if(form){
                const formData = new FormData(form);
                isValid(formData);
            }
        } 
    }   
})

// controller les saisies pour empêcher les erreurs de format 
const isValid  = (formData : FormData ) : void => {
   
        for( const [key, value ] of formData){
            console.log(key, value);
            switch(key){
                case "firstname":
                    if(typeof(value) === "string"){
                        alertCarBuilder(noSpecialCaracters(value));
                    }
                break;
            }

        }
      
;}

const noSpecialCaracters = (input : string) => {
    const regex = /^[a-zA-Z0-9]+$/;
    const result = regex.test(input);
    return result;
}

const alertCarBuilder = (isForbidden : boolean) => {
    const alertDiv = document.createElement('div');
    alertDiv.classList.add('alert-char');
    alertDiv.innerText = "Les caratères spéciaux sont interdits!"
    let targetElement = document.querySelector("[data-input=firstname]")

    if (targetElement){
        targetElement.appendChild(alertDiv);
    } else {
        console.log("élement ciblé non trouvé");
    }
}