using System;
using System.Collections.Generic;
namespace WordBreak
{
    public class Program
    {
        public static bool WordBreak(string s, List<string> wordDict)
        {
            // Ein HashSet für schnelle Suche im Wörterbuch.
            var wordSet = new HashSet<string>(wordDict);
            int maxLength = 0;
            foreach(var word in wordDict)
            {
                if(word.Length > maxLength)
                {
                    maxLength = word.Length;
                }
            }



            // Ein Array zur Speicherung von Bool-Zwischenergebnissen.
            bool[] dp = new bool[s.Length + 1];

            // Ein leerer String kann immer in Wörter zerlegt werden.(base case)
            dp[0] = true;


            for (int i = 1; i <= s.Length; i++) //jeder Buchstabe erhält einen Bool
            {
                //Begrenze die innere Schleife auf die letzten maxLength Positionen
                int start = Math.Max(i - maxLength, 0);


                for (int j = start; j < i; j++)
                {
                    // Überprüfe, ob der Teilstring s[j..i] im Wörterbuch enthalten ist
                    // und ob der vorherige Teilstring s[0..j] bereits zerlegt werden kann.
                    if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break; // Keine weiteren Überprüfungen für dieses i notwendig.
                    }
                }
            }

            // Der letzte bool in dem boolArray entscheidet, ob es einen validen Pfad gibt, bei dem
            // alle Wörter gebildet werden können mit den chars aus s.
            return dp[s.Length];
        }

        public static void Main()
        {
            List<string> wordDict = new() { "apple", "pen" };

            //Erklärung
            string s = "applepenapple";
            //          tffftfftfffft   <-    der Pfad ergibt am Ende true. Vom letzten Wort ausgehend muss man rückwärts gucken
            //          /\  /\ /\  /\          dies ergibt beim letzten DP Array Eintrag hier ein true.

            // False-Beispiel
            //string s ="catsandog"  und das Array=["cats","dog","sand","and","cat"]
            //           tfttfftff
            //
            //dp[0]=true c = true
            //           ca = false
            //           cat = true
            //           cats = true
            //           atsa = false   (maxLength schneidet ab)
            //           tsan = false
            //           sand = true
            //           ando = false
            //          (n)dog = false (obwohl eigentlich true, wird auch der bool vor dem Wort an Pos.5 geprüft um den Pfad zu bestätigen.)
            //
            //Beim Vergleichen muss der boolean vor dem Wort das zu prüfen ist, true ergeben, da sonst der gesamte Pfad nicht true ist.
            //
            // Bei "applepenapple" rückwärts ist das n von pen true und das e vom ersten apple ist auch true und somit passen alle Wörter
            // und es wird am Ende true zurückgegeben.
            //Bei "catsandog" passen cat,cats und spätestens bei and und dog wird es ein Problem geben. Wenn man annimmt ,dass 
            bool result = WordBreak(s, wordDict);
            Console.WriteLine($"Kann der String zerlegt werden? {result}");
        }
    }
}



