
//Durch das Factory Pattern wird die Instanziierung des Objektes abstrahiert.
//Somit wird die Erstellung eines Objektes mittels Schnittstelle bewerkstelligt
//und die Client-Logik von der konkreten Klasse getrennt.
//Man möchte z.B. verhindern, das Objekte mittels new Operator instanziiert werden.
//Wird meist verwendet wenn :
// - man Abhängigkeiten zu konkreten Klassen vermeiden möchte.
// - man komplexe Initialisierungslogik benötigt.
// - Abhängigkeiten von anderen Objekten bestehen
// - Konkretisierungsklassen sich ändern können, ohne den Client-Code anzupassen
//Bspl.: GUI-Toolbox
//       Logger, die verschiedene Logger-Implementierungen mittels Factory bereitstellen.
//       Erstellung eines Objektes wenn erst zur Laufzeit die genaue Klasse bekannt ist
//       und der Client erst dann entscheidet, welche konkrete Implementierung er benötigt.(z.B. Dokumentenleser für PDF,DOCX,TXT)



namespace FactoryPattern
{
    //Erzeugendes Entwurfsmuster  Factory Pattern
    public interface ITier
    {
        void GeräuscheMachen();
    }

    public class Hund : ITier
    {
        public void GeräuscheMachen()
        {
            Console.WriteLine("Der Hund bellt: Wuff!");
        }
    }

    public class Katze : ITier
    {
        public void GeräuscheMachen()
        {
            Console.WriteLine("Die Katze miaut: Miau!");
        }
    }

    public class Vogel : ITier
    {
        public void GeräuscheMachen()
        {
            Console.WriteLine("Der Vogel zwitschert: Zwitscher!");
        }
    }

    //Dies ist die eigentliche Factory
    public class TierFactory
    {
        public static ITier ErstelleTier(string tierArt)           //Rückgabetyp ist das Interface bzw. GeräuscheMachen()
                            // hier ist es egal,welche Klasse diese Methode aufruft da individuell entschieden werden kann
                            // solange diese Klassen auch das Interface ITier implementiert haben,
                            // wird die richtige GeräuscheMachen() Methode aufgerufen. (Polymorphismus)
        {
            switch (tierArt)
            {
                case "Hund":
                    return new Hund();
                case "Katze":
                    return new Katze();
                case "Vogel":
                    return new Vogel();
                default:
                    throw new ArgumentException("Unbekannte Tierart.");
            }
        }


        public class Program
        {
            public static void Main(string[] args)
            {
                //Durch die Erzeugung von ITier Objekten ist man nicht von der Klasse abhängig.
                //Es wird auf die Schnittstelle programmiert und nicht die konkrete Klasse.
                //Die Factory entscheidet durch die ErstelleTier Methode, welches Objekt mit welchem Geräusch(Polymorphie) erzeugt wird.
                ITier tier1 = TierFactory.ErstelleTier("Hund");
                tier1.GeräuscheMachen();

                ITier tier2 = TierFactory.ErstelleTier("Katze");
                tier2.GeräuscheMachen();

                ITier tier3 = TierFactory.ErstelleTier("Vogel");
                tier3.GeräuscheMachen();
            }
        }
    }
}
