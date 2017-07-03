using Newtonsoft.Json;
using System.Collections.Generic;

namespace AudiosearchNet.Models
{
	/// <summary>
	/// TODO: Confirm: Added as a result of a call to ShowById. Not sure if this class is the same for other API calls.
	/// </summary>
	public class Urls
	{
		[JsonProperty("self")]
		public string self { get; set; }
		[JsonProperty("ui")]
		public string ui { get; set; }
	}
}
