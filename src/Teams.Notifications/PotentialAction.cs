using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Teams.Notifications
{
    public class PotentialAction
    {
        public PotentialAction() : this("") { }

        public PotentialAction(string name) => Name = name;

        [JsonPropertyName("@type")]
        public string Type { get; } = "OpenUri";

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("targets")]
        public IList<PotentialActionLink> Targets { get; set; } = new List<PotentialActionLink>();
    }
}
