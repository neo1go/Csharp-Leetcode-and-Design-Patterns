namespace MergeMaximumArrays
{
    public class Program
    {
        public static HashSet<int> MergeMaximumArrays(int[] value1, int[] value2)
        {
            HashSet<int> result = new HashSet<int>();

            int minValue = int.MaxValue;  //Maximalwert,denn ein integer haben kann

            //Herausfinden des Minimalwert in Array 1
            for (int i = 0; i < value1.Length; i++)
            {
                minValue = Math.Min(minValue, value1[i]);
                result.Add(value1[i]);
            }

            //Wenn größer als Minimalwert, dann zu Resultat hinzufügen
            for (int i = 0; i < value2.Length; i++)
            {
                if (value2[i] > minValue)
                {
                    result.Add(value2[i]);
                }
            }
            return result;
        }

        public static List<int> sortingHash(HashSet<int> workHashSet)
        {
            List<int> listToSort = new List<int>();

            foreach (int i in workHashSet)
            {
                listToSort.Add(i);
            }
            listToSort.Sort();

            return listToSort;
        }


        public static void Main(string[] args)
        {
            int[] mainArr = { 25, 15, 11, 9, 12 };
            int[] addedArr = { 1, 4, 5, 3, 15, 11, 17, 18,5 };


            //Duplikate werden durch Nutzung des HashSet unterbunden
            HashSet<int> mergedResult = MergeMaximumArrays(mainArr, addedArr);


            List<int> final = sortingHash(mergedResult);

            foreach (int i in final)
            {
                Console.WriteLine(i);
            }
        }

    }

}
