namespace EventHandlerÜbung
{

    public class MyClass
    {
        //Hier wird das Event definiert mittels dem Delegate vom Typ EventHandler
        public event EventHandler? MyEvent;


        //Dies ist das TriggerEvent das MyEvent auslöst. Also wird das Event nur ausgelöst wenn es nicht null ist und invoked wird.
        public void TriggerEvent()
        {
            MyEvent?.Invoke(this, EventArgs.Empty);//Invoke - Aufruf
        }

        //Diese Methode entspricht der Signatur eines EventHandler und wird bei dem Eventaufruf ausgelöst an den es angehangen wurde.

        private static void MyClass_MyEvent(object? sender, EventArgs e)//EventHandler
        {
            Console.WriteLine("Das Event wurde ausgelöst");
        }

        //Diese Methode fügt den EventHandler zum Event hinzu
        public void RegisterEventHandler()
        {
            MyEvent += MyClass_MyEvent; //Abonnieren
        }

    }

    public class Progam
    {
        public static void Main(string[] args)
        {
            var myClass = new MyClass();           //Objektinstanziierung
            myClass.RegisterEventHandler();        //Hier muss dem Event eine EventHandler-Methode angefügt werden(Abonnieren)
                                                   //,damit das Event nicht null ist.
            //(Geht auch anonym)
           //  myClass.MyEvent += (sender, e) => Console.WriteLine("Event ausgelöst");


            myClass.TriggerEvent();                //Hiermit wird die ganze Eventkette ausgelöst,
                                                   //aber nur falls ein EventHandler abonniert ist.
        }

       
    }

}