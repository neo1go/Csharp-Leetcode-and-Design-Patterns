using System;


namespace AlternatingGroupsII
{

    class Program
    {
        //Leetcode 3208
        // Es geht darum, in einem kreisförmigen Ring mit Länge k herauszufinden, ob die Farben wirklich abwechselnd
        // erscheinen.
        // Es wird ein sliding Window mit der Länge k erstellt, das dann alle Einträge des Arrays
        // auf abwechselnde Werte kontrolliert mit 2 Pointern.
        // Das besondere ist, das es sich um eine kreisförmige Datenstruktur handelt, also quasi endlos.
        // Bspl.:
        // [0,1,0,1,0,1]  k = 3;
        //  -----
        //    -----
        //      -----
        //  -       ---   hier ist die Besonderheit wegen Kreisform. Die Enden grenzen ja aneinander.
        //  ---       -
        //
        // Es wird in der Lösung quasi der OutOfBounds-Bereich an das existierende Array angehangen um den Kreis zu simulieren.
        // Mit dem Index nums[i%n] wird der Beich außerhalb des Arrays definiert, eigentlich der Anfang des
        // Arrays, der ans Ende angehangen wird.
        // Hier haben wir auch einen schleppenden linken Pointer während der rechte Pointer normal iteriert.
        // Bei falschem Wert wird l auf r gesetzt, und die Logik für die Result-Erhöhung wird umgangen.
        public static int AlternatingGroups(int[] colors, int k)
        {
            int result = 0;
            int length = colors.Length;
            int l = colors[0];

            for (int r = 1; r < length + (k - 1); r++) // Dies ist die Länge plus Fenstergröße 
                                                       // minus 1 für den rechten Pointer.
                                                       // Wenn wir das gesamte Fenster anhängen würden, würden wir zirkular nochmal den
                                                       // Anfang abschreiten.Deswegen wird nur k-1 angehangen.
            {

                if (colors[r % length] == colors[(r - 1) % length])// bei gleichem Wert wird linker Pointer nachgezogen
                {//also nur bei gleichem Wert, was wir ja eigentlich nicht wollen. 
                    l = r;// So wird die Verkürzung der Fensterlänge quasi wie ein bool behandelt.WICHTIG!!! 
                }
                if (r - l + 1 > k)  //falls Fenster zu groß wird, linken Pointer nachziehen.
                {
                    l++;
                }
                if (r - l + 1 == k) //nur wenn Fenstergröße exakt stimmt, sind auch die Werte abwechselnd.
                {               //ansonsten wird das Fenster verkleinert und result wird nicht erhöht.
                    result++;   //Die Verkleinerung des Fensters agiert hier als Melder wie ein bool. 
                }
            }
            return result;
        }

        public static void Main(string[] args)
        {
            // 0,1,0 -> 1,0,1 -> 0,1,0 also 3. die folgenden sind nicht abwechselnd ->> 1,0,0 ->>0,0,1  
            int[] colors = [0, 1, 0, 1, 0];
            int k = 3; //Fenstergröße

            Console.WriteLine($" Anzahl der wechselnden Gruppen: {AlternatingGroups(colors, k)}");
        }
    }
}
