
class Stack
{
    static void Main(string[] args)
    {
        // Beispiel für einen Stack (Stapel)
        Stack<int> stack = new Stack<int>();

        // Elemente zum Stack hinzufügen
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        foreach (int i in stack)
        {
            Console.WriteLine(i);
        }
        // Elemente vom Stack entfernen
        int poppedItem = stack.Pop(); // Entfernt oberstes Element
        Console.WriteLine($"Popped item: {poppedItem}");

        //nur zum Nachschauen
        var lookUp = stack.Peek();
        Console.WriteLine($"Peeking at top: {lookUp}");

        // gibt bool true,wenn Element vorhanden
        bool contains = stack.Contains(1);
        Console.WriteLine($"is Element 1 in Stack(true/false): {contains}");

        //zählt Anzahl der Einträge des Stacks
        int count = stack.Count();
        Console.WriteLine($"Number of entries in Stack: {count}");

        //Übertrag des Stacks in ein Array
        var array = stack.ToArray();
        foreach (int i in array)
        {
            Console.WriteLine($"Eintrag im Array: {i}");
        }

        //Speicherplatz freimachen
        stack.TrimExcess();
        Console.WriteLine("Speicherplatz aufgeräumt");

        //Leeren des gesamten Stacks
        stack.Clear();
        Console.WriteLine("Stackinhalt gelöscht");
    }
}