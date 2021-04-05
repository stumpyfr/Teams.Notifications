using System.Text.Json.Serialization;

namespace Teams.Notifications
{
    public class PotentialActionLink
    {
        [JsonPropertyName("os")]
        public string Type { get; set; } = "default";

        [JsonPropertyName("uri")]
        public string? Value { get; set; }
    }
}
