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
                int m = (linkerPtr + rechterPtr) / 2;   //Halbierung des Arrays bei jedem Durchlauf,
                                                        //so dass immer wieder halbiert wird. Die Variable muß innerhalb
                                                        //des while Loop sein um jedesmal die neue Halbierung zu berechnen

                if (target > values[m])     //Zielwert größer als der Mittelwert,wäre er gleich, würde direkt true returned werden
                {

                    linkerPtr = m + 1;  //Pointer wird eins größer als m

                }
                else if (target < values[m]) //Zielwert kleiner als der Mittelwert,wäre er gleich,würde direkt true returned werden
                {
                    rechterPtr = m - 1;//Pointer wird eins kleiner als m

                }
                else
                {
                    return true;
                }
            }
            return false;
        }




        public static void Main(string[] args)
        {
            int[] myValues = { 1, 3, 5, 7, 8, 9, 11 }; //muss sortiert sein
            int target = 7;

            Console.WriteLine(" Die Zahl ist im Array vorhanden: " + returnTrueIfValueIsinArray(myValues, target));
        }
    }
}
