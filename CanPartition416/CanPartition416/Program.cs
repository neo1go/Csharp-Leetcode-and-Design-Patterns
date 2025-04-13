
//Leetcode 416
//Es soll herausgefunden werden, ob ein Array in 2 Partitionen von gleicher Wertigkeit aufgeteilt werden kann.
//Man nimmt die Gesamtsumme des Arrays. Wenn diese nicht durch 2 teilbar ist (Primzahl), kann man sofort abbrechen.
//Ansonsten wird der Wert halbiert und als Zielwert für die Partitionsgröße genommen.
//Es gibt hier mehrere Versionen,um zum Ergebnis zu gelangen.
//Entweder mit bools als flags in einem Array, oder z.B. mit Hashset Einträgen der gesamten Kombinationen von Additionen.

public class Program
{

    public static bool GetPartition(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();
        int partitionSum = (nums.Sum()) / 2; //Halbierte Summe ist der Partitionswert 

        if (nums.Sum()% 2 != 0)
        {
            return false;//baseCase
        }

        set.Add(0); //ohne die 0 als Basis wären keine Additionen möglich.

        foreach (int num in nums) {

            HashSet<int> newSet = new HashSet<int>(set);  //muß man setzen, da sonst zu instabil

            foreach (int value in set) 
            {              
                int newSum = num + value;
                newSet.Add(newSum);           
            }

            set = newSet;  //hier werden die Werte übertragen.
        }


        if (set.Contains(partitionSum))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static void Main(string[] args)
    {
        //int[] nums = [3,1,2,4];  //5 
        int[] nums = [1, 2, 3, 4, 5, 6, 7];  //14
        //int[] nums = [2, 2, 1, 1];   //3
        // int[]nums = [1, 2, 5];  //false
        Console.WriteLine(GetPartition(nums));

    }

}
