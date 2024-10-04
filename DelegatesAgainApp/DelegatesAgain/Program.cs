namespace Delegates2
{
    //Hier wird der delegate erstellt.
    public delegate void MeinDelegat(string message);
    public class Program
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine($"Die 'Print message' Methode sagt: {message}");
        }

        public static void AnotherMethod(string message2)
        {
            Console.WriteLine($"'AnotherMethod' sagt: {message2}");
        }



        public static void Main(string[] args)
        {
            MeinDelegat delegatenInstanz = new MeinDelegat(PrintMessage);  //hier wird die ganze Methode übergeben

            delegatenInstanz("Hier wurde die printMessage Methode an den Delegaten übergeben.");



            delegatenInstanz = new MeinDelegat(AnotherMethod);  //und hier eine weitere Methode. Wichtig ist die gleiche
                                                                //Parameterliste

            delegatenInstanz("Es wurde eine zweite Methode an den Delegaten übergeben und auch eine neue Instanz erstellt.");

            Console.ReadKey();
        }
    }
}
