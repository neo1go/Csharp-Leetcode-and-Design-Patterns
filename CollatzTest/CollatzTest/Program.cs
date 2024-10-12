namespace Collatz
{
    public class Program
    {
        public static long CollatzCalc(long number)
        {
            //wenn die Zahl gerade ist, wird Sie durch 2 geteilt,andernfalls wird Sie mit  3 multipliziert und es wird 1 addiert.
            //dadurch wird am Ende immer die Zahl 1 errreicht. 
            while (number != 1 && number > 0)
            {
                if (number % 2 == 0)
                {
                    number = number / 2;
                    Console.WriteLine($"Das Ergebnis der geteilten Nummer ist {number}.");
                }
                else
                {
                    number = (number * 3) + 1;
                    Console.WriteLine($"Das Ergebnis der multiplizierten Nummer ist {number}.");
                }
            }
            return number;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Bitte eine Zahl eingeben");
            string? input = Console.ReadLine();

            //es wird versucht, den string in eine long Variable umzuwandeln
            if (long.TryParse(input, out long number))
            {
                if (number <= long.MaxValue)  //MaxValue ist ein c# Befehl für einen Max-Wert für numerische Datentypen
                {
                    long result = CollatzCalc(number);
                    Console.WriteLine($"Das Endergebnis ist {result}.");
                }
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß.");
                }
            }
            else
            {
                Console.WriteLine("Die eingegebene Zeichenfolge ist keine gültige Zahl.");
            }

            // Warten auf Benutzereingabe, bevor das Programm endet
            Console.WriteLine("Drücken Sie eine beliebige Taste, um das Programm zu beenden.");
            Console.ReadKey();
        }
    }
}
