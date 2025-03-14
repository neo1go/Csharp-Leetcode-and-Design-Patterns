//Leetcode 1358
//Es sollen alle Substrings gezählt werden, die zumindestens alle 3 Buchstaben a,b und c beinhalten.

namespace NumberOfSubstrings1358{
public class Program
{

    public int NumberOfSubstrings(string s)
    {
        int n = s.Length;
        int[] count = new int[3]; // Für 'a', 'b', 'c'  -> [0,1,2]
        int result = 0;
        int left = 0;
        // Wert a ist   'a'-'a' = 0  ,also Index 0
        // Wert b ist   'b'-'a' = 1  ,also Index 1 
        // Wert c ist   'c'-'a' = 2  ,also Index 2 
        // ACHTUNG dies funktioniert für die Indexerstellung nur, wenn die Buchstaben im ASCII-Satz direkt
        // nebeneinander stehen und nur jeweils 1 Wert Unterschied besteht. 

        for (int right = 0; right < n; right++)
        {
            // Zähler für das aktuelle Zeichen erhöhen
            count[s[right] - 'a']++;    //Index relativ zu a . Es wird jedes gefundene Zeichen -a gerechnet, um den Index im Array zu finden.

            // Wenn das Fenster alle drei Zeichen enthält, verkleinere das Fenster von links
            while (count[0] > 0 && count[1] > 0 && count[2] > 0)
            {   // WICHTIG
                // Alle Substrings, die mit dem aktuellen Fenster beginnen, sind gültig. 
                // Es wird quasi von dem aktuellen validen Substring alles angehangen und bei jedem char um 1 erhöht.
                result = result + n - right; // hier ist die Besonderheit der Aufgabe: 
                                             // Alle nachfolgenden Buchstaben zum validen Substring erzeugen einen zusätzlichen Substring,
                                             // der hinzu addiert wird.

                // Entferne das linke Zeichen aus dem Fenster
                count[s[left] - 'a']--;    //Index relativ zu a
                left++;
            }
        }
        return result;
    }

    public static void Main()
    {
        Program program = new Program();
        string s = "abcabc";
        int finalResult = program.NumberOfSubstrings(s);
        Console.WriteLine($"Anzhal der Substrings ist {finalResult}");
    }
}
}