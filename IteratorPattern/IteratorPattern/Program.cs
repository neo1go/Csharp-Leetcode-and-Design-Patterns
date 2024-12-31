using System;
using System.Text.RegularExpressions;

namespace IteratorPattern
{   //Das Iterator Pattern wird verwendet, um eine Möglichkeit bereitzustellen,sequentiell über Elemente einer Aggregatstruktur(Collection)
    //zu iterieren, ohne die interne Repräsentation dieser Struktur offenzulegen. Das DesignPattern ermöglicht es, verschiedene Arten
    //von Iterationen zu implementieren,unabhängig davon, wie die Sammlung intern organisiert ist.

 /*   Zweck des Iterator Patterns:
     1. Abstraktion der Iteration: Es kapselt die Logik, wie eine Sammlung durchlaufen wird, in eine eigene Klasse,
        was den Code sauberer und flexibler macht.

     2. Trennung von Sammlung und Iteration: Die Sammlung(z.B.eine Liste) ist nicht für die Iterationslogik verantwortlich.

     3. Vielfältige Iterationen: Ermöglicht mehrere gleichzeitige Iterationen oder benutzerdefinierte Iterationsmechanismen 
        (z.B.nur gerade Zahlen, rückwärts iterieren).

     4. Einheitliche Schnittstelle: Es bietet eine standardisierte Schnittstelle für den Zugriff auf Elemente, 
        unabhängig von der Art der zugrunde liegenden Sammlung.
 */

    //Die Iterator Schnittstelle definiert, wie auf Elemente in der Sammlung(Iterable) zugegriffen wird
    //und wie durch diese Sammlung navigiert wird.
    //Der Iterator ist der "Durchschreiter" und iteriert somit durch die Sammlung.
    //Er bekommt nur die Referenz der originalen Sammlung (in diesem Fall List<T>) übergeben.

    public interface IIterator<T>
    {
        T Current { get; } //generische Eigenschaft
        bool MoveNext();
        void Reset();
    }


    //Die Sammlung die iteriert werden soll. Sie beinhaltet auch die Methode GetIterator die den Iterator bereitstellt.
    public class CustomCollection<T>
    {
        private readonly List<T> _items = new List<T>(); //Dies ist die tatsächliche Sammlung
        public void Add(T item) => _items.Add(item); //eine Methode zum Hinzufügen von Objekten zur Sammlung
                                                     //obwohl Add schon in .net existiert ist dies bestPractice weil dadurch die
                                                     //Methode veränderbar oder/und erweiterbar ist. 
                                                                                                              

        public IIterator<T> GetIterator()=>new CustomIterator<T>(_items);     //Instanziierung des echten Iterators mit der List.
                                                                             //Diese _items List wird hier an den Konstruktor übergeben.
    }



    //Der konkrete Iterator, also quasi der "Durchschreiter" der durch die Sammlung iteriert (durchschreitet).
    public class CustomIterator<T> : IIterator<T>
    {
        /*
        private readonly IEnumerable<T>? _collections;
        private IEnumerator<T>? _enumerator;

        private Iterator(IEnumerable<T> collection) {  _collections = collection ?? throw new ArgumentNullException(nameof(collection));
        _enumerator = _collections.GetEnumerator();
        }
        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }
        public void Reset()
        {
         _enumerator = _collection.GetEnumerator();
        }
        //Das IEnumerable bedeutet unter .net, das die Collection durchschreitbar ist 
        //und der IEnumerator ist zentral wichtig in .net und foreach .
        */
        private readonly List<T> _collection; 
        private int _currentIndex = -1;   //muss -1 sein wegen der MoveNext() welche sonst den 0 Index missachten würde.
        public CustomIterator(List<T> collection) //Hier wird also _items übergeben von der tatsächlichen Sammlung.
        {
            _collection = collection;  //Dies ist nur eine Referenz auf die echte List _items im Heap.
        }
        public T Current  //Getter, der den aktuellen Wert zurückgibt an dem der Iterator steht.
        {
            get 
            {
                return _collection[_currentIndex]; 
            }
        }
        public bool MoveNext()
        {
            if(_currentIndex +1 < _collection.Count) //solange der nächste Wert noch vorhanden ist,wird weiter iteriert.
            {
                _currentIndex++;
                return true;
            }
            return false;
        }

        public void Reset() => _currentIndex = -1; //Dies muss auf -1 gesetzt werden da mit MoveNext() immer der nächste Eintrag
                                                  //überprüft wird und sonst die 0te Stelle nicht mit berücksichtigt würde.
                                                  //Hiermit wird nur der Iterator zurückgesetzt.

      /*  alternative normale Schreibweise(mir eigentlich lieber)
        public void Reset()
        {
            _currentIndex = -1;
        }
      */

    }

    public class Program
    {
        public static void Main() 
        {
            var collection = new CustomCollection<string>();
            collection.Add("Element 1");
            collection.Add("Element 2");
            collection.Add("Element 3");

            IIterator<string> iterator = collection.GetIterator();

            while (iterator.MoveNext())  //Wenn in der Sammlung keine Werte mehr sind,
                                         //wird MoveNext auf false gesetzt und die Schleife bricht dann ab.
            {
                Console.WriteLine(iterator.Current);
            }
        }
        
    }
}