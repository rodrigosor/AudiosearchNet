using Newtonsoft.Json;
using System.Collections.Generic;

namespace AudiosearchNet.Models
{
	public class Url
	{
		/// <summary>
		/// TODO: Confirm: Added as a result of a call to ShowById. Not sure if this class is the same for other API calls.
		/// </summary>
		[JsonProperty("full")]
		public string full { get; set; }
		[JsonProperty("thumb")]
		public string thumb { get; set; }
	}
}
