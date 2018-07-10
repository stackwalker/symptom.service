using Newtonsoft.Json;

namespace symptoms.rules
{
    public class Condition
    {
        [JsonProperty("commonName")]
        public string CommonName { get; set; }
    }
}