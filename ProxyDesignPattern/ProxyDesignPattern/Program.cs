// Das Proxy Pattern dient dazu, die Zugriffssteuerung für die Hauptklasse zu übernehmen,aber nur wenn die Instanz auch
//wirklich benötigt wird.
//Dabei ist dem BookReader egal, ob BookParser oder LazyBookParser die Instanz erstellt.
//Der Proxy dient nur der Zugriffssteuerung und soll keine Logik enthalten.
//Der Proxy soll nur für den Zugriff und nicht für die Logik verantwortlich sein. (SRP- Single Responsibility Principle)
//Der Proxy verwaltet also nur den Instanziierungsprozess des Objektes.


namespace ProxyPattern
{
    public interface IBookParser
    {
        int GetNumberOfPages();
    }

    // Reale Implementierung
    public class BookParser : IBookParser
    {
        private int numberOfPages;
        public BookParser(string bookContent)
        {
            //Teure Berechnung
            Console.WriteLine("Parsing book content...");
            numberOfPages = bookContent.Length / 100; //Beispielberechnung
            //Nachdem die Instanz hier erstellt wird, steht sie automatisch
            //beim 2ten Aufruf bereit und muss nicht mehr instanziiert werden. 
        }
        public int GetNumberOfPages()
        {
            return numberOfPages;
        }
    }

    //Die Proxyklasse mit dem selben Interface.(Verzögerte Intitialisierung)
    //Diese Klasse dient nur der Trennung der Zuständigkeiten.
    public class LazyBookParser : IBookParser
    {
        private BookParser? realBookParser;    //hier wird das echte Objekt referenziert und dann bearbeitet
        private string bookContent;
        public LazyBookParser(string bookContent)
        {
            this.bookContent = bookContent;
        }
        public int GetNumberOfPages()
        {
            if (realBookParser == null) //Hier wird entschieden, ob überhaupt instanziiert werden soll.(kostenintensiv)
            {
                realBookParser = new BookParser(bookContent);
            }
            return realBookParser.GetNumberOfPages();
        }



    }

    //Client
    public class BookReader
    {
        private readonly IBookParser bookParser;

        public BookReader(IBookParser bookParser)
        {
            this.bookParser = bookParser;
        }

        public void DisplayNumberOfPages()
        {
            Console.WriteLine($"Number of pages: {bookParser.GetNumberOfPages()}");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string bookContent = new string('a', 1000);

            IBookParser parser = new LazyBookParser(bookContent);
            BookReader reader = new BookReader(parser);

            reader.DisplayNumberOfPages();
        }
    }
}
