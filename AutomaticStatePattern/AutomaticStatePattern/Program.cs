// Das State Pattern ist ein behavioral-Pattern und wird genutzt,
// um das Verhalten eines Objektes, basierend auf seinem internen Zustand (State), 
// zu ändern. Zustände werden in eigene Klassen gekaspelt und an sie delegiert
// anstatt sie mit vielen if-else oder switch-Blöcken zu implementieren.

//   Komponenten sind :  
//   State: Definiert das gemeinsame Verhalten,das von den konkreten Zuständen implementiert wird.
//   Concrete State: Die konkrete Implementierung des Zustands, die das Verhalten für den jeweiligen Zustand bereitstellen.
//   Context: Die Hauptklasse die das aktuelle Verhalten repräsentiert.

// In diesem Beispiel wird der Zustand automatisch verändert durch den Request-Aufruf. 


namespace AutomaticStatePattern
{

    // 1. State Interface
    public interface IKaffeeMaschineState
    {
        void Handle(KaffeeMaschine context);
    }

    // 2. Concrete States
    public class BereitState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Maschine ist bereit. Kaffee wird zubereitet...");
            context.SetState(new ZubereitungState());
        }
    }

    public class ZubereitungState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Kaffee wird zubereitet. Maschine wechselt in Wartungsmodus.");
            context.SetState(new WartungState());
        }
    }

    public class WartungState : IKaffeeMaschineState
    {
        public void Handle(KaffeeMaschine context)
        {
            Console.WriteLine("Maschine benötigt Reinigung. Zurück in den Bereit-Modus nach Wartung.");
            context.SetState(new BereitState());
        }
    }

    // 3. Context Class
    public class KaffeeMaschine
    {
        private IKaffeeMaschineState _currentState; //Instanzvariable

        public KaffeeMaschine()
        {
            // Initialzustand
            _currentState = new BereitState();
        }

        public void SetState(IKaffeeMaschineState state)
        {
            _currentState = state;
        }

        public void Request()
        {
            _currentState.Handle(this);
        }
    }

    // 4. Nutzung
    class Program
    {
        static void Main()
        {
            KaffeeMaschine maschine = new KaffeeMaschine();

            // Zustandswechsel auslösen
            maschine.Request(); // Maschine ist bereit. Kaffee wird zubereitet...
            maschine.Request(); // Kaffee wird zubereitet. Maschine wechselt in Wartungsmodus.
            maschine.Request(); // Maschine benötigt Reinigung. Zurück in den Bereit-Modus nach Wartung.
        }
    }
}