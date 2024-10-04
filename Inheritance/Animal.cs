namespace Inheritance;

public class Animal : Lifeform
{
    public Animal(double weight, int age, int noOfLegs, double velocity) : base(weight, age, noOfLegs, velocity)
    {
    }
    public override void Sleep()
    {
        Console.WriteLine("The animal is snoozing");
    }

    public override void Sound()
    {
        Console.WriteLine("The animal is barking");
    }
}