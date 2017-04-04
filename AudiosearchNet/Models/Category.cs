using Newtonsoft.Json;

namespace AudiosearchNet.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
