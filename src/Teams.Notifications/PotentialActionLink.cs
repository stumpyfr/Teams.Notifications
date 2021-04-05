using Newtonsoft.Json;

namespace Teams.Notifications
{
    public class PotentialActionLink
    {
        [JsonProperty("os")]
        public string Type { get; set; } = "default";

        [JsonProperty("uri")]
        public string? Value { get; set; }
    }
}
