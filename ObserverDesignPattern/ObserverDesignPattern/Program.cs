using ObserverPattern;
using System;


/* Eigenschaften vs. Konstruktoren
 
Eigenschaften:
Zugriff: Sie bieten einen kontrollierten Zugriff auf ein Feld (_state), um dessen Wert zu lesen oder zu ändern.
Getter und Setter: Sie verwenden get- und set-Accessoren, um den Wert zu erhalten oder zu setzen. Diese können auch Logik enthalten, die beim Lesen oder Schreiben des Wertes ausgeführt wird.
Syntax: Sie nutzen eine spezielle Syntax ohne Klammern (()), was sie wie Felder erscheinen lässt. Dies erleichtert den Zugriff und macht den Code lesbarer.
Verwendung: Sie sind für den Zugriff und die Modifikation von Feldern gedacht, die möglicherweise zusätzliche Logik benötigen.


Konstruktoren:
Zweck: Konstruktoren werden verwendet, um neue Instanzen einer Klasse zu initialisieren. Sie legen den anfänglichen Zustand von Objekten fest.
Syntax: Konstruktoren haben den gleichen Namen wie die Klasse und keine Rückgabewerte. Sie werden mit Klammern () aufgerufen, oft mit Parametern, um Felder zu initialisieren.



Unterschiede:

Eigenschaften: Stehen für den Zugriff und die Manipulation von Werten nach der Initialisierung eines Objekts. Sie sind Teil der öffentlichen Schnittstelle der Klasse.
Konstruktoren: Werden nur einmal beim Erstellen eines Objekts aufgerufen und sind für die Initialisierung verantwortlich.
*/

namespace ObserverPattern
{


    //Observer Interface das die Update Methode vereinbart
    public interface IObserver
    {
        void Update(string state);
    }


    //Zu beobachtendes Objekt ist das Subjekt
    public class Subject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private string _state;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);//Hier wird der Beobachter zu der Abonnentenliste _observers hinzugefügt
            Console.WriteLine($"Subscription gestartet für {observer}");
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);//Hier wird der  ausgesuchte Beobachter aus der Abonnentenliste _observers entfernt
            Console.WriteLine($"Subscription beendet für {observer}");
        }

        //Notify wird durch den Setter von _state aufgerufen, also nur wenn der Setter genutzt wird um einen neuen Wert zu setzen
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_state); // hier werden alle Subjekte die das Interface implementiert haben, informiert
                                         // observer sind alle aktuellen Instanzen in _observers
            }
        }


        //Achtung, dies ist eine Porperty(Eigenschaft) und keine direkte Methode
        //es wird das Feld und die Kapselung von _state verwaltet 
        public string State
        {
            get => _state;  //dasselbe wie { return _state;}
            set
            {
                _state = value;
                Notify();
            }
        }


    }

    //Konkreter Observer mit der konkreten Updatemethode
    public class ConcreteObserver : IObserver
    {
        private readonly string _name;

        //Konstruktor
        public ConcreteObserver(string name)
        {
            _name = name;
        }
        public void Update(string state)
        {
            Console.WriteLine($"{_name} hat den neuen Zustand empfangen: {state}");
        }

        //ToString wird hier benötigt um observer in ConsoleWriteLine auszugeben
        public override string ToString()
        {
            return _name;
        }
    }





    public class Program
    {
        public static void Main(string[] args)
        {
            //es gibt in diesem Beispiel nur ein Subjekt welches hier instanziiert wird
            var subject = new Subject();

            //Erstellen von 2 Observern/Clients
            var observer1 = new ConcreteObserver("Beobachter 1");  //Konstruktoraufruf mit Übergabe des Namen des Beobachters
            var observer2 = new ConcreteObserver("Beobachter 2");

            //hier werden die Beobachter nach Erstellung an das Subjekt gekoppelt (Subscription)
            subject.Attach(observer1);
            subject.Attach(observer2);


            subject.State = "Neuer Zustand 1"; //Der erste Zustand des einen Subjektes
            subject.State = "Neuer Zustand 2"; //Der nächste Zustand desselben Subjektes

            subject.Detach(observer1); //Die Subscription wird beendet für observer1

            subject.State = "Neuer Zustand 3"; //Der nächste Zustand des Subjektes
        }
    }
}
