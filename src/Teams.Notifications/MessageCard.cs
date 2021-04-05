using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Teams.Notifications
{
    public class MessageCard
    {
        [JsonPropertyName("@type")]
        public string Type { get; } = "MessageCard";

        [JsonPropertyName("@context")]
        public string Context { get; } = "http://schema.org/extensions";

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("themeColor")]
        public string? Color { get; set; }

        [JsonPropertyName("sections")]
        public IList<MessageSection>? Sections { get; set; }

        [JsonPropertyName("potentialAction")]
        public IList<PotentialAction>? PotentialActions { get; set; }
    }
}
