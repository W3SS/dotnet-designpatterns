using System.Collections.Generic;

namespace MvcDesignPattern.Core
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
