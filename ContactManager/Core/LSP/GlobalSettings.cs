using System;
using System.Collections.Generic;

namespace ContactManager.Core
{
    public class GlobalSettings : IReadableSettings, IWritableSettings
    {
        public Dictionary<string, string> GetSettings()
        {
            return new Dictionary<string, string>
            {
                { "Theme", "Summer" }
            };
        }

        public string SetSettings(Dictionary<string, string> settings)
        {
            foreach (var item in settings)
            {
                // save settings
            }
            return $"Global settings saved on {DateTime.Now}";
        }
    }
}
