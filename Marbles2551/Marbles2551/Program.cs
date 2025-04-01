// Leetcode 2551  Put Marbles in Bags
// es gibt k Anzahl an Säcken(Tüten Behälter etc.)
// es gibt weiterhin einen 0-indizierten Array mit Zahlen,
// die die Gewichte der einzelnen Kugeln(Steinkugeln) repräsentieren.
// Die Kugeln sollen nach folgenden Regeln auf die Säcke verteilt werden:
//
// Kein leerer Sack
// wenn die (i)te Kugel und die (j)te Kugel in dem Sack sind, müssen alle Kugeln die 
// mit ihrem Index dazwischen liegen, in dem gleichen Sack sein.
// wenn ein Sack alle Kugeln von i bis j enthält, dann sind die Kosten
// des Sacks = weights[i] + weights[j].
// Die Punktzahl nach dem Verteilen aller Kugeln ist die Summe der Kosten von allen Säcken.
// Gib die Differenz zwischen der Maximum- und der Minimum-Punktzahl zurück.
// Bspl.:
// 1,3,5,1  und k=2, also 2 Säcke
// beide müssen befüllt sein, 

public class Solution
{
    Dictionary<string, int> minMemo = new Dictionary<string, int>();
    Dictionary<string, int> maxMemo = new Dictionary<string, int>();


    //Min-Wert errechnen
    public int CalculateMin(int[] array, int start, int k)
    {
        string key = $"{start}-{k}";
        if (minMemo.TryGetValue(key, out int cachedValue))
        {
            return cachedValue;
        }

        if (k == 1)
        {
            int cost = array[start] + array[array.Length - 1];
            minMemo[key] = cost;
            return cost;
        }

        int minValue = int.MaxValue;

        for (int i = start; i <= array.Length - k; i++)
        {
            int currentCost = array[start] + array[i];
            int nextCost = CalculateMin(array, i + 1, k - 1);
            int total = currentCost + nextCost;

            if (total < minValue)
            {
                minValue = total;  //Setzen des minimalen Wertes
            }
        }

        minMemo[key] = minValue;
        return minValue;
    }

    //Das gleiche für den Maxwert
    public int CalculateMax(int[] array, int start, int k)
    {
        string key = $"{start}-{k}";
        if (maxMemo.TryGetValue(key, out int cachedValue))
        {
            return cachedValue;
        }

        if (k == 1)
        {
            int cost = array[start] + array[array.Length - 1];
            maxMemo[key] = cost;
            return cost;
        }

        int maxValue = int.MinValue;

        for (int i = start; i <= array.Length - k; i++)
        {
            int currentCost = array[start] + array[i];
            int nextCost = CalculateMax(array, i + 1, k - 1);
            int total = currentCost + nextCost;

            if (total > maxValue)
            {
                maxValue = total;//Setzen des maximalen Wertes
            }
        }

        maxMemo[key] = maxValue;
        return maxValue;
    }

    public int GetMinMaxDifference(int[] array, int k)
    {
        minMemo.Clear();//Da die Methode GetMinMaxDifference immer wieder aufgerufen wird,
        maxMemo.Clear();//sollten beide Dicts immer geleert werden um Überschreibungen zu vermeiden.

        int min = CalculateMin(array, 0, k);
        int max = CalculateMax(array, 0, k);
        return max - min;
    }


    public static void Main(string[] args)
    {
        int[] weights = [1, 3, 5, 1]; // 10-6= 4  ->  1+1+3+1=6 als MIN       und 1+3+5+1=10 als MAX
        int k = 2;  //Anzahl der Säcke.  Trennung des Array int k-1 
        Solution solution = new Solution();

        int result = solution.GetMinMaxDifference(weights, k);

        Console.WriteLine(result);
    }
}