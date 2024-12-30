using System.Data;
//Das Visitor Design Pattern ist ein Verhaltensmuster das verwendet wird, um eine Gruppe von Objekten
//(Liquor,Necessity,Tobacco) mit neuen Operationen zu erweitern ohne die Klasse zu ändern.
//Es ermöglicht, Logik von den Datenstrukturen zu trennen und so das System besser erweiterbar zu machen.
//
//Die Hauptaufgabe des Patterns besteht darin, eine neue Operation auf eine bestehende Objektstruktur anzuwenden,
//ohne die Klassen der Objekte zu verändern. Dazu nutzt es die Trennung von Algorithmen und den Datenstrukturen,
//auf die sie angewendet werden.
//
//Visitor: Ein Visitor ist ein Objekt, das verschiedene Methoden bereitstellt,
//um spezifische Typen von Objekten in einer Objektstruktur zu besuchen.
//
//Die Objektstruktur enthält eine Vielzahl von Elementen, die alle eine gemeinsame
//Schnittstelle implementieren und den Visitor(durch Visitable) akzeptieren.
//
//Die Operation wird also durch den Visitor definiert und nicht in den Klassen der zu besuchenden Objekte selbst.
//
// Der Name rührt daher, das der Bsucher die verschiedenen Elemente der Objektstruktur besucht indem er die Accept() Methode 
//aufruft und  dann die darauf basierenden Operationen ausführt(Prozentrechnung der GetPrice()Methode auf die Objekte Liquor usw.).

namespace VisitorPattern
{
    //IVisitor dient der Definition der Operationen, in diesem Fall Visit.Dies ist getrennt von der Objektstruktur.
    public interface IVisitor
    {
        public double Visit(Liquor liquor);
        public double Visit(Necessity necessity);
        public double Visit(Tobacco tobacco);
    }

    //Erlaubt der Objektstruktur, Besucher zu akzeptieren. Ohne Visitable sind Objekte auch nicht besuchbar.
    public interface Visitable
    {
        public double Accept(IVisitor visitor);
    }


    // Konkreter Visitor, jeweils mit seiner eigenen Implementierung.
    // Wenn der TaxVisitor auf die Objekte angewandt wird, besucht er diese und berechnet in diesem Fall die Steuern.
    public class TaxVisitor : IVisitor
    {
        public TaxVisitor()
        {

        }
        public double Visit(Liquor liquorItem)//Dies ist der Besuch
        {

            return (liquorItem.GetPrice() * 0.18) + liquorItem.GetPrice();
        }

        public double Visit(Necessity necessityItem)//Hier wird mittels Polymorphie Visitor angepasst je nach Objekt
        {
            return (necessityItem.GetPrice() * 0.0) + necessityItem.GetPrice();
        }

        public  double Visit(Tobacco tobaccoItem)
        {
            return (tobaccoItem.GetPrice() * 0.32) + tobaccoItem.GetPrice();
        }


    }

    // Konkreter Visitor, jeweils mit seiner eigenen Implementierung.
    public class TaxHolidayVisitor : IVisitor
    {
        public TaxHolidayVisitor()
        {

        }
        public double Visit(Liquor liquorItem)
        {

            return (liquorItem.GetPrice() * 0.10) + liquorItem.GetPrice();
        }

        public double Visit(Necessity necessityItem)
        {
            return (necessityItem.GetPrice() * 0.0) + necessityItem.GetPrice();
        }

        public virtual double Visit(Tobacco tobaccoItem)
        {
           // return (tobaccoItem.GetPrice() * 0.28) + tobaccoItem.GetPrice();
            return (tobaccoItem.GetPrice() * 1.28) ;
        }


    }

    //Objekte
    public class Necessity : Visitable
    {
        private double price;

        public Necessity(double item)
        {
            price = item;
        }

        public double GetPrice()
        {
            return price;
        }

        public double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class Tobacco : Visitable
    {
        private double price;

        public Tobacco(double item)
        {
            price = item;
        }

        public double GetPrice()
        {
            return price;
        }

        public double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }
    public class Liquor : Visitable
    {
        private double price;

        public Liquor(double item)
        {
            price = item;
        }

        public double GetPrice()
        {
            return price;
        }

        public double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }


    public class VisitorTest
    {
        public static void Main()
        {
            //Client
            //Der Client erstellt die Objekte und koordiniert die Interaktionen zwischen Ihnen.
            
            TaxVisitor taxCalc = new TaxVisitor();
            TaxHolidayVisitor holidayCalc = new TaxHolidayVisitor();

            //Man sollte anstatt double auch decimal nehmen, das ist genauer.

            Necessity milk = new Necessity(3.47);
            Liquor vodka = new Liquor(11.99);
            Tobacco cigars = new Tobacco(19.99);

            double milkPrice = milk.Accept(taxCalc);
            double vodkaPrice = vodka.Accept(taxCalc);
            double cigarsPrice = cigars.Accept(taxCalc);

            Console.WriteLine("Normal Taxes:");

            Console.WriteLine(Math.Round(milkPrice, 2)+" $ for milk");  //hier wird gerundet
            Console.WriteLine($"{(vodkaPrice):F2} $ for vodka"); //hier wird nur absgeschnitten mit 2 Stellen nach dem Komma
            Console.WriteLine(Math.Round(cigarsPrice) + " $ for cigars");


            double holidayMilkPrice = milk.Accept(holidayCalc); 
            double holidayVodkaPrice= vodka.Accept(holidayCalc);
            double holidayCigarsPrice= cigars.Accept(holidayCalc);

            Console.WriteLine("Holiday Taxes:");

            Console.WriteLine($"{(holidayMilkPrice):F2} $ for milk");
            Console.WriteLine($"{(holidayVodkaPrice):F2} $ for vodka");
            Console.WriteLine(Math.Round(holidayCigarsPrice,2) + " $ for cigars");
        }
    }
}
