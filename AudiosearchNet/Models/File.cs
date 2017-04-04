using Newtonsoft.Json;

namespace AudiosearchNet.Models
{
    public class File
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("thumb")]
        public File Thumbnail { get; set; }
    }
}
