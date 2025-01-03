public class Program
{
    // es soll in einem Array der größte Durschnittswert von zusammenhängenden Zahlen mit der 
    // Zahlenlänge k ermittelt werden (k sollte gleich oder kleiner der Gesamtlänge des Arrays sein)
    static double findMaxAverage(int[] nums, int k)
    {
        //Die Summe des starting window mit Länge k wird ermittelt
        int sum = 0;
        for (int i = 0; i < k; i++)   //Dies ergibt die Windowgröße und die erste Summe (Gruppenvorlauf)
        {
            sum += nums[i];
        }
        int maxSum = sum;  //Erstellen der ersten Summe in dem Fenster

        //Start sliding window
        int startIndex = 0;
        int endIndex = k;
       


        //Durchschreiten des Arrays
        while (endIndex < nums.Length)  //während das rechte Ende des Windows noch nicht am Ende des Arrays ist
        {

            sum = sum - nums[startIndex];      //es wird der erste Wert von der Summe abgezogen und
                                               //die linke Fensterkante wird dann nach rechts verschoben
            startIndex++;

            sum = sum + nums[endIndex];       // es wird der letzte neue Wert hinzu addiert und dann die rechte 
                                              // Fensterkante nach rechts verschoben
            endIndex++;
           
            maxSum = Math.Max(maxSum, sum);   //hier wird die maximale Summe gespeichert


        }
        return (double)maxSum / k;  //erst hier wird der average errechnet indem die größte Summe durch die Fenstergröße k dividiert wird.

    }




    public static void Main(string[] args)
    {
        int[] nums = { 1, 12, -5, -6, 50, 3 }; //     49 / 4 ergibt 12,75 
        int k = 4;  //errechnet den max average im Array von 4 aufeinanderfolgenden Zahlen
        double result = findMaxAverage(nums, k);

        Console.WriteLine($"Das Ergebnis lautet {result}");
    }
}
