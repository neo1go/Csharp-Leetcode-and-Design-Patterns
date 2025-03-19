using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;



//Leetcode 542  01Matrix
//es sollen die kürzesten Wege in einer Matrix von Nullen ausgehend in jeds Feld eingetragen werden.

public class Program
{
    public int[,] UpdateMatrix(int[,] matrix)
    {
        // Defintion des Rückgabearrays und die Dimensionen für row und column
        //
        // bei einem Jagged Array muß eine innere Array-Erstellung erfolgen, da die Arrays 
        // unterschiedlich lang sein können. Anders bei einem echten 2d Array, das mit [,]
        // erstellt wird und bei dem sofort mittels GetLength(0) und GetLength(1) für rows
        // und columns die Definition für Zeilen und Spalten erstellt wird da bei einem 
        // richtigen 2d Array die Zeilen immer gleichlang sind.
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int[,] result = new int[rows, columns];


        //Nur die result-Matrix mit MaxValue befüllen.(Klappt nicht wegen +1 welches einen riesigen - Wert erzeugt wegen overflow)
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = rows*columns; //hier habe ich rows*columns gewählt, was der größten Zahl in der Matrix entsprechen würde
                                             //bei der Wegfindung. Mit int.MaxValue ergibt es einen Overflow und eine riesige Minus Zahl.
            }                                //Dieser Wert gilt nur als Platzhalter.
        }

        // erstes Mal durchlaufen von oben links bis unten rechts. Ausbreitung nach rechts und unten mittels i-1 und j-1
        // So benötigt man für die gesamte Matrix nur 2 Durchläufe. Einmal für rechts und unten und beim zweiten Durchlauf der unten rechts startet
        // für die Korrektur nach links und oben mit i+1 und j+1
        for (int i = 0; i < rows; i++)
        {// Es wird das aktuelle Feld immer zum einen mit dem vorherigen linken Feld +1 und dem darüberliegenden Feld +1 verglichen um das aktuelle Feld
         // bei Bedarf dann auch +1 zu setzen falls Math.Max an aktueller Stelle zumindest gleich ist. Bspl.:
         // [1 >1<]  >aktuelles Feld<, vorheriges Feld ist 1 und somit wird dies als 1+1 im Vergleich dargestellt.
         // Da die aktuelle 1 kleiner ist, wird sie auf 2 erhöht.
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] == 0)
                {
                    result[i, j] = 0;
                }
                else
                {
                    if (i > 0)
                    {
                        result[i, j] = Math.Min(result[i, j], result[i - 1, j] + 1);// durch diesen +1 Vergleich wird das nächste Kästchen immer
                                                                                    // um 1 größer.
                    }
                    if (j > 0)
                    {
                        result[i, j] = Math.Min(result[i, j], result[i, j - 1] + 1);
                    }
                }
            }
        }
        //Zweiter Durchlauf von unten rechts nach oben links. Ausbreitung nach links und oben mittels i+1 und j+1 als Vergleichfeld
        for (int i = rows-1; i >= 0; i--)
        {
            for (int j = columns-1; j >= 0; j--)
            {
                if (matrix[i, j] !=0)
                {


                    if (i < rows - 1)
                    {
                        result[i, j] = Math.Min(result[i, j], result[i + 1, j] + 1); // durch diesen +1 Vergleich wird das nächste Kästchen immer
                                                                                     // um 1 größer.
                    }
                    if (j < columns - 1)
                    {
                        result[i, j] = Math.Min(result[i, j], result[i, j + 1] + 1);
                    }
                }
            }
        }

        return result;
    }

    //Dient nur dem Anzeigen der Matrix
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);  //gibt Zeile zurück und ist das äußere Array,hier 0,1,2 
        int columns = matrix.GetLength(1);//gibt Spalte zurück und ist das innere Array,hier 0,1,2,3,4,5,6
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        Program program = new Program();

        int[,] matrix =
        {
            {1,0,1,1,1,1,1},    //0
            {1,1,1,1,1,1,1},    //1
            {1,1,1,0,1,1,1}     //2
        };

        int[,] result = program.UpdateMatrix(matrix);

        PrintMatrix(result);
    }
}
