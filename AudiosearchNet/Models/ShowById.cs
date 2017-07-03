using Newtonsoft.Json;
using System.Collections.Generic;

namespace AudiosearchNet.Models
{
 	public class ShowById
	{
		[JsonProperty("id")]
		public int id { get; set; }
		[JsonProperty("title")]
		public string title { get; set; }
		[JsonProperty("description")]
		public string description { get; set; }
		[JsonProperty("network")]
		public object network { get; set; }
		[JsonProperty("itunes_id")]
		public int itunes_id { get; set; }
		[JsonProperty("categories")]
		public List<string> categories { get; set; }
		[JsonProperty("buzz_score")]
		public string buzz_score { get; set; }
		[JsonProperty("image_files")]
		public List<ImageFile> image_files { get; set; }
		[JsonProperty("number_of_episodes")]
		public int number_of_episodes { get; set; }
		[JsonProperty("episode_ids")]
		public List<int> episode_ids { get; set; }
		[JsonProperty("urls")]
		public Urls urls { get; set; }
		[JsonProperty("rss_url")]
		public string rss_url { get; set; }
		[JsonProperty("sc_feed")]
		public object sc_feed { get; set; }
		[JsonProperty("web_profiles")]
		public object web_profiles { get; set; }
	}
}
