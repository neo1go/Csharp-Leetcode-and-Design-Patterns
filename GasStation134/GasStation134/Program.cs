//Leetcode 134
//Gas Station
//Zyklisches Durchlaufen einer Collection mittels (startStation + i) % n
public class Program
{
    public static int ValidStart(int[] gasStations, int[] consumption)
    {
        int n = gasStations.Length;  //Länge eines ganzen Zyklus
        if (n != consumption.Length) // Ungültige Eingabe, wenn Längen nicht übereinstimmen.
        {
            Console.WriteLine("Die Arrays sind nicht gleich groß");
            return -1;
        }
        if (consumption.Sum() > gasStations.Sum())  
        {
            Console.WriteLine("Der Verbrauch ist höher als der tankbare Sprit.");
            return -1;
        }

        for (int startStation = 0; startStation < n; startStation++) // Es wird jedesmal die nächste Tankstelle als start genommen und ein
                                                                     // ganzer Zyklus n iteriert.
        {
            int currentFuel = 0;

            for (int i = 0; i < n; i++) //hier wird immer die gesamte Länge einmal iteriert.
            {
                int currentStationIndex = (startStation + i) % n;//das ist die Besonderheit für die Positionsbestimmung
                currentFuel += gasStations[currentStationIndex] - consumption[currentStationIndex];

                if (currentFuel < 0)
                {
                    break; // Tank wäre leer, also zum nächsten Startpunkt weiterziehen
                }
            }

            // Wenn die innere Schleife komplett durchgelaufen ist,
            // bedeutet das, dass die Reise von dieser startStation möglich war.
            if (currentFuel >= 0)
            {
                Console.WriteLine("Es ist genug Sprit vorhanden.");
                return startStation;
            }
        }

        return -1;
    }

    public static void Main(string[] args)
    {

        int[] gasStations = [4, 2, 3, 4, 5];
        int[] consumption = [3, 4, 5, 1, 2];

        Console.WriteLine(ValidStart(gasStations, consumption));
    }
}



