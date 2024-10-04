//Ziel ist die Löschung des nten Knotens von hinten aus der LinkedList
public class Program
{
    public static LinkedListNode<int> RemoveNthNodeFromEnd(LinkedList<int> myList, int n)
    {
        if (myList.Count == null || myList.First == null)
        {
            return null;
        }


        LinkedListNode<int> dummy = new LinkedListNode<int>(0);
        myList.AddFirst(dummy);                                  //Dummy wird vor die LinkedList gesetzt
        LinkedListNode<int> firstPtr = dummy;
        LinkedListNode<int> secondPtr = dummy;

        for (int i = 0; i < n; i++)
        {
            secondPtr = secondPtr.Next;    //hier wird der 2te Pointer gesetzt mit Abstand n
        }
        while (secondPtr.Next != null)
        {
            firstPtr = firstPtr.Next;  //hier werden beide Pointer nach vorne bewegt bis der 2te Pointer am
                                       //Ende angelangt ist und auf Null zeigt.Somit ist der Eintrag links vom
                                       //linken Pointer zu löschen mit Remove 
            secondPtr = secondPtr.Next;
        }
        if (firstPtr.Next != null)
        {
            myList.Remove(firstPtr.Next);  //dies ist dann die nte Stelle die somit gelöscht wird
        }

        myList.RemoveFirst();       //hier wird der Dummy entfernt

        return myList.First;
    }





    public static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(15);
        list.AddLast(10);
        list.AddLast(35);
        list.AddLast(7);
        list.AddLast(29);

        LinkedListNode<int>? current = list.First;
        Console.WriteLine("Aktuelle Linked List");
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();


        RemoveNthNodeFromEnd(list, 3);

        //Zur Ausgabe der linkedList
        LinkedListNode<int>? current2 = list.First;
        Console.WriteLine("Neue LinkedList ");
        while (current2 != null)
        {
            Console.Write(current2.Value + " ");
            current2 = current2.Next;
        }
    }
}
