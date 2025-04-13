//Leetcode 1922
//Es wird eine Länge mit k angegeben. Es soll der größte Wert herausgegeben werden.
//Bei jeder geraden Position soll mit 5 multipliziert werden, ansonsten mit 4.

//Wenn also k=3 ist ,dann wäre die Formel 5*4*5 ,gerade,ungerade,gerade.
//Die Besonderheit ist die Berechnung mittels Helfermethode, um auch große Zahlen zu bearbeiten.

public class Program
{

    static int MultiplyOddEven(long n)
    {
        long MOD = 1000000000 + 7; //von leetcode, um große Zahlen mit modulo zu verkleinern.

        long even = (long)Math.Ceiling((double)n / 2);  //ergibt die Anzahl der geraden Zahlen
        long odd = n / 2;  //ergibt die Anzahl der ungeraden Zahlen
                           //------------------------------------------------------------------------------
                           //Hilfsmethode
        long Potenzieren(long x, long n)
        {
            if (n == 0) //basecase
            {
                return 1;
            }
            long result = 1; //Initialisieren mit 1 für die Multiplikation


            while (n > 1)
            {
                if (n % 2 == 1)
                {
                    result = (result * x) % MOD;
                }

                n = n / 2;        // Hier wird n immer kleiner.
                x = (x * x) % MOD;// hier wird entweder 5 oder 4 mit sich selbst multipliziert.(und dann verkleinert)
                                  // Dies ist der Trick. Man zerlegt n.
                                  // n wird also immer mehr verkleinert während der Exponent x immer größer wird.
                                  // Mathematischer Trick:
                                  // 5^11 (5 ist für den geraden Eintrag und n=11)
                                  // 5^11 halbieren ergibt 5*(5^2)^5 (die Erklärung ist, dass der Exponent 11 halbiert wird,
                                  // mit mod2 und das ergibt dann 5 und eine 5 als Rest, die als Multiplikator vorne angestellt wird.
                                  // Somit ist x= 25. 5*(25^2)^2. Der Exponent 5 wurde geteilt mit Rest. Somit ist der Exponent nun
                                  // hoch 2 für die 25 in der Klammer aber es bleibt ein Rest und somit wird nun eine 25 vorne angestellt.
                                  // 25*5*(25^2)^2 ist die aktuelle Iteration.
                                  // Der letzte Schritt wäre (625^2)^1. Hoch 1 weil der modulo 2 keinen Rest ergab. 25*5 wurden schon dem
                                  // result hinzugefügt.
                                  // Dass geht so weiter und bei ungerader Teilung wird der Rest als Multiplikator vorne angefügt.
                                  // Deswegen ist result = x*x wobei das x dann der vorangestellte Wert ist).
            }

            return (result * x) % MOD;
        }

        long resultEven = Potenzieren(5, even);
        long resultOdd = Potenzieren(4, odd);

        return (int)((resultEven * resultOdd) % MOD);
    }

    public static void Main(string[] args)
    {

        int n = 50;
        Console.WriteLine(MultiplyOddEven(n));
    }

}
