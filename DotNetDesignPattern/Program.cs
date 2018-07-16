using DotNetDesignPattern.Patterns.Behavioral;
using DotNetDesignPattern.Patterns.Creational;
using DotNetDesignPattern.Patterns.Structural;
using DotNetDesignPattern.SOLID.DIP;
using DotNetDesignPattern.SOLID.LSP;
using DotNetDesignPattern.SOLID.OCP;
using DotNetDesignPattern.SOLID.SRP;
using System;
using System.Collections.Generic;

namespace DotNetDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Command();

            Console.ReadKey();
        }

        public static void Command()
        {
            var invoker = new Invoker();
            var receiver = new Calculator();

            invoker.Compute(CommandFactory.GetCommand(receiver, '+', 100));
            invoker.Compute(CommandFactory.GetCommand(receiver, '-', 50));
            invoker.Compute(CommandFactory.GetCommand(receiver, '*', 10));
            invoker.Compute(CommandFactory.GetCommand(receiver, '/', 2));

            invoker.Undo(3);
            invoker.Redo(2);
        }

        public static void Singleton()
        {
            var mySingleton = MySingleton.Instance;
            Console.WriteLine(mySingleton.Count);

            var otherSingleton = MySingleton.Instance;
            Console.WriteLine(otherSingleton.Count);
        }

        public static void Factory()
        {
            // simple factory
            var simpleFactory = new SimplePizzaFactory();
            var simpleStore = new SimplePizzaStore(simpleFactory);

            var pizza = simpleStore.OrderPizza("cheese");
            pizza = simpleStore.OrderPizza("pepperoni");

            // factory method
            pizza = new CheesePizzaFactory().OrderPizza();
            pizza = new PepperoniPizzaFactory().OrderPizza();
        }

        public static void Decorator()
        {
            var espresso = new Espresso();
            Console.WriteLine($"{espresso.Description} ${espresso.Cost()}");

            Beverage houseblend = new HouseBlend();
            houseblend = new Mocha(houseblend);
            houseblend = new Mocha(houseblend);
            houseblend = new Soy(houseblend);
            Console.WriteLine($"{houseblend.Description} ${houseblend.Cost()}");
        }

        public static void Observer()
        {
            // custom
            var weatherData = new WeatherData();

            var currentDisplay = new CurrentConditionDisplay(weatherData);

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);

            // using buildin class
            var provider = new LocationTracker();

            var reporter1 = new LocationReporter("Report1");
            reporter1.Subscribe(provider);

            var reporter2 = new LocationReporter("Report2");
            reporter2.Subscribe(provider);

            provider.TrackLocation(new Location(47.6456, -122.1312));
            reporter1.Unsubscribe();
            provider.TrackLocation(new Location(47.6677, -122.1199));
            provider.TrackLocation(null);
            provider.EndTransmission();
        }

        public static void Solid()
        {
            Console.WriteLine("SOLID");

            // srp
            var studentWithLog = new StudentWithLog();
            studentWithLog.Remove(1);

            // ocp
            ILogger logger = new LogToOutput();
            logger.Log("Log to output");

            // lsp
            var students = new List<ICandidate>
            {
                new NormalStudent(),
                new AdvancedStudent(),
                // new ForeignStudent()
            };

            foreach (var student in students)
            {
                student.SecretaryCandidate();
            }

            // dip
            new LogManagerDip(new LogToOutput()).Log("Log to output with DIP");
            new LogManagerDip(new LogToFile()).Log("Log to file with DIP");
        }
    }
}
