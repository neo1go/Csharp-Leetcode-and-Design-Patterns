
using System;

/*
Wie funktioniert der Richtungswechsel?
Steigende Sequenz (nums[i-1] < nums[i]): Wenn der Wert an der aktuellen Position größer ist als der vorherige Wert,
bedeutet dies, dass die Sequenz steigt. Wenn wir bereits in einer steigenden Sequenz sind (increasing == 1),
erhöhen wir den Zähler (cur). Wenn wir von einer nicht-steigenden Sequenz (z. B. fallend oder gleich) kommen,
setzen wir den Zähler auf cur = 2(Richtungswechsel) und stellen increasing = 1, um den Beginn einer neuen steigenden
Sequenz zu kennzeichnen.


Fallende Sequenz (nums[i-1] > nums[i]): Wenn der Wert an der aktuellen Position kleiner ist als der vorherige, 
bedeutet dies, dass die Sequenz fällt. Wenn wir bereits in einer fallenden Sequenz sind (increasing == -1), 
erhöhen wir den Zähler (cur). Wenn wir von einer nicht-fallenden Sequenz kommen (z.B. steigend oder gleich), 
setzen wir den Zähler auf cur = 2 (Richtungswechsel) und stellen increasing = -1, um den Beginn einer neuen fallenden 
Sequenz zu kennzeichnen.

Gleiche Werte (nums[i-1] == nums[i]): Wenn die beiden benachbarten Werte gleich sind, unterbrechen wir die monotone Sequenz, 
da eine Sequenz nur dann als monotone Folge betrachtet wird, wenn sie entweder nur steigt oder fällt. 
In diesem Fall setzen wir cur = 1 und setzen increasing = 0, um eine neue Sequenz zu starten.


Warum cur = 2 bei einem Richtungswechsel?
Das Setzen von cur = 2 dient dazu, die Länge der neuen Sequenz zu starten, weil der aktuelle Wert und der vorherige Wert
zusammen eine neue monotone Sequenz bilden. Sobald der Richtungswechsel festgestellt wurde, muß man die 
neue Sequenz von der Länge 2 beginnen (der erste Wert und der zweite Wert in der Reihenfolge).
Es geht also nur darum, das bei einem Richtungswechsel der schon dazugehörende Wert sonst nicht erfasst würde.
*/

namespace LongestMonotonicSubarray
{
    public class Program
    {
        public static int LongestMonotonicSubarray(int[] nums)
        {
            if (nums.Length == 0) //Edgecase
            {
                return 0;
            }

            int counter = 1;
            int result = 1;
            int isIncreasing = 0; //(es gibt hier nur -1 und 1 als Zustand und 0 als neutral)


            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i])   //aufsteigende Folge
                {
                    if (isIncreasing > 0)  //wenn Wert positiv, dann aufsteigend, sonst absteigend
                    {
                        counter += 1;
                    }
                    else //bedeutet somit Richtungswechsel durch Erkennen der Flag -1,0 oder 1 und somit
                         //Ende der monotonen Reihe 
                    {
                        counter = 2;
                        isIncreasing = 1;      // also aufsteigend 
                    }
                }

                else if (nums[i - 1] > nums[i])
                {
                    if (isIncreasing < 0)  //kleiner, also absteigende Reihe
                    {
                        counter += 1;
                    }
                    else //bedeutet somit Richtungswechsel durch Erkennen der Flag -1,0 oder 1 und somit
                         //Ende der monotonen Reihe 
                    {
                        counter = 2;
                        isIncreasing = -1;  //nun also absteigend
                    }
                }

                else// komplett gleiche Zahl
                {
                    counter = 1;       // nums[i] muss noch u.U. mitgezählt werden,dewegen die Erhöhung
                    isIncreasing = 0;  // Neutralstellung wegen Ende der monotonen Reihe.
                }
                result = Math.Max(result, counter);
            };
           
            return result;
        }


        public static void Main()
        {
            //int[] nums = [ 4, 3, 3, 2 ];
            int[] nums = [1, 10, 10];
            int solution = LongestMonotonicSubarray(nums);
            Console.WriteLine($"Das längste Array ist {solution} lang");
        }
    }
}