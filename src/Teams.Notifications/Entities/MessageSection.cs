using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nogic.Teams.Notifications.Entities
{
    public record MessageSection(
        [property: JsonPropertyName("title")] string? Title = null,
        [property: JsonPropertyName("facts")] IList<MessageFact>? Facts = null
    );
    public record MessageFact(
        [property: JsonPropertyName("name")] string? Name,
        [property: JsonPropertyName("value")] string? Value
    );
}
