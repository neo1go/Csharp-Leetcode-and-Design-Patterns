

//Wenn ohne html gstartet werden soll, im Terminal  node dateiname.js eingeben.

// mittels require wird festgesetzt,das diese Datei oder Funktion benötigt wird zur Ausführung der App
//die Abhängigkeit ist nur möglich wenn man vorher mittels npm i prompt-sync eingibt.
const prompt = require("prompt-sync")();

//js primitive Variables string, number, bigint, boolean, undefined, symbol, null  (diese sind call by Value)
//js complex Datatypes Object()   (call by Reference)

//lexical environment, also scopes
// let,var,const (var soll nicht mehr genutzt werden)
//global scope =  außerhalb einer Funktion
//local scope = innerhalb einer Funktion
//block scope = z.B. innerhalb eines if-Statements mit Ausnahme von var ,welches in den localscope übertragen wird.
//wenn man (this) nutzt innerhalb einer Funktion ,bezieht sich this auf das window Objekt (global).
//wenn this in einer Objektdefiniton steht, bezieht es sich auf das Objekt.
//mit bind kann man eine Funktion an ein Objekt anbinden

//javascript nutzt einen non-blocking eventloop, d.h. das asynchrones Ausführen ohne serielles Abarbeiten des codes.


//bind
function wtfPrint(){
    console.log(this.name); //this verweist auf das Objekt
}
const  person ={name:"John"};  //Objekt
const personPrint = wtfPrint.bind(person);//hier wird der console.log an die Instanz person gebunden.
personPrint();

//Array
const list=['null','eins','zwei'];
//Hash Set, hier nur Set genannt
const uniq = new Set(list);
//Hashmap mit Key-Value Paaren wobei die Keys einzigartig sind und im normalen Fall bei map auch primitive Datentypen sein können wie hier strings.
const  dict = new Map([
    ['foo',1],
    ['bar',2]
])

//Weak Map
const key1={};
const key2={};
const  weakDict = new WeakMap([  //können eher vom garbage collector überwacht werden wegen weak map. Besonderheit - 
    [key1,1],                    //Es können als key nur Objekte verwendet werden da nur Objekte vom garbage collector überwacht werden können.
    [key2,2]
])




//Anonyme Funktion
const showValue ={
    value:"Hi",
    print:() =>{
        console.log(this.value);  //bei diesem Beispiel funktioniert "this" nicht in Bezug auf das Objekt showValue sondern global
    }                             //das Ergebnis ist "undefined".
}
showValue.print();


//Dies ist ein normaler Aufruf,also nicht anonym wegen print: function. "This" bezieht sich nun auf den eigenen Objektwert (local)
const showValue2 ={
    value:"Hallo",
    print: function(){
        console.log(this.value);
    }
}
showValue2.print();


//Erzeugen eines Objektes mit Key-Value Paaren.
const PERSON_RECORD={
     "Wins": 0,
      "Losses":0,
}

const exampleArray =[34,55,55,34,2,5];
//foreach
for(value of exampleArray){
console.log("Wert im Array ist "+value);
}
//auch foreach
exampleArray.forEach ((value) => {
    console.log(" Wert im Array "+ value);
});


//Funktion
const inputValue = () =>{
const userValue =  prompt("Gebe eine Zahl ein: ");

//Überprüfen des Wertes 
if(userValue <=0 || userValue >400 ||  isNaN(userValue)){
                                     //isNaN()  isNotaNumber - überprüft ob der Wert eine Zahl ist
    console.log("Falscher Wert");
}

// let output = parseFloat(userValue);
//console.log("Wert wurde vom string zu int ohne Nachkommastellen umgewandelt mit parseFloat "+output);
// let roundedOutput = Math.floor(output);
let roundedOutput = Math.floor(userValue);

console.log("Abgerundeter Wert ist "+roundedOutput);
}
// Funktionsaufruf
// inputValue();


//JavaScript Class
class Person {
    constructor(name){
        this.name="Gordon";
        this.age=10;
        this.dna="AAB";
    }
        get gender(){
            return this.gender;
        }
        set gender(val){
            this.gender=val;
        }
    static walk(){
        console.log("walking");
    }
    isHuman(human){
        if(human.dna == 'AAB'){
            console.log("its a person Object");
            return true;
        }
        return false;
    }
}
 const personOb = new Person();
personOb.isHuman(personOb);



//Timeout
setTimeout(() =>{
    console.log('5 seconds in the future');
},5000);

//normaler Promise
const promise = new Promise(
    (resolve, reject) =>{
        //do something here

        if(greatSuccess){
            resolve('success');
        }else{
            reject('failure');
        }
    }
)

//der Verbraucher der Promise kann Funktionen auf den Promise anwenden
promise 
.then(success =>{
    console.log('yay!',success)
})

.catch(err => {
    console.log('oh no!',err)
})

//Async Funktionen
async function asyncFun(){
   try {
     const result = await promise;
   } catch (error) {
    console.log(error);
   }

}
/*  alte Variante
fetch('https://catfact.ninja/fact')
     .then(function(){
        console.log('Fertig!')
     });
*/
async function load(){
    let response = await fetch('https://catfact.ninja/fact');
    let result = await response.json();
    console.log(result.fact);
}
load();

//mit 'export default'  wird eine Funktion definiert, die in einer anderen js Datei mittels   import Funktionsname from './help.js';    weiterverwendet werden kann. 


// DOM Abfragen in Bezug auf HTML und CSS 

const btn = document.querySelector('.button');     //sucht im Dokument nach dem rsten css-Selector mit dieser Bezeichnung
const allBtns = document.querySelectorAll('.button');//  erfasst alle .button Elemente auf einmal

btn.addEventListener('click',()=>{          //hier wird der btn Variable ein Eventlistener hinzugefügt um, wie in diesem Fall, 
    console.log('clicked');                 //bei einem Click Event den console,log auszuführen.

    document.body.style.backgroundColor='red'; //dies ist imperativ und meist nicht gewünscht
});

const eingabe =document.getElementById('htmlEingabeFeld'); //hier wird das Element basierend auf der ID gekoppelt, z.B. ein Eingabefeld oder ähnliches.
//ID's in html sind immer einzigartig währenddessen die Klassen mehrfach vorkommen können wie z.B. ein Layout für buttons,
//welche dann immer wieder verwendet werden können auf der geichen Seite und bei Bedarf dann durch eine einzigartige ID auseinandergehalten werden können.    