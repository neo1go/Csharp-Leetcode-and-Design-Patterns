using System;

namespace AreAlmostEqual
{
    public class Program 
    {
            public static bool AreAlmostEqual(string s1, string s2)
            {
                if (s1.Length != s2.Length)
                {
                    return false;
                }
                int[] diffIndices = new int[2];  //hier wird z.B. index 0 und 3 gespeichert für das untere Beispiel
                int diffCount = 0;

                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i]) //wenn ein Unterschied vorhanden ist,dann...
                    {
                        // Wenn es mehr als zwei Unterschiede gibt, können wir sofort false zurückgeben
                        if (diffCount >= 2) return false;//Bei genau 2 tauschbaren Werten und dem Ende der Schleife wird nie false ausgegeben.
                        diffIndices[diffCount] = i;
                        diffCount++;
                    }
                }
                // Wenn es keine Unterschiede gibt, sind die Zeichenketten bereits gleich.
                if (diffCount == 0) return true;

                // Wenn es exakt einen Unterschied gibt, können sie nicht durch einen Tausch gleich gemacht werden.
                if (diffCount == 1) return false;

                // Überprüfen, ob die 2 Zeichen an den unterschiedlichen Index-Positionen getauscht werden können.
                // 0 und 1 sind die beiden Einträge des Index-Arrays. Es werden also insgesamt 4 Positionen verglichen.
                return s1[diffIndices[0]] == s2[diffIndices[1]] && s1[diffIndices[1]] == s2[diffIndices[0]];
            }

        public static void Main(String[] args)
        {
            string s1 = "bank";
            string s2 = "kanb";

            bool result = AreAlmostEqual(s1, s2);

            Console.WriteLine($"Die beiden Strings können ausgetauscht werden {result}");
        }
    }
}
