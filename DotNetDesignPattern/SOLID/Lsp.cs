using System;

namespace DotNetDesignPattern.SOLID.LSP
{
    public partial class Student
    {
        //public virtual void SecretaryCandidate()
        //{
        //    // do something
        //}
    }
    public class NormalStudent : Student, ICandidate
    {
        public void SecretaryCandidate() => Console.WriteLine("Normal student secretary candidate");
    }

    public class AdvancedStudent : Student, ICandidate
    {
        public void SecretaryCandidate() => Console.WriteLine("Advanced student secretary candidate");
    }

    // problem
    public class ForeignStudent : Student
    {
        //public override void SecretaryCandidate()
        //{
        //    throw new Exception("Not allowed");
        //}
    }

    // handle
    public interface ICandidate
    {
        void SecretaryCandidate();
    }
}
