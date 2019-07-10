using Newtonsoft.Json;
using System.Collections.Generic;

namespace Teams.Notifications
{
    public class PotentialAction
    {
        [JsonProperty("@type")]
        public string Type { get; } = "OpenUri";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("targets")]
        public IList<PotentialActionLink> Targets { get; set; }
    }
}
