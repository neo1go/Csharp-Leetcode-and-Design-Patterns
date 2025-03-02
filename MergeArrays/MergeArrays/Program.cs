namespace MergeArrays
{
    //Leetcode 2570
    // Merge two 2D Arrays
    // Es sollen 2 Arrays der Größe nach zusammengeführt werden. Wenn der erste Indexwert beider Arrays gleich ist, wird der addierte Wert
    // als value an zweiter Stelle eingetragen.
    // Bspl.:
    //       arr1=(1,2)(3,4)
    //       arr2=(1,3)(5,6)
    // Ergebnis = (1,5)(3,4)(5,6)
   
    public class Program
    {
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            List<int[]> result = new List<int[]>(); // sollte leicht erweiterbar sein im Gegensatz zu Array
            int i = 0; //Muss man wegen der Nichtinitialisierung in der while Schleife hier machen
            int j = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i][0] < nums2[j][0])   //Bspl.: 1,2 ist kleiner als 2,2. Also addieren von 1,2
                {
                    result.Add(new int[] { nums1[i][0], nums1[i][1] });
                    i++;
                }
                else if (nums1[i][0] > nums2[j][0])
                {
                    result.Add(new int[] { nums2[j][0], nums2[j][1] });
                    j++;
                }
                else
                {
                    result.Add(new int[] { nums1[i][0], nums1[i][1] + nums2[j][1] });  // hier findet die Addition bei gleicher "ID" statt.
                   //war für mich am Anfang verwirrend,linke Seite an Stelle 0 und nach dem Komma der addierte Wert für Stelle 1.
                    i++;
                    j++;
                }
            }
            //Diese while-Schleifen decken den Fall ab, das ein Array länger als das andere ist.
            while (i < nums1.Length)
            {
                result.Add(nums1[i]);
                i++;  //i wird weiter vergrößert falls noch Werte vorhanden sind. 
            }
            while (j < nums2.Length)
            {
                result.Add(nums2[j]);
                j++;  //j wird weiter vergrößert falls noch Werte vorhanden sind.
            }

            return result.ToArray();
        }

        public static void Main()
        {
            int[][] nums1 = [
                new int[] {1,2},
                new int[] {3,3},
                new int[] {4,5}
            ];

            int[][] nums2 = [
               new int[] {1,4},
               new int[] {2,3},
               new int[] {4,1}
           ];

            Program program = new Program();

            int[][] result = program.MergeArrays(nums1, nums2);


            var output = result.Select(inner => string.Join(" ", inner)).ToList();

            output.ForEach(z => Console.WriteLine(z));
            
            //foreach (int[] innerArray in result)
            //{
               
            //    foreach (int value in innerArray)
            //    {
            //        Console.Write(value + " ");
            //    }
            //    Console.WriteLine("");
            //}
            
        }
    }



}
