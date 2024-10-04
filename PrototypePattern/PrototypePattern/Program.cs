using System;


namespace PrototypePattern
{
    //wird genutzt, um ein existierendes Objekt zu kopieren ohne das der Code von den konkreten Klassen abhängt.
    //So können auch Kopien von Objekten erstellt werden die sich nicht komplett gleichen.

    public class Program
    {
        public static void Main(string[] args)
        {
            //Originalobjekt erstellen
            ConcretePrototypeA original = new ConcretePrototypeA("Max", 23);
            //Klonen des Originalobjekt durch Aufrufen der Clone Methode
            //so dass man dann nicht mehr alle Werte beim Erzeugen des Objektes eingeben muss wie beim Original 
            ConcretePrototypeA cloned = (ConcretePrototypeA)original.Clone();

            //Anzeigen von Original und Klon
            Console.WriteLine("Original: "+ original);
            Console.WriteLine("Klon: "+ cloned);
        }
    }

    //Das Interface enthält nur die abstrakte Methode Clone
    public interface Prototype
    {
        public Prototype Clone();
    }

    
    public class ConcretePrototypeA : Prototype
    {
        public string Name {  get; set; }
        public int Age { get; set; }

        //Konstruktor
        public ConcretePrototypeA(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //Reale Implementierung
        public Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();// shallow copy, also nur die Referenzen werden kopiert - führt zu Seiteneffekten u.U.
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

}
