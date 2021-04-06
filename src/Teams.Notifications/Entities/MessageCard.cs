using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Teams.Notifications.Entities
{
    public record MessageCard(
        [property: JsonPropertyName("title")] string? Title = null,
        [property: JsonPropertyName("text")] string? Text = null,
        [property: JsonPropertyName("themeColor")] string? ThemeColor = null,
        [property: JsonPropertyName("sections")] IList<MessageSection>? Sections = null,
        [property: JsonPropertyName("potentialAction")] IList<OpenUriAction>? PotentialActions = null
    )
    {
        [JsonPropertyName("@type")]
        public string Type => "MessageCard";

        [JsonPropertyName("@context")]
        public string Context => "http://schema.org/extensions";
    }
}
