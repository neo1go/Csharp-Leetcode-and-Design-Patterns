namespace StrategyPattern
{

    //Basierend auf dem Konstruktoraufruf in der Main-Methode wird
    //mittels Polymorphie der Interface-Methode wayOfTravel() die passende Funktion gewählt.

    public interface ITransportStrategy
    {
        string transport();

    }

    public class WalkStrategy : ITransportStrategy
    {
        public string transport()
        {
            return "Walking to work.";

        }
    }

    public class CarStrategy : ITransportStrategy
    {
        public string transport()
        {
            return "Driving to work with my car.";

        }
    }

    public class BusStrategy : ITransportStrategy
    {
        public string transport()
        {
            return "Using the bus to get to work.";

        }
    }

    public class BikeStrategy : ITransportStrategy
    {
        public string transport()
        {
            return "Using the bike to drive to work";

        }
    }
    public class BetterCommuter()
    {
        private ITransportStrategy? _strategy;   //Privates Feld für Komposition 

        public void SetStrategy(ITransportStrategy strategy)//hiermit wird die tatsächliche Strategie initialisiert obwohl
                                                            //dies kein Konstruktor ist.
        {
            _strategy = strategy;
        }

        public void GoToWork()
        {
            if (_strategy != null)
            {
                Console.WriteLine(_strategy.transport());// hier wird dann die passende Strategie eingefügt.
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
            commuter.SetStrategy(walking);
            commuter.GoToWork();


            var driving = new CarStrategy();
            commuter.SetStrategy(driving);
            commuter.GoToWork();


            var busComute = new BusStrategy();
            commuter.SetStrategy(busComute);
            commuter.GoToWork();

        }
    }
}
