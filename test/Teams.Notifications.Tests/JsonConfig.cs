using System.Text.Json;

namespace Nogic.Teams.Notifications.Tests
{
    public static class JsonConfig
    {
        public static JsonSerializerOptions Default = new(JsonSerializerDefaults.Web)
        {
            IgnoreNullValues = true,
            WriteIndented = false
        };
    }
}
