using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

// Leetcode 2874 Die weiterführende Aufgabe des greedy Approach vom Vortag.
// Es wird mittels Math.Max einfach der größte Wert und außerdem die größte Spanne zwischen
// dem MaxWert und dem kleinsten Wert genommen.
// Alle anderen Werte sind nicht brauchbar und werden so übersprungen bzw. ignoriert und nicht in die
// Formel mit aufgenommen.

public class Program
{
    public int OrderedTripletII(int[] nums)
    {
        int result = 0;
        int prefixMax = nums[0];
        int maxDifference = 0;   //Die größte Spanne zwischen prefixMax und aktuellem Wert

        for (int k = 0; k < nums.Length; k++)
        {
            prefixMax = Math.Max(prefixMax, nums[k]); //größter Wert

            maxDifference = Math.Max(prefixMax - nums[k], maxDifference); //größte Differenz 

            result = Math.Max(result, maxDifference * nums[k]);
        }

        return result;
    }
    public static void Main(string[] args)
    {
        Program program = new Program();
        int[] nums = [12, 6, 1, 2, 7];
        int result = program.OrderedTripletII(nums);
        Console.WriteLine(result);
    }
}
