using System;
using System.Collections.Generic;





// 1. Command Interface – Definiert die gemeinsame Schnittstelle für alle Befehle
public interface ICommand
{
    void Execute(); // Führt den Befehl aus
    void Undo();    // Macht den Befehl rückgängig
}




// 2. Receiver – Die Klasse, auf der die Aktionen ausgeführt werden
public class TextEditor
{
    private string _text = ""; // Aktueller Inhalt des Editors

    public void AddText(string newText)
    {
        _text += newText;
        Console.WriteLine($"Text hinzugefügt: \"{newText}\" | Aktueller Text: \"{_text}\"");
    }

    public void RemoveText(int length)
    {
        if (length > _text.Length) length = _text.Length;
        string removed = _text.Substring(_text.Length - length, length);
        _text = _text.Substring(0, _text.Length - length);
        Console.WriteLine($"Text entfernt: \"{removed}\" | Aktueller Text: \"{_text}\"");
    }

    public string GetText() => _text;
}

// 3. Concrete Commands – Jeder Befehl kapselt eine Aktion auf dem Receiver
public class AddTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _textToAdd;

    public AddTextCommand(TextEditor editor, string textToAdd)
    {
        _editor = editor;
        _textToAdd = textToAdd;
    }

    public void Execute() => _editor.AddText(_textToAdd); // Führt den Befehl aus
    public void Undo() => _editor.RemoveText(_textToAdd.Length); // Macht ihn rückgängig
}

public class RemoveTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _length;
    private string _removedText = "";

    public RemoveTextCommand(TextEditor editor, int length)
    {
        _editor = editor;
        _length = length;
    }

    public void Execute()
    {
        _removedText = _editor.GetText().Substring(Math.Max(0, _editor.GetText().Length - _length), _length);
        _editor.RemoveText(_length);
    }

    public void Undo() => _editor.AddText(_removedText); // Stellt den entfernten Text wieder her
}

// 4. Invoker – Verwalter der Befehle mit Undo/Redo-Funktion
public class CommandManager
{
    private readonly Stack<ICommand> _undoStack = new Stack<ICommand>(); // Speichert vergangene Befehle für Undo
    private readonly Stack<ICommand> _redoStack = new Stack<ICommand>(); // Speichert rückgängig gemachte Befehle für Redo

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command); // Nach der Ausführung im Stack speichern für Undo 
        _redoStack.Clear(); // Redo wird ungültig, wenn neue Befehle ausgeführt werden
    }

    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            ICommand command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command); // Nach Undo für Redo speichern
        }
        else
        {
            Console.WriteLine("Nichts zum Rückgängigmachen!");
        }
    }

    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            ICommand command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command); // Nach Redo wieder für Undo speichern
        }
        else
        {
            Console.WriteLine("Nichts zum Wiederholen!");
        }
    }
}

// 5. Client – Simuliert eine Textbearbeitung mit Undo/Redo
public class Program
{
    public static void Main()
    {
        TextEditor editor = new TextEditor(); // Der Receiver
        CommandManager manager = new CommandManager(); // Der Invoker

        // Benutzer fügt Text hinzu
        manager.ExecuteCommand(new AddTextCommand(editor, "Hallo, "));
        manager.ExecuteCommand(new AddTextCommand(editor, "Welt!"));

        // Benutzer entfernt Text
        manager.ExecuteCommand(new RemoveTextCommand(editor, 5));

        // Rückgängig machen
        Console.WriteLine("\n--- UNDO ---");
        manager.Undo();
       // manager.Undo();

        // Wiederholen
        Console.WriteLine("\n--- REDO ---");
        manager.Redo();
        // manager.Redo();

        Console.WriteLine("\n--- UNDO ---");
        manager.Undo();
    }
}

