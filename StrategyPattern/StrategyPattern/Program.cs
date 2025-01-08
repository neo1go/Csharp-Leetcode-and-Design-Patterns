namespace StrategyPattern
{

    //Basierend auf dem Konstruktoraufruf in der Main-Methode wird
    //mittels Polymorphie der Interface-Methode transport() die passende Funktion gewählt.

    public interface ITransportStrategy
    {
        string transport();

    }

    public class WalkStrategy : ITransportStrategy //Dies sind Klassen, die polymorph die Methode zurückgeben
    {
        public string transport()
        {
            return "Walking to work.";

        }
    }

    public class CarStrategy : ITransportStrategy //Dies sind Klassen, die polymorph die Methode zurückgeben
    {
        public string transport()
        {
            return "Driving to work with my car.";

        }
    }

    public class BusStrategy : ITransportStrategy //Dies sind Klassen, die polymorph die Methode zurückgeben
    {
        public string transport()
        {
            return "Using the bus to get to work.";

        }
    }

    public class BikeStrategy : ITransportStrategy //Dies sind Klassen, die polymorph die Methode zurückgeben
    {
        public string transport()
        {
            return "Using the bike to drive to work";

        }
    }
    public class BetterCommuter()
    {
        private ITransportStrategy? _strategy;   //Privates Feld für Komposition, also die DP
        // Das Interface wird nicht vererbt sondern es wird eine Variable über eine Setter Methode bereitgestellt

        public void SetStrategy(ITransportStrategy strategy)//hiermit wird die tatsächliche Strategie initialisiert obwohl
                                                            //dies kein Konstruktor ist, sondern eine Setter-Methode.
        {
            _strategy = strategy;
        }

        public void GoToWork()
        {
            if (_strategy != null)
            {
                Console.WriteLine(_strategy.transport()); // WICHTIG!!!!
                                                          // hier wird dann die passende Strategie, polymorph
                                                          // je nach Objekterzeugung durch seperate Klassen, eingefügt.
            }
            else
            {
                Console.WriteLine("No transport strategy has been set.");
            }
        }

    }


    public class Program
    {
        public static void Main(string[] args)
        {
            var commuter = new BetterCommuter();


            var walking = new WalkStrategy();
            commuter.GoToWork();  //hier ist der Setter noch nicht ausgeführt worden
            commuter.SetStrategy(walking);        //Setter Aufruf
            commuter.GoToWork();                  //Je nach erstelltem Objekt wird eine Variante von GoToWork() aufgerufen.


            var driving = new CarStrategy();
            commuter.SetStrategy(driving);
            commuter.GoToWork();


            var busComute = new BusStrategy();
            commuter.SetStrategy(busComute);
            commuter.GoToWork();
        }
    }
}
