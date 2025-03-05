//Leetcode 994
// Werte in der Matrix mit 1 gelten als normale Orangen.
// Werte mit 2 gelten als verfaulte Orangen. Auf diesen Orangen wird dfs angewandt um zu sehen, ob andere 1er Orangen infiziert werden können.
// Falls eine Orange alleine stehen bleibt (mit MaxValue im helperBoard), dann soll -1 zurückgegeben werden.
// Ansonsten wird die kürzeste Zeit wiedergegeben, die benötigt wird, um alle Orangen zu infizieren.
public class Program
{
    public int OrangesRotting(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] helperBoard = new int[rows][];

        // Kopiere `grid` nach `board`, setze frische Orangen auf einen hohen Wert(int.MaxValue).
        for (int i = 0; i < rows; i++)
        {
            helperBoard[i] = new int[cols];// hier werden erst die Spalten initialisiert
            for (int j = 0; j < cols; j++)
            {
                helperBoard[i][j] = grid[i][j] == 1 ? int.MaxValue : grid[i][j];//hier wird MaxValue ins board eingetragen,
                                                                                //wenn im Grid eine 1 steht.
            }
        }

        // Startet DFS von jeder faulen Orange,also nur bei einer 2
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 2) //falls die Orange faul ist
                {
                    dfs(helperBoard, i, j, 0);
                }
            }
        }

        // Berechne das Maximum der Tage oder überprüfe, ob eine Orange unerreicht bleibt.
        int result = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (helperBoard[i][j] == int.MaxValue) return -1; // Diese frische Orange mit MaxValue wurde nie erreicht.
                result = Math.Max(result, helperBoard[i][j]); // Maximaler Tag wird eingetragen als Ergebnis.
            }
        }
        return result;
    }

    private void dfs(int[][] board, int i, int j, int days)
    {
        int oben = i - 1;
        int unten = i + 1;
        int links = j - 1;
        int rechts = j + 1;

        // Grenzen der Matrix prüfen
        if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || board[i][j] == 0) return;

        // Falls der besuchte Wert kleiner ist als der aktuelle Tageswert, wird abgebrochen weil ein früherer DFS schon mit weniger Tagen alles
        // infiziert hat.
        if (board[i][j] <= days) return;

        // Aktualisiere den aktuellen Wert mit dem kleineren Tag
        board[i][j] = days;

        // Rekursiv in alle vier Richtungen weitergehen und dabei automatisch den Tag um 1 erhöhen.
        dfs(board, oben, j, days + 1); // Oben
        dfs(board, unten, j, days + 1); // Unten
        dfs(board, i, links, days + 1); // Links
        dfs(board, i, rechts, days + 1); // Rechts
    }

    public static void Main()
    {
        //int[][] grid = [new int[] { 1, 2 }];   //Das Ergebnis ist 1,weil die 2 in einem Tag die 1 infiziert.

        int[][] grid = new int[][]
        {
        new int[]{ 1, 0, 0, 0 },   //Diese 1 kann nicht erreicht werden.Das Ergebnis ist -1
        new int[]{ 0, 0, 2, 0 },
        new int[]{ 1, 1, 1, 1 },
        new int[]{ 0, 0 ,2 ,1 }
        };

        Program program = new Program();
        Console.WriteLine(program.OrangesRotting(grid)); 
    }
}
