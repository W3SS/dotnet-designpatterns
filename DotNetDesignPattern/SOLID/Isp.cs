using System;

namespace DotNetDesignPattern.SOLID.ISP
{
    public interface IStudy
    {
        void LearnMath();
        void LearnEnglish();
        void LearnFrench();
    }

    public class NormalStudent : SRP.Student, IStudy
    {
        public void LearnEnglish() => Console.WriteLine("Learning English");

        public void LearnMath() => Console.WriteLine("Learning Math");

        // problem
        public void LearnFrench() => throw new Exception("I do not need to learn French");
    }

    // handlle
    public interface ICommonStudy
    {
        void LearnMath();
    }

    public interface INormalStudy
    {
        void LearnEnglish();
    }

    public interface IAdvancedStudy
    {
        void LearnFrench();
    }

    public class AdvancedStudent : SRP.Student, ICommonStudy, IAdvancedStudy
    {
        public void LearnFrench() => Console.WriteLine("Learning French");

        public void LearnMath() => Console.WriteLine("Learning Math");
    }
}
