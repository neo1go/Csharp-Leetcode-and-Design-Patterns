public class Program
{
    //beim threeSum Problem wird der erste Wert des Arrays ausgelagert und dann
    //bei den restlichen Zahlen der 2 Pointer Approach genutzt

    //Die HashSet<List<int>> nimmt nur einzigartige Listen auf, basierend auf den Integer-Werten
    public static HashSet<List<int>> ThreeSum(int[] arr)
    {
        if (arr.Length == 0 || arr.Length < 3)//falls Array zu kurz oder null ist
        {
            return new HashSet<List<int>>();
        }

        //muß sortiert werden für 2Pointer Approach
        Array.Sort(arr);
        Console.Write("Sortierter Array ");
       
        foreach (int i in arr) //von mir fürs Anzeigen des sortierten Arrays
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();


        HashSet<List<int>> result = new HashSet<List<int>>();

        for (int i = 0; i < arr.Length - 2; i++) //arraylength -2 wegen der Länge von 3 Zahlen als Summe
        {
            int left = i + 1; //Pointer an 2.ter Stelle 
            int right = arr.Length - 1;  //letzte Stelle 

            while (left < right)
            {
                int sum = arr[i] + arr[left] + arr[right]; //arr[i] ist immer der ausgelagerte Wert
                                                           //left und right werden mittels Pointer iteriert
                if (sum == 0)
                {
                    //es wird eine neue Liste erstellt die dann in das HashSet intergriert wird und 
                    //nur einzigartige Listen zulässt
                    List<int> triplet = new List<int> { arr[i], arr[left], arr[right] };
                    result.Add(triplet);  //gesamte Liste wird geaddet und bei Duplikat verworfen

                    left++;//Pointer laufen aufeinander zu
                    right--;
                }
                else if (sum < 0)//da das Array sortiert ist, ist bei einem Wert unter null
                                 //zuerst der linke Pointer zu bewegen, um aus dem minus zu kommen
                {
                    left++;
                }
                else
                {
                    right--;//wenn der Wert größer als die Summe ist,
                            //kann nur der größte Wert dafür verantwortlich sein der zu groß ist um auf 0 zu kommen
                }
            }

        }
        return result;
    }


    public static void Main(string[] args)
    {
        int[] arr = [1, 2, 3, 0, -1, 10, -10, 4, -5, 7, 6, 14, -3, -4];


        HashSet<List<int>> triplets = ThreeSum(arr);

        Console.WriteLine("Einzigartige Triplets mit der Summe 0:");
        

        //erste foreach für die gesamte HashSetListe
        foreach (var triplet in triplets)
        {
            Console.Write("[");

            foreach (var num in triplet)//diese foreach zeigt die einzelnen Werte aus dem einzigartigen Eintrag an
            {
                Console.Write(num + ",");
            }

            Console.WriteLine("]");
        }
    }
}
