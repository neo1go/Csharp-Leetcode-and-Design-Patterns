// Das State Pattern ist ein behavioral Pattern und wird genutzt,
// um das Verhalten eines Objektes basierend auf seinem internen Zustand (State)
// zu ändern. Zustände werden in eigene Klassen gekaspelt und an sie delegiert
// anstatt sie mit vielen if-else oder switch Blöcken zu implementieren.

//   Komponenten sind :
//   State (interface): Definiert das gemeinsame Verhalten,das von den konkreten Zuständen implementiert wird.
//   Concrete State: Die konkrete Implementierung des Zustands, die das Verhalten für den jeweiligen Zustand bereitstellen.
//   Context: Die Hauptklasse die das aktuelle Verhalten repräsentiert.

namespace StatePattern
{
    //1.  Interface
    public interface IKaffeeMaschineState
    {
        void Handle(KaffeeMaschine context);
    }

    //2. Concrete States
    public class BereitState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context) //Hier wird die state Methode entsprechend dem Verhalten angepasst
        {
            Console.WriteLine("Maschine ist bereit. Bitte wählen Sie eine Aktion: 'starten', 'wartung' oder 'ausschalten'");
            var input = Console.ReadLine();
            if (input == "starten")
            {
                context.SetState(new ZubereitungsState());
            }
            else if(input == "wartung")
            {
                context.SetState(new WartungsState());
            }
            else if (input == "ausschalten") 
            {
                context.SetState(new AusschaltenState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Zustand bleíbt unverändert.");
            }
            
        }
    }

    public class ZubereitungsState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Kaffee wird zubereitet. Maschine wechselt in Wartungsmodus.");
            context.SetState(new WartungsState());
        }
    }

    public class WartungsState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Maschine benötigt Reinigung. Zurück in den Bereit-Modus nach Wartung.");
            context.SetState(new BereitState());
        }
    }

    public class AusschaltenState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Maschine wird ausgeschaltet.");
            Environment.Exit(0);  //Beendet in diesem Fall die gesamte App
        }
    }

    //3. Context Class - repräsentiert das aktuelle Verhalten des Objektes 
    public class KaffeeMaschine
    {
        private IKaffeeMaschineState _currentState;

        public KaffeeMaschine()  //Konstruktor
        {
            _currentState = new BereitState();
        }

        //Setter
        public void SetState(IKaffeeMaschineState state)
        {
            _currentState = state;
        }

        public void Request()
        {
            _currentState.Handle(this); //hier wird das polymorphe Handle() übergeben.
        }
    }

    // 4. Nutzung
    public class Program
    {
        public static void Main()
        {
            KaffeeMaschine maschine = new KaffeeMaschine();

            while (true) 
            {
                maschine.Request();  //Alle Zustände werden automatisch durchschritten
            }
        }
    }
}
