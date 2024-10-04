public abstract class Lifeform
{
    public int Age { get; protected set; }
    public double Weight { get; protected set; }
    public int NoOfLegs { get; protected set; }
    public double Velocity { get; protected set; }

    public abstract void Sleep();
    public abstract void Sound();

    protected Lifeform(double weight, int age, int noOfLegs, double velocity)
    {
        if (age <= 0 || age > 120)
        {
            Console.WriteLine("Alter nicht gültig");
            Age = 1;
        }
        else
        {
            Age = age;
        }

        if (weight <= 0)
        {
            Console.WriteLine("Gewicht nicht zulässig");
            Weight = 0.1;
        }
        else
        {
            Weight = weight;
        }

        if (velocity <= 0 || velocity > 120)
        {
            Console.WriteLine("Geschwindigkeit nicht zulässig");
            Velocity = 0.1;
        }
        else
        {
            Velocity = velocity;
        }

        NoOfLegs = noOfLegs;
    }
}