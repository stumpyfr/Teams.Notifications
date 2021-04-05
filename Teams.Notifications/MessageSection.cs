using Newtonsoft.Json;
using System.Collections.Generic;

namespace Teams.Notifications
{
    public class MessageSection
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("facts")]
        public IList<MessageFact> Facts { get; set; }
    }
}
