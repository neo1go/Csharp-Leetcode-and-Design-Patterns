public class Program
{
    //Leetcode 268 Missing Number

    /*
    //Das ist die komplizierte Variante( sehr ineffizient) 

    public int MissingNumber(int[] nums)
    {
        
        HashSet<int> set = new HashSet<int>(); //hashset ist leer

        for (int i = 0; i < nums.Length+1; i++)//+1, da ein Wert fehlt in nums
        {
            set.Add(i); //alle einzelnen Indexe werden gesetzt
        }

        for (int i = 0; i < nums.Length; i++) 
        {
            if (nums.Contains(i)) 
            {
                set.Remove(i);//Index löschen, falls in nums vorhanden. Somit bleibt ein Wert übrig (in Aufgabe so definiert).
            }
        }
        return set.First();
    }
    */

    // Das ist die schnelle Variante mit der gaußschen Summenformel
    //
    // n*n+1 ergibt immer einen durch 2 teilbaren Wert, da entweder n gerade und somit n+1 ungerade ist(oder n ungerade und n+1 gerade ist).
    // Und wenn ein ungerader und ein gerader Wert multipliziert werden, ist er immer durch 2 teilbar.
    // Das Produkt von 2 aufeinander folgenden Zahlen, geteilt durch 2, ist immer eine ganze Zahl.
    // 
    // Achtung:
    // 3+4=7 -> nicht teilbar 
    // aber
    // 3*4=12, 12/2=6 
    // also bringt die Multiplikation zweier Zahlen immer einen durch 2 teilbaren Wert.
    public int MissingNumber(int[] nums)
    {
        int sum = 0;

        foreach (int n in nums)
        {
            sum += n;
        }

        //Gaußsche Summenformel -> Multiplizierende Zähler sind immer ganzzahlig durch 2 teilbar,
        //weil der Zähler aus 2 Werten besteht, also nums.Length * nums.Length*1 und ist somit immer glatt teilbar. 
        int expectedSum = ((nums.Length) * (nums.Length + 1)) / 2;
        return expectedSum - sum;
    }

    public static void Main(string[] args)
    {
        Program program = new Program();
        int[] nums = { 3, 0, 1 };// 2 fehlt

        Console.WriteLine(program.MissingNumber(nums));
    }
}