using System;
using System.Collections.Generic;


using System.Linq;

// Leetcode 2560 House Robber IV
// Diese Aufgabe hat mir ganz schöne Probleme bereitet. (Kleinster Maximalwert)
// Ein Array mit Häusern in einer Straße wobei die Zahlen den Geldwert anzeigen.
// Der Räuber beklaut nie zwei nebeneinander liegende Häuser.
// Bspl.:  [2,3,11,9] und die Anzahl der auszuraubenden Häuser ist k = 2 ;
// Die richtige Antwort ist 9, wobei die 2(k) Werte 2 und 9 oder 3 und 9 sein können.
// Mittels binarySearch mit der Range von 0 bis zum Max Wert im Array, in diesem Fall bis 11,
// wird herausgefunden, ob genügend Häuser in die Bedingung passen.
// Es werden mit einer Helfermethode alle Häuser geprüft, die kleiner als m sind.(m ist die Mitte für den binary Search).
// Mit der Helfermethode wird auch entschieden, ob ein Wert genommen werden kann oder übersrpungen werden muß.
// Es wird gefordert, die kleinste Kombination zurückzugeben und davon den größeren Wert auszugeben.
//
// Die Besonderheit ist die Helfermethode CanRob(), welche, basierend auf einem Vergleich mit Math.Max, ermittelt, ob der Zähler für
// die validen Werte erhöht werden soll die im validen Bereich liegen; in diesem Fall kleiner m.
// Wenn 2 Werte nebeneinander liegen, wird der Zähler durch den Vergleich Math.Max(curr,prev+1) quasi nicht erhöht.
// Der Trick ist eigentlich, das der Vergleich von curr mit prev+1 immer gleich ausgeht,da ja curr nur 1 höher ist als prev, wenn sie nebeneinander liegen.
// Ansonsten ist curr eins oder mehr von prev entfernt und somit größer,was zur Folge hat, das der Zähler erhöht wird.
// Hat zwar etwas von Indexvergleichen, nutzt aber in Wirklichkeit die Abstände 0 und 1 geschickt mittels prev und curr. Wenn prev+1 denselben Wert wie
// curr hat, wird der Zähler eben nicht erhöht. 

public class Program
{

    public int MinCapability(int[] houses, int k)
    {
        int result = 0;
        int left = houses.Min();
        int right = houses.Max(); //ergibt die Range der binary Strecke, die geprüft wird.

        while (left <= right) //Achtung, nicht nur < nutzen. Bei gleichen Werten im Array würde nicht weit genug berechnet werden.
        {
            int mid = left + ((right - left) / 2);  //left hinzuaddieren wegen OutOfBounds.Dies ist die binary-Search Bedingung mit left, right und mid.
            if (CanRob(mid, houses, k))  //wenn Werte passen,dann wird result auf mid gesetzt.
            {
                result = mid;
                right = mid - 1;//Wichtig, den Pointer zu setzen. Das hat deepseek vergessen und left wurde nie gleich oder größer right.
            }
            else
            {
                left = mid + 1;  //andernfalls muß der binary-Search den Bereich rechts von m durchsuchen 
            }
        }
        return result;
    }


    //Achtung,diese Methode vergleicht und liest die Werte nur aus und erhöht u.U. einen Zähler, um einen Bool zurückzugeben.
    //Wenn Math.Max(curr,prev+1) gleich sind ,wird der Zähler nicht erhöht. Dies steht für einen direkten Nachbarn der somit nicht gezählt wird.
    //Das ist alles.
    private bool CanRob(int maxValue, int[] houses, int k)  //maxVal ist m vom binary Search,also werden bei dieser Aufgabe immer nur Werte,
                                                            //die kleiner als m sind, als valide angesehen.
                                                            //Hier wird nun bestimmt, ob die Werte weit genug auseinander stehen zum Ausrauben.
    {
        int prev = 0;  
        int curr = 0;  

        foreach (int house in houses)
        {
            //hier wird mittels curr ermittelt, ob genügend zutreffende Kandidaten im Array vorhanden sind. Wenn sie nebeneinander stehen, wird 
            //somit der Zähler nicht erhöht, weil newCurr dann dem vorherigen Wert entspricht und somit bleibt der Zähler gleich.
            if (house <= maxValue)
            {
                int newCurr = Math.Max(curr,prev+1);// überspringen oder nehmen wird hier entschieden mittels Math.Max.
                prev = curr;//hier wird der (alte) Wert gespeichert von der (quasi)-vorherigen Iteration.
                curr = newCurr;   //hier wird curr wieder überschrieben
            }
            else
            {
                prev = curr;//somit kann das nächste Haus genommen werden und muss nicht übersprungen werden
            }
        }
        return curr >= k;  // bool für: Anzahl der Häuser, die nicht nebeneinander stehen, ist größer gleich k?   
    }
    public static void Main(string[] args)
    {
        int[] nums = [2,3,5,6,9];
        int k = 3;
        Program program = new Program();
        int result = program.MinCapability(nums, k);
        Console.WriteLine($"Der größte Wert der kleinsten geklauten Menge ist {result}");

    }
}
