namespace SudokuSolver
{

    public class SudokuSolver
    {
        private static readonly int GRID_SIZE = 9;  // 9 Zeilen * 9 Spalten
        public static void Main(String[] args)
        {

            //Sudokuboards


            //int[][] board = new int[][] {
            //[7,0,2,0,5,0,6,0,0 ],
            //[0,0,0,0,0,3,0,0,0 ],
            //[1,0,0,0,0,9,5,0,0 ],
            //[8,0,0,0,0,0,0,9,0 ],
            //[0,4,3,0,0,0,7,5,0 ],
            //[0,9,0,0,0,0,0,0,8 ],
            //[0,0,9,7,0,0,0,0,5 ],
            //[0,0,0,2,0,0,0,0,0 ],
            //[0,0,7,0,4,0,2,0,3 ]
            //                     };

            int[][] board = new int[][] {
                [0,0,1,2,0,3,4,0,0],
                [0,0,0,6,0,7,0,0,0],
                [5,0,0,0,0,0,0,0,3],
                [3,7,0,0,0,0,0,8,1],
                [0,0,0,0,0,0,0,0,0],
                [6,2,0,0,0,0,0,3,7],
                [1,0,0,0,0,0,0,0,8],
                [0,0,0,8,0,5,0,0,0],
                [0,0,6,4,0,2,5,0,0]
                                   };

            //int[][] board = new int[][] {
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0],
            //    [0,0,0,0,0,0,0,0,0]
            //                       };

            //int[][] board = new int[][]  //unsolvable board 
            //{
            //    [5,1,6,8,4,9,7,3,2],
            //    [3,0,7,6,0,5,0,0,0],
            //    [8,0,9,7,0,0,0,6,5],
            //    [1,3,5,0,6,0,9,0,7],
            //    [4,7,2,5,9,1,0,0,6],
            //    [9,6,8,3,7,0,0,5,0],
            //    [2,5,3,1,8,6,0,7,4],
            //    [6,8,4,2,5,7,0,0,0],
            //    [7,9,1,0,3,4,6,0,0],
            //};

            Console.WriteLine("Original board!");

            printBoard(board);


            if (solveBoard(board))//wenn true
            {
                Console.WriteLine("");
                Console.WriteLine("Solved succesfully!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unsolvable board!");
            }

            printBoard(board); //Ausgabe des fertiggestellten Boards. Die Variable board wird dadurch geändert

            Console.ReadKey();

        }

        //Nur zum Ausdrucken des Boards
        private static void printBoard(int[][] board)
        {
            for (int row = 0; row < GRID_SIZE; row++) //Zeileniteration
            {
                if (row % 3 == 0 && row != 0)  //Erzeugen der Trennzeichen nach jeweils 3 Zeilen
                {
                    Console.WriteLine("-----------");
                }
                for (int column = 0; column < GRID_SIZE; column++) //Spalteniteration
                {
                    if (column % 3 == 0 && column != 0) //Erzeugen der Trennzeichen nach jeder 3 Spalte
                    {
                        Console.Write("|");
                    }
                    Console.Write(board[row][column]);
                }
                Console.WriteLine();
            }
        }
        //Die Bools sind umgekehrt
        //Wenn die Zahl schon vorhanden ist in der Zeile, gibt es ein true zurück. Deswegen wird in isValidPlacement ein ! genutzt.
        //Überprüfen ob Wert in Zeile schon vorhanden ist.
        private static bool isNumberInRow(int[][] board, int number, int row)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (board[row][i] == number)
                {
                    return true;
                }
            }
            return false;
        }

        //Überprüfen, ob Wert in Spalte ist
        private static bool isNumberInColumn(int[][] board, int number, int column)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (board[i][column] == number)
                {
                    return true;
                }
            }
            return false;
        }

        //Überprüfung, ob Wert in der 3x3 Box vorhanden ist mittels Modulo 3
        private static bool isNumberInBox(int[][] board, int number, int row, int column)
        {
            int localBoxRow = row - row % 3;//der schwierigste Part, hiermit wird der Anfang der Box ermittelt von woaus dann iteriert wird
            int localBoxColumn = column - column % 3;
            for (int i = localBoxRow; i < localBoxRow + 3; i++)
            {
                for (int j = localBoxColumn; j < localBoxColumn + 3; j++)
                {
                    if (board[i][j] == number)//wenn Nummer in der Box vorhanden ist
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //hier werden alle Bool Abfragen aggregiert ausgegeben
        //wobei die Platzierung nur dann valide ist, wenn man in allen 3 Methoden ein false zurückbekommt
        //d.h. das die Zahl vorher weder in der Zeile, noch der Spalte oder der Box vorhanden sein darf.
        private static bool isValidPlacement(int[][] board, int number, int row, int column)
        {
            return !isNumberInRow(board, number, row) &&
                !isNumberInColumn(board, number, column) &&
                !isNumberInBox(board, number, row, column);
        }

        private static bool solveBoard(int[][] board) // hier werden rekursiv die Zahlen eingefügt, bis das Board gelöst ist. 
        {
            for (int row = 0; row < GRID_SIZE; row++)//Gridsize ist für alle Werte gleich 9, also 9 Zeilen, 9 Spalten und 9 Kästchen.
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    if (board[row][column] == 0)
                    {
                        for (int numberToTry = 1; numberToTry <= GRID_SIZE; numberToTry++)//Dies ist die Schleife, die die Zahl einsetzt zum Testen.
                        {
                            if (isValidPlacement(board, numberToTry, row, column))//wenn Zeile,Spalte u. Box false sind, wird numberToTry eingesetzt.
                            {
                                board[row][column] = numberToTry;

                                if (solveBoard(board))              //jetzt wird geschaut,ob das gesamte Boar lösbar ist.
                                {
                                    return true;
                                }
                                else
                                {
                                    board[row][column] = 0;  //hier wird der Wert wieder zurückgesetzt an der exakten Stelle,
                                                             //um mit dem nächsthöheren Wert von numberToTry nochmal zu probieren.
                                }
                            }
                        }
                        return false;//bei false ist das Board nicht lösbar
                    }
                }
            }
            return true;
        }
    }
}
