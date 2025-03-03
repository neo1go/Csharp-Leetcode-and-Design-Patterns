namespace PartitionArray
{
    //Leetcode 2161
    // Die Aufgabe besteht darin, denn Array zu partitionieren.
    // Alle Werte die kleiner als der Pivot sind, sollen links ´vom Pivot eingetragen werden, dann die Pivot-Werte und dann rechts vom Pivot die
    // größeren Werte. Die Reihenfolgen vor und nach dem Pivot sind egal, es handelt sich um Sorting und nicht Partitioning.
    public class Program
    {

        //Dies ist die funktionierende Variante, benötigt aber viel Speicher
        public int[] PartitionArray(int[] nums, int pivot)
        {


            List<int> before = new List<int>();  //mit extra Memory
            List<int> piv = new List<int>();     // ""   ""
            List<int> after = new List<int>();   // ""   ""

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < pivot)
                {
                    before.Add(nums[i]);
                }
                if (nums[i] == pivot)
                {
                    piv.Add(nums[i]);
                }
                if (nums[i] > pivot)
                {
                    after.Add(nums[i]);
                }

            }

            return before.Concat(piv).Concat(after).ToArray();
        }


        // Diese Variante arbeitet mit 4 Pointern
        // 2 Pointer laufen im vorgegebenen Array aufeinander zu.
        // Ist der Wert kleiner als pivot , wird er an Stelle des linken Pointers im Result Array eingetragen und der result Pointer um 1 erhöht.
        // Nun das besondere: Wenn der Wert größer als der Pivot ist, wird der Wert am Ende des Arrays eingetragen
        // und der Pointer im Ziel Array verringert.
        // Immer nach einem Vergleich ob größer oder kleiner, werden die beiden Pointer im vorgegebenen Array aufeinander zu bewegt.
        // So bleibt die Stelle im Array übrig, die automatisch von dem/den Pivotwert/en eingenommen wird.
        public int[] PartitionArrayII(int[] nums, int pivot)
        {
            int i = 0;  //zum normalen Durchiterieren des vorgegebenen Arrays
            int j = nums.Length-1; //zum normalen Durchiterieren von rechts nach links des vorgegebenen Arrays
            int i2 = 0;  //Dieser Pointer wird für das Eintragen von Werten in das Result-Array von links genutzt. 
            int j2 = nums.Length-1; //Dieser Pointer wird für das Eintragen der Werte in das Result-Array von rechts genutzt.


            int[] result = new int[nums.Length];

            while (i < nums.Length)   //läuft solange bis Ende erreicht wird
            {
                if (nums[i] < pivot) //Auslesen des Vorgabe Arrays
                {
                    result[i2] = nums[i];    //Einfügen von Wert an Stelle i wenn kleiner als Pivot
                    i2++;
                }
                if (nums[j] > pivot)
                {
                    result[j2] = nums[j]; //Einfügen von Wert j ausgehend vom Ende des Arrays, wenn größer als Pivot
                    j2--;
                }
                i++;
                j--;
            }
                while (i2 <= j2)         //Erst wenn die größeren und kleineren Werte eingetragen wurden,werden die Pivot-Werte eingetragen.
                                         //Hier z.B. wäre  die Mitte noch frei: [3,4,6,0,0,11,17,12] pivot =10 ergibt [3,4,6,10,10,11,17,12]
                {
                    result[i2] = result[j2] = pivot;  //Zuweisung von rechts nach links, also pivot in j2 ,dann j2 in i2.
                    i2++;
                    j2--;
                }
            
            return result;
        }



        public static void Main(String[] args)
        {
            int[] nums = [9, 12, 5, 10, 14, 3, 10];
            int pivot = 10;
            Program program = new Program();


            int[] result = program.PartitionArrayII(nums, pivot);

            foreach (int r in result)
            {
                Console.Write(r + " ");
            }
        }

    }



}
