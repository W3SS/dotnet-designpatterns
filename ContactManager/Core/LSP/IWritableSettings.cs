using System.Collections.Generic;

namespace ContactManager.Core
{
    public interface IWritableSettings
    {
        string SetSettings(Dictionary<string, string> settings);
    }
}
