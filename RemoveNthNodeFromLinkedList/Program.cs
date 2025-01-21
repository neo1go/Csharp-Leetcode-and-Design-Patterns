//Ziel ist die Löschung des nten Knotens von hinten aus der LinkedList

namespace RemoveNthNodeFromLinkedList
{
    public class Program
    {
        // LinkedList Framework-Befehle:
        // Count           Zählt
        // First         zeigt den ersten Knoten an und initialisiert die gesamte LL, falls diese durchschritten werden sollte mittels foreach.
        //               Knoten werden also durch die jeweiligen Referenzen im Speicher gefunden, haben aber keine feste Speicheradresse. 

        // Last          zeigt den letzten Knoten an
        // 
        // Methoden:  ACHTUNG - 'LinkedListNode<T> node'        steht für einen schon erstellten Knoten, i.d.F mit dem Bezeichner "node"

        // AddFirst(T value);       Vorne anfügen eines Wertes (es wird automatisch ein Knoten erstellt mit LinkedListNode<T> node)
        // AddFirst(LinkedListNode<T> node);   in diesem Fall existiert der Knoten schon und wird verschoben an den Anfang.
        // AddLast(T value);          hinten an eine LL anfügen eines Wertes
        // AddLast(LinkedListNode<T> node);  bereits existierender Knoten wird ans Ende gesetzt.
        // AddBefore(LinkedListNode<T> node, T value);
        // AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode);
        // AddAfter(LinkedListNode<T> node, T value);
        // AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode);
        // Remove(T value);         Wert aus der LL entfernen,egal an welcher Stelle
        // Remove(LinkedListNode<T> node);
        // Contains(T value);        abfragen, ob Wert irgendwo enthalten ist in LL
        // Find(T value);            findet den genauen Wert und speichert den Knoten in einer Variable
        // FindLast(T value);
        // Clear();   Löscht alle Knoten 
        // CopyTo(T[] array, int index);
        //
        //
        // LinkedListNode<T>
        // List;     zeigt gesamte LL an
        // .Next         gibt den nächsten Knoten aus einer LL zurück
        // .Previous     gibt den vorherigen Knoten aus einer LL zurück
        // .Value        gibt den Wert eines Knoten zurück
        //
        // LinkedLists implementiert IEnumerable<T> und somit kann man LL's mit foreach iterieren.
        //
        // Linq Beispiel: var filteredList = myLinkedList.Where(x => x > 10).ToList();
        //
        // in c# kann ein mit new erstellter Knoten immer nur einer linkedList angehören (unique).
        // Außerdem sind alle LL in c# doppeltverkettet. Jeder Knoten zeigt auf den vorherigen(oder null bei erstem Knoten)
        // und den nächsten Knoten (oder null bei letztem Knoten).

        public static LinkedListNode<int>? RemoveNthNodeFromEnd(LinkedList<int> myList, int n)
        {
            if (myList.Count == 0 || myList.First == null || n > myList.Count) //Abbruchregel 
            {
                return null;
            }

            //Dummy erstellen
            LinkedListNode<int>? dummy = new LinkedListNode<int>(0);
            myList.AddFirst(dummy);                                  //Dummy wird vor die LinkedList gesetzt um den ersten Knoten
                                                                     //löschen zu können bei Bedarf.
            LinkedListNode<int>? firstPtr = dummy;
            LinkedListNode<int>? secondPtr = dummy;


            for (int i = 0; i < n; i++)
            {
                secondPtr = secondPtr?.Next; //hier wird der 2te Pointer mit Abstand n gesetzt um bei Erreichen des Endes den Abstand
                                             //zu gewährleisten.
            }

            // Nächster Schritt
            while (secondPtr?.Next != null)
            {
                firstPtr = firstPtr?.Next;  //hier werden beide Pointer nach vorne bewegt bis der 2te Pointer am
                                            //Ende angelangt ist und auf Null zeigt.Somit ist der Eintrag rechts vom
                                            //linken Pointer zu löschen mit Remove. 
                secondPtr = secondPtr.Next;
            }
            //Entfernung des gewünschten Knoten
            if (firstPtr?.Next != null)
            {
                myList.Remove(firstPtr.Next);  //der linke Pointer zeigt auf den Knoten vor dem zu löschenden Knoten.
                                               //Deswegen ist der zu löschende Knoten somit firstPtr.Next.
            }

            myList.RemoveFirst(); //hier wird der Dummy entfernt mittels framework-Funktion um die LinkedList wieder
                                  //normal erscheinen zu lassen ohne eventuelle temporäre Knoten. 

            return myList.First;
        }





        public static void Main()
        {
            //Leere LinkedList erstellen und Einträge ans Ende anfügen.
            LinkedList<int> list = new ();
            list.AddLast(15);
            list.AddLast(10);
            list.AddLast(35);
            list.AddLast(7);
            list.AddLast(29);

            //Ursprungs Linked List
            LinkedListNode<int>? current = list.First;  //hier wird die Referenz auf den ersten Knoten im Speicher übergeben
            Console.WriteLine("Aktuelle Linked List");

            while (current != null) //Weiter Iterieren bis NULL erreicht ist (Ende der List).
            {
                Console.Write(current.Value + " ");
                current = current.Next; //wie i++, es wird die nächste Referenz ausgelesen solange bis keine Referenzierung mehr möglich ist.  
            }
            Console.WriteLine();

            //Hiermit wird von hinten der nte Eintrag gelöscht.
            RemoveNthNodeFromEnd(list, 3);

            //Für die Ausgabe der LinkedList
            LinkedListNode<int>? current2 = list.First;
            Console.WriteLine("Neue LinkedList ");
            while (current2 != null)  //Weiter Iterieren bis NULL erreicht ist (Ende der List).
            {
                Console.Write(current2.Value + " ");
                current2 = current2.Next;
            }
            Console.WriteLine();


            // Liste wird gelöscht
            list.Clear();
            LinkedListNode<int>? current3 = list.First;   //sollte leer sein

            Console.WriteLine("Die Liste wurde geleert");
            while (current3 != null)
            {
                Console.WriteLine(current3.Value);
            }
        }
    }
}