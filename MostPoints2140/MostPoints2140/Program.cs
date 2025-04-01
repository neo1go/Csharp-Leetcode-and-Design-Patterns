using System;
using System.Collections.Generic;
// Leetcode 2140
// Es wird ein 2d Array angegeben, da immer Paare beinhaltet.
// Es soll der maximale Wert an Punkten ermittelt werden.
// Die Punkte errechnen sich aus dem ersten Wert eines Paares. 
// Der zweite Wert des Paares bestimmt die Anzahl der Fragen, die anschließend
// übersprungen werden müßen falls man den Wert nimmt.
// Bspl.:
// (1, 1),(2, 2),(4, 4),(5, 5)
// Wenn ich 1 nehme, muß ich index 1 überspringen und kann erst bei Index 2 weitermachen
// Wenn ich die 2 nehme, muß ich 2 Indexe überspringen usw.
// Das maximale Ergebnis dieses Beispiels ist der Wert von Index 1 plus Wert von Index 3 , also 2+5=7.


namespace MostPoints2140
{
    public class Program
    {
        // Rekursiver Aufruf. Dies macht die Sprünge für i einfach. Das dict "cache" wird immer wieder mit übergeben.
        public static int MostPoints(List<(int value, int jump)> matrix, int i, Dictionary<int, int> cache)
        {
            // Basecase: wenn der Index außerhalb der Liste liegt, wird 0 zurückgegeben
            if (i >= matrix.Count)
                return 0;

            // Wenn der Wert bereits berechnet wurde, wird dieser genommen. Der Cache enthält key-value Paare und der Index dient als key.
            if (cache.ContainsKey(i))//Dies ist Memoization. Da unterschiedliche Pfade durch die Matrix bestehen, können schon berechnete Werte
                                     //sofort übernommen werden.
                return cache[i];

            int take = matrix[i].value + MostPoints(matrix, i + matrix[i].jump, cache);      //matrix[i].jump ist die Sprungweite

            int skip = MostPoints(matrix, i + 1, cache);

            // Das Ergebnis ist der maximale Wert aus beiden Möglichkeiten
            int result = Math.Max(take, skip);
            cache[i] = result;   //Ergebnis setzen, damit dann aufaddiert werden kann. Immer wenn ein Inde besucht wird, an dem schon berechnet wurde,
                                 // hat man an der Stelle key i den eingetragenen MAX-Wert.
            return result;  //Der return findet hier in der Schleife statt,da die Funktion rekursiver Natur ist.
        }

        public static void Main()
        {

            var matrix = new List<(int, int)>
        {
            (1, 1),
            (2, 2),
            (4, 4),
            (5, 5)
        };
            // Aufruf der Funktion mit Startindex 1 und einem leeren Cache -> 1 wegen den korrekten Sprüngen.
            int maxPoints = MostPoints(matrix, 1, new Dictionary<int, int>());
            Console.WriteLine("Maximale Punkte: " + maxPoints);
        }
    }
}