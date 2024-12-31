let randomize_array = document.getElementById("randomize_array_btn");
let sort_btn = document.getElementById("sort_btn");
let bars_container = document.getElementById("bars_container");
let minRange = 1;
let maxRange = 100;
let numOfBars = 100;
let heightFactor = 6.5;
let unsorted_array = new Array(numOfBars);
let bars = bars_container.getElementsByClassName("bar");

// Erzeugen einer Zufallsganzzahl
function randomNum(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// Erzeugen eines Arrays mit Zufallszahlen mit Zahlengröße zwischen minRange und maxRange
function createRandomArray() {
    for (let i = 0; i < numOfBars; i++) {
        unsorted_array[i] = randomNum(minRange, maxRange);
    }
}

// Erstellen der Balkengrafik
function createBars(array) {
    bars_container.innerHTML = ""; // füllt den div mit "",(wird benötigt da einige frameworks sonst nichts durchführen)
    for (let i = 0; i < array.length; i++) {
        let bar = document.createElement("div");
        bar.classList.add("bar");
        bar.style.height = array[i] * heightFactor + "px";
        bars_container.appendChild(bar);
    }
}

async function quickSort(array, start, end) {
    if (start >= end) return;

    let pivotIndex = await partition(array, start, end);
    await quickSort(array, start, pivotIndex - 1);//linke Seite vom pivot
    await quickSort(array, pivotIndex + 1, end); //rechte Seite vom pivot
}
//wichtigste Funktion
//
async function partition(array, start, end) {
    let pivot = array[end]; //ein Wert , der als Dreh- und Angelpunkt gilt
    let pivotIndexPointer = start;//quasi ein Pointer. An dieser Stelle wird nachher der pivot eingefügt und mit dem Pointer getauscht

    

    for (let i = start; i < end; i++) {
        if (array[i] < pivot) {
            await swap(array, i, pivotIndexPointer);//Pointerwert mit i vergleichen und ggf. tauschen
            pivotIndexPointer++;
        }
    }

    await swap(array, pivotIndexPointer, end);// hier wird der Pointer mit dem End Wert getauscht !!!!!!

    
    return pivotIndexPointer;
}

//generelle SWAP Funktion, die mittels temporärer Variable Werte tauscht
async function swap(array, i, j) {
    let temp = array[i];
    array[i] = array[j];
    array[j] = temp;

    renderBars(array);
    await sleep(20);
}

//Erneuert Balkenhöhe aufgrund des Wertes im Array, also refresh
function renderBars(array) {
    let bars = bars_container.getElementsByClassName("bar");
    for (let i = 0; i < array.length; i++) {
        bars[i].style.height = array[i] * heightFactor + "px";
    }
}

//Verlangsamt die Darstellung
function sleep(ms) {
    return new Promise((resolve) => setTimeout(resolve, ms));
}

// Zufallsarray erstellen und Balken zeichnen beim Laden der Seite
document.addEventListener("DOMContentLoaded", function () {
    createRandomArray();
    createBars(unsorted_array);
});

// Zufallsarray erstellen und Balken zeichnen beim Klicken des "Zufälliges Array" Buttons(auch eine anonyme Funktion)
randomize_array.addEventListener("click", function () {
    createRandomArray();
    createBars(unsorted_array);
});

// Anonyme  Funktion, die sortiert beim Klicken des "Sortieren" Buttons
sort_btn.addEventListener("click", async function () {
    await quickSort(unsorted_array, 0, unsorted_array.length - 1);
});
