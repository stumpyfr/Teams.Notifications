using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teams.Notifications
{
    public class PotentialActionLink
    {
        private string name;

        [JsonProperty("os")]
        public string Type
        {
            get
            {
                return this.name ?? "default";
            }
            set
            {
                this.name = value;
            }
        }

        [JsonProperty("uri")]
        public string Value { get; set; }
    }
}
