using System;

namespace Decorator
{
    // Component
    public abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract double Cost();
    }

    // Decorator
    public abstract class CondimentDecorator : Beverage
    {
        public Beverage Beverage;
        public override abstract string GetDescription();
    }

    // Concrete Decorator
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            this.Beverage = beverage;
        }

        public override double Cost()
        {
            return Beverage.Cost() + 0.20;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + ", Mocha";
        }
    }

    // Concrete component
    public class Espresso : Beverage
    {
        public override string GetDescription() => "Espresso";
        public override double Cost() => 1.99;
    }

    // Concrete component
    public class HouseBlend : Beverage
    {
        public override string GetDescription() => "House Blend Coffee";
        public override double Cost() => 0.89;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            Console.WriteLine($"{ beverage.GetDescription() } ${ beverage.Cost() }");

            Beverage beverage2 = new HouseBlend();
            beverage2 = new Mocha(beverage2);

            Console.WriteLine($"{ beverage2.GetDescription() } ${ beverage2.Cost() }");
        }
    }
}
