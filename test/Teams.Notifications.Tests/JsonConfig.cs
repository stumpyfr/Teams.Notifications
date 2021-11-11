using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nogic.Teams.Notifications.Tests;

public static class JsonConfig
{
    public static JsonSerializerOptions Default = new(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.Never
    };
}
