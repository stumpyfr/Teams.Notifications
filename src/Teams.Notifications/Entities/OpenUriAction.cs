using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nogic.Teams.Notifications.Entities
{
    public record OpenUriAction(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("targets")] IList<OpenUriTarget> Targets
    )
    {
        [JsonPropertyName("@type")]
        public string Type => "OpenUri";
    }

    public record OpenUriTarget(
        [property: JsonPropertyName("uri")] string Uri,
        [property: JsonPropertyName("os")] string OS = "default"
    );
}
