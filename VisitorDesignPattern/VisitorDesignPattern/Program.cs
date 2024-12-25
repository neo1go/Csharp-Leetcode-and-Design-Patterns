using System.Data;

namespace VisitorPattern
{
    public interface Visitor
    {
        public double Visit(Liquor liquor);
        public double Visit(Necessity necessity);
        public double Visit(Tobacco tobacco);
    }

    public interface Visitable
    {
        public double Accept(Visitor visitor);
    }



    public class TaxVisitor : Visitor
    {
        public TaxVisitor()
        {

        }
        public double Visit(Liquor liquorItem)
        {

            return (liquorItem.GetPrice() * 0.18) + liquorItem.GetPrice();
        }

        public double Visit(Necessity necessityItem)
        {
            return (necessityItem.GetPrice() * 0.0) + necessityItem.GetPrice();
        }

        public virtual double Visit(Tobacco tobaccoItem)
        {
            return (tobaccoItem.GetPrice() * 0.32) + tobaccoItem.GetPrice();
        }


    }

    public class TaxHolidayVisitor : Visitor
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

        public double Accept(Visitor visitor)
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

        public double Accept(Visitor visitor)
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

        public double Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }

    }


    public class VisitorTest
    {
        public static void Main()
        {
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
            Console.WriteLine(Math.Round(vodkaPrice,2)+ " $ for vodka"); //hier wird nur absgeschnitten
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
