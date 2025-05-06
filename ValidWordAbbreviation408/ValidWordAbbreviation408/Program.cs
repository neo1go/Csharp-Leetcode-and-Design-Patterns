using System;

// Leetcode 408
// Es geht bei dieser Aufgabe darum, ein Wort mit einer Abbrivation 
// (Abkürzung mit Zahlen als Platzhaltern) zu vergleichen und bei korrekter Abbrivation ein true 
// zurückzugeben.
// Führende Nullen sind nicht zulässig.
// Bspl.:  "Hallo" -> "Ha2o" == true. Die 2 ersetzt die beiden l's im String.
// 
// Die Besonderheit ist hier das Auslesen des Int-Wertes aus dem string in dem while-Loop.
// Es geht hier um die ASCII-Vergleiche. '0' ist immer der Basiswert 48, der dann subtrahiert wird,
// um den tatsächlichen Wert zu erhalten.
// Achtung !!!! Mittels der Subtraktion des ASCII-Wertes des strings mit dem ASCII Wert von '0' wird 
// dann automatisch ein int erzeugt.
// Bspl.: string '12'     '1'-'0' -> 49-48 = 1              also ASCII Wert minus ASCII Wert ergibt integer
//                        '2'-'0' -> 50-48 = 2
//
// Umwandlung in eine zusammenhängende Dezimalzahl:    (wobei subLength am Anfang immer 0 sein muß.)
// für das erste Zeichen      subLength = 0 * 10 + 1  = 1     (dieser Wert wird durch *10 dann zur führenden Zahl.)
// für das zweite Zeichen     subLength = 1 * 10 + 2  = 12  und somit umgewandelt in eine komplette Dezimalzahl.

public class Program
{
    public static bool Abbreviation(string word, string abbr)
    {
        int wordIndex = 0;
        int abbrIndex = 0;

        while (abbrIndex < abbr.Length && wordIndex < word.Length)
        {
            if (char.IsDigit(abbr[abbrIndex])) //wenn es eine Zahl ist
            {
                if (abbr[abbrIndex] == '0')
                {
                    return false;//bei führender Null sofort abbrechen. Nicht gestattet.
                }
                int subLength = 0; //hier muß immer wieder für jede neue Zahl auf null gesetzt werden.

                while (abbrIndex < abbr.Length && char.IsDigit(abbr[abbrIndex]))//solange es eine Nummer ist 
                                                                                //und noch nicht das Ende des Strings erreicht wurde.
                                                                                //Es wird also die gesamte Zahl eingelesen durch das while.
                {
                    subLength = subLength * 10 + (abbr[abbrIndex] - '0');//Dadurch wird ein char in int umgewandelt.
                    abbrIndex++;
                }
                wordIndex += subLength;//hier wird die Nummer zu dem anderen Pointer hinzuaddiert,also die Zahl aus der abbr wird addiert,damit
                                       //richtig in word weiteriteriert wird mit dem Pointer.WICHTIG. 
            }
            else
            {
                //Buchstaben müssen exakt übereinstimmen und Länge muss stimmen.
                if (wordIndex >= word.Length || word[wordIndex] != abbr[abbrIndex])
                {
                    return false;
                }
                wordIndex++;
                abbrIndex++;
            }
        }
        //Beide Strings müssen vollständig abgearbeitet sein.
        return wordIndex == word.Length && abbrIndex == abbr.Length;
    }

    public static void Main(string[] args)
    {
        string word = "internationalization";
        string abbr = "i12iz4n";

        Console.WriteLine(Abbreviation(word, abbr));
    }

}


