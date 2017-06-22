using Newtonsoft.Json;

namespace AudiosearchNet.Models
{
    public class Network
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
