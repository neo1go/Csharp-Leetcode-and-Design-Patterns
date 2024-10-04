public class Program
{
    public static void Main(string[] args)
    {

        int temp = 0;
        int maxTemp = 0;

        int[] ones = { 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1 };

        foreach (int entry in ones)
        {
            if (entry == 1)
            {
                temp++; //Zähler erhöhen
                maxTemp = Math.Max(maxTemp, temp); //Größter Wert wird eingetragen
            }
            else
            {
                temp = 0;//taucht eine Null auf, wird der Zähler zurückgesetzt
            }

        }
        Console.WriteLine($"Es sind maximal {maxTemp} aufeinanderfolgende Einsen im Array vorhanden. ");

        Console.ReadKey();

    }
}