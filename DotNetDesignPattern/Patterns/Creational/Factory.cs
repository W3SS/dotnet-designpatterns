using System.Collections.Generic;

namespace DotNetDesignPattern.Patterns.Creational
{
    public abstract class IPizza
    {
        protected List<string> _toppings = new List<string>();

        public string Name { get; set; }
        public string Dough { get; set; }
        public string Sauce { get; set; }


        public virtual IPizza Bake()
        {
            System.Console.WriteLine("Bake for 25 minutes at 350");
            return this;

        }

        public virtual IPizza Box()
        {
            System.Console.WriteLine("Place pizza in official PizzaStore box");
            return this;
        }

        public virtual IPizza Cut()
        {
            System.Console.WriteLine("Cutting the pizza into diagonal slices");
            return this;
        }

        public virtual IPizza Prepare()
        {
            System.Console.WriteLine("Preparing " + Name);
            System.Console.WriteLine("Tossing dough ...");
            System.Console.WriteLine("Adding sauce ...");
            System.Console.WriteLine("Adding toppings: ");
            foreach (var topping in _toppings)
            {
                System.Console.WriteLine("\t" + topping);
            }
            return this;
        }
    }

    public class CheesePizza : IPizza
    {
        public CheesePizza()
        {
            Name = "Cheese Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";

            _toppings.Add("Grated Reggiano Cheese");
        }
    }

    public class PepperoniPizza : IPizza
    {
        public PepperoniPizza()
        {
            Name = "Pepperon Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";

            _toppings.Add("Shredded Mozzarella Pepperoni");
        }

        public override IPizza Cut()
        {
            System.Console.WriteLine("Cutting the pizza into square slices");
            return this;
        }
    }

    public class ClamPizza : IPizza
    {
    }

    #region Simple Factory
    public interface ISimplePizzaFactory
    {
        IPizza CreatePizza(string type);
    }

    public class SimplePizzaFactory : ISimplePizzaFactory
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

    public class SimplePizzaStore
    {
        private ISimplePizzaFactory _factory;

        public SimplePizzaStore(ISimplePizzaFactory factory)
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
    #endregion

    #region Factory Method
    public abstract class PizzaStore
    {
        public abstract IPizza CreatePizza();
        public IPizza OrderPizza()
        {
            var pizza = CreatePizza();
            System.Console.WriteLine("Making " + pizza.Name);

            return pizza?.Prepare()?.Bake()?.Cut()?.Box();
        }
    }

    public class CheesePizzaFactory : PizzaStore
    {
        public override IPizza CreatePizza()
        {
            return new CheesePizza();
        }
    }

    public class PepperoniPizzaFactory : PizzaStore
    {
        public override IPizza CreatePizza()
        {
            return new PepperoniPizza();
        }
    }
    #endregion
}
