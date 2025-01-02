// Das Singleton Pattern stellt sicher, dass eine Klasse genau eine Instanz hat
// und bietet globalen Zugriff auf diese Instanz.
// Z.B. werden Loggins von Usern als Singleton behandelt.
// Weitere Beispiele sind Konfigurationsverwaltung oder Datenbankverbindungen.
namespace SingletonPattern
{

    public sealed class Singleton
    {
        // Statische Instanz, die über Lazy<T> erstellt wird
        // Mit lazy wird sichergestellt, das die Instanz erst erstellt wird, wenn die Instanz benötigt wird.
        //Außerdem wird durch lazy Threadsicherheit gewährleistet.

        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        //Privater Konstruktor, um Instanziierung von außen zu verhindern
        private Singleton()
        {
            Console.WriteLine("Singleton Instanz erstellt.");
        }

        // Öffentliche statische Eigenschaft, um auf die Instanz zuzugreifen
        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }

        //Beispielmethode
        public void DoSomething()
        {
            Console.WriteLine("Singleton-Methode DoSomething() aufgerufen.");
        }

    }


    public sealed class LockedSingleton
    {
        private static LockedSingleton? instance = null;
        private static readonly object lockObject = new object();

        private LockedSingleton()
        {
            Console.WriteLine("Locked-Singleton-Instanz erstellt.");
        }
        public static LockedSingleton GetInstance()
        {
            if (instance == null) //fals false, wird schnell die Instanz zutückgegeben.
            {
                lock (lockObject)//Falls keine Instanz besteht, betritt der Thread hier das lock.
                {
                    if (instance == null) //Dieser erneute Check ist nötig, um bei gleichzeitigem Druchlaufen
                                          //von mehreren Threads in der ersten Abfrage zu verhindern,
                                          //das mehr als eine Instanz erstellt wird.
                    {
                        instance = new LockedSingleton();
                    }
                }
            }
            return instance;

        }
        public void DoAnotherThing()
        {
            Console.WriteLine("Locked-Singleton-Methode DoSomething() aufgerufen.");
        }

    }


    public class Program
    {
        public static void Main(String[] args)
        {
            //Zugriff auf die Singleton-Instanz
            Singleton singleton1 = Singleton.Instance;
            Singleton singleton2 = Singleton.Instance; //DIES IST DIE BEREITS ERSTELLTE INSTANZ DIE EINFACH MITTELS GETTER- 
                                                       //ODER INSTANCE-METHODE WIEDER ABGERUFEN WIRD:

            //Methode aufrufen
            singleton1.DoSomething();

            //Überprüfen,ob beide Referenzen gleich sind
            Console.WriteLine(ReferenceEquals(singleton1, singleton2) ? "Gleiche Instanz" : "Verschiedene Instanzen");

            // Diesesmal mit lock anstatt lazy wobei lock im Getter definiert wird.
            LockedSingleton lSingleton1 = LockedSingleton.GetInstance(); //Auf Klasse angewandt, da GetInstance() statisch ist.
            LockedSingleton lSingleton2 = LockedSingleton.GetInstance();

            lSingleton1.DoAnotherThing();

            Console.WriteLine(ReferenceEquals(lSingleton1, lSingleton2) ? "Gleiche Instanz" : "Verschiedene Instanzen");
        }
    }


}
