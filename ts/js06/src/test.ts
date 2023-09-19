// déclaration de base 

function consoleSize (arg : string[]) { return arg.length}

consoleSize(['1']);

// Utilisation d'un generic : 

function  consoleSizeGeneric<Type extends { length : number}>(arg :  Type) : Type { return arg }

class A<T> {
    constructor( private items : T[] ){

    }

    add(item: T) : this{
        this.items.push(item);
        return this;
    }

    toString() : void {
        this.items.forEach(item => console.log(item));
    }

    isEqual(a : this) : boolean {
        return a.items[0] === this.items[0];
    }

}

const a  = new A(['hello', 4, 5]);
const b = new A(['hello', 4, 5]);

a.toString();
console.log(a.isEqual(b));




function buildTab<T>(arg : T[]) : void { arg.forEach(item => console.log(item)); }

buildTab(['hello', 4, 5]);