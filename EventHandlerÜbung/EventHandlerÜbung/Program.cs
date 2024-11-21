namespace EventHandlerÜbung
{

    public class MyClass
    {
        //Hier wird das Event definiert mittels dem Delegate vom Typ EventHandler
        public event EventHandler? MyEvent;


        //Dies ist der Abonnent
        private static void MyClass_MyEvent(object? sender, EventArgs e)
        {
            Console.WriteLine("\nDas Event wurde ausgelöst.\n");
        }

       // Diese Methode fügt den Abonnenten zum bis dahin leeren Event hinzu.
        public void RegisterEventHandler()
        {
            MyEvent += MyClass_MyEvent; //Abonnieren
            Console.WriteLine("Abo wurde hinzugefügt mit +=");
        }

        //Um Speicherleaks zu minimieren, sollten Abonnenten auch wieder abgemeldet werden
        public void DropEventHandler()
        {
            MyEvent -= MyClass_MyEvent; //Abmelden
            Console.WriteLine("Abo wurde beendet mit -=");
        }

        //Dies ist das TriggerEvent das MyEvent auslöst. Also wird das Event nur ausgelöst
        //wenn es nicht null ist und invoked wird.
        public void TriggerEvent()
        {
            MyEvent?.Invoke(this, EventArgs.Empty);//Invoke - Aufruf auf einem Klassenobjekt 
        }
    }

    public class Progam
    {
        public static void Main(string[] args)
        {
            var myClass = new MyClass();           
            myClass.RegisterEventHandler();  //Abonnent(EventHandler) wird registriert (+=) bzw angehangen
                                             //auf dem Objekt myClass
                                                   
           //  (Geht auch anonym)
           //  myClass.MyEvent += (sender, e) => Console.WriteLine("Event ausgelöst");


            myClass.TriggerEvent();                //Hiermit wird die ganze Eventkette ausgelöst,
                                                   //aber nur falls ein EventHandler abonniert ist.

            //Abo beenden
            myClass.DropEventHandler();

        }

       
    }

}