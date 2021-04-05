using Newtonsoft.Json;
using System.Collections.Generic;

namespace Teams.Notifications
{
    public class PotentialAction
    {
        public PotentialAction()
        {
            this.Targets = new List<PotentialActionLink>();
        }

        public PotentialAction(string name)
        {
            this.Name = name;
            this.Targets = new List<PotentialActionLink>();
        }

        [JsonProperty("@type")]
        public string Type { get; } = "OpenUri";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("targets")]
        public IList<PotentialActionLink> Targets { get; set; }
    }
}
