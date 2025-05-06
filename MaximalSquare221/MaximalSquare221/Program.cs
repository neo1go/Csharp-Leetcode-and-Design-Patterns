// Leetcode 221 (Dynamic Programming)
// Es soll das Quadrat mit der größten Seitenlänge zurückgegeben werden, bei dem alle Felder mindestens 1
// sind. Der Trick ist, dass man vorherige Einträge mitberücksichtigen kann und mit in die
// Math.Min Funktion übernimmt. Es werden die Koordinaten hinter und über dem aktuellen Wert verglichen,
// da man noch nicht weiß, wie groß die ganze Fläche ist und somit nicht OutOfBounds läuft.
// Somit muß der Startpunkt gesondert behandelt werden.
// Es wird iteriert und die 3 vorherigen Koordinatenwerte werden mittels min-Funktion in ein neues 2dArray 
// eingetragen und am Ende wird der Maxwert ausgelesen in result, der der maximalen Seitenlänge des vollen Quadrates entspricht. 
// Es wird in dem dp 2d Array immer wieder,basierend auf den vorherigen Nachbarn, eine Addition nach
// der anderen durchgeführt, so das der Eintrag eines Feldes immer annhand des niedrigsten Wertes +1  
// der Dreier-Gruppe erhöht wird.
// Wenn dort noch eine Null vorhanden ist in der Dreier-Gruppe, bleibt der Wert auf Seitenlänge 1 stehen, da dann nur das Quadrat mit der
// Seitenlänge 1 sein kann und nicht größer.
// Nullen bleiben im dp Array auch Null und werden durch die else Bedingung somit gesetzt.
//
//        ^ ^   
//         \| 
//        <-1
public static class Program
{
    public static int MaximalSquare221(char[][] matrix)
    {
        int row = matrix.Length;
        int col = matrix[0].Length;
        int[][] dp = new int[row][];
        for (int i =0;i<row;i++) //nur für ein jagged Array. Ein [,] geht viel einfacher.
        {
            dp[i] = new int[col];
        }


        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (matrix[i][j] == '1')  //wenn der Wert an der aktuellen Koordinate eine 1 ist.
                {
                    if (i == 0 || j == 0)//Dies ist die Ausnahme für die Startkoordinate (0,0) der 2d Matrix.
                    {
                        dp[i][j] = 1; //Die obere linke Start-Ecke wird dann auf 1 gesetzt(Sonderfall)
                    }
                    else
                    {
                        dp[i][j] = Math.Min(Math.Min(dp[i][ j - 1], dp[i - 1][ j - 1]), dp[i - 1][ j]) + 1;
                    }
                }
                else
                {
                    dp[i][j] = 0;//Nullen bleiben gesetzt als Null, um Überschreiben durch die Logik zu verhindern.
                }

            }
        }
        int result = dp.SelectMany(innerArray => innerArray).Max();  // diese Max Funktion ist eine linq Funktion, nicht die Math Funktion die zwei Werte vergleicht.
                                            // hier wird mittels SelectMany auch wieder abgeflacht und innerArray ist nur eine anonyme Variable.
                                            //es wird jedes innere int[] zu einem einzigen flachen IEnumerable<int> zusammengeführt.

        return result*result; //für die Fläche quadrieren. 1*1 bleibt 1.

    }


    public static void Main(string[] args)
    {
        /*
        char[][] matrix =
        {
        new char[] { 1, 0, 1, 0, 0 },
        new char[] { 1, 0, 1, 1, 1 },
        new char[] { 1, 1, 1, 1, 1 }, // hier an Index 3 wird das erste Mal das 2seitige Quadrat erkannt im dp Array,
        new char[] { 1, 0, 0, 1, 0 }  // da alle vorherigen Werte an den Koordinaten mindestens 1 sind und mittels Min+1
        };                            // dann eine 2 gesetzt wird.
        */

        char[][] matrix =
        {
            new char[]{'0','1' },
            new char[]{'1','0'},
        };
        Console.WriteLine(MaximalSquare221(matrix));

    }
}
