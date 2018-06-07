using DotNetDesignPattern.SOLID.OCP;
using DotNetDesignPattern.SOLID.SRP;
using System;

namespace DotNetDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Solid();

            Console.ReadKey();
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
        }
    }
}
