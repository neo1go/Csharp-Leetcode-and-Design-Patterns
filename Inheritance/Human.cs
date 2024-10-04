class Human : Lifeform
{
    public Human(double weight, int age, int noOfLegs, double velocity)
        : base(weight, age, noOfLegs, velocity)
    {
    }

    public override void Sleep()
    {
        Console.WriteLine("The human is sleeping");
    }

    public override void Sound()
    {
        Console.WriteLine("The human is yelling");
    }
}