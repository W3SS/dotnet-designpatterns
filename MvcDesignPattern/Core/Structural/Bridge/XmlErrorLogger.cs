using System;
using System.IO;

namespace MvcDesignPattern.Core
{
    public class XmlErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            if (!Directory.Exists(AppSettings.LogFileFolder))
            {
                Directory.CreateDirectory(AppSettings.LogFileFolder);
            }
            msg = $"<error><message>{msg}</message><timestamp>{DateTime.Now}</timestamp></error>";
            File.AppendAllText(AppSettings.LogFileFolder + "/errorlog.xml", msg);
        }
    }
}
