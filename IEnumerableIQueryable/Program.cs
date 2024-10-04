using System.Reflection.Metadata;

namespace Iterieren
{
    public class Program
    {
        // IEnumerable wird verwendet für inMemory Sammlungen wie Listen und Arrays
        // Wird ausgeführt sobald aufgerufen
        // Einfach zu nutzen für kleinere Datensätze die vollständig im Speicher vorhanden sind


       



        public static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            IEnumerable<int> result = numbers.Where(r => r > 3);

            foreach (var number in result) 
            {
                Console.WriteLine(number);
            }

            // Nur ein Beispiel, welches einen Datenbankzugriff simuliert

            // Mittels IQueryable wird genutzt, um Daten von entfernten Datenquellen wie z.B. Datenbanken
            // bereitzustellen. Wird erst ausgeführt, wenn die Abfrage komplett durchlaufen wurde

            /*
            using( var context = new MyDbContext())
            {
                IQueryable<User> users= context.Users.Where(u => u.Age > 30);

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
            */

        }
    }
}
