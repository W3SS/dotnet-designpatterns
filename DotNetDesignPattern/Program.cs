using DotNetDesignPattern.SOLID.SRP;
using System;
using System.IO;

namespace DotNetDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // SOLID
            Console.WriteLine("SOLID");

            var fileName = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\log.txt";

            var studentWithLog = new StudentWithLog();

            studentWithLog.Remove(1);

            Console.ReadKey();
        }
    }
}
