public class Program
{
    public static bool Palindrome(LinkedList<int> palindrome)
    {
        Stack<int> stack = new Stack<int>();

        // Erstellen einer Kopie der LinkedList, um die Originaldaten nicht zu ändern für den Abgleich
        LinkedList<int> reversedList = new LinkedList<int>(palindrome);

        //  Setzen des Start-Knotenpunkts der 2 Hälfte des Palindroms 
        LinkedListNode<int>? currentNode = SplitLinkedList(reversedList);
        while (currentNode != null)
        {
            //hier wird umgedreht alles der zweiten Hälfte der linkedList in den Stack gepusht,
            //also erst die 7 pushen, dann die 2 und zuletzt die 1
            //die Stackgröße entspricht also der Hälfte der palindrome LinkedList
            stack.Push(currentNode.Value);
            Console.WriteLine("Werte der reversed split Linked List +" + currentNode.Value);
            currentNode = currentNode.Next;//Es wird der nächste Knotenpunkt der 2 Hälfte gesetzt
        }

        // Überprüfen, ob die LinkedList ein Palindrom ist

        //Knotenpunkt wird auf First gesetzt
        currentNode = palindrome.First;

        while (currentNode != null)
        {
            //Wenn noch Werte im Stack sind und nicht gepoppt werden können wegen unterschiedlicher Zahlen
            if (stack.Count > 0 && currentNode.Value != stack.Pop())
            {
                return false; //Abbruch
            }
            //Die originale Liste wird durchschritten , also wird die 1 der LinkedList mit der 1 des Stacks verglichen
            currentNode = currentNode.Next;
        }

        return true; //Hier ist also der Stack empty und somit konnten alle Werte gepoppt werden.
    }

    //-------------------------------------------------------------------

    //SplitLinkedList gibt den Startpunkt der 2 Hälfte der palindrome linkedList aus
    public static LinkedListNode<int>? SplitLinkedList(LinkedList<int> palindrome)
    {
        if (palindrome == null || palindrome.First == null)
        {
            return null;
        }

        //Beide Pointer starten am Anfangsknoten
        LinkedListNode<int>? slowPointer = palindrome.First;
        LinkedListNode<int>? fastPointer = palindrome.First;

        while (fastPointer != null && fastPointer.Next != null)
        {
            //Solange das Ende der LinkedList noch nicht erreicht ist werden beide Pointer bewegt
            slowPointer = slowPointer.Next;
            fastPointer = fastPointer.Next.Next;

        }

        // Festlegen des Anfangs der zweiten Hälfte der LinkedList
        //da der zweite Pointer genau dann die null am Ende erreicht, wenn der erste Pointer in der Mitte ist
        //da Pointer 2 mit .Next.Next doppelt so schnell iteriert wie Pointer 1 
        LinkedListNode<int>? secondHalfStart = slowPointer;

        return secondHalfStart;
    }

    public static void Main(string[] args)
    {
        // Palindrom LinkedList
        LinkedList<int> palindrome = new();

        palindrome.AddLast(1);
        palindrome.AddLast(2);
        palindrome.AddLast(7);
        palindrome.AddLast(7);
        palindrome.AddLast(2);
        palindrome.AddLast(1);

        bool isPalindrome = Palindrome(palindrome);
        Console.WriteLine("Ist die LinkedList ein Palindrom? " + isPalindrome);
    }

}
