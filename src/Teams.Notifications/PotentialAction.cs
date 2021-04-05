using System.Collections.Generic;
using Newtonsoft.Json;

namespace Teams.Notifications
{
    public class PotentialAction
    {
        public PotentialAction() : this("") { }

        public PotentialAction(string name) => Name = name;

        [JsonProperty("@type")]
        public string Type { get; } = "OpenUri";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("targets")]
        public IList<PotentialActionLink> Targets { get; set; } = new List<PotentialActionLink>();
    }
}
