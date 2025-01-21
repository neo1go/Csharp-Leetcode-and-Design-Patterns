using System;
namespace QuickSortAlgo
{


    public  class Program
    {
        public static int[] QuickSort(int[] list)
        {
            if(list.Length <= 1)  //Abbruchbedingung
            {
                return list;
            }

            int pivot = list[0];  //pivot wird hier auf den ersten Wert gelegt. Dies ist kritisch bezüglich der Dauer der Suche.

            int[] leftArray = Array.FindAll(list, x => x < pivot);  //alle Werte, die kleiner als pivot sind
            int[] rightArray = Array.FindAll(list, x => x > pivot); //alle Werte, die größer als pivot sind

            /*  Alternativ die normale Variante
            List<int> leftList = new List<int>();
            foreach (int number in list)
            {
                if (number < pivot)
                    leftList.Add(number);
            }
            int[] leftArray = leftList.ToArray();

             List<int> rightList = new List<int>();
            foreach (int number in list)
            {
                if (number < pivot)
                    rightList.Add(number);
            }
            int[] rightArray = rightList.ToArray();
            */



            leftArray = QuickSort(leftArray);  //hier wird solange rekursiv aufgerufen, bis length <=1 ist, also Abbruch.
            rightArray = QuickSort(rightArray);

            int[] result = new int[leftArray.Length + 1 + rightArray.Length];  //+1 für den pivot

            leftArray.CopyTo(result, 0);  //mit CopyTo wird ein Array in ein anderes eingefügt ab dem Index der angegeben wird, hier 0;

            result[leftArray.Length] = pivot; //Achtung Length und index sind nicht gleich.Length ist +1 im Vergleich zum
                                              //Index. Deswegen wird der pivot an eine leere Stelle nach dem linken Array gesetzt.
            rightArray.CopyTo(result, leftArray.Length + 1);

            return result;
        }


        public static void Main() 
        {
            int[] list =[34, 5, 2, 132, 6, 7, 8, 34, 8, 8, 1, 2, 3, 4,];
            int[] sortedList = QuickSort(list);

            Console.WriteLine("Sortiertes Array: "+ String.Join(",",sortedList));

        }

    }


}
