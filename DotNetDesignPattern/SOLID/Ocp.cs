using System;
using System.IO;

namespace DotNetDesignPattern.SOLID.OCP
{
    public class Logger
    {
        public enum LogType
        {
            Console,
            File
        };

        // break closed to modified if added more log types
        public void Log(string error, LogType type)
        {
            switch (type)
            {
                case LogType.Console:
                    Console.WriteLine(error);
                    break;
                case LogType.File:
                    File.WriteAllText("log.txt", error);
                    break;
                default:
                    break;
            }
        }
    }

    // handle
    public interface ILogger
    {
        void Log(string error);
    }

    public class LogToOutput : ILogger
    {
        public void Log(string error) => Console.WriteLine(error);
    }

    public class LogToFile : ILogger
    {
        public void Log(string error) => File.WriteAllText("log.txt", error);
    }
}
