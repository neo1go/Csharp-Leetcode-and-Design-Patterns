using System;
using System.Collections;
using System.Collections.Generic;


// Grunderklärung Iterator Design Pattern
// Man hat verschiedene Collections von Daten, über die man gleichzeitig iterieren möchte.
// Man erstellt einen Iterator 
// IEnumerable<T> gibt Zugriff auf die zuvor erstellte Sammlung durch die Bereitstellung des Iterators. (foreach Bereitstellung)
// IEnumerator<T> läuft tatsächlich über die Sammlung. (Iterator)

//also quasi:

// List<T> ist ein Buch
// IEnumerable<T> ist die Bibliothek, die einem das Buch gibt.(Es gibt auch Sammlungen ohne IEnumerable, dann aber ohne foreach)
// IEnumerator<T> ist der Finger, der über die Seiten fährt. (Iterator)




// (IEnumerable trennt Datenspeicherung von Datenzugriff. Deswegen werden die Funktionalitäten wegen besserer Performance getrennt.)

// Nicht jede Sammlung muß iterierbar sein und       (bei dicts z.B. wird über die KeyValue Paare iteriert und nicht alle Einzelelemente)
//
// nicht jeder Iterator muss eine Sammlung besitzen. (der Iterator kann auch auf dynamische Daten zur Laufzeit angewandt werden,
//                                                    nicht nur Collections. (lazy evaluation, verzögerte Berechnung))




//--------------------------------------------------------------------

//Enität: Einkaufsprodukt Bauplan
public class Einkaufsprodukt
{
    public string Name { get; set; }
    public decimal Preis { get; set; }

    public Einkaufsprodukt(string name, decimal preis)//Konstruktor
    {
        Name = name;
        Preis = preis;
    }
}
//Entität: Zutat Bauplan
public class Zutat
{
    public string Name { get; set; }
    public string Menge { get; set; }

    public Zutat(string name, string menge)
    {
        Name = name;
        Menge = menge;
    }
}



//-------------------------------------------------------------------------------------------

//Iterator für Einkaufsprodukte, also eine Liste vom Datentyp Einkaufsprodukt mit den Methoden MoveNext(), Reset() und Dispose(); 
//Es wird eine extra Iterator-Klasse erstellt für die ursrpüngliche Klasse, da das single-responsibility-principle gilt.
//So wird  die Verantwortung getrennt.
//Nur so sind mehrere Iterationen gleichzeitig auf der selben Liste möglich.
public class EinkaufsproduktIterator : IEnumerator<Einkaufsprodukt> //durch dieses Interface müssen wir Current implementieren
{
    private List<Einkaufsprodukt> _einkaufsprodukte;
    private int _position = -1; //Wird  durch die Länge der Liste geupdated

    public EinkaufsproduktIterator(List<Einkaufsprodukt> einkaufsprodukte)
    {
        _einkaufsprodukte = einkaufsprodukte;
    }

    public Einkaufsprodukt Current => _einkaufsprodukte[_position]; //Current ist eine Eigenschaft (getter only)

    object IEnumerator.Current => Current;//die aktuelle Instanz des Elementes einer Liste. Current wird vom Interface bereitgestellt und muß somit
                                          //implementiert werden. Es gibt eine generische und eine nciht-generische Variante von Current für
                                          //ältere c# Versionen.
    public bool MoveNext()
    {
        _position++;
        return _position < _einkaufsprodukte.Count;   //hier wird solange returned, bis die Liste erschöpft ist.
    }

    public void Reset() => _position = -1;
    public void Dispose() { }

}

//Iterator für Zutaten.
public class ZutatenIterator : IEnumerator<Zutat>
{
    private List<Zutat> _zutaten;
    private int _position = -1; //damit MoveNext richtig anfängt, wird hier auf -1 gesetzt.

    public ZutatenIterator(List<Zutat> zutaten)
    {
        _zutaten = zutaten;
    }

    public Zutat Current => _zutaten[_position];//Eigenschaft Current

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < _zutaten.Count;
    }
    public void Reset() => _position = -1;
    public void Dispose() { }

}

// Sammlung für Einkaufsprodukte
public class Einkaufsprodukte : IEnumerable<Einkaufsprodukt>// Damit man foreach  auf der Klasse Zutaten nutzen kann, muß man IEnumerable einfügen.
{                                                           // Es ist keine extra Itrator-Instanz mehr nötig und es lassen sich .Where() und .Select()
                                                            // nutzen. IEnumerable() stellt einzig und allein GetEnumerator() bereit.

    private List<Einkaufsprodukt> _produkte = new List<Einkaufsprodukt>();

    public void Add(Einkaufsprodukt produkt)
    {
        _produkte.Add(produkt);
    }

    public IEnumerator<Einkaufsprodukt> GetEnumerator()
    {
        return new EinkaufsproduktIterator(_produkte);  //hir wird der selbst ertstellte Iterator zurückgegeben.
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Sammlung für Zutaten
public class Zutaten : IEnumerable<Zutat>
{
    private List<Zutat> _zutaten = new List<Zutat>();

    public void Add(Zutat zutat)
    {
        _zutaten.Add(zutat);
    }

    public IEnumerator<Zutat> GetEnumerator()//DIE EINZIGE AUFGABE VON IENUMERABLE IST DIE BEREITSTELLUNG DES ITERATORS.
    {                                        //IEnumerable ist die Tür zur Sammlung, nicht die Sammlung selbst.
        return new ZutatenIterator(_zutaten);
    }

    IEnumerator IEnumerable.GetEnumerator()  //das muß man machen um von der generischen IEnumerable()<T> zu IEnumerable() zu wechseln.
                                             //ältere Versionen von C# kennen keine Generics und benötigen IEnumerable() ohne das <T>.
    {
        return GetEnumerator();//nicht generisch
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        // Erstellen der Listen
        var einkaufsprodukte = new Einkaufsprodukte();  //Liste erzeugen
        einkaufsprodukte.Add(new Einkaufsprodukt("Apfel", 1.2m)); //Liste befüllen
        einkaufsprodukte.Add(new Einkaufsprodukt("Brot", 2.5m));
        einkaufsprodukte.Add(new Einkaufsprodukt("Milch", 1.5m));

        // Zutatenliste
        var zutaten = new Zutaten();
        zutaten.Add(new Zutat("Mehl", "500g"));
        zutaten.Add(new Zutat("Zucker", "200g"));
        zutaten.Add(new Zutat("Butter", "250g"));

        //Iterator für beide Listen instanziieren mittels GetEnumerator
        var einkaufsproduktIterator = einkaufsprodukte.GetEnumerator();
        var zutatenIterator = zutaten.GetEnumerator();

        while (einkaufsproduktIterator.MoveNext() && zutatenIterator.MoveNext())
        {
            var produkt = einkaufsproduktIterator.Current;    
            var zutat = zutatenIterator.Current;

            Console.WriteLine($"Produkt: {produkt.Name}, Preis: {produkt.Preis} EUR - Zutat: {zutat.Name}, Menge: {zutat.Menge}");
        }

    }

}
