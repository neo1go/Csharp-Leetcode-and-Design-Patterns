// Bei diesem Problem geht es um die Farben der Nationalflagge mit maximal 3 Farben, repräsentiert
// durch die Zahlen 0,1 und 2 die im Array ohne Sort Funktion sortiert werden sollen.
// Es werden die vorderste und hinterste Position miteinander verglichen und bei Bedarf getauscht
// um Nullen und Zweien an die richtige Stelle zu setzen

public class Program
{

    public static void sortColors(int[] nums)
    {
        int start = 0;          //3 Pointer
        int mid = 0;
        int end = nums.Length - 1;

        while (mid <= end)
        {
            switch (nums[mid])
            {
                case 0:              //ist die Zahl eine 0 beim Middle Pointer, wird sie mit dem Startpointerwert
                                     //getauscht (sind diese identisch, bleibt die 0 an der Position stehen)
                                     //da der midPointer immer öfter weiterreist als der StartPointer,
                                     //wird bei einer 0 der Wert mit dem startPointer Wert getauscht
                    swap(nums, start, mid);
                    mid++;
                    start++;
                    break;

                case 1:                       //ist die Zahl eine 1, wird nichts unternommen und nur der
                                              //MidPointer weiterbewegt nach rechts
                    mid++;
                    break;

                case 2:                     // ist die Zahl eine 2 beim MidPointer,
                                            // wird sie ans Ende gesetzt und der EndPointer
                                            // nach links bewegt 
                    swap(nums, mid, end);
                    end--;
                    break;
            }
        }


    }
    // Mit dieser Funktion werden die Einträge getauscht im Array
    private static void swap(int[] arr, int pos1, int pos2)
    {
        int temp = arr[pos1];
        arr[pos1] = arr[pos2];
        arr[pos2] = temp;
    }


    public static void Main(string[] args)
    {
        int[] testSample = { 2, 0, 2, 1, 0, 0, 2, 0, 1, 1, 2, 1 };

        Console.WriteLine("Original Array");
        foreach (int i in testSample)
        {
            Console.Write(i + " ");
        }

        sortColors(testSample);

        Console.WriteLine("\nNeues sortiertes Array");
        foreach (int i in testSample)
        {
            Console.Write(i + " ");
        }

    }
}
