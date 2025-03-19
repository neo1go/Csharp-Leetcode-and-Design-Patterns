using System;
using System.Collections.Generic;
using System.Linq;

//Leetcode 2401
// Es wird der längste Eintrag in einem Array von Zahlen gesucht die keine Bitüberlappung haben.
// Es wird mit linkem und rechtem Pointer gearbeitet.
// Alle Werte werden bitweise mit AND auf Überlappung geprüft und wenn keine Überlappung besteht, "zusammengesetzt" mit | (OR).
// Das bedeutet 0101 und 0011 ergeben wegen dem OR den Wert 0111 sprich 5 oder 3 ergeben dann 7. Es wird jedes bit gesetzt,das vorhanden war.
// Durch die voeherige AND Überprüfung können alle leeren Bits solange belegt werden, bis die nächste Überlappung eintritt.
// Sobald bei dem bitwisen AND eine 1 erscheint,darf nicht mehr zusammengesetzt werden. Es muß der linke Pointer nachgezogen werden und 
// der Wert aus dem kumulativen Wert herausgenommen werden. Dies geschieht mit XOR.
// Das XOR nimmt durch das Flippen  der bits, die nicht gleich sind, den linken Wert aus dem kumulierten Wert heraus.
// Bspl.:  1111 war der kumulierte Bitwert und der neue Wert ist 0101 . Jetzt werden mit XOR alle bits "gedreht",die "EXKLUSIV" sind.
//                Also
// 1.ter Wert     1111   linker Pointer
// 2.ter Wert     0101   rechter Pointer
//                ----
// neuer Wert     1010  . Die 1111 an der linken Stelle wurde herausgenommen. 1 XOR 0 ergibt 1, 0 XOR 1 ergibt 1, alles andere eine 0.
// 
public class Program
{

    public int LongestNiceSubarray(int[] nums)
    {
        int left = 0;
        int result = 1;
        int cumulative = nums[0];
        for (int right = 0; right < nums.Length; right++)
        {
            while ((cumulative & nums[right]) != 0 && left < right)// 1&0=0 0&1=0 1&1=1 DADURCH ERKENNT MAN SOFORT EINE ÜBERSCHNEIDUNG
            { // Bei einer Überschneidung wird der linke Pointer nach der XOR-Ausführung mit bewegt (nicht vorher)   
              // und der Wert wird aus dem kumulativen Bitwert entfernt,
              // durch das Flippen des bits quasi: 1111 und neuer Wert 0101 ergibt z.B. 1010. 
              // Das XOR arbeitet wie eine Entfernung des neuen Bitwertes auf die anderen bits!!!
                cumulative ^= nums[left];  //XOR  
                left++;


            }
            cumulative |= nums[right];// es werden die bits "zusammengesetzt". Jedes existierende bit wird hinzugefügt.
                                      // Durch die Filterung mittels der oberen While-Logik werden nur Bitwerte zusammengefügt, die keine
                                      // gleichen Bitzustände besitzen.
                                      // 0101 | 1000 = 1101  
                                      // Die Schreibweise entspricht x = x | y 
            result = Math.Max(result, right - left + 1);
        }
        return result;
    }

    public static void Main(string[] args)
    {
        Program program = new Program();
        int[] nums = [1, 3, 8, 48, 10]; //Länge 3 mit 3,8,48
                                        //
        //32 16 8 4 2 1
        //  000001 x        
        //  000011 x  1         AND ergibt 000001  OR ergibt 000011 und Überschneidung,dann left nachziehen und XOR ergibt 000010  
        //  001000 x  1         AND ergibt 000000  OR ergibt 001011 keine Überschneidung also Wert = 2
        //  110000    1         AND ergibt 000000  OR ergibt 111000 keine Überschneidung also Wert = 3
        //  001010 x            AND ergibt 001010  OR ergibt 111011 und Überschneidung, dann left nachziehen un XOR ergibt 111010 

      
        Console.WriteLine($"Die längste gute Kette im Array ist {program.LongestNiceSubarray(nums)} Indexe lang");
    }
}
