using System;
using Inheritance;

class Program
{
    public static void Main(string[] args)
    {
        Human hum = new Human(98, 121, 2, 28);

        Console.WriteLine("Age: " + hum.Age);
        Console.WriteLine("Weight: " + hum.Weight);
        Console.WriteLine("Number of Legs: " + hum.NoOfLegs);
        Console.WriteLine("Velocity: " + hum.Velocity);

        hum.Sleep();
        hum.Sound();

        Animal anim = new Animal(10, 5, 4, 36);

        Console.WriteLine("Age: " + anim.Age);
        Console.WriteLine("Weight: " + anim.Weight);
        Console.WriteLine("Number of Legs: " +anim.NoOfLegs);
        Console.WriteLine("Velocity: " + anim.Velocity);
        anim.Sleep();
        anim.Sound();
    }
}