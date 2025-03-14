// Leetcode 2226
// Das Array enthält eine Anzahl an Süßigkeiten und es gibt eine Anzahl an 
// Kindern k, auf die der maximale Wert an Süßigkeiten verteilt wird.
// Die Besonderheit ist, das die Haufen auch mehrmals geteilt werden dürfen, ansonsten wäre
// es nur ein Auslesen des kleinsten Wertes, der in alle Haufen Süßigkeiten passen würde.
// 
// Lösung:
// Es wird gerechnet mit den Werten von 1 bis candies Summe /k. (Das Ergebnis von Summe durch k ergibt den hypothetischen Maximalwert pro Kind k.)
// Darauf wird ein binary Search genutzt.
// Bspl: [5,8,6] k=3
// 5+8+6 = 19   19/3 = 6
// Der Bereich ist [1,2,3,4,5,6] mit Pointern left mid right wobei left =0; mid =left+(right-left)/2; right = candies.Sum/k
// Darauf wird ein binary Search angewandt, also immer halbiert um den richtigen Wert m auszulesen.
// Es wird mit der Mitte angefangen:
// Bspl.: 
// [1,100,100]  Summe 201 /3 = 67 . Diese 67 ist nur hypothetisch der größte Wert pro Kind (oder wenn alle Einträge genau diesen Wert besitzen würden).
// 1/67 ist kleiner als ein Kind, dann 100/67 =1 ,dann 100/67=1, aber noch keine 3 Kinder sonder nur 2. Also rechten Pointer nach links von m verschieben. 
// von 67 die Hälfte ist der neue m Wert, also 33
// 1/33 =kleiner, 100/33=2 und 100/33=2 also k=4 also >3 , somit linker Pointer wieder rechts von 33 und m zwischen 67 und 33,also m = 50.
// 1/50 kleiner, 100/50 =2 und 100/50=2 also wieder >3
// zur Verkürzung des Beispiels (50 ist der Maxwert)
// 1/51 kleiner, 100/51 =1 und 100/51 =1 also höchstens 2 Kinder und somit zu wenig.(diese Einser sind somit unser totalChildren Wert, der additiv erechnet wird)
// Mit 50 candies werden alle 3 Kinder als Maximalwert versorgt.
public class Program
{

    public int MaximumCandies(int[] candies, int k)
    {

        long sumCandies = candies.Sum(x => (long)x);//Summe der Candies, die dann durch Anzahl Kinder geteilt werden

        // Grundlegende Edge Cases
        if (sumCandies < k) return 0;
        if (k == 0) return int.MaxValue;


        // Binäre Suche zwischen 1 und Maximalwert (sum/k)
        int left = 1;
        int right = (int)(sumCandies / k);//dies ist der maximale Wert der hypothetisch verteilt werden kann 
                                          //dies ergibt also alle aktuellen Werte, über die dann die binäre Teilung angewandt wird.
        int result = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;// Mittenberechnung, die mit mid den eigentlichen Prüfwert enthält
            long totalChildren = 0;

            foreach (int pile in candies) //es wird nun über die echten Werte iteriert im Array candies
            {

                totalChildren += (long)pile / mid; // Vermeidet Zwischenüberlauf durch long. Es wird hier die reine Anzahl an Kindern ermittelt
                                                   // pro Haufen pile und im foreach +1 gerechnet. Also 1stes Kind, 2tes Kind, 3tes Kind usw.
                if (totalChildren >= k) break;     // Early exit 
            }                                      // Wenn die Anzahl Haufen erreicht wurde 
                                                   // bei der alle Kinder k versorgt wurden, wird vorzeitig abgebrochen.


            if (totalChildren >= k) // wenn also mindestens alle Kinder versorgt werden können,
                                    // wird hier entschieden, ob links oder rechts von m weitergesucht wird.
            {                       // Auch nur dann wird result eingetragen.
                                    // Da Richtung größtem Wert iteriert wird, wird auch result höchstens größer aber nie
                                    // kleiner da sonst die Anzahl der totalChildren ja zu klein wäre.
                result = mid;       // Potentielle Lösung merken
                left = mid + 1;     // Versuche höhere Werte im binary search (so wird immer der höchste Wert = result)
            }
            else
            {
                right = mid - 1;    // Gehe zu niedrigeren Werten aber result wird nicht upgedated weil links kleiner als aktueller Wert
            }
        }

        return result;
    }


    public static void Main(string[] args)
    {
        int[] candies = [100, 1, 100];
        int k = 3;
        Program program = new Program();

        Console.WriteLine($"Der maximale Süßigkeitenhaufen pro Kind beträgt {program.MaximumCandies(candies, k)} Süßigkeiten");

    }
}


