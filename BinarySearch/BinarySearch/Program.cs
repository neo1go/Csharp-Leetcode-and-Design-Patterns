namespace BinarySearch
{

    public class Program
    {
        public static bool ReturnTrueIfValueIsinArray(int[] values, int target)
        {
            int linkerPtr = 0;
            int rechterPtr = values.Length - 1;
            while (linkerPtr <= rechterPtr)
            {
                //Berechnung des mittleren Index
                int middle = (linkerPtr + rechterPtr) / 2; 

                //Prüfen,ob Zielwert im rechten Bereich liegt
                if (target > values[middle])    
                {

                    linkerPtr = middle + 1;  

                }
                //Prüfen,ob Zielwert im linken Bereich liegt
                else if (target < values[middle])    //else if ist wichtig, um genau diese beiden Optionen auch abzugleichen.
                {
                    rechterPtr = middle - 1;

                }
                //Zielwert gefunden
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static void Main()
        {
            int[] myValues = [ 1, 3, 5, 6, 7, 8, 9, 11 ]; //muss sortiert sein, WICHTIG
            int target = 3;

            Console.WriteLine("Die Zahl ist im Array vorhanden: " + ReturnTrueIfValueIsinArray(myValues, target));
        }


    }
}
