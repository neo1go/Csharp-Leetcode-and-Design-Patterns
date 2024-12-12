//Das Addapter Pattern wird genutzt um Schnittstellen, die inkompatibel sind, miteinander zu verbinden.

namespace AdapterPattern
{
    public class Square
    {
        private double sidelength;

        public Square(double sidelength)
        {
            this.sidelength = sidelength;
        }

        public virtual double GetSideLength()  //mit virtual wird die Methode später überschreibbar.
        {
            return this.sidelength;
        }

    }

    public class Circle
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetRadius()
        {
            return this.radius;
        }
    }

    public class SquareHole
    {
        private double sidelength;

        public SquareHole(double sidelength)
        {
            this.sidelength = sidelength;
        }

        public bool CanFit(Square square)
        {
            return this.sidelength >= square.GetSideLength(); //Hier wird nun die entsrechende Methode eingefügt, entweder vom Adapter 
            //oder von der Grundklasse.
        }
    }

    public class CircleToSquareAdapter : Square
    {
        private Circle circle;  //Feld von anderer Klasse

        public CircleToSquareAdapter(Circle circle) : base(0)  //ruft Konstruktor der Basisklasse auf 
        {
            this.circle = circle;

        }
        public override double GetSideLength()  //Hier passiert die Anpassung durch Polymorphie der Ursprungsmethode.
        {
            //Man kann also sowohl den Wert des Kreises(*2) oder den eines Quadrates übergeben, um ihn dann mit CanFit() zu überprüfen

            return 2 * this.circle!.GetRadius();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            SquareHole hole = new SquareHole(10);
            Circle circle = new Circle(3);

            CircleToSquareAdapter adapter = new CircleToSquareAdapter(circle);


            Console.WriteLine($"Can the circle fit? {hole.CanFit(adapter)}");

        }
    }


}