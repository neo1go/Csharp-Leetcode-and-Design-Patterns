using System.Collections;

namespace IteratorCompositePattern
{
    //Die abstrakte Klasse, die entsprechend dem Datentyp unterschiedlich genutzt wird.
    public abstract class FileSystemComponent
    {
        public string Name { get; }


        protected FileSystemComponent(string name)
        {
            Name = name;
        }

        public abstract void Display(int indent = 0);
        public abstract IEnumerator<FileSystemComponent> GetEnumerator();
    }

    //Blattknoten: Datei
    public class File : FileSystemComponent
    {
        public File(string name) : base(name) { }       //Basiskontruktoraufruf,also wird der Konstruktor der Basisklasse FileSystemComponent
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + "- Datei: " + Name);
        }

        public override IEnumerator<FileSystemComponent> GetEnumerator()   // Dateien haben keine Kinder, also wird hier bei Aufruf rekursiv gearbeitet.
        {
            return new List<FileSystemComponent>().GetEnumerator();
        }
    }

    public class Folder : FileSystemComponent
    {
        private readonly List<FileSystemComponent> _children = new();

        public Folder(string name) : base(name) { }

        public void Add(FileSystemComponent component)  //kann sich potentiell unendlich aufrufen
        {
            _children.Add(component);
        }
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + "+ Ordner: " + Name);
            foreach (var child in _children)
            {
                child.Display(indent + 2);     //einzige Erhöhung von indent
            }
        }

        public override IEnumerator<FileSystemComponent> GetEnumerator()
        {
            return new FileSystemCompositeIterator(_children);  //hier werden die child Elemente angehangen
        }
    }

    public class FileSystemCompositeIterator : IEnumerator<FileSystemComponent>
    {
        private readonly Stack<IEnumerator<FileSystemComponent>> _stack = new();
        public FileSystemCompositeIterator(IEnumerable<FileSystemComponent> rootComponents)
        {
            _stack.Push(rootComponents.GetEnumerator());
        }

        public FileSystemComponent Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()   //wird hier nicht benötigt. Dies nutzt man eher bei Dateihandles, Netzwerkverbindungen oder anderen Ressourcen.
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            while (_stack.Count > 0)
            {
                var currentEnumerator = _stack.Peek();

                if (currentEnumerator.MoveNext())
                {
                    Current = currentEnumerator.Current;

                    // Wenn es ein Folder ist, dann seine Kinder auch iterieren
                    if (Current is Folder folder)
                    {
                        _stack.Push(folder.GetEnumerator());
                    }

                    return true;
                }
                else
                {
                    _stack.Pop();
                }
            }
            return false;
        }

        public void Reset()  // Es ist wohl in .net und anderen Sprachen schwierig, den Enumerator auf den Anfangszustand zurückzusetzen wenn mit stack
                             // gearbeitet wird. Deswegen wird Reset() meist nicht unterstützt und es wird eine NotSupportedException geworfen.
        {                    // Durch die rekursive Natur des Iterator/Composite Patterns ist die genaue Rücksetzung meist nicht exakt möglich.
                             // Es wird einfach ein neuer Iterator erzeugt stattdessen.
            throw new NotImplementedException();
        }
    }





    class Program
    {
        static void Main()
        {
            var root = new Folder("Root");
            var sub1 = new Folder("Bilder");
            var sub2 = new Folder("Dokumente");

            sub1.Add(new File("Foto1.jpg"));
            sub1.Add(new File("Foto2.png"));

            sub2.Add(new File("Lebenslauf.pdf"));
            sub2.Add(new File("Anschreiben.docx"));

            root.Add(sub1);
            root.Add(sub2);
            root.Add(new File("readme.txt"));

            Console.WriteLine("Struktur anzeigen:");
            root.Display();

            Console.WriteLine("\nAlle Elemente iterieren:");
            var iterator = root.GetEnumerator();
            while (iterator.MoveNext())
            {
                Console.WriteLine("- " + iterator.Current.Name);
            }
        }
    }



}
