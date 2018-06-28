using System.Collections.Generic;

namespace MvcDesignPattern.Core
{
    public class SettingHelpers
    {
        public static Dictionary<IReadableSettings, Dictionary<string, string>> GetAllSettings(List<IReadableSettings> items)
        {
            var allSettings = new Dictionary<IReadableSettings, Dictionary<string, string>>();
            foreach (var item in items)
            {
                allSettings.Add(item, item.GetSettings());
            }
            return allSettings;
        }

        public static List<string> SetAllSettings(List<IWritableSettings> items, List<Dictionary<string, string>> values)
        {
            var messages = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                messages.Add(items[i].SetSettings(values[i]));
            }
            return messages;
        }
    }
}
