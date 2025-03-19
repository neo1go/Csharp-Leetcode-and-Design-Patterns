//Leetcode 3191
// Die Aufgabe besteht darin, ein  in einem Array, das aus den Bitwerten 1 und 0 besteht, die
// minimale Zahl für das Flippen der Bits amzugeben die benötigt wird, um alle Nullen zu flippen.
// Wenn am Ende eine 0 nicht mehr gedreht werden kann, soll stattdessen -1 zurückgeben werden.
// Die Besonderheit bei der Aufgabe ist ein festgelegtes Fenster, in dem die Bits geflippt werden.
// So werden immer bits mitgedreht, die eigentlich schon 1 sind. Bspl.:  010  wird zu 101.
// Es reicht also, an der Stelle des Schleifeniterators i zu prüfen und bei schon vorhandenen Einsen
// einfach weiter zu iterieren. Die letzten drei Werte eines Arrays sollten dann seperat geprüft werden
// da das sliding window ja nicht weiter iterieren kann wegen OutOfBounds.

public class Program
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int flips = 0;
        // XOR     1 1  -> 0
        //         0 1  -> 1
        //         1 0  -> 1

        for (int i = 0; i <= n - 3; i++)
        {
            if (nums[i] == 0)
            {                     // Trick: 
                nums[i] ^= 1;     // Wenn xor mit dem Wert gegen 1 genutzt wird, wird sichergestellt, 
                nums[i + 1] ^= 1; // dass immer der Wert gedreht wird: 1 wird 0.   0 wird zu 1.
                nums[i + 2] ^= 1;
                flips++;
            }

        }

        //Prüfung der letzten 3 Einträge
        if (nums[n - 1] != 1 || nums[n - 2] != 1 || nums[n - 3] != 1)
        {
            return -1;
        }

        return flips;

    }

    public static void Main(string[] args)
    {
        Program program = new Program();

        int[] nums = [0, 1, 1, 1, 1, 1, 1, 0, 0];
        Console.WriteLine($"Die minimalen Flips sind {program.MinOperations(nums)}");

    }
}