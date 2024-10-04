public static class Program
{
    //Aufgabe: Es sollen nur Werte zusammenaddiert werden, die im Array einzigartig sind

    public static int sumOfUniqueElements(int[] nums)
    {
        int[] freq = new int[101];  //maximale Länge des Arrays in das übertragen wird
        int sum = 0;

        foreach (int num in nums)
        {
            freq[num]++; //hier wird fütr jeden Eintrag eine 1 gesetzt und bei Dopplungen erhöht sich der Wert 
                         //bezogen auf den Index
            Console.WriteLine("Array Eintrag "+num+" und die Häufigkeit im neuen Array " + freq[num]);
        }
        for (int i = 0; i < freq.Length; i++)
        {
            if (freq[i] == 1)  //nur wenn an [i]ter Stelle eine 1 steht, wird summiert
                               //doppelte Zahlen haben also einen höheren Wert als 1 und werden nicht addiert
            {
                sum += i;
            }
        }
        return sum;
    }





    public static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5, 4, 1, 4, 4, 7 };//2+3+5+7=17


        int solution = sumOfUniqueElements(nums);
        Console.WriteLine("Die Summe ist " + solution);
    }
}
