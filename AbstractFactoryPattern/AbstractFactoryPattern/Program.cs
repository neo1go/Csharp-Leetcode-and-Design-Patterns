using System;
//   abstract factory wird z.B. genutzt für plattformübergreifende GUI-Anwendungen.
// - Es ermöglicht Modularität und gute Erweiterbarkeit
// - Es wird verwendet, wenn Familien verwandter Objekte erstellt werden müssen.
// - Dynamisches Management von Objekten gewünscht ist.
// - Die Testbarkeit der Anwendung erhöht werden soll.



namespace AbstractFactoryPattern
{
    //1. Abstrakte Produkte
    public interface IButton
    {
        void Render(); //Aktion anstatt Ergebnis ,deswegen void um die Lesbarkeit zu verbessern
    }

    public interface ICheckbox
    {
        void Render();
    }


    //2. Konkrete Produkte für Windows wobei die Interfaces implementiert werden
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendern eines Windows Button, der vom Interface IButton bereitgestellt wurde.");
        }
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendern einer Windows Checkbox, die vom Interface ICheckbox bereitgestellt wurde.");
        }
    }


    //3. Konkrete Produkte für Mac
    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendern eines Mac Button, der vom Interface IButton bereitgestellt wurde.");
        }
    }

    public class MacCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendern einer Mac Checkbox, die vom Interface ICheckbox bereitgestellt wurde.");
        }
    }


    //4. Abstrakte Factory die die abstrakten Methoden bereitstellt
    public interface IGUIFactory
    {
        IButton CreateButton();//gibt ein IButton-Objekt zurück bei Aufruf
        ICheckbox CreateCheckbox(); //gibt ein ICheckbox-Objekt zurück bei Aufruf
    }


    //5. Konkrete Windows Factory die die konkreten Create Methoden implementiert
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    //6. Konkrete Mac Factory, die die konkrteten Create-Methoden implementiert
    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }

    //7. Client Code
    public class Application 
    {
        private readonly IButton _button;  //Diese beiden Felder können später nicht mehr verändert werden
        private readonly ICheckbox _checkbox;//die Werte werden aus dem Konstruktor bereitgestellt

        public Application(IGUIFactory factory) //Konstruktor, entweder für win oder mac Factory;
                                                //dies ist Dependency Injection (DI)
        {
            _button = factory.CreateButton();      //hier wird die polymorphe Methode CreateButton an die factory-Variable gekoppelt
            _checkbox = factory.CreateCheckbox();  //dasselbe mit der Checkbox, die je nach Factory (mac,windows) ausgewählt wird
        }
        public void Render() //Ruft die konnkrete(n) Methode(n) der Button- und Checkbox-Objekte auf.
        {
           _button.Render();//auch diese Methode nutzt die Daten aus dem Konstruktor um Render auf den jeweiligen Objekten aufzurufen.
           _checkbox.Render();//d.h. das die konkreten Rendermethoden aufgerufen werden. 
                              // z.B.: _button.Render() wird zu WindwosButton.Render() oder MacButton.Render()
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IGUIFactory factory;  //hier wird die Deklaration erzeugt, um dann einen Vertag zu erstellen und die Factory entscheidet,
                                  //durch die Instanziierung des jeweiligen Objektes polymorpisch, welches konkrete Objekt erzeugt wird.

            //Dies sind die Voraussetzung für die instanziierung für windows-Objekte in diesem Beispiel
            factory=new WindowsFactory(); //hier wird ein Vertrag zwischen der Schnittstelle und der windows-Factory geschlossen
            Application app = new Application(factory); //hier werden die Werte übergeben
                                                        //mittles des Konstruktoraufrufs der ein Objekt IGUIFactory entgegennimmt
            app.Render();  //dann wird die Methode aufgerufen und die Werte aus der Variable app werden angewendet.


            //2.tes Beispiel für ein Mac Objekt aus der mac-Factory
            factory = new MacFactory();    //es muss factory genommen werden wegen der Erzeugung des Vertrags
                                           //und MacFactory entscheidet über die Erzeugung
            app = new Application(factory); //Aufruf des Konstruktors in Application 
            app.Render();
        }
    }
}