using System;


namespace PrototypePattern
{
    //wird genutzt, um ein existierendes Objekt zu kopieren ohne das der Code von den konkreten Klassen abhängt.
    //So können auch Kopien von Objekten erstellt werden, die sich nicht komplett gleichen.

   

    //Das Interface enthält nur die abstrakte Methode Clone
    public interface IPrototype
    {
        public IPrototype Clone();
    }

    
    //Hier wird das Interface implementiert,das die Methode "Clone" bereitstellt. 
    public class ConcretePrototypeA : IPrototype
    {
        public string Name {  get; set; }
        public int Age { get; set; }

        //Konstruktor
        public ConcretePrototypeA(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //Reale Implementierung für die Methode,
        //die ein tatsächliches Objekt vom Typ ConcretePrototypeA als Klon zurückgibt.
        public IPrototype Clone()
        {//Hier wird ein Objekt zurückgegeben, dessen Klasse das Interface IPrototype implementieren muss,
         //d.h. das CroncretePrototypeA als Klon zurückgegeben werden kann, da diese Klasse IPrototype implementiert.
            return (IPrototype)this.MemberwiseClone();// shallow copy, also nur die Referenzen werden kopiert - führt zu Seiteneffekten u.U.
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //Originalobjekt erstellen.
            ConcretePrototypeA original = new ConcretePrototypeA("Max", 23);
            //Klonen des Originalobjekt durch Aufrufen der Clone Methode
            //so dass man dann nicht mehr alle Werte beim Erzeugen des Objektes eingeben muss wie beim Original 
            ConcretePrototypeA cloned = (ConcretePrototypeA)original.Clone();

            //Anzeigen von Original und Klon
            Console.WriteLine("Original: " + original);
            Console.WriteLine("Klon: " + cloned);
        }
    }
}
