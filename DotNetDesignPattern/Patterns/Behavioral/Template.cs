using System;

namespace DotNetDesignPattern.Patterns.Behavioral
{
    public abstract class CaffeineBeverage
    {
        public abstract void Brew();

        public abstract void AddCondiments();

        public void BoilWalter() => Console.WriteLine("Boilling walter");

        public void PourInCup() => Console.WriteLine("Pouring into cup");

        public void PrepareRecipe()
        {
            BoilWalter();
            Brew();
            PourInCup();
            if (WantCondiments())
            {
                AddCondiments();
            }
        }

        // hook method
        public virtual bool WantCondiments() => true;
    }

    public class Tea : CaffeineBeverage
    {
        public override void AddCondiments() => Console.WriteLine("Adding lemon");

        public override void Brew() => Console.WriteLine("Steeping the tea");

        public override bool WantCondiments() => false;
    }

    public class Coffee : CaffeineBeverage
    {
        public override void AddCondiments() => Console.WriteLine("Adding sugar and milk");

        public override void Brew() => Console.WriteLine("Dripping coffee through filter");
    }
}
