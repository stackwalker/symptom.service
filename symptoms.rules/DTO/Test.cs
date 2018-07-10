using Newtonsoft.Json;

namespace symptoms.rules
{
    public class Test
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("positiveResult")]
        public bool PositiveResult { get; set; }
        [JsonProperty("negativeResult")]
        public bool NegativeResult { get; set; }
    }
}