using System;
using System.Collections.Generic;
using System.Linq;


//Leetcode 3174
// Rückwärts iterieren und bei einem digit den counter erhöhen und solange dieser >0 ist, wird kein Buchstabe dem Ergebnis hinzugefügt.


namespace ClearDigits
{
    public class Program
    {
        public static char[] ClearDigits(string list)
        {
            List<char> result = new List<char>();

            int count = 0;

            for (int i = list.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(list[i]))
                {
                    count += 1;
                }
                else if (count > 0)
                {
                    count--;
                    continue;
                }
                else
                {
                    result.Add(list[i]);
                }
            }
            result.Reverse();
            return result.ToArray();
        }
/*
 short Version mit lambda 
       input.Reverse()   ist rückwärts iterieren
       Der ternäre Operator:  Bedingung ist: Wenn char eine Zahl ist,count erhöhen,aber bool auf false setzen,sonst falls count größer
                                             als 0, den count verkleinern. Andernfalls ein Zeichen setzen.
                                             Anschließend das Ergebnis wieder mit Reverse() rumdrehen und zum Array machen.
                                             ACHTUNG (Mit dem false wird gekennzeichnet,das dieser Wert nicht in den Lösungsarray
                                                    aufgenommen wird!!!)
                       Where behält also nur Werte in der Lösung, die nicht mit false gekennzeichnet wurden.
    {
        int count = 0;

        return new string(input.Reverse()
            .Where(c => char.IsDigit(c) ? (++count > 0) == false : count-- <= 0)
            .Reverse()
            .ToArray());
    }
*/

        public static void Main(String[] args)
        {
            string list = "tgs4f4d2ad2";

            string result = new string(ClearDigits(list));

            Console.WriteLine($"Der Ergebnisstring lautet: {result}");
        }
    }
}


