const ampouleOn = document.querySelector("#on") as HTMLElement;
const ampouleOff = document.querySelector("#off") as HTMLElement;

    document.addEventListener( 'click', (e : Event) => {
      e.preventDefault;

      const targetElement = e.target as HTMLElement;
      if(targetElement.id === "on"){
        ampouleOn?.classList.add("hidden");
        ampouleOff?.classList.remove("hidden");
      } else if (targetElement.id === "off"){
        ampouleOff?.classList.add("hidden");
        ampouleOn?.classList.remove("hidden");
    } else {
        const body = document.querySelector('body') as HTMLElement;
        const warning = document.createElement('h1');
        warning.textContent = "Merci de cliquer sur une lampe";
        
   
        body.appendChild(warning);
        setTimeout( () => {
            body.removeChild(warning);
        }, 1500)
      
    }
    
})


