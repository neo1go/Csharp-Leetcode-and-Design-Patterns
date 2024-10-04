

using System.Diagnostics;

public static class Program
{

    static void Main(string[] args)
    {
        ProcessPeople();
    }


    public static void ProcessPeople()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"Startzeit {stopwatch.ElapsedMilliseconds} ms");

        var people = GetPeople(1000000);   //Diese Personen werden alle erzeugt, auch wenn nur 1000 benötigt werden
        foreach (var person in people)
        {
            if (person.Id < 1000)  //Hier setzt der yield return Befehl an um nur die 1000 Ergebnisse zu liefern und nicht die ganze Millionen
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
            }
            else
            {
                break;
            }

        }
        stopwatch.Stop();
        Console.WriteLine($"Endzeit {stopwatch.ElapsedMilliseconds} ms");
    }

    static IEnumerable<Person> GetPeople(int count)
    {
        //durch yield bei der ProcessPeople foreach nur das verarbeitet ,was wirklich benötigt wird ;also die 1000
        //yield ist also ein custom Iterator
        //Dies reduziert die Zeit und verbessert die Performance signifikant
        for (int i = 0; i < count; i++)
        {
            yield return (new Person() { Id = i, Name = $"Name {i}" }); // dieses yield ist der Kern
        }
    }


    //Dies ist die schlechte Methode bei der alles erzeugt wird!!

    //static List<Person> GetPeople(int count)
    //{
    //    var people = new List<Person>();
    //    for (int i = 0; i < count; i++)
    //    {
    //        people.Add(new Person() { Id = i, Name = $"Name {i}" });
    //    }
    //    return people;
    //}
}