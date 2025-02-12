using System;
using System.Collections.Generic;


// Hier werden überlappende Intervalle gezählt und die minimale Anzahl an zu löschenden Intervallen returned.
// Um dies zu erreichen, wird erst das intervals Array, basierend auf der 2ten Zahl, sortiert.
// Das ergibt:
// [1,2]   index 0
// [1,3]   index 1   ->    dies ist überlappend weil die 1 kleiner ist als die 2 vom vorherigen Array.
// [2,3]   index 2
// [3,4]   index 3
//
// im Array [index 0, index 1]
//
// Durch das Sortieren des jagged Array wird automatisch bei einer Überlappung immer das erste Intervall herausgeworfen (Greedy).
// Das beugt dem vor, das ansonsten vielleicht eine größere Anzahl späterer kombinierter Arrays herausgeworfen wird.
// Deswegen muß sortiert werden.
public class Program
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return 0;
        }

        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int count = 1;
        int previousInterval = 0;

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[previousInterval][1] <= intervals[i][0])   //Endwert des ersten Arrays <= Startwert des zweiten Arrays
            {//Hiermit werden also die guten Intervalle markiert,ansonsten werden sie übersprungen
                previousInterval = i;
                count++;
            }
        }
        return intervals.Length - count;
    }

    public static void Main(String[] args)
    {
        int[][] testValues = 
        [
             [1,2],
             [2,3],
             [3,4],
             [1,3]        //Das 1,3 Intervall ist das einzig Überlappende
        ]; 

        Program program = new Program();

        int result = program.EraseOverlapIntervals(testValues);

        Console.WriteLine($"Die Anzahl überlappender Intervalle: {result}");

    }
}

