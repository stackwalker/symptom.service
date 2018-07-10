using Newtonsoft.Json;

namespace symptoms.rules
{
    public class TestRatio
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("positiveLR")]
        public LikelihoodRatio PositiveLR { get; set; }
        [JsonProperty("negativeLR")]
        public LikelihoodRatio NegativeLR { get; set; }
    }

    public class LikelihoodRatio
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("ciLower")]
        public decimal LowerCI { get; set; }
        [JsonProperty("ciUpper")]
        public decimal UpperCI { get; set; }
    }
}