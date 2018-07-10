using Newtonsoft.Json;
using System.Collections.Generic;

namespace symptoms.rules
{
    public class RuleRequest
    {
        [JsonProperty("condition")]
        public Condition Condition { get; set; }
        [JsonProperty("symptoms")]
        public List<Test> Tests { get; set; }
    }
}