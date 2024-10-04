namespace MergeSort
{
    //Divide & Conquer
    public class Program
    {
        public static int[] mergeSort(int[] array)
        {
            int length = array.Length;

            if (length <= 1) //Ende, da das jeweils eingefügte Array zu klein ist und nicht weiter sortiert werden kann
            {
                return null;
            }

            int middle = length / 2;  //ermittelt die Mitte 
            int[] leftArray = new int[middle];  //Array mit halber Länge des Original Arrays
            int[] rightArray = new int[length - middle];//rechtes Array (length-middle) falls die beiden Hälften nicht gleich sind

            int i = 0;
            int j = 0;
            for (; i < length; i++)
            {
                if (i < middle)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }
            mergeSort(leftArray); //rekursives Sortieren, bei der die linke Seite immer kleiner wird bis sie die Länge 1 hat
            mergeSort(rightArray);
            merge(array, leftArray, rightArray);
            return array;
        }

        //Helferfunktion bei der
        public static int[] merge(int[] array, int[] leftArray, int[] rightArray)
        {
            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int i = 0, l = 0, r = 0;         // l und r sind Index Pointer

            while (l < leftSize && r < rightSize)
            {
                if (leftArray[l] < rightArray[r]) //Wertevergleich der beiden Seiten
                {
                    array[i] = leftArray[l];  //linken Wert in Original Array eintragen an Stelle [i] , also immer der vordersten Stelle im Array 
                    i++;
                    l++;  //linken Pointer erhöhen, da Werte nicht verschwinden sondern nur ausgelesen werden
                }
                else
                {
                    array[i] = rightArray[r];//ansonsten wird der rechte Wert in den Original Array eingetragen an der Stelle
                    i++;
                    r++;//rechten Pointer erhöhen
                }
            }
            //Diese beiden While-loops decken den Fall ab das eine der beiden Seiten nach der Halbierung größer ist als die andere Seite.
            //Bei der Halbierung des Arrays sind entweder beide Seiten gleichgroß oder eine Seite ist um 1 länger als die andere
            while (l < leftSize)
            {
                array[i] = leftArray[l];
                i++;
                l++;
            }
            while (r < rightSize)
            {
                array[i] = rightArray[r];
                i++;
                r++;
            }
            return array;
        }



        public static void Main(string[] args)
        {
            int[] array = { 17,2, 5, 8, 5, 3, 43, 23 };
         

            int [] result = mergeSort(array);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]+" ");
            }
        }


    }
}
