// Aufgabe ist herauszufinden, mit wievielen Booten man im Idealfall übersetzen kann bei einem Maximalgewicht
// und höchstens maximal 2 Personen pro Boot.
// Greedy Aproach  mit linkem und rechtem Pointer.
// Die Antwort beinhaltet nur die Anzahl der Boote.

namespace BoatsToSavePeople
{
    public class Program
    {
        // Achtung - Limit darf nie kleiner sein als größte Zahl im Array, also eine Person kann immer befördert werden
        // und darf das Max-Gewicht nicht überschreiten.
        public static int NumberToRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);        //muss sortiert werden, damit man mit den Pointern arbeiten kann
            foreach (int person in people)
            {
                Console.Write(person + " ");
            }
            Console.WriteLine();




            int boats = 0;
            int left = 0;                   //linker Pointer
            int right = people.Length - 1;  //rechter Pointer



            while (left <= right)
            {
                int weight ;

                if (left == right)  // Dieser Teil ist von mir und dient der korrekten Berechnung des Gewichtes für
                                    // die console.log Anzeige und ist verbunden mit der Hauptlogik im else if damit nicht
                                    //mehrere Werte addiert werden wenn der Pointer an der selben Stelle steht.
                {

                    weight = people[left];
                    left++; //damit wird aus der while Schleife ausgebrochen sonst wird es infinite

                }
                else if (people[left] + people[right] <= limit)//wenn beide zusammen unter maxWeight bleiben
                {


                    weight = people[left] + people[right];
                    left++;     //wenn also links und rechts unter dem Limit liegen, erfüllen sie die Bedingung
                    right--;


                }

                else          //andernfalls past nur die eine people[right] person ins Boot
                {
                    weight = people[right];
                    right--;  //ansonsten wird nur der rechte Pointer bewegt, da dies das größte Gewicht ist


                }




                boats++; //es wird dann immer ein Boot hinzugefügt solange die Pointer sich noch nicht getroffen haben.


                Console.WriteLine($"Gewicht von Boot {boats} ist {weight} kg");


            }
            return boats;
        }

        public static void Main()
        {
            int[] people = [ 60, 57, 51, 89, 92 ];   //Einträge müssen jeweils unter Limit bleiben.
            //int[] people = [ 119, 119, 119, 12, 14, 119 ];
            int limit = 120;

            int solution = NumberToRescueBoats(people, limit);

            Console.WriteLine($"Es werden {solution} Boote benötigt bei einem Gewichtslimit von {limit} kg pro Boot.");
        }

    }
}