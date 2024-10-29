namespace BinarySearch
{







    public class Program
    {
        public static bool returnTrueIfValueIsinArray(int[] values, int target)
        {
            int linkerPtr = 0;
            int rechterPtr = values.Length - 1;
            while (linkerPtr <= rechterPtr)
            {
                int middle = (linkerPtr + rechterPtr) / 2; //Halbierung des jedesmal neu erstellten Arrays bei jedem Durchlauf,
                                                           //so dass immer wieder halbiert wird. Die Variable muß innerhalb
                                                           //des while Loop sein um jedesmal die neue Halbierung zu berechnen

                if (target > values[middle])     //Zielwert größer als der Mittelwert,wäre er gleich, würde direkt true returned werden
                {

                    linkerPtr = middle + 1;  //Pointer wird eins größer als middle

                }
                else if (target < values[middle]) //Zielwert kleiner als der Mittelwert,wäre er gleich,würde direkt true returned werden
                {
                    rechterPtr = middle - 1;//Pointer wird eins kleiner als middle

                }
                else
                {
                    return true;
                }
            }
            Console.WriteLine("Wert nicht in Array vorhanden!!");
            return false;
        }




        public static void Main(string[] args)
        {
            int[] myValues = { 1, 3, 5, 6, 7, 8, 9, 11 }; //muss sortiert sein, WICHTIG
            int target = 2;

            Console.WriteLine("Die Zahl ist im Array vorhanden: " + returnTrueIfValueIsinArray(myValues, target));
        }
    }
}
