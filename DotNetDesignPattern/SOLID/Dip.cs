using DotNetDesignPattern.SOLID.OCP;

namespace DotNetDesignPattern.SOLID.DIP
{
    // problem
    public class LogManager
    {
        public void LogToOutput(string error)
        {
            var logger = new LogToOutput();
            logger.Log(error);
        }

        public void LogToFile(string error)
        {
            var logger = new LogToFile();
            logger.Log(error);
        }
    }

    // handle
    public class LogManagerDip
    {
        private readonly ILogger _logger;

        public LogManagerDip(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string error) => _logger.Log(error);
    }
}
