namespace MissingNumber
{
    public class Program
    {
        public static (int, int) MissingNumber(int[] nums)  //gibt mehrere int zurück
        {
            int allXOR = 0;
            int totalXOR = 0;
            int n = nums.Length;

            for (int i = 0; i <= n; i++)
            {
                allXOR ^= i;     //hier wird der gesamte Array durchlaufen und alle XOR Werte gesetzt.
                                 //0   0^0         0      bitweise     0000^0000  ergibt 0000     
                                 //1   0^1         1                   0000^0001  ergibt 0001
                                 //2   1^2         3                   0001^0010  ergibt 0011
                                 //3   3^3         0                   0011^0011  ergibt 0000
                                 //4   0^4         4                   0000^0100  ergibt 0100
                                 //5   4^5         1                   0100^0101  ergibt 0001
                                 //6   1^6         7                   0001^0110  ergibt 0111
                                 //7   7^7         0                   0111^0111  ergibt 0000 
                                 //8   0^8         8                   0000^1000  ergibt 1000
                                 //9   8^9         1 Endergebnis       1000^1001  ergibt 0001

                Console.WriteLine($"Gesetzter Wert für Zahl {i} ist {allXOR}");
            }

            foreach (int num in nums)
            {
                totalXOR = totalXOR ^ num; // nun werden alle XOR Werte im aktuellen Array mit fehlender Zahl durchlaufen

                Console.WriteLine($"XOR Wert für {num} ist {totalXOR}");
                //0   0^0         0      bitweise     0000^0000  ergibt 0000     
                //1   0^1         1                   0000^0001  ergibt 0001
                //9   1^9         8                   0001^1001  ergibt 1000
                //3   8^3         11                  1000^0011  ergibt 1011
                //4   11^4        15                  1011^0100  ergibt 1111
                //5   15^5        10                  1111^0101  ergibt 1010
                //2   10^2        8                   1010^0010  ergibt 1000
                //6   8^6         14                  1000^0110  ergibt 1110 
                //7   14^7        9                   1110^0111  ergibt 1001

            }
            return (allXOR, totalXOR);
        }






        public static void Main(string[] args)
        {
            int[] arr = { 0, 1, 9, 3, 4, 5, 2, 6, 7 };

            (int ergebnis1, int ergebnis2) = (MissingNumber(arr));    //beide int werden befüllt

            int missingNumber = ergebnis1 ^ ergebnis2;
            // die Ergebnis-Zahlen 1 und 9 werden bitweise mit XOR gegeneinander gewertet.
            // 0001^1001 ergibt 1000 also das Ergebnis 8 welches die fehlende Zahl ist.  

            Console.WriteLine($"Ergebnis aus dem gesamten Array ist {ergebnis1} und wird XOR gegen das zweite Ergebnis {ergebnis2}");
            Console.WriteLine($"Die fehlende Nummer ist {missingNumber}");
        }
    }
}