
using System;



namespace MinimumRecolors
{
    // Leetcode 2379
    // Bei dieser Aufgabe wird ein String ausgelesen und es soll die minimale Anzahl an Wechseln von W (White) zu B (Black) gezählt werden, um einen
    // durchgehenden String mit Länge k zu erhalten, der nur aus B bestehen würde.
    // Erst wird der Array von 0 bis Länge k durchschritten um quasi alle W in der Fensterlänge k zu ermitteln.
    // Dann wird das Fenster verschoben und wenn ein W wegfällt,wird es abgezogen und wenn ein W dazu stößt, wird der Zähler erhöht.
    // Mittels minC und currentC Zählern wird der kleinste Wert ermittelt und dann zuückgegeben.

    class Program
    {
        
        public static int MinimumRecolors(string blocks, int k)
        {

            if (k > blocks.Length) return 0;

            int currentC = 0;

            //Das erste Fenster wurde erstellt mit der Länge k und alle 'W's werden gezählt.
            for (int i = 0; i < k; i++)
            {
                if (string.Equals(blocks[i].ToString(), "w", StringComparison.OrdinalIgnoreCase)) currentC++;

            }
            int minC = currentC;  //Grundwert für min-Wert nach einer Fensterlänge, sozusagen der Startwert

            // Sliding Window -> "hier wird also verschoben"
            for (int i = k; i < blocks.Length; i++)  //vom letzten Punkt von k bis zum Ende des Arrays
            {
                if (string.Equals(blocks[i - k].ToString(), "w", StringComparison.OrdinalIgnoreCase)) currentC--;   //Anfangspunkt wird verglichen an [0] und wenn w da war wird es
                                                                                                                   // beim Verschieben des Fensters wegfallen.

                if (string.Equals(blocks[i].ToString(), "w", StringComparison.OrdinalIgnoreCase)) currentC++;   //Der letzte Wert wird ermittelt und falls es ein W ist, dem Counter
                                                                                                               // hinzugefügt.  

                minC = Math.Min(minC, currentC); //Ermitteln des min Wertes.
            }
            return minC;
        }


        public static void Main(string[] args)
        {
            string blocks = "WBBWWBBWBW";
            int k = 7;

            int minCount = MinimumRecolors(blocks, k);

            Console.WriteLine($"Die wenigsten Wechsel in diesem string sind {minCount} ");
        }





    }









}
