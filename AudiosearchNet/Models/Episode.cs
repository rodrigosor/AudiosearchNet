using Newtonsoft.Json;

namespace AudiosearchNet.Models
{
    public class Episode
    {
        [JsonProperty("item_id")]
        public int Id { get; set; }

        [JsonProperty("file_name")]
        public string Name { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("file_status")]
        public string Status { get; set; }
    }
}
