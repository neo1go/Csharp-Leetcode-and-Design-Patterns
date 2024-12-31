const cells = document.querySelectorAll(".cell");
const statuText = document.querySelector("#statusText");
const restartBtn = document.querySelector("#restartBtn");
const winConditions = [
    [0, 1, 2],  /*winncondition 0 */
    [3, 4, 5],  /*winncondition 1 */
    [6, 7, 8],  /*winncondition 2 */
    [0, 3, 6],  /*winncondition 3 */
    [1, 4, 7],  /*winncondition 4 */
    [2, 5, 8],  /*winncondition 5 */
    [0, 4, 8],  /*winncondition 6 */
    [2, 4, 6]   /*winncondition 7 */
];

let options = ["", "", "", "", "", "", "", "", ""];
let currentPlayer = "X";
let running = false;

initializeGame();


function initializeGame() {
    running = true;
    cells.forEach(cell => cell.addEventListener("click", cellClicked));
    restartBtn.addEventListener("click", restartGame);
    statusText.textContent = `${currentPlayer}'s turn`;
}

function cellClicked() {
    const cellIndex = this.getAttribute("cellIndex");

    if (options[cellIndex] != "" || !running) {
        /* wenn Spiel nicht läuft oder Feld schon belegt ist,
         wird übersprungen. Ansonsten wird die geklickte Zelle geupdated*/
        return;
    }
    updateCell(this, cellIndex);
    checkWinner();  /*nach jedem Klick wird gecheckt */
}

function updateCell(cell, index) {
    options[index] = currentPlayer;
    cell.textContent = currentPlayer;
}

function changePlayer() {
    currentPlayer = (currentPlayer == "X") ? "O" : "X";
    statusText.textContent = `${currentPlayer}'s turn`;
}

function checkWinner() {
    let roundWon = false;

    for (let i = 0; i < winConditions.length; i++) {
        const condition = winConditions[i];
        const cellA = options[condition[0]]; /*Spalte 1 Eintrag von winConditions*/
        const cellB = options[condition[1]]; /*Spalte 2 Eintrag von winConditions*/
        const cellC = options[condition[2]]; /*Spalte 3 Eintrag von winConditions*/
        /*eine Winncondition besteht immer aus 3 Einträgen an Position 0,1 und 2, 
          die hier verglichen werden */

        if (cellA == "" || cellB == "" || cellC == "") {
            continue;
        }
        if (cellA == cellB && cellB == cellC) {
            roundWon = true;
            break;/* Ausstieg aus checkWinner */
        }
    }
    if (roundWon) {
        statusText.textContent = `${currentPlayer} wins !! `;
        running = false;
    }
    else if (!options.includes("")) {
        /*wenn alle Zeichen gesetzt wurden (also keine "" mehr übrig sind)
          und die WinnCondition nicht zutrifft, ensteht ein Unentschieden*/
        statusText.textContent = ` Draw !! `;
        running = false;
    }
    else {
        changePlayer();
    }
}

function restartGame() {
    /*  hier wird alles zurückgesetzt und die Variablen 'geleert'   */
    running = true;
    currentPlayer = "X";
    options = ["", "", "", "", "", "", "", "", ""];
    statusText.textContent = `${currentPlayer}'s turn`;
    cells.forEach(cell => cell.textContent = "");

}