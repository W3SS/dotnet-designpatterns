namespace DotNetDesignPattern.Patterns.Structural
{
    public abstract class Beverage
    {
        public virtual string Description { get; set; } = "Unknown Beverage";

        public abstract double Cost();
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "HouseBlend";
        }

        public override double Cost()
        {
            return .99;
        }
    }

    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage _beverage;
        protected double _price;

        public CondimentDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost() => _price + _beverage.Cost();
    }

    public class Mocha : CondimentDecorator
    {
        public override string Description => $"{_beverage.Description}, Mocha";

        public Mocha(Beverage beverage) : base(beverage)
        {
            _price = .20;
        }
    }

    public class Soy : CondimentDecorator
    {
        public override string Description => $"{_beverage.Description}, Soy";

        public Soy(Beverage beverage) : base(beverage)
        {
            _price = .10;
        }
    }
}
