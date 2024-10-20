

//Wenn ohne html gstartet werden soll, im Terminal  node dateiname.js eingeben.

// mittels require wird festgesetzt,das diese Datei oder Funktion benötigt wird zur Ausführung der App
//die Abhängigkeit ist nur möglich wenn man vorher mittels npm i prompt-sync eingibt.
const prompt = require("prompt-sync")();

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

// inputValue();