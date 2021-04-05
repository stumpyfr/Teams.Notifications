using Newtonsoft.Json;

namespace Teams.Notifications
{
    public class MessageFact
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
