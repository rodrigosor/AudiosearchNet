using Newtonsoft.Json;

namespace AudiosearchNet.Models
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
