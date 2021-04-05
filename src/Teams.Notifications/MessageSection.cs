using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Teams.Notifications
{
    public class MessageSection
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("facts")]
        public IList<MessageFact>? Facts { get; set; }
    }
}
