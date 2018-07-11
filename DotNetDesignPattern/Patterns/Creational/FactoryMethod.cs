namespace DotNetDesignPattern.Patterns.Creational
{
    public abstract class IPizza
    {
        public virtual IPizza Bake()
        {
            System.Console.WriteLine("Bake");
            return this;

        }

        public virtual IPizza Box()
        {
            System.Console.WriteLine("Box");
            return this;
        }

        public virtual IPizza Cut()
        {
            System.Console.WriteLine("Cut");
            return this;
        }

        public virtual IPizza Prepare()
        {
            System.Console.WriteLine("Prepare");
            return this;
        }
    }

    public class CheesePizza : IPizza
    {
    }

    public class PepperoniPizza : IPizza
    {
    }

    public class ClamPizza : IPizza
    {
    }

    #region Simple Factory
    public interface ISimplePizzaFactory
    {
        IPizza CreatePizza(string type);
    }

    public class NewYorkPizzaFactory : ISimplePizzaFactory
    {
        public IPizza CreatePizza(string type)
        {
            switch (type)
            {
                case "cheese": return new CheesePizza();
                case "pepperoni": return new PepperoniPizza();
                case "clam": return new ClamPizza();
                default:
                    break;
            }

            return null;
        }
    } 
    #endregion

    public class PizzaStore
    {
        private ISimplePizzaFactory _factory;

        public PizzaStore(ISimplePizzaFactory factory)
        {
            _factory = factory;
        }

        public IPizza OrderPizza(string type)
        {
            return _factory.CreatePizza(type)
                ?.Prepare()
                ?.Bake()
                ?.Cut()
                ?.Box();
        }
    }
}
