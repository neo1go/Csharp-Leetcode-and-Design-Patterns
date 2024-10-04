using System.Collections.Generic;
//Dieser Code funktioniert nicht ,da Kontenpunkte einer LinkedList in c# scheinbar
//schreibgeschützt sind und nicht ohne Weiteres abgeändert werden können
public class Program
{
    public static void reorderList(LinkedList<int> orgList)
    {
        if (orgList == null || orgList.Count <= 1)
        {
            return;
        }
        //Pointer an Mitte der Linked List setzen
        LinkedListNode<int> pointer1 = orgList.First;
        LinkedListNode<int> pointer2 = orgList.First;
        while (pointer2.Next != null && pointer2.Next.Next != null)
        {
            pointer1 = pointer1.Next;
            pointer2 = pointer2.Next.Next;
        }

        //zweite Hälfte der linkedList rumdrehen
        LinkedListNode<int> preMiddle = pointer1;
        LinkedListNode<int> preCurrent = pointer1.Next;

        while (preCurrent != null && preCurrent.Next != null)
        {
            LinkedListNode<int>? current = preCurrent.Next;
            preCurrent.Next = current.Next;
            current.Next = preMiddle.Next;
            preMiddle.Next = current;
        }

        //LinkedList neu schreiben in gewünschter Reihenfolge
        pointer1 = orgList.First;
        pointer2 = preMiddle.Next;
        while (pointer1 != preMiddle)
        {
            preMiddle.Next = pointer2.Next;
            pointer2.Next = pointer1.Next;
            pointer1.Next = pointer2;
            pointer1 = pointer2.Next;
            pointer2 = preMiddle.Next;


        }

    }



    public static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(4);
        list.AddLast(8);
        list.AddLast(15);
        list.AddLast(16);
        list.AddLast(23);

        reorderList(list);

        foreach (var item in list)
        {
            Console.WriteLine(item + " ");
        }
    }
}
