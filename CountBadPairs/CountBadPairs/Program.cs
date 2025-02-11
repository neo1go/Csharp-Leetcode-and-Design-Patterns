using System;
using System.Globalization;

namespace CountBadPairs
{
    //Absoluter Brain fart
    // ein gutes Paar (i,j) erfüllt diese Bedingung:
    //
    //     pairs[i] - pairs[j] = i - j            z.B. bei 4,1,3,3  ist die 1 und die zweite 3 genauso weit auseinander wie deren Differenz(2)
    //         Wert - Wert     = Position - Position
    //
    // Die Vereinfachung der Formel lautet: pairs[i]-i = pairs[j]-j
    //
    // Man kann also bei einem Durchlauf durch pairs[i]-i schon die Einträge als key speichern. Ein gleicher zweiter Wert gibt ein gutes Paar.
    //
    // In dieser Aufgabe wird wegen evtl. Laufzeitproblemen eher mit den goodPairs und einer einfachen Berechnung aller Paare
    // mit totalPairs += i; gearbeitet.
    //
    // Im dictionary werden die Keys errechnet und gespeichert mit (Zahlenwert an der jeweiligen Stelle - Wert des Indexes)
    // Erst wenn der Key ein weiteres Mal errechnet wird, trifft die Bedingung ContainsKey zu und es gibt ein gutes Paar.
    //
    //WICHTIGTSER PUNKT
    //Zwei Zahlen bilden genau dann ein gutes Paar, wenn sie im Dictionary den selben Key erzeugen bzw haben.
    //Weil die Gleichstellungsformel dies quasi vorgibt. Wenn also pairs[i]-i denselben Key gibt, sind zwei Werte mit gleichem key ein
    //gutes Paar weil ihr Abstand genauso groß wie ihre Differenz ist.
    public class Program
    {

        public static int CountBadPairs(List<int> pairs)
        {
            
            int goodPairs = 0;
            int totalPairs = 0;
            Dictionary<int,int> count = new Dictionary<int,int>();

            for (int i = 0; i < pairs.Count; i++)
            {
                totalPairs += i;  //0+1+2+3 etc  dies ergibt die Nummer aller Kombinationen von Paaren

                int key = pairs[i] - i;       //Der Key der verschiedenen Key-Value Paare ist tatsächlich pairs[i]-i

                Console.Write($"i={i}, Arraywert = {pairs[i]}, key={key}, ");

                if (count.ContainsKey(key)) //also nur wenn schon ein gleicher Key vorkam, wird diese Bedingung erfüllt. WICHTIGSTER PUNKT
                {
                    goodPairs += count[pairs[i] - i];
                    count[pairs[i] - i] += 1;          //hier wird die Value des KeyValue Paares erhöht in dem dict
                    Console.Write($"Anzahl guter Paare: {goodPairs}");
                }
                else
                {
                    count[key] = 1; //setzt key auf 1 falls leer
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"Gesamtanzahl Paare: {totalPairs}");
            return totalPairs-goodPairs;
        }



        public static void Main(String[] args)
        {
            //List<int> pairs = [4, 1, 3, 3];
            List<int> pairs = [2,5,4,6,8];

            Console.WriteLine($"Das Ergebnis der falschen Paare ist: {CountBadPairs(pairs)}");
        }
    }














}