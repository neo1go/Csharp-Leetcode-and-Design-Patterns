//Leetcode 206


public class ListNode
{
    public int value;
    public ListNode next;
    public ListNode(int value = 0, ListNode next = null)
    {
        this.value = value;
        this.next = next;
    }
}

// Wenn wir uns mit A B C die Zeiger vorstellen, dann wird durch next nur die Referenz geändert bzw umgedreht.
// A B C   ist previous, current, next 
// Die ursprüngliche LL ist:  head-> A -> B -> C -> null
// Gewünscht ist am Ende:     null<- A <- B <- C <- head
//



public class Program
{
    public static ListNode ReverseList(ListNode head)
    {
        ListNode current = head;
        ListNode previous = null;

        while (current != null) //bei jedem Durchlauf wird jeweils nur einmal ein Wert neu referenziert.
        {
            ListNode? nextNode = current.next;// wird hier erzeugt, da die Prüfung für current damit
                                             // sozusagen schon abgedeckt wird durch die while-Bedingung.

            current.next = previous; // Zeiger wird rumgedreht. A zeigt beim ersten Durchlauf somit auf Null
            previous = current;    // die Null wird beim ersten Durchlauf mit dem aktuellen Wert überschrieben
            current = nextNode;          // dies ist die Iteration nach vorne zum nächsten Knoten
        }
        head = previous;  //man könnte auch previous zurückgeben, aber so ist es verständlicher.

        return head;
    }

    public static void PrintList(ListNode head)
    {
        ListNode? current = head;

        while (current != null)
        {
            Console.Write(current.value + " -> ");
            current = current.next;
        }
        Console.WriteLine("null");
    }


    public static void Main(string[] args)
    {
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        ListNode newH = ReverseList(head);
        PrintList(newH);
    }
}



