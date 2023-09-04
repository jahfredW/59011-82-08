const body = document.querySelector('body') as HTMLElement;
const lines = document.querySelector('#lineNumber') as HTMLElement;

lines.addEventListener('input', (e : Event) => {
    e.preventDefault();
    const target = e.target as HTMLInputElement;
    console.log(target.value);
})
