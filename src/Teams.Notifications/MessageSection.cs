using System.Collections.Generic;
using Newtonsoft.Json;

namespace Teams.Notifications
{
    public class MessageSection
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("facts")]
        public IList<MessageFact>? Facts { get; set; }
    }
}
