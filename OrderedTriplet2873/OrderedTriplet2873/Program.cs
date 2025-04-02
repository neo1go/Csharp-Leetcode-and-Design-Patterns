using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

// Leetcode 2873
// Es soll das maximale Triplet zurückgegeben werden mit der Formel
// [i,j,k] wobei der Wert errechnet wird mit (i-j)*k und die Indexe immer von links nach rechts
// gelesen werden.
// Der erste Wert wird mit einem Window weitergeschoben. Der 2te Wert sollte ein sehr kleiner
// Wert sein und der dritte Wert ein sehr großer Wert.
// 
// Es geht auch der greedy Aproach bei dem die äußere Schleife wegfällt.
// Falls also Mid größer Left ist, wird Mid zu Left und man kann einen continue danach setzen, 
// damit der nächste Wert berechnet wird weil der aktuelle rausfällt weil er ja die Bedingung
// nicht erfüllt.
// int left= nums[0];
// if(nums[mid]>left)
//   {left=nums[mid];
//          continue;}




public class Program
{

    //Alte Variante
    /*
    public int OrderedTriplet(int[] nums)
    {
        int result = 0;
        int left = 0;
        int mid = left + 1;
        int right = mid + 1;

        for (left = 0; left < nums.Length - 2; left++)
        {
            for (mid = left + 1; mid < nums.Length - 1; mid++)
            {
                for (right = mid + 1; right < nums.Length; right++)
                {
                    result = Math.Max(result, (nums[left] - nums[mid]) * nums[right]);
                }
            }
        }
        return result;
    }
    */

    // Neue Variante mit greedy Aproach.Wir sparen die äußere Schleife. Da wir mid von left subtrahieren müssen,
    // sollte left immer größer sein als mid. Außerdem wird der Algorithmus durch das continue eventuell performanter.
    public int OrderedTriplet(int[] nums)
    {
        int result = 0;
        int left = 0;
        int mid = left + 1;
        int right = mid + 1;

        
        
            for (mid = left + 1; mid < nums.Length - 1; mid++)
            {
            if (nums[mid] > nums[left]) 
            {
                left = mid;  //Falls mid größer als left ist, können wir überspringen.
                continue;
            }

                for (right = mid + 1; right < nums.Length; right++)
                {
                    result = Math.Max(result, (nums[left] - nums[mid]) * nums[right]);
                }
            }
        
        return result;
    }


    public static void Main(string[] args)
    {
        Program program = new Program();
        int[] nums = [12, 6, 1, 2, 7];
        int result = program.OrderedTriplet(nums);
        Console.WriteLine(result);
    }
}
