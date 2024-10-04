using System.Text;


public class Program
{
    //eine # repräsentiert einen Backspace(delete) 
    //Es werden 2 Strings miteinander verglichen, die an verschiedenen Stellen einen backspace enthalten(#)

    public static bool backspaceCompare(String s, String t)
    {
        return getActual(s).Equals(getActual(t));  //Vergleich mit Ergebnis bool
    }


    private static string getActual(String input)
    {
        StringBuilder sb = new StringBuilder();  //um die chars immer an index[0] einzufügen
        int deleteCounter = 0;

        for (int i = input.Length - 1; i >= 0; i--)//es wird am Ende des Strings angefangen
        {
            if (input[i].Equals('#'))
            {
                deleteCounter++;
                continue;             //bei einem del wird der Lösch-Counter erhöht es wird direkt zum nächsten char gesprungen
            }
            if (deleteCounter > 0)//hier wird der char einfach ignoriert sofern
                                  //ein delete(backspace) im Counter gespeichert ist was einer Löschung gleichkommt.
                                  //(der char wird einfach nicht in den neuen String eingefügt)-Die wichtigste Stelle
            {
                deleteCounter--;
            }
            else
            {
                sb.Insert(0, input[i]);  //andernfalls wird der char im neuen String gespeichert

            }
        }
        Console.WriteLine("Neuer String "+sb.ToString());
        return sb.ToString();
    }





    public static void Main(string[] args)
    {//in diesem Beispiel: "ab##dlk#u"
        //Rückwärts vom Ende des Strings zum Anfang iterieren.
        //u wird inserted,dann erscheint die erste # und somit wird k übersprungen, dann l und d die eingefügt werden,
        //danach werden 2 # gespeichert und somit die letzten beiden chars b und a übersprungen.
        string s = "ab##dlk#u";  //wenn man die Werte links vom # löscht,erhält man dlu
        string t = "c#d#dlk#u";  //hier das Gleiche
     // string s = "ab##z"; //a und b werden gelöscht
     // string t = "c#d#";  // leerer String
 
        bool result = backspaceCompare(s, t);

        Console.WriteLine("Sind die beiden Strings identisch? " + result);
    }
}
