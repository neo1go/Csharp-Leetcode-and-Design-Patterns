


namespace ClosestPrimes
{

    public class Program
    {
        public static bool isPrime(int n)
        {
            if (n < 2)// Die 1 ist keine Primzahl, erst ab der 2 entstehen Primzahlen; 1 ist NUR durch sich selber teilbar.
            {
                return false;
            }
            //Wenn eine Zahl KEINE Primzahl ist, dann kann sie in zwei Faktoren zerelgt werden: n = a*b . WICHTIG!!!!!!
            //Wenn sowohl a als auch b größer als (Wurzel aus n) wären, dann wäre ihr Produkt  größer als n, was nicht möglich ist.
            //Das bedeutet: Mindestens einer der beiden Faktoren muss kleiner oder gleich (Wurzel aus n) sein.
            int maxTeiler = (int)Math.Sqrt(n); //Optimierung,da das Iterieren nach der Wurzel von n immer die selben Teiler zeigt ,nur in umgedrehter Abfolge.
                                               //Beispiel n = 100
                                               //Faktoren von 100
                                               //1*100
                                               //2*50
                                               //4*25
                                               //5*20
                                               //10*10 -> größter Faktor, der noch eine 100 ergibt, eine 11 ist zu groß. Dies ist der größte Wurzelwert. 
                                               //Jetzt wiederholen sich die Multiplikatoren, nur rumgedreht(z.B. 20*5,25*4,50*2 etc).
                                               //Dies ist eine exponentielle Verbesserung.
                                               //Bei n = 1.000.000 wäre die Wurzel gleich 1000

            // eine 11 würde für n = 100 nicht funktionieren. Bspl.:
            //           11,22,33,44,55,66,77,88,99,110,121
            //Faktoren   1  2  3  4  5  6  7  8  9  10  11     man sieht, das 11*11 schon außerhalb unseres n =100 ist.
            //                                                 Deswegen kann man mit der Wurzel von 100 arbeiten.     
            //  Für 10 sind dann die Primzahlen 2,3,5,7 
            for (int i = 2; i <= maxTeiler; i++)
            {                        //WICHTIGSTER PART für die Primzahlerkennung
                if (n % i == 0)// i ist immer der Faktor, bei dem geschaut wird, ob er in die Zahl glatt rein passt. Wenn nicht, ist dies eine Primzahl.
                {
                    return false;
                }
            }
            return true;
        }

        public int[] ClosestPrimes(int left, int right)
        {

            List<int> primes = new List<int>();

            // Es werden einfach alle vorhanden Primzahlen in die Liste aufgenommen, sehr einfach!!!
            for (int i = left; i <= right; i++)
            {
                if (isPrime(i)) primes.Add(i);  //Alle Primzahlen werden eingetragen in primes.
            }

            if (primes.Count < 2) return new int[] { -1, -1 }; // Falls es keine oder nur eine Primzahl gibt.(baseCase)

            // Bestimme das Paar mit dem kleinsten Abstand.
            int minDiff = int.MaxValue;
            int[] result = new int[2];
            for (int i = 1; i < primes.Count; i++)//wird mit 1 initialisiert, um beim Vergeich nicht outOfBounds zu gelangen. Deswegen der Vergleich i-1.
            {
                int diff = primes[i] - primes[i - 1];//Da der kürzeste Abstand zwischen benachbarten Einträgen sein muss, wird i mit i-1 verglichen.
                if (diff < minDiff)
                {
                    minDiff = diff;
                    result[0] = primes[i - 1];//hier wird alles geupdatet im Array an Stelle 0 und 1.
                    result[1] = primes[i];
                }
            }
            return result;
        }

        public static void Main()
        {
            int left = 10;
            int right = 19;
            Program program = new Program();

            Console.WriteLine($"Das Ergebnis ist {String.Join(", ", program.ClosestPrimes(left, right))} ");
        }
    }

}