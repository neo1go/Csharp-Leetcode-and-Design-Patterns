namespace ApplyOperations
{
    using System;

    //Leetcode 2460 

    // Es werden Werte in einem Array beeitgestellt
    // Bei zwei gleichen Werten soll eine Verdoppelung des ersten Wertes erfolgen und der zweite Wert wird gelöscht/ignoriert
    // Des weiteren sollen alle Werte vorne stehen und der restliche Platz soll von den vorhandenen 0 eingenommen werden.
    // Bspl.:
    // [1,2,0,3,3] ergibt
    // [1,2,6,0,0]
    // 

    public class Program
    {

        public int[] ApplyOperations(int[] nums)
        {
            int[] result = new int[nums.Length];       // Alle Elemente sind standardmäßig 0, also muß man die Nullen gar nicht setzen sondern kann diese beim
                                                       // Durchschreiten ignorieren (!=0).
            int index = 0;  //Dieser index ist der Zähler des Ergebnisarrays


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0) //Die ganze Logik hier trägt nur einen Wert ein, wenn dieser positiv ist.
                {
                    if (i < nums.Length - 1 && nums[i] == nums[i + 1])
                    {
                        result[index] = nums[i] * 2;  // Verdoppelung des Wertes
                        index++;
                        i++; // Überspringt dann den nächsten Wert,da i ja schon einmal erhöht wird. Die Aufgabenstellung gibt vor,
                             // das bei gleichen Werten der Wert verdoppelt wird und der darauffolgende Wert gelöscht(ignoriert) wird.   -> 3,3 ergibt 6,0
                    }
                    else
                    {
                        result[index] = nums[i];
                        index++;
                    }
                }
            }
            return result;
        }



        public static void Main()
        {

            Program program = new Program();

            int[] zahlen = [0, 1, 2, 0, 4, 4, 0, 6, 5];


            int[] result = program.ApplyOperations(zahlen);

            foreach (int r in result)
            {
                Console.Write(r + " ");
            }
        }
    }








}
