//Leetcode 2206
// Teilen eines Arrays mit 2*n Paaren in gleiche Paare.
// Also soll ein bool zurückgegeben werden, ob alle Einträge paarweise erscheinen.
public class Program
{

    public bool DivideArray(int[] nums)
    {
        bool result = true;
        Dictionary<int, int> dict = new Dictionary<int, int>();


        //Basecase
        if (nums.Length % 2 != 0)
        {
            result = false;
        }


        foreach (int num in nums)
        {
            if (dict.ContainsKey(num))    // dies muß man bei Dictionaries machen,
                                          // um den Wert bei Finden des passenden Schlüssels, in diesem Fall die Nummer, zu erhöhen.
            {
                dict[num]++;

            }
            else
            {
                dict.Add(num, 1);   //Hier wird der Wert mit 1 initialisiert falls noch kein Wert bei dem Key num  
            }
        }

        foreach (int val in dict.Values)  //man kann die Keys mit dict.Keys oder Values mit dict.Values auslesen auf diese Art.
        {
            if (val % 2 != 0)
            {
                result = false;
            }
        }


        return result;
    }


    // Andere Variante, die immer bei Auftauchen eines zweiten gleichen Wertes den bestehenden Wert aus dem HashSet löscht und
    // so bei paarweiser Anordnung am Ende ein leeres Hashset zurückgibt. Ansonsten ist die Länge >0 , da nicht alle Werte Paare waren.

    public bool DivideArrayII(int[] nums)
    {
        HashSet<int> oddSet = new HashSet<int>(); //speichereffizienter als ein Dictionary(Hashmap)

        foreach (int num in nums)
        {
            if (!oddSet.Contains(num))// einen Wert eintragen
            {
                oddSet.Add(num);
            }
            else
            {
                oddSet.Remove(num);    // dies bedeutet, es ist ein Paar und somit wird der Eintrag aus dem Set gelöscht.
            }
        }
        return oddSet.Count == 0;
    }

    public static void Main(string[] args)
    {
        Program program = new Program();
        int[] nums = [1, 2, 3, 4];
        //int[] nums =[2,2,2,2];
        //int[] nums =[3,2,3,2,2,2];
        bool result = program.DivideArray(nums);
        bool result2 = program.DivideArrayII(nums);

        Console.WriteLine($"Der Array besteht aus gleichen Paaren: {result2}");

    }
}
