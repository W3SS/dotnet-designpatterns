using System;
using System.IO;

namespace MvcDesignPattern.Core
{
    public class TextFileErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            if (!Directory.Exists(AppSettings.LogFileFolder))
            {
                Directory.CreateDirectory(AppSettings.LogFileFolder);
            }
            msg += $"[{DateTime.Now}]";
            msg += "\r\n";
            File.AppendAllText(AppSettings.LogFileFolder + "/errorlog.txt", msg);
        }
    }
}
