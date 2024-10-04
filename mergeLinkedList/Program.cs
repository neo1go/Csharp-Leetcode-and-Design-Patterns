using System.Security.Cryptography.X509Certificates;

public class Program
{
    //es werden 2 LinkedLists zusammengeführt

    public static int PrintForEach(LinkedList<int> solutionList,string name)
    {
        Console.Write(name);
        foreach (int i in solutionList)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        return 0;

    }


    public static void Main(string[] args)
    {
        LinkedList<int> list1 = new LinkedList<int>();
        LinkedList<int> list2 = new LinkedList<int>();

        list1.AddLast(2);
        list1.AddLast(7);
        list1.AddLast(9);
        list1.AddLast(15);

        list2.AddLast(4);
        list2.AddLast(8);
        list2.AddLast(12);
        list2.AddLast(17);
        /* Brute force method   
              List<int> solution= new List<int>();

              foreach(int value in list1)
              {
                 solution.Add(value);
              }
              foreach (int value in list2)
              {
                  solution.Add(value);
              }
              solution.Sort();  //alles  zusammenschmeissen und dann sortieren lol
              foreach (int value in solution)
              {
                  Console.Write(value+" "); ;
              }
        */

        //Erstellen der Pointer in beiden LinkedLists
        LinkedListNode<int>? pointer1 = list1.First;
        LinkedListNode<int>? pointer2 = list2.First;
       
        //Ergebnisliste als neue zusammengeführte LinkedList
        LinkedList<int> solution = new LinkedList<int>();


        while (pointer1 != null || pointer2 != null)
        {
        //Pointer1 hat Wert und Pointer2 hat keinen Wert oder Pointer2 ist größer, wird Wert 1 eingetragen(kleiner)
            if (pointer1 != null &&( pointer2 ==null || pointer1.Value < pointer2.Value))
            {
                solution.AddLast(pointer1.Value);
                pointer1=pointer1.Next;
            }
        //Pointer2 hat Wert und Pointer1 hat keinen Wert oder Pointer1 ist größer, wird Wert 2 eingetragen(kleiner)
            else if (pointer2 != null && (pointer1 == null || pointer2.Value <= pointer1.Value))
            {
                solution.AddLast(pointer2.Value);
                pointer2=pointer2.Next;
            }
        };



        PrintForEach(list1,"Liste 1: ");
        PrintForEach(list2,"Liste 2: ");
        PrintForEach(solution,"zusammengeführtes Ergebnis ");
       
    }
}


