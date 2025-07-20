public class Program
{

    public static void Main(string[] args)
    {
        var list = new List<int> { 1, 2, 3 };

        var query = list.Select(x => x * 10);   // deferred Execution, es wird definiert aber noch nicht ausgeführt hier.
                                                // Es wird ein IEnumerable<int> erstellt welches erst beim Iterieren in der foreach ausgeführt wird.

        list.Add(4);   // Liste enthält jetzt 1,2,3,4


        foreach (var x in query)  // hier wird query erst ausgeführt.
        {
            Console.WriteLine($"{x}");
        }

    }

}