
using System;
using System.Runtime.ConstrainedExecution;
// Das Template Pattern hilft bei Klassen, die gemeinsame Methoden nutzen,
// den Code zu vereinfachen und Redundanzen zu vermeiden.
//
// Ein Algorithmus wird in einer Basisklasse definiert und variierende Teile werden in Subklassen
// ausgelagert. Die Reihenfolge der Schritte wird in der Basisklasse festgelegt.
// Subklassen können einzelne Schritte anpassen, aber nicht den Gesamtstruktur des Ablaufs ändern.
// Bestimmte Schritte können in Subklassen überschrieben werden, um spezifisches Verhalten einzubinden, ohne den
// Gesamtalgorithmus zu stören. Dies fördrt das Open/Closed Prinzip.(Erweiterbarkeit ohne Modifikation des bestehenden Codes).
// 
//
// Die Superklasse ist abstrakt und definiert die Methoden, die genutzt werden sollen sowie deren Ablauf.
// ACHTUNG - Sind die Methoden abstrakt, MÜSSEN sie von konkreten vererbten Kind-Klassen implementiert werden.
//
// Wird eine Methode in der abstrakten Klasse schon konkretisiert, KANN sie implementiert werden, muß aber nicht.
// Dies nennt man einen Hook. Es entsteht eine kontrollierte Flexibilität.
//
//
// Das Template-Pattern macht am meisten Sinn, wenn mehrere Kind-Klassen sich viele oder einige der Funktionalitäten bzw das Grundgerüst
// teilen oder Methoden in ähnlicher Form nutzen, wobei sich individuelle Schritte unterscheiden können.
//
//
// Die Reihenfolge der Schritte sollte dabei gleich sein. Wenn Unterklassen keine erkennbare gemeinsame Prozessstruktur besitzen oder
// der Algorithmus nur in einer Klasse vorkommt, macht das Template-Pattern keinen Sinn.



// Diese abstrakte Basisklasse definiert die Template-Methoden
abstract class DataProcessor
{
    // Template-Methode (sollte so bleiben und nicht überschrieben werden. In Java z.B. wird dies 'final' gesetzt)
    public void ProcessData()
    {
        LoadData();
        TransformData();
        SaveData();
        if (ShouldLog()) // Hook
        {
            Log();
        }
    }

    // Standardmethoden, die von Subklassen implementiert werden müssen
    protected abstract void LoadData();
    protected abstract void TransformData();
    protected abstract void SaveData();

    // Hook-Methode - diese konkretisierte Methode kann von Subklassen überschrieben werden, muß aber nicht zwangsläufig vererbt werden.
    protected virtual bool ShouldLog() 
    {
        return false;
    }

    // Optionale Methode, die von Subklassen bei Bedarf überschrieben werden kann. Durch 'virtual' gekennzeichnete Methoden dürfen überschrieben werden.
    protected virtual void Log()
    {
        Console.WriteLine("Standard-Logging: Verarbeitung abgeschlossen.");
    }
}



// Konkrete Implementierung ohne Nutzung des Hooks
class CsvDataProcessor : DataProcessor
{
    protected override void LoadData()
    {
        Console.WriteLine("CSV-Daten geladen.");
    }

    protected override void TransformData()
    {
        Console.WriteLine("CSV-Daten transformiert.");
    }

    protected override void SaveData()
    {
        Console.WriteLine("CSV-Daten gespeichert.");
    }

    // Standardmäßig bleibt ShouldLog() auf false

    // Hier wird auf die Hook-Methode "Log" verzichtet.
}



// Konkrete Implementierung mit Nutzung des Hooks
class JsonDataProcessor : DataProcessor
{
    protected override void LoadData()
    {
        Console.WriteLine("JSON-Daten geladen.");
    }

    protected override void TransformData()
    {
        Console.WriteLine("JSON-Daten transformiert.");
    }

    protected override void SaveData()
    {
        Console.WriteLine("JSON-Daten gespeichert.");
    }

    // Hook überschreiben, um Logging zu aktivieren
    protected override bool ShouldLog() => true;

    protected override void Log()  //hier wird also überschrieben
    {
        Console.WriteLine("JSON-Daten erfolgreich verarbeitet und geloggt.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- CSV Verarbeitung (ohne Hook) ---");
        DataProcessor csvProcessor = new CsvDataProcessor();
        csvProcessor.ProcessData();

        Console.WriteLine("\n--- JSON Verarbeitung (mit Hook) ---");
        DataProcessor jsonProcessor = new JsonDataProcessor();
        jsonProcessor.ProcessData();
    }
}
