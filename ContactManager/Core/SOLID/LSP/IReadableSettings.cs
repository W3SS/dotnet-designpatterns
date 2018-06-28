using System.Collections.Generic;

namespace ContactManager.Core
{
    public interface IReadableSettings
    {
        Dictionary<string, string> GetSettings();
    }
}
