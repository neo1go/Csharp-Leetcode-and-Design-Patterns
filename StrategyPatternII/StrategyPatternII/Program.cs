using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace StrategyPatternII
{
    public interface IFLy
    {
        public string Fly();
    }

    public abstract class Animal
    {
        public IFLy? FlyingType { get; set; } //Instanz-Eigenschaft   
       

        public Animal(IFLy flyingType)  //dient hier nur dem Interface
        {
            FlyingType = flyingType; //Das Objekt FlyingType ist eine Schnittstelle (Interface-Referenz)
        }

        public string TryToFly() //Dies ist ein einheitlicher ,polymorpher Zugriffspunkt auf die Fähigkeit zu fliegen.
                                 //Somit wird die Fluglogik CanFly,CantFly von der Tierlogik Animal getrennt
        {
            return FlyingType!.Fly();    //Hier wird die Interfacemethode an das Objekt gekoppelt              (NonNullable -> !)
        }

        public void SetFlyingAbility(IFLy newFlyType) //Setter, der die Methode bei new-Operator neu setzt.
        {
            FlyingType = newFlyType;
        }
    }

    public class CanFly : IFLy   //Dies sind die Klassen, die dann die realen Methoden an die vererbende Klassen weitergeben.
    {
        public string Fly()
        {
            return "Ich kann fliegen.";
        }
    }

    public class CantFly : IFLy    //Dies sind die Klassen, die dann die realen Methoden an die vererbende Klassen weitergeben.
    {
        public string Fly()
        {
            return "Ich kann nicht fliegen.";
        }
    }

    public class Dog : Animal
    {
        public Dog() : base (new CantFly())   //hier wird das Interface im Konstruktor sofort übergeben.
        {

        }
    }
    public class Bird : Animal
    {
        public Bird():base (new CanFly())  //hier wird das Interface im Konstruktor sofort übergeben.
        {
            
        }
    }
       

    public class Program
    {
        public static void Main(String[] args) 
        {
            Bird birdy = new Bird();
            Console.WriteLine($"Vogel {birdy.TryToFly()} ");


            Animal sparky = new Dog();         
            Console.WriteLine($"Hund {sparky.TryToFly()}");


            sparky.SetFlyingAbility(new CanFly()); //Hier wird mittels Setter strategisch die Eigenschaft möglich gemacht.
            Console.WriteLine($"Hund nach Änderung {sparky.TryToFly()}");
            
        }
    }
}
