namespace BubbleSort
{
    //BubbleSort,so benannt weil der größere Wert quasi
    //nach oben an die Oberfläche gespült wird (Bubbles) (also durch den Array bewegt wird)

    public class Program
    {

        public static int[] BubbleSort(int[] nums)
        {
            if (!validArray(nums))
            {
                return nums; // Abbruch, falls das Array ungültig ist
            }


            bool swapped = false;
            int temp;


            

            for (int i = 0; i < nums.Length - 1; i++)
            {


                for (int j = 0; j < nums.Length - 1 - i; j++) //Hier wird -i genutzt weil bei jedem Durchlauf der Array um 1 kürzer
                                                              //wird da ja der größte Wert nach hinten gespült wird
                                                              //und nicht mehr sortiert werden muß.
                {
                    if (nums[j] > nums[j + 1])
                    {   
                        //Bei BubbleSort werden die benachbarten Werte solange vertauscht bis der Wert ganz hinten steht.
                        temp = nums[j]; 
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;

                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    Console.Write("Das Array war schon sortiert. ");   //Falls der Array schon sortiert ist
                    break;
                }
            }

            return nums;
        }


        public static void printArray(int[] sortedArray)
        {
            


            foreach (int i in sortedArray)
            {
                Console.Write(i + " ");
            }

        }

        // Methode zur Validierung des Arrays
        public static bool validArray(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine("Array ist null");
                return false;
            }

           else if (array.Length == 0)
            {
                Console.WriteLine("Array ist leer aber erstellt");
                return false;
            }

           else if (array.Length == 1)
            {
                Console.WriteLine("Array zu klein zum Sortieren");
                return false;
            }

            return true; // Array ist gültig
        }


        public static void Main(string[] args)
        {
            int[] nums = { 34, 2, 56, 7, 8, 3, 2, 4 };
            //int[] nums = new int[]{ 1 };
            //int[] nums = new int[]{   };
            //int[] nums = { 1, 2, 3, 4 };

            int[] sortedArray = BubbleSort(nums);

            printArray(sortedArray);
        }


    }
}
