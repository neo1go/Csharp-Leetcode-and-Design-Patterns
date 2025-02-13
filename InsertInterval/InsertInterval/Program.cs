// Leetcode 57 Einfügen eines Intervalls 
// Falls die Intervalle überlappen, werden sie verschmolzen.
// Gleiche Start- und Endwerte werden in diesem Beispiel auch verbunden.

public class Program
{
    public int[][] InsertInterval(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>(); //lässt sich leichter erweitern
        int i = 0;

        //Fügt alle Intervalle in Result, die enden bevor das Neue startet
        while (i < intervals.Length && intervals[i][1] < newInterval[0])//solange der Endwert von intervals kleiner als der
                                                                        //Anfangswert von newInterval ist.
        {
            result.Add(intervals[i]);
            i++;
        }

        //Dies führt automatisch zu dieser while-Schleife da ja logisch gesehen eine Überlappung stattfindet.
        //Überlappende Intervalle verschmelzen
        while (i < intervals.Length && intervals[i][0] <= newInterval[1]) //während vordere Zahl des originalen Arrays kleiner oder gleich
                                                                          //dem Endwert des einzufügenden Arrays ist.
        {
            newInterval[0] = Math.Min(intervals[i][0], newInterval[0]); //kleinsten Anfang ermitteln
            newInterval[1] = Math.Max(intervals[i][1], newInterval[1]); //größtes Ende ermitteln
            i++;
        }
        result.Add(newInterval);

        //Somit wird in der logischen Kette entweder das Ende der Vergleiche erreicht oder 
        //es werden die restlichen Intervalle eingefügt.
        while (i < intervals.Length)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }

    public static void Main(String[] args)
    {
        int[][] intervals = [
                          [1,2],
                          [3,5],
                          [6,7],
                          [8,10],
                          [12,14]
                            ];

        int[] newInterval = [4, 9];

        Program program = new Program();


        int[][] result = program.InsertInterval(intervals, newInterval);

        foreach (var interval in result)
        {
            Console.WriteLine(string.Join(", ", interval));
        }
    }
}


