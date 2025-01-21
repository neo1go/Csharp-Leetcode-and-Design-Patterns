namespace MergeSortAlgo
{
    //Divide & Conquer

    // Binäres Zerlegen des Haupt-Arrays rekursiv in linkes und rechtes Teil-Array bis auf ArrayLength 1.
    // Erst beim Mergen werden die Werte der beiden Teilarrays verglichen und, der entsprechenden Größe nach,
    // in das ursprüngliche Hauptarray eingesetzt, um Speicher zu sparen.
    public class Program
    {
        public static int[]? MergeSort(int[] array)
        {
            int length = array.Length;

            if (length <= 1) //Ende, da das jeweils eingefügte Array zu klein ist und nicht weiter sortiert werden kann
            {
                return null;
            }

            int middle = length / 2;  //ermittelt die Mitte als Index-Zahl
            int[] leftArray = new int[middle];  //leeres Array mit halber Länge des Original Arrays
            int[] rightArray = new int[length - middle];//leeres rechtes Array (length-middle) 

            int i = 0;
            int j = 0;
            for (; i < length; i++)
            {
                if (i < middle) //Middle dient als pivot
                {
                    leftArray[i] = array[i];       //hier werden die aktuellen Werte in den Array eingetragen.
                }
                else
                {         //j ist der index des rechten Arrays und somit unabhängig von i. Es muß eigenständig sein
                          //da j nur erhöht wird,wenn das rechte Array auch befüllt wird.
                    rightArray[j] = array[i];      // hier werden die aktuellen Werte in den Array eingetragen.
                    j++;
                }
            }
            MergeSort(leftArray); //rekursives Halbieren, bei der die linke Seite immer kleiner wird bis sie die Länge 1 hat
            MergeSort(rightArray);
            Merge(array, leftArray, rightArray);
            return array;
        }


        //Helferfunktion, in der der eigentliche Sortiervorgang stattfindet
        public static int[] Merge(int[] array, int[] leftArray, int[] rightArray)
        {
            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int i = 0, l = 0, r = 0;         // l und r sind Index Pointer

            while (l < leftSize && r < rightSize)// wenn eine von beiden nicht mehr zutrifft, folgen die nächsten while-Loops.
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

            //Durch eine eventuelle ungerade Länge des Ursprungsarrays und der Halbierung zur Längenbestimmung und
            //die zu füllenden Werte ist nicht immer gewährleistet, das beide Hälften gleichlang(gleichgroß) sind.
            //Hiermit wird dann noch die fehlenden Werte eingetragen, entweder links oder rechts.
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

            //Bspl.:   leftArray=[3,5,8];
            //         rightArray=[2,4];
            //3l mit 2r -> 2 in Hauptarray
            //3l mit 4r -> 3 in Hauptarray
            //5l mit 4r -> 4 in Hauptarray
            //jetzt bleiben 5 und 8 im leftArray und da somit l kleiner als die Länge des leftArrays ist, werden die noch
            //vorhandenen Werte 5 und 8 nun in den Hauptarray eingetragen.
        }

        public static void Main()
        {
            int[] array = [ 17,2, 5, 8, 5, 3, 43, 23 ];
         

            int []? result = MergeSort(array);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]+" ");
            }
        }
    }
}
