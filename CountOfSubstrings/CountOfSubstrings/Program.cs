using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

// Leetcode 3306 CountOfSubstrings
// Es werden alle Substrings gezählt, die
// 1, alle Selbstlaute enthalten {(a,e,i,u,o)(auch mehrfach)(in einem HashSet vorhanden)} und
// 2. die Anzahl an Umlauten k oder mehr enthalten (WICHTIG).
// Es wird mit sliding Window gerabeitet.
// Es wird ein Dict erstellt, nur für die Anzahl der Selbstlaute (key,value -> char, int).
// Das HashSet stellt nur die Selbstlaute bereit.(Es wird ein HashSet genutzt, um Contains in O(1),also KONSTANT, auszuführen.
// Es geht hier nur um effizientes Nachschlagen, die Einzigartigkeit der Einträge wird hier nicht genutzt.
// Eine List<char> würde O(n) benötigen, wäre also LINEAR.)
class Program
{
    public static int CountOfSubstrings(string word, int k)
    {
        static int AtLeastK(int k, string word)
        {
            int result = 0;
            int umlautC = 0;
            int left = 0;
            int n = word.Length; //Länge des gesamten Strings

            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            Dictionary<char, int> count = new Dictionary<char, int>();

            for (int right = 0; right < n; right++) // Iterieren durch den gesamten String
            {

                if (vowels.Contains(word[right])) //Nur wenn Selbstlaut gefunden wurde, wird der Zähler erhöht und ein Eintrag im dict erstellt.WICHTIG
                {

                    if (count.ContainsKey(word[right]))//Falls schon im dict, wird der Zähler im dict erhöht.
                    {
                        count[word[right]]++;
                    }
                    else
                    {
                        count[word[right]] = 1; //Ansonsten den neuen Eintrag auf 1 intialisieren.
                    }

                }
                else  //also nicht im HashSet vorhanden, somit ein Umlaut
                {
                    umlautC++;
                }


        //Dies wird nur aktiviert,wenn alle Selbstlaute mindestens 1 haben als value und somit der count 5 ist(Anzahl der keys im dict) und
        //die Anzahl der Umlaute gleich oder größer als k ist.
                while (count.Count == 5 && umlautC >= k)//WICHTIG. Sollten nicht genug Umlaute vorhanden sein, wird dies gar nicht ausgelöst.
                {
                    result += word.Length - right; //Gesamtlänge des strings inklusive aller Selbstlaute(5)

                    if (vowels.Contains(word[left])) //falls Selbstlaut vorhanden an Pointer-Stelle word[left]
                    {
                        count[word[left]]--; //Zähler des Selbstlautes im dict an der Stelle des linken Pointers reduzieren.

                        if (count[word[left]] == 0)// Wenn die Selbstlaut-Value auf 0 ist im dict, z.B. e = 0 
                        {
                            count.Remove(word[left]); //Der Selbstlaut wird herausgenommen bis er wieder gefunden wird. Somit ist Count.count < 5
                        }
                    }
                    else //wenn es kein Selbstlaut ist, bleibt nur der Umlaut übrig an der Stelle
                    {
                        umlautC--; 
                    }
                    left += 1;  // somit wird der linke Pointer nur dann nachgezogen, wenn die while erfolgreich ausgeführt wird. 
                }
            }
            return result;//Anzahl aller korrekten Längen(substrings). Diese werden von allen Längen mit k+1 abgezogen am Ende.
        }



     return AtLeastK(k, word) - AtLeastK(k + 1, word);

        // Es werden ja in der Methode auch Substrings mit mehreren Umlauten,als gewollt,
        // zurückgegeben und dann nochmal mit k+1,also 1 größer als k. Dies wird dann subtrahiert.                                     
    }      // AtLeastK(k) zählt alle substrings , auch mit k+1,k+2,k+3 usw.
           // AtLeastK(k+1)zählt alle substrings mit k+1 Substrings aber ohne die ersten k.
           // Wird nun beides subtrahiert, erhalten wir die exakte Anzahl an Substrings mit genau k.

    // Jetzt habe ich es verstanden: als Bspl.: beim ersten Aufruf werden alle Substrings erkannt,
    // als Beispiel mal angenommen 10 Substrings bei k=2, die alle Selbstlaute und 
    // mindestens k=2 oder mehr als k Umlaute beinhalten, also 2,3,4,5,6, also 5 Substrings.
    // Wenn mit k+1 geprüft wird, werden ja nur die größere Zahl untersucht von k. Somit entstehen z.B. nur  die Substrings 3,4,5, also 3 Substrings.
    // In diesem Beispiel wird also der string word auf k=3 geprüft und es werden alle größeren 
    // Ergebnisse für k angezeigt, z.B. 3 Substrings mit dem k=3 oder höher.
    // Somit ist die genaue Anzahl an Substrings 5-3 und somit 2 Substrings, die genau k enthalten.
    // Der Startpunkt von k und k+1 grenzt somit dann die validen Ergebnisse ein.


    public static void Main(string[] args)
    {
        string word = "aoisulea";
        int k = 2; // genau gesuchte Anzahl an Umlauten
        int count = CountOfSubstrings(word, k);
        Console.WriteLine($"Anzahl der gültigen Substrings: {count} ");

    }
}
