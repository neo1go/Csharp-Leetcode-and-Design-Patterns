public class Program
{
    //Wenn alle Ziffern einer Zahl quadriert und dann addiert werden und wieder quadriert werden usw.
    //und am Ende eine 1 stehen bleibt,
    //gilt diese Zahl als "Happy Number"
    //andernfalls entsteht ein loop 
    public static bool HappyNumber(int number)
    {
        HashSet<int> usedIntegers = new HashSet<int>(); // falls eine Nummer wieder erscheint, handelt es sich
                                                        // um einen Loop


        while (true)  //läuft unendlich bis ein return eintrifft
        {
            int sum = 0;

            while (number != 0)
            {
                sum += (int)Math.Pow(number % 10, 2.0); //Beispiel: 19%10 wird zu 9, 9^2 ergibt 81
                                                        //19/10 ergibt Ganzzahl 1 und wird addiert zur 81.
                                                        //82 wird zum neuen Berechnen genutzt 
                                                        
                // Console.Write(sum+" ");
                number = number / 10;// um die vordere Stelle zu nutzen
               
            }
            if (sum == 1)
            {
                return true;
            }
            else
            {
                number = sum;    //hier wird die neue errechnete Zahl eingesetzt
            };

            if (usedIntegers.Contains(number))     //hier wird entschieden, ob es sich um einen Loop handelt
            {
                return false;
            }
            usedIntegers.Add(number);

        }
    }


    public static void Main(string[] args)
    {
        for (int num = 0; num < 200; num++)
        {
            bool answer = HappyNumber(num);
            Console.WriteLine($" Die Zahl {num} ist eine happy Number ?: " + answer);
        }
    }

}
