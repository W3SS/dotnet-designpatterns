using System.Collections.Generic;

namespace MvcDesignPattern.Core
{
    public interface IWritableSettings
    {
        string SetSettings(Dictionary<string, string> settings);
    }
}
