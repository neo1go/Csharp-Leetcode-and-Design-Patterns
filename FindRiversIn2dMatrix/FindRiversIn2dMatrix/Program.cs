
using System;
using System.Collections.Generic;

//DFS Beispiel mit Stack um alle Flüsse in einer 2d Matrix zu finden.

//Es werden also grundlegend immer alle 1er Koordinaten im Stack abgelegt,
//um sie der Reihe nach abzuarbeiten und bei jeder, in allen vier Richtungen gefundenen 1, wird gleichzeitig die Länge des Flusses
//erhöht und im Bool-Raster die Koordinate auf true gesetzt für den Besuch.
//Wenn keine Koordinaten mehr im Stack sind, wird der gesamte Fluss der List hinzugefügt und es wird in der Hauptmatrix weiteriteriert
//bis eine 1 gefunden wurde, deren bool auf false steht(noch nicht besucht). Dann wird ExploreRiver() wieder ausgeführt für den nächsten
//dfs.


namespace FindRiversIn2dMatrix
{
    class Program
    {
        static void Main()
        {
            int[,] grid = {
            { 1, 1, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 0, 0, 1 }
        };

            List<int> riverLengths = GetRiverLengths(grid);
            Console.WriteLine(string.Join(", ", riverLengths)); // Beispielausgabe: 2, 3, 1, 2
        }


        //Hiermit wird iteriert und die Ergebnisliste vervollständigt
        static List<int> GetRiverLengths(int[,] grid)//Übergabe der 2d-Matrix
        {
            int rows = grid.GetLength(0);//gezählt in y Richtung, also wieviele Zeilen
            int cols = grid.GetLength(1);//gezählt in x Richtung, also wieviele Spalten
            bool[,] visited = new bool[rows, cols];  //2d Matrix mit bools, genauso groß wie das Original-Grid.
            List<int> riverLengths = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == 1 && !visited[i, j])//sobald eine 1 erreicht wurde und bool auf false steht, wird die Suche gestartet!.
                    {
                        int length = ExploreRiver(grid, visited, i, j);//hier wird auch das bool-2d-Array mit übergeben.
                        riverLengths.Add(length);
                    }
                }
            }
            return riverLengths;
        }


        //Dies ist die dfs Suche, die auch alle anliegenden Koordinaten prüft und der Länge hinzufügt. 
        static int ExploreRiver(int[,] grid, bool[,] visited, int row, int col)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int length = 0;

            // Bewegungsrichtungen: Oben, Unten, Links, Rechts
            int[] dRow = { -1, 1, 0, 0 };//Reihen können nur hoch oder runter vom Punkt erkannt werden.
            int[] dCol = { 0, 0, -1, 1 };//Spalten können nur links und rechts vom Punkt erkannt werden.

            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((row, col));//Man steht ja auf der ersten 1 und dann wird diese Funktion aufgerufen.

            while (stack.Count > 0)
            {
                (int currentRow, int currentCol) = stack.Pop(); //weil diese gesamte Funktion nur bei Treffen einer 1 aufgerufen wird.

                // Überspringen aller restlichen Zeilen zum nächsten while, falls die Koordinate bereits besucht wurde.
                if (visited[currentRow, currentCol]) continue;

                visited[currentRow, currentCol] = true; //Setzen von besuchter Koordinate
                length++;

                // - und dann Nachbarn überprüfen
                for (int i = 0; i < 4; i++)
                {
                    int newRow = currentRow + dRow[i];//d.h. zuerst[x][][][],dann[][x][][],dann[][][x][]und zuletzt[][][][x]
                    int newCol = currentCol + dCol[i];

                    if (newRow >= 0 && newRow < rows &&  //hier werden die Grenzen der Matrix berücksichtigt und ob der Wert 1 ist und ob
                        newCol >= 0 && newCol < cols &&  //die Koordinate noch nicht besucht wurde.
                        grid[newRow, newCol] == 1 &&
                        !visited[newRow, newCol])
                    {
                        stack.Push((newRow, newCol));//Die neue Koordinate wird in den Stack gepusht und bei der nächsten while-Iteration
                                                     //abgearbeitet(LIFO). Dies gilt dann auch für alle anderen evtl. noch vorhandenen Koordinaten
                                                     //im Stack.
                    }
                }
            }
            return length;
        }
    }
}












