using Newtonsoft.Json;
using System.Collections.Generic;

namespace AudiosearchNet.Models
{
    public class Show
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("network")]
        public Network Network { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ui_url")]
        public string AudiosearchUrl { get; set; }

        [JsonProperty("rss_url")]
        public string RssUrl { get; set; }

        [JsonProperty("buzz_score")]
        public string Score { get; set; }

        [JsonProperty("image_files")]
        public List<Image> Images { get; set; }

        [JsonProperty("sc_feed")]
        public string Feed { get; set; }

        [JsonProperty("web_profiles")]
        public List<object> Profiles { get; set; }

        [JsonProperty("episode_ids")]
        public List<int> EpisodeIds { get; set; }

        [JsonProperty("urls")]
        public object Urls { get; set; }

        [JsonProperty("recent_episodes")]
        public List<Episode> RecentEpisodes { get; set; }
    }
}
