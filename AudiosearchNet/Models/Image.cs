using Newtonsoft.Json;

namespace AudiosearchNet.Models
{
    public class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("item_id")]
        public int? ItemId { get; set; }

        [JsonProperty("file")]
        public File File { get; set; }

        [JsonProperty("original_file_url")]
        public string CoverUrl { get; set; }

        [JsonProperty("md5hash")]
        public string Md5Hash { get; set; }
    }
}
