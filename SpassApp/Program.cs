namespace SpassApp;



public class Program
{

    public string ErstellungDatenverbindung(bool connection)
    {
        if (connection == true)
        {
            string answer = "Datenverbindung erstellt";
            Console.WriteLine(answer);
            return answer;
        }
        else
        {
            string answer = "Connection failed";
            Console.WriteLine(answer);
            return answer;
        }


         static void Main(string[] args)
        {
            Program newConnection = new Program();
            newConnection.ErstellungDatenverbindung(true);

            
            Zaehler.loopCounter();
        }
    }
}
