using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace symptoms.rules
{
    public class ConditionMap
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("basePrevalence")]
        public decimal BasePrevalence { get; set; }
        [JsonProperty("testRatios")]
        public List<TestRatio> TestRatios { get; set; }
    }
}
