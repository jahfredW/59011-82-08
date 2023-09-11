"use strict";
const form = document.querySelector('form');
document.addEventListener('click', (e) => {
    let target = e.target;
    if (target instanceof Element) {
        if (target.tagName === "BUTTON") {
            if (form) {
                const formData = new FormData(form);
                isValid(formData);
            }
        }
    }
});
// controller les saisies pour empêcher les erreurs de format 
const isValid = (formData) => {
    for (const [key, value] of formData) {
        console.log(key, value);
    }
    ;
};
