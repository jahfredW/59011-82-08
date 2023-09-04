"use strict";
const body = document.querySelector('body');
const lines = document.querySelector('#lineNumber');
lines.addEventListener('input', (e) => {
    e.preventDefault();
    const target = e.target;
    console.log(target.value);
});
