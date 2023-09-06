"use strict";
// déclaration de base 
function consoleSize(arg) { return arg.length; }
consoleSize(['1']);
// Utilisation d'un generic : 
function consoleSizeGeneric(arg) { return arg; }
class A {
    items;
    constructor(items) {
        this.items = items;
    }
    add(item) {
        this.items.push(item);
        return this;
    }
    toString() {
        this.items.forEach(item => console.log(item));
    }
    isEqual(a) {
        return a.items[0] === this.items[0];
    }
}
const a = new A(['hello', 4, 5]);
const b = new A(['hello', 4, 5]);
a.toString();
console.log(a.isEqual(b));
function buildTab(arg) { arg.forEach(item => console.log(item)); }
buildTab(['hello', 4, 5]);
