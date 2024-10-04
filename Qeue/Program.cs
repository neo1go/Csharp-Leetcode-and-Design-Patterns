class Queue
{
    public static void Main(string[] args)
    {
        Queue<string> queue = new Queue<string>();
        //Einfügen in den Queue
        queue.Enqueue("Erstes Element");
        queue.Enqueue("Zweites Element");
        queue.Enqueue("Drittes Element");

        foreach (var item in queue)
        {
            Console.WriteLine($"Element :{item}");

        }
        Console.WriteLine();

        //Entfernt erstes Element
        string dequeuedItem = queue.Dequeue();
        Console.WriteLine($"gelöschtes item: {dequeuedItem}\n");

        //Nachschauen im Queue
        var peeking = queue.Peek();
        Console.WriteLine($"Eintrag an erster Stelle ist: {peeking}\n");

        //Zählen der Queue Einträge
        int count = queue.Count();
        Console.WriteLine($"Anzahl der Queue-Einträge: {count}\n");

        //Ist 2tes Element vorhanden
        bool contains = queue.Contains("Zweites Element");//muß gleich dem Queue Eintrag sein
        Console.WriteLine($"Ist Element in Queue vorhanden?: {contains}\n");

        //Der Queue wird in ein Array eingetragen
        var array = queue.ToArray();
        foreach (var item in array)
        {
            Console.WriteLine($"im Array ist vorhanden: {item}\n");
        }
        //Speicherplatz freimachen
        queue.TrimExcess();
        Console.WriteLine("Queue wurde gesäubert mit Trim.Excess");

        //Löschen des Queues
        queue.Clear();
        Console.WriteLine("Queue-Einträge wurden gelöscht");
        //Abfrage, ob Queue leer ist
        if (queue.Count() <= 0)
        {
            Console.WriteLine("Queue ist leer\n");
        }
    }

}
