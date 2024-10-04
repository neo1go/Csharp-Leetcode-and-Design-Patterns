namespace Linq
{
    public class Program
    {


        public static void Main(string[] args)
        {
            List<Person> list = new List<Person>
            {
            new Person("Frank", "Schmidt", 35),
            new Person("Dieter", "Schmidt", 38),
            new Person("Peter", "Huba", 47),
            new Person("Mollie", "Ziegel", 22),
            new Person("Anne", "Polke", 28)
                };


            //var ageOver = list.Where(l => l.Age > 21).ToList();

            //foreach (var person in ageOver)
            //{
            //    Console.WriteLine($"Vorname: {person.FirstName} Nachname: {person.LastName} Alter:{person.Age}");
            //}




            //var firstEntry = list.FirstOrDefault(f => f.Age > 0);
            //if (firstEntry != null)
            //{
            //    Console.WriteLine(firstEntry.LastName);
            //}
            //else
            //{
            //    Console.WriteLine("Keine Person gefunden");
            //}





           // var orderByAlphabet = list.OrderBy(o => o.LastName).ThenBy(o => o.FirstName).ToList();
              var orderByAlphabet = list.OrderByDescending(o => o.Age).ToList();

            foreach (var person in orderByAlphabet)
            {
                Console.WriteLine($"Vorname: {person.FirstName} Nachname: {person.LastName} Alter:{person.Age}");
            }



            //var takeTwo = list.Take(2).OrderBy(t => t.FirstName);
            //foreach (var person in takeTwo)
            //{
            //    Console.WriteLine($"Vorname: {person.FirstName} Nachname: {person.LastName} Alter:{person.Age}");
            //}





            //var groupLastName = list.GroupBy(x => x.LastName).ToList();
            //foreach (var group in groupLastName)
            //{
            //    Console.WriteLine($"Nachname: {group.Key}");
            //    foreach (var person in group)            //in der Gruppe nochmals iterieren 
            //    {
            //        Console.WriteLine($"Vorname: {person.FirstName} Nachname: {person.LastName} Alter:{person.Age}");
            //    }
            //}






            //var skipTwo = list.Skip(2).OrderByDescending(s => s.LastName).ToList();
            //foreach (Person p in skipTwo)
            //{
            //    Console.WriteLine(p.LastName);
            //}





            //var containsChar = list.Where(c => c.FirstName.Contains("a",StringComparison.OrdinalIgnoreCase) || c.LastName.Contains("a", StringComparison.OrdinalIgnoreCase)).ToList();     //   .Ordinal vergleicht egal ob groß oder klein

            //foreach (var person in containsChar)
            //{
            //    Console.WriteLine(person.FirstName+" "+person.LastName);
            //}
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
