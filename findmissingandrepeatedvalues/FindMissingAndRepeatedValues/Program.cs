// Leetcode 2965
// Finden von Duplikat und fehlender Zahl in einer Matrix.
// Es werden die Werte in ein HashSet eingefügt. Bei Erreichen eines Duplikates wird
// dieses sofort in die Lösungsmenge eingetragen.
// Bei dem HashSet mit den zu erwartenden Nummern werden alle besuchten Zahlen gelöscht und
// es bleibt nur der fehlende Eintrag zurück als einziger Eintrag.
public class Program
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        int n = grid.Length;
        HashSet<int> numbers = new HashSet<int>(Enumerable.Range(1, n * n));//Erstellt ein HashSet mit den Werten von 1 bis n
        int duplicate = -1;


        //  Gitter durchgehen und Werte zählen
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int value = grid[i][j];

                if (!numbers.Contains(value))//ein mögliches Duplikat wird beim Iterieren sofort erkannt
                                             // da ja alle besuchten Werte immer entfernt werden.
                                             // Da ein Duplikat einem doppelten Besuch gleichkommt und der Wert schon aus dem
                                             // HashSet entfernt wurde, wird dieser nichtvorhandene Wert als Duplikat erkannt.
                {
                    duplicate = value;
                }
                else
                {
                    numbers.Remove(value); // Gefundene Zahlen werden einfach entfernt.
                }
            }
        }

        //  Die einzige verbleibende Zahl im Set ist die fehlende Zahl
        int missing = numbers.First();

        return new int[] { duplicate, missing };
    }

    public static void Main()
    {
        int[][] grid = new int[][]
        {
            new int[]{1, 3},
            new int[]{2, 2} // "2" kommt doppelt vor, "4" fehlt
        };

        Program program = new Program();
        int[] ergebnis = program.FindMissingAndRepeatedValues(grid);
        Console.WriteLine($"Das Ergebnis ist: [{string.Join(", ", ergebnis)}]");
    }
}

