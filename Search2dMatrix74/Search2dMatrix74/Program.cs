//Leetcode 74 Search a 2d Matrix

public class Program
{   //BruteForce 
    /*
    public bool SearchMatrix(int[][]matrix, int target)
    {
        bool result = false;

        for(int i =0; i<matrix.Length;i++)
        {
            for(int j = 0;j<matrix[i].Length;j++)
            {
                if(matrix[i][j]==target)
                {
                    result =true;

                    if(result==true)return result; //Direkter Abbruch 
                }
            }
        }
         return result;
    }
    */
    //binary Search Variante für Leetcode 74 Search2dMatrix
    // Die Besonderheit liegt in der Behandlung des 2d jagged-Arrays mit Vektoren, um es wie ein 1d Array
    // zu behandeln, ohne Rechen- oder Speicher-Kosten zu verursachen durch Umwandlung des Arrays.
    // row und col müssen jedesmal neu berechnet werden wobei col durch mid-modulo berechnet wird.
    // Es wird mittels dieser Berechnung von col und row das 2d Array wie ein 1d Array behandelt.
    // Bspl:
    // Index (1d) 0 1 2 3 4  5  6  7  8  9  10 11
    // Wert       1 3 5 7 10 11 16 20 23 30 34 60
    // mid = 6
    // row = midIndex/numOfColumns   row = 6/4 =  Zeile 1  (also bei 0 basiert,sonst Zeile 2)
    // col = mid%numberOfColumns     col = 6%4 = Spalte 2  (also bei 0 basiert, sonst Spalte 3)  
    // Ergebnis ist für mid value dann:  value = matrix[row][col] = 16
    //
    // Da die Vektorbrechnung nicht im 1d Raum stattfindet, spricht man anstatt von mid
    // als best pratice von value, da es sich nicht um eine flache eindimensionale Datenstruktur handelt.

    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)//basecase
        {
            return false;
        }

        int rows = matrix.Length;
        int cols = matrix[0].Length; // Achtung, funktioniert nur hier. Im jagged Array können Einträge 
                                     // unterschiedlich lang sein.
        int left = 0;
        int right = (rows * cols) - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;//in der Schleife, da sich die Werte immer wieder verändern
            int row = mid / cols; //neue Berechnung wegen jagged Array ergibt dann die tatsächliche Reihe
            int col = mid % cols;//neue Berechnung ergibt hier die tatsächliche Spalte im 2d Array
            int value = matrix[row][col];

            if (target == value) //typischer binary search
            {
                return true;
            }
            else if (value < target)
            {
                left = mid + 1;
            }
            else if (value > target)
            {
                right = mid - 1;
            }
        }
        return false;
    }


    public static void Main(string[] args)
    {
        Program program = new Program();
        int[][] matrix = new int[][]
        {
            new int[] {1,3,5,7},
            new int[] {10,11,16,20},
            new int[] {23,30,34,60}
        };
        int target = 30;

        Console.WriteLine(program.SearchMatrix(matrix, target));
    }
}

