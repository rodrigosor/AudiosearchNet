using Newtonsoft.Json;
using System.Collections.Generic;

namespace AudiosearchNet
{
    public class AudiosearchNetApiResult<T>
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("total_results")]
        public int Count { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("results_per_page")]
        public int ResultsPerPage { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
