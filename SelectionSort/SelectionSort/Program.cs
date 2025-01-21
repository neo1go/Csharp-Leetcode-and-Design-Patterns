
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace SelectionSort
{


    public class Program()
    {

        public static int[]? SelectionSort(int[] nums)
        {
            bool swapped = false;
            int temp;

            if (nums.Length <= 1)
            {
                Console.WriteLine("Der Array ist zu klein");
                return null;
            }

           
            for (int i = 0; i < nums.Length; i++)
            {
               
                for (int j = i+1; j < nums.Length; j++)//j muss immer i+1 sein 
                {
                    if (nums[i] > nums[j])// dies ist SelectionSort, da dies für jedes Element im Array wiederholt wird wegen i und j
                    {                     // anstatt nur j und j+1 zu vergleichen wie bei BubbleSort
                        temp = nums[i];   // Bei SelectionSort werden die Werte bei den Pointerstellen bei Bedarf vertauscht.
                        nums[i] = nums[j];
                        nums[j] = temp;

                        swapped = true;                      
                    }                
                }
                if (!swapped)
                {
                    Console.Write("Array ist schon sortiert. "); //Aus Schleife ausbrechen und den Array direkt ausgeben!
                    break;
                }
            }
           

            return nums;
        }


        public static void PrintArray(int[] sortedArray)
        {
            if (sortedArray.Length > 1)
            {
                foreach (int i in sortedArray)
                {
                    Console.Write(i + " ");
                }
            }
        }



        public static void Main()
        {
            int[] nums = [ 34, 2, 56, 7, 8, 3, 2, 4 ];
            // int[] nums = {};
            //int[] nums = [1,2,3,4 ];
            int[]? sortedArray = SelectionSort(nums);

            PrintArray(sortedArray);   
        }


    }
}
