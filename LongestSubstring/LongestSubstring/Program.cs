using System;
using System.Collections.Generic;
//Two Pointer Approach
// links und rechts starten bei chars[0].
// Der rechte Pointer startet und sobald ein Duplikat im HashSet gefunden wurde,
// rückt der linke Pointer nach rechts, bis das Zeichen nicht mehr doppelt ist.
// Das linke Zeichen wird aus dem HashSet entfernt und das nächste rechte Zeichen
// wird eingefügt, um den maximal längsten Substring beizubehalten.
// Es muss Remove genutzt werden, weil nicht der neue Eintrag ins hashSet falsch ist,
// sondern der alte Eintrag.
// Man könnte jede beliebig erweiterbare Collection für die Lösung nutzen, weil hier 
// die Einzigartigkeit von Einträgen ins HashSet gar nicht genutzt wird, aber
// das HashSet ist am Effizientesten wegen dem schnelleren Nachschlagen durch Hashing.

namespace LongestSubstring{
    public class Program
    {
        public static int LongestSubstring(string chars)
        {
            int leftPointer = 0;
            int result = 0;
            HashSet<char> setOfChars = new HashSet<char>();

            for (int rightPointer = 0; rightPointer < chars.Length; rightPointer++)
            {
                while (setOfChars.Contains(chars[rightPointer]))// Wenn Duplikat erscheint
                {
                    setOfChars.Remove(chars[leftPointer]); // Entferne das doppelte Zeichen
                    leftPointer++; // Verschiebe den Startindex
                }

                setOfChars.Add(chars[rightPointer]);
                result = Math.Max(result, rightPointer - leftPointer + 1);
            }

            return result;
        }

        public static void Main(String[] args)
        {
            string chars = "abacaacbb";
            int result = LongestSubstring(chars);
            Console.WriteLine($"Der längste Substring ist {result} Zeichen lang.");
        }
    }
}