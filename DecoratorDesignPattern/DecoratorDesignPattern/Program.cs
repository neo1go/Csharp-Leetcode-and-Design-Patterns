
//Das Decorator-Pattern wird häufig genutzt, um einem Objekt dynamisch zusätzliche Funktionalitäten
//hinzuzufügen ohne die Klasse zu verändern.
//Die Objekte werden zur Laufzeit und nicht zur Kompilierzeit erweitert.
//Anwendungsfälle sind UI-Komponenten in GUI-Frameworks,
//Ein-und Ausgabestreams,
//Erweiterung von Objekten, ohne eine große Klassenhierarchie zu erstellen,
//Logging,Caching und Monitoring,
//Änderung von Objekteigenschaften zur Laufzeit z.B. für Produkte in einem E-Commerce-System,
//die je nach laufender Aktion dekoriert werden.
//Das Open/Closed Prinzip wird eingehalten.


namespace DecoratorPattern
{
    public abstract class Getränk  //Stellt alle erforderlichen abstrakten Methoden bereit
    {
        public abstract string GetraenkeSorte();
        public abstract double Kosten();
    }

    //Konkrete Komponente
    public class Kaffee : Getränk 
    {
        public override string GetraenkeSorte()
        {
            return "Kaffee";
        }

        public override double Kosten()
        {
            return 2.00;
        }
    }

    //Abstrakter Decorator
    public abstract class GetränkeDecorator : Getränk
    {
        protected Getränk _getränk;
        protected GetränkeDecorator(Getränk getränk)    
        {
            _getränk = getränk;
        }
        public override string GetraenkeSorte()
        {
            return _getränk.GetraenkeSorte();
        }
        public override double Kosten()
        {
            return _getränk.Kosten();
        }
    }

    //Konkreter Decorator für Zucker

    public class Zucker : GetränkeDecorator  //Weiter runter in der Vererbungshierarchie:
                                             //Getränk -> Kaffee, Getränk -> GetränkeDecorator -> Zucker, Getränkedecorator -> Sahne
                                             //GetränkeDecorator -> Schokolade
    {
        public Zucker(Getränk getränk) : base(getränk)
        {

        }
        public override string GetraenkeSorte()
        {
            return _getränk.GetraenkeSorte() + ", Zucker";
        }

        public override double Kosten()
        {
            return _getränk.Kosten() + 0.50;
        }
    }
    //Konkreter Decorator für Sahne
    public class Sahne : GetränkeDecorator
    {
        public Sahne(Getränk getränk) : base(getränk)
        {

        }
        public override string GetraenkeSorte()
        {
            return _getränk.GetraenkeSorte() + ", Sahne";
        }

        public override double Kosten()
        {
            return _getränk.Kosten() + 0.70;
        }
    }
    //Konkreter Decorator für Schokolade im Kaffee
    public class Schokolade : GetränkeDecorator
    {
        public Schokolade(Getränk getränk) : base(getränk)
        {

        }
        public override string GetraenkeSorte()
        {
            return _getränk.GetraenkeSorte() + ", Schokolade";
        }

        public override double Kosten()
        {
            return _getränk.Kosten() + 0.60;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Getränk kaffee = new Kaffee();

            //Einfacher Kaffee
            Console.WriteLine($"{kaffee.GetraenkeSorte()} {kaffee.Kosten().ToString("F2")}");

            //Kaffee mit Zucker (kaffee ist das Grundgetränk)
            kaffee = new Zucker(kaffee);  //Zucker wird hier hinzugefügt
            Console.WriteLine($"{kaffee.GetraenkeSorte()} {kaffee.Kosten().ToString("F2")}");

            //Kaffee mit Sahne (wird an das Objekt angehängt (decorated))
            kaffee = new Sahne(kaffee);
            Console.WriteLine($"{kaffee.GetraenkeSorte()} {kaffee.Kosten().ToString("F2")}");

            //Kaffee mit Zucker (wird an das Objekt angehängt)
            kaffee = new Schokolade(kaffee);
            Console.WriteLine($"{kaffee.GetraenkeSorte()} {kaffee.Kosten().ToString("F2")}");

            //lässt sich mittels decorator einfach erweitern, in diesem Fall zu  2x Zucker
            kaffee = new Zucker(kaffee);
            Console.WriteLine($"{kaffee.GetraenkeSorte()} {kaffee.Kosten().ToString("F2")}");

        }
        //Eine Möglichkeit,die Dekoratoren zu entfernen ist, eine List oder Stack
        //mit diesen Dekoratoren zu erstellen, und dann den entsprechenden Eintrag oder den letzten Eintrag
        //zu löschen und das Objekt basierend auf diesen Daten neu zu erstellen.
        //Beim Decorator Pattern gibt es keine normale Möglichkeit der Entfernung der Dekoratoren (Objekte) 
        //sondern nur das Hinzufügen von Dekoratoren (Objekten).
    }
}
