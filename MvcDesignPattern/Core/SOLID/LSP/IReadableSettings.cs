using System.Collections.Generic;

namespace MvcDesignPattern.Core
{
    public interface IReadableSettings
    {
        Dictionary<string, string> GetSettings();
    }
}
