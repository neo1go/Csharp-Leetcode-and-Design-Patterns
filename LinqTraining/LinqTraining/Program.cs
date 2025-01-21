using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{

    public static void Main()
    {
        /*
         int[] numbers =  [1,2,3,4,5,6,7,7,8,6,5,36];

         var evenNumbers = from n in numbers 
             where n%2 == 0 
             select n; 

         foreach (var num in evenNumbers)
         {
             Console.WriteLine(num);
         }
         */
        //------------------------------------
        /*
        List<String> names = new List<string>{"Anna","Bob","Charlie"};
        
        var filteredNames = names.Where(n=> n.StartsWith("a",StringComparison.OrdinalIgnoreCase));
        
        foreach(var n in filteredNames)
        {
            Console.WriteLine(n);
        }
        */
        //-------------------------------------
        /*
        Dictionary<int,string> data = new Dictionary<int,string>
        {
            {1,"One"},
            {2,"Two"},
            {3,"Three"}
        };
        
        var keys = from k in data
            where k.Value.StartsWith("t",StringComparison.OrdinalIgnoreCase)
            select k.Key;
            
            
            foreach(var key in keys)
            {
                Console.WriteLine(key);
            }
          */
        //------------------------------------
        /*
        int[] numbers = {1,2,3,4,5,6,7,8};
        var evenNumbers = numbers.Where(n=>n%2==0)
            .Select(n=>n);
            
        foreach(var num in evenNumbers){
        Console.WriteLine(num);
        }
        */
        //--------------------------------------

        int[] numbers = { 1, 3, 4, 5, 6, 7, 8, 9, 10, 2, 4 };

        var query = from n in numbers
                    where n % 2 == 0
                    select n;

        var sortedQuery = query.OrderBy(n => n);

        foreach (var s in sortedQuery)
        {
            Console.WriteLine(s);
        }

    }
}