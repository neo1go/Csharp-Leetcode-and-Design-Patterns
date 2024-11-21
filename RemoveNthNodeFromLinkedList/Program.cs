//Ziel ist die Löschung des nten Knotens von hinten aus der LinkedList
public class Program
{
    public static LinkedListNode<int>? RemoveNthNodeFromEnd(LinkedList<int> myList, int n)
    {
        if (myList.Count == 0 || myList.First == null || n> myList.Count)
        {
            return null;
        }


        LinkedListNode<int>? dummy = new LinkedListNode<int>(0);
        myList.AddFirst(dummy);                                  //Dummy wird vor die LinkedList gesetzt
        LinkedListNode<int>? firstPtr = dummy;
        LinkedListNode<int>? secondPtr = dummy;
      

        for (int i = 0; i < n; i++)
        {
            secondPtr = secondPtr?.Next;    //hier wird der 2te Pointer gesetzt mit Abstand n
        }
        while (secondPtr?.Next != null)
        {
            firstPtr = firstPtr?.Next;  //hier werden beide Pointer nach vorne bewegt bis der 2te Pointer am
                                       //Ende angelangt ist und auf Null zeigt.Somit ist der Eintrag links vom
                                       //linken Pointer zu löschen mit Remove 
            secondPtr = secondPtr.Next;
        }
        if (firstPtr?.Next != null)
        {
            myList.Remove(firstPtr.Next);  //dies ist dann die nte Stelle die somit gelöscht wird
        }

        myList.RemoveFirst();       //hier wird der Dummy entfernt

        return myList.First;
    }





    public static void Main(string[] args)
    {
        //Leere LinkedList erstellen und Einträge ans Ende anbringen.
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(15);
        list.AddLast(10);
        list.AddLast(35);
        list.AddLast(7);
        list.AddLast(29);

        //Usprungs Linked List
        LinkedListNode<int>? current = list.First;
        Console.WriteLine("Aktuelle Linked List");
        while (current != null) //Weiter Iterieren bis NULL erreicht ist (Ende der List).
        {
            Console.Write(current.Value + " ");
            current = current.Next;     //wie i++
        }
        Console.WriteLine();

        //Hiermit wird von hinten der nte Eintrag gelöscht.
        RemoveNthNodeFromEnd(list, 3);

        //Für die Ausgabe der LinkedList
        LinkedListNode<int>? current2 = list.First;
        Console.WriteLine("Neue LinkedList ");
        while (current2 != null)  //Weiter Iterieren bis NULL erreicht ist (Ende der List).
        {
            Console.Write(current2.Value + " ");
            current2 = current2.Next;
        }
    }
}
