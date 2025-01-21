namespace MinMaxHeapExample
{


   // Die Max-Heap und Min-Heap Funktionen dienen dem Herausfinden entweder des Maximalwert oder
   // Minimalwerts der dann als Root gilt.
   
   // ACHTUNG: Der unterste Elternknoten in einem Array ist IMMER:  (LängeArray n/2) -1 (bei 0 Index)
   // Der Baum wird dann immer von diesem Elternknoten bis zur Root rückwärts (bildlich nach oben) iteriert.
   // Der Unterschied zwischen dem min und max Prinzip ist somit nur der Austausch der + - Zeichen.

    // Die Kindknoten eines Elternknotens werden in einem 0-basierten Array immer mit 
    //   linker Kindknoten:  2*i +1
    //   rechter Kindknoten: 2*i +2

    // Um von einem Kindknoten in einem 0-basierten Array den Elternknoten zu ermitteln,
    // wird der index-1 dann halbiert und anschließend abgerundet(floor),
    // also Math.floor((i-1)/2) ergibt den Elternknoten eines Kindknotens.
    public class Program
    {
        public static int[] MaxHeap(int[] heap)
        {
            int n = heap.Length;

            for (int i = (n / 2) - 1; i >= 0; i--)
            {
                HeapifyDownMax(heap, n, i);
            }
            return heap;
        }

        // MinHeap erstellen
        public static int[] MinHeap(int[] heap)
        {
            int n = heap.Length;

            for (int i = (n / 2) - 1; i >= 0; i--)
            {
                HeapifyDownMin(heap, n, i);
            }
            return heap;
        }

        // HeapifyDown für MaxHeap
        public static void HeapifyDownMax(int[] heap, int heapLength, int rootIndex)
        {
            int largest = rootIndex;    //Dieser Wert ist wegen der rekursiven Natur der aktuell besuchte Knoten. 
            int leftChild = 2 * rootIndex + 1;//Um im Array die richtige Position des childs zu ermitteln in Bezug auf den Elternknoten,
                                              //muß der rootIndex mal zwei genommen werden.
            int rightChild = 2 * rootIndex + 2;

            if (leftChild < heapLength && heap[leftChild] > heap[largest])//der Vergleich mit heapLength verhindert outOfBounds
            {
                largest = leftChild;
            }

            if (rightChild < heapLength && heap[rightChild] > heap[largest])
            {
                largest = rightChild; 
            }
              
            if (largest != rootIndex)//nachdem beide Kindknoten verglichen wurden, wird an der i Stelle der größte Wert eingesetzt
            {                        //falls dies nicht schon der größte Wert ist.
                int temp = heap[rootIndex];
                heap[rootIndex] = heap[largest];
                heap[largest] = temp;

                HeapifyDownMax(heap, heapLength, largest);  // Rekursiv weitermachen
            }
        }


       

        // HeapifyDown für MinHeap
        public static void HeapifyDownMin(int[] heap, int heapLength, int rootIndex)
        {
            int smallest = rootIndex;
            int leftChild = 2 * rootIndex + 1;
            int rightChild = 2 * rootIndex + 2;

            if (leftChild < heapLength && heap[leftChild] < heap[smallest])
            {
                smallest = leftChild;
            }

            if (rightChild < heapLength && heap[rightChild] < heap[smallest])
            {
                smallest = rightChild;
            }

            if (smallest != rootIndex)
            {
                int temp = heap[rootIndex];
                heap[rootIndex] = heap[smallest];
                heap[smallest] = temp;

                HeapifyDownMin(heap, heapLength, smallest);  // Rekursiv weitermachen
            }
        }

        
        public static void Main()
        {
            int[] heap = [4, 10, 3, 5, 1, 8, 2]; 
            int[] heap2 = [4, 10, 3, 5, 1, 8, 2];

            int[] result = MaxHeap(heap);

            int[] result2 = MinHeap(heap2);

            Console.WriteLine("MaxHeap");
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("MinHeap");
            foreach (int i in result2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
