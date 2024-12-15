//Das State Pattern ist ein behavioral Pattern und wird genutzt,
//um das Verhalten eines Objektes basierend auf seinem internen Zustand (State)
//zu ändern. Zustände werden in eigene Klassen gekaspelt und an sie delegiert
//anstatt sie mit vielen if-else oder switch Blöcken zu implementieren.
//   Komponenten sind :
//   Context: Die Hauptklasse die das aktuelle Verhalten repräsentiert.
//   State: Definiert das gemeinsame Verhalten,das von den konkreten Zuständen implementiert wird.
//   Concrete State: Die konkrete Implementierung des Zustands, die das Verhalten für den jeweiligen Zustand bereitstellen.
//
//   In diesem Beispiel wird das Ende der Anwendung durch eine Kontrollvariable ausgelöst.

namespace ManualStatePatternWithBool
{
    //1. State Interface
    public interface IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context);
    }

    // 2. Concrete States
    public class BereitState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Maschine ist bereit. Bitte wählen Sie eine Aktion: 'starten', 'wartung' oder 'ausschalten'.");
            var input = Console.ReadLine();
            if (input == "starten")
            {
                context.SetState(new ZubereitungState());
            }
            else if (input == "wartung")
            {
                context.SetState(new WartungState());
            }
            else if (input == "ausschalten")
            {
                context.SetState(new AusschaltenState());
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Zustand bleibt unverändert.");
            }
        }
    }

    public class ZubereitungState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Kaffee wird zubereitet. Maschine wechselt in Wartungsmodus.");
            context.SetState(new HeizState());
        }
    }

    public class WartungState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Maschine benötigt Reinigung. Zurück in den Bereit-Modus nach Wartung.");
            context.SetState(new HeizState());
        }
    }

    public class HeizState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Wasser heizt auf.");
            context.SetState(new BereitState());
        }
    }

    public class AusschaltenState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            context.Stop(); // Beendet die Schleife
        }
    }


    // 3. Context Class
    public class KaffeeMaschine
    {
        private IKaffeeMaschineState _currentState;
        public bool IsRunning { get; private set; } = true; // Kontrollvariable

        public KaffeeMaschine()
        {
            _currentState = new HeizState();
        }

        public void SetState(IKaffeeMaschineState state)
        {
            _currentState = state;
            Console.WriteLine($"Neuer Zustand: {_currentState.GetType().Name}");
        }

        public void Request()
        {
            _currentState.Handle(this);
        }

        public void Stop()
        {
            IsRunning = false;
            Console.WriteLine("Kaffeemaschine wird ausgeschaltet.");
        }
    }

   
  

    // Hauptprogramm
    class Program
    {
        static void Main(string[] args)
        {
            KaffeeMaschine maschine = new KaffeeMaschine();

            while (maschine.IsRunning)
            {
                maschine.Request();
            }
        }
    }





}