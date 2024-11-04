using System;


namespace Delegates
{
    //"Veröffentlicher"/"Herausgeber"
    public class Publisher
    {
        public delegate void Notify(string message);  //Alle delegates die hinzugefügt werden ,
                                                      //müssen die gleiche Parameterliste besitzen


        public event Notify? OnNotify;                  //Deklaration des Events.
                                                        //An dieses Event wird nun ein String angehangen
                                                        //in der Methode DoSomething.



        public void DoSomething()
        {
            // Ereignis auslösen
            OnNotify?.Invoke("Event wurd gerade ausgelöst");            //Deklariertes Event OnNotify wird hier ausgelöst
                                                            //und der String wird hier übergeben (message)
        }
    }



    //Abonnent
    public class Subscriber
    {
        public void Subscribe(Publisher pub)
        {
            pub.OnNotify += PrintMessage;                   // Hier wird der delegat erweitert indem
            Console.WriteLine("Abonnent hat hier abonniert");        // OnNotify mit PrintMessage gekoppelt wird
        }

        private void PrintMessage(string message)  //besitzt die gleiche Parameterliste, andernfalls könnten
                                                   //sie nicht gekoppelt werden mit pub.OnNotify
        {
            Console.WriteLine(message);
        }
    }



    public class Program
    {
        public static void Main(string[] args)
        {
            Publisher pub = new ();   //neues Publisher Objekt
            Subscriber sub = new ();  //neues Subscriber Objekt


            sub.Subscribe(pub);

            pub.DoSomething();
        }
    }
}