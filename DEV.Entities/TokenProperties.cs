using Newtonsoft.Json;

namespace DEV.Entities
{
    [JsonObject("ServiceTokenManagement")]
    public class TokenProperties
    {
        [JsonProperty("SecretKey")]
        public string SecretKey { get; set; }

        [JsonProperty("Issuer")]
        public string Issuer { get; set; }

        [JsonProperty("Audience")]
        public string Audience { get; set; }
    }
}
