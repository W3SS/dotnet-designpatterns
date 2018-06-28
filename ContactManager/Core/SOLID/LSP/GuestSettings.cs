using System.Collections.Generic;

namespace ContactManager.Core
{
    public class GuestSettings : IReadableSettings
    {
        public Dictionary<string, string> GetSettings()
        {
            return new Dictionary<string, string>
            {
                { "GuestName", "John" }
            };
        }
    }
}
