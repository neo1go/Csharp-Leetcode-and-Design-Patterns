// Aufgabe ist herauszufinden, mit wievielen Booten man im Idealfall übersetzen kann bei einem Maximalgewicht
// und höchstens 2 Personen pro Boot
// Greedy Aproach  mit linkem und rechtem Pointer
public class Program
{
    //Achtung - Limit darf nie kleiner sein als größte Zahl im Array, also eine Person kann immer befördert werden
    public static int numRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);        //muss sortiert werden, damit man mit den Pointern arbeiten kann
        foreach (int person in people)
        {
            Console.Write(person + " ");
        }
        Console.WriteLine();


        int boats = 0;
        int left = 0;//linker Pointer
        int right = people.Length - 1;  //rechter Pointer

        while (left <= right)
        {
            if (people[left] + people[right] <= limit)//wenn beide zusammen unter maxWeight bleiben
            {
                
               
                left++;     //wenn also links und rechts unter dem Limit liegen, erfüllen sie die Bedingung
                right--;
                
            }
            else            //andernfalls past nur die eine people[right] person ins Boot
            {
               
                right--;  //ansonsten wird nur der rechte Pointer bewegt, da dies das größte Gewicht ist
               
            }
            boats++; //es wird dann immer ein Boot hinzugefügt solange die Pointer sich noch nicht getroffen haben
        }
        return boats;
    }
    
    public static void Main(string[] args)
    {
        int[] people = { 60, 57, 51, 89, 92 };   //Einträge müssen jeweils unter Limit bleiben
        int limit = 120;

        int solution = numRescueBoats(people, limit);

        Console.WriteLine($"Es werden {solution} Boote benötigt bei einem Gewichtslimit von {limit} kg pro Boot");
    }

}
