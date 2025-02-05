
namespace CommandPattern
{
    //Das Command Pattern ist ein Verhaltensmuster, das es ermöglicht, Anfragen als Objekte zu behandeln.
    //Dadurch kann man Parameter an Methoden übergeben, die dann später ausgeführt werden,
    //ohne dass der Sender der Anfrage Details über die Ausführung der Anforderung kennt.

    //Jeder Receiver, Invoker sowie Commands müssen instanziiert werden.


    //-----Command Interface
    public interface ICommand
    {
        //Methodendeklaration zum Ausführen des Befehls ohne Körper
        void Execute();
    }

    //-----Konkrete Befehle
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        // Konstruktor erhält das Light-Objekt,das die konkrete Aktion ausführt.
        public LightOnCommand(Light light)
        {
            _light = light;
        }

        //Ausführen des Einschaltbefehls
        public void Execute()
        {
            _light.TurnOn();
        }
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        // Konstruktor erhält das Light-Objekt, das die konkrete Aktion ausführt
        public LightOffCommand(Light light)
        {
            _light = light;
        }

        //Ausführen des Ausschaltbefehls
        public void Execute()
        {
            _light.TurnOff();
        }
    }
    //-----Receiver-Klasse (führt die eigentliche Aktion aus)
    public class Light
    {

        // Schaltet das Licht aus
         public void TurnOff()
        {
            Console.WriteLine("Licht ausgeschaltet!");
        }

        // Schaltet das Licht ein
        public void TurnOn()
        {
            Console.WriteLine("Licht eingeschaltet!");
        }
    }

    //-----Invoker-Klasse (verwaltet und ruft die Befehle)
    public class RemoteControl
    {
        private ICommand _command;  //Stellt eine private Instanz des Interfaces zur Verfügung.

        public void SetCommand(ICommand command) //Hier wird der richtige Command gesetzt,entweder lightOn oder lightOff.
        {
            _command = command;
        }
        public void PressButton()
        {
            _command.Execute(); // Hier wird die von ICommand bereitgestellte Methode Execute() gekapselt und an die Instanz gebunden,
                                //entweder mit turnOn() oder turnOff(), je nach übergebenem Setter-Objekt.
        }

    }

    //-------Client-Code
    public class Program
    {
        public static void Main(string[] args)
        {
            //Empfänger-Objekt (Receiver) Das Light-Objekt,das die Aktionen durchführt.
            Light livingRoomLight = new Light();

            //Befehle (Commands)
            ICommand lightOn = new LightOnCommand(livingRoomLight); //die instanziierten Befehle,aber noch ohne Ausführung.
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            //Invoker 
            RemoteControl remote = new RemoteControl(); //der Invoker ermöglicht es, die entsprechenden Befehle auf dem Objekt auszuführen.

            //Einschalten des Lichts
            remote.SetCommand(lightOn); //Erst hier werden die Commands eingesetzt, gebunden an den Invoker.
            remote.PressButton();  //Hier wird die richtige Execute()-Methode zu dem Kommando lightOn oder lightOff ausgeführt mittels
                                   //remote-Instanz.

            //Ausschalten des Lichtes
            remote.SetCommand(lightOff);
            remote.PressButton();
        }
    }
}
