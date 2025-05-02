


// Leetcode 1762 Buildings with an Ocean View
//
// Es sollen nur die Indexe der Hotels im Array angezeigt werden, die Blick aufs Meer auf der rechten Seite haben.
// Bspl.:
// [4,2,3,1] -> 4 kann alles sehen und 3 sowie 1 können alles sehen und werden nicht blockiert in ihrem Blick.
// Das Ergebnis lautet also [0,2,3].
//
// Die 2te Variante ist performanter, da sie nur eine Schleife nutzt und rückwärts iteriert.
// Anschließend kann man mit stack oder der Reverse()-Funktion das Ergebnis rumdrehen.
public class Program
{
    /*
    public static int[] OceanIsVisible(int[] hotels)
    {
        List<int> result = new List<int>();//habe ich gewählt, um leicht zu erweitern
      
        
        for (int i = 0; i<hotels.Length;i++)
        {
            bool hasView=true;
            
            for(int j = i+1;j<hotels.Length;j++)
            {
                
                if(hotels[j]>=hotels[i])
                {
                   hasView=false;
                    break;
                }
            }
             if(hasView)
        {
            result.Add(i);
        }
            
        }
           
        return result.ToArray();
    }
    
   */
    public static int[] OceanSuperPerformant(int[] hotels)
    {
        List<int> result = new List<int>();
        int maxHeight = 0;
        Stack<int> current = new Stack<int>();

        for (int i = hotels.Length - 1; i >= 0; i--)
        {
            if (hotels[i] > maxHeight)
            {
                current.Push(i);
                maxHeight = hotels[i];
            }
        }

        while (current.Count > 0)
        {
            result.Add(current.Pop());
        }

        return result.ToArray();
    }

    public static void Main(string[] args)
    {
        //int [] hotels =[4,2,3,1];
        int[] hotels = [3, 5, 4, 4, 3, 2, 1];

        //int[] result = OceanIsVisible(hotels);

        int[] result = OceanSuperPerformant(hotels);
        foreach (var r in result)
        {
            Console.WriteLine(r);
        }
    }

}


