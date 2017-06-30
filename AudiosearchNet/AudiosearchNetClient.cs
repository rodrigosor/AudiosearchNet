using AudiosearchNet.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;

namespace AudiosearchNet
{
	/// <summary>
	/// A client to handles API calls.
	/// </summary>
	public class AudiosearchNetClient
	{
		/// <summary>
		/// Audiosear.ch OAuth Access Token.
		/// </summary>
		public AccessToken AccessToken { get; private set; }

		/// <summary>
		/// Audiosear.ch Application Id.
		/// </summary>
		public string ApplicationId { get; private set; }

		/// <summary>
		/// Audiosear.ch Application Secret.
		/// </summary>
		public string ApplicationSecret { get; private set; }

		/// <summary>
		/// Creates an instance of a client to handles API calls.
		/// </summary>
		/// <param name="applicationId">Audiosear.ch Application Id.</param>
		/// <param name="applicationSecret">Audiosear.ch Application Secret.</param>
		public AudiosearchNetClient(string applicationId, string applicationSecret)
		{
			ApplicationId = applicationId;
			ApplicationSecret = applicationSecret;
			AccessToken = this.Authorize(Config.AUTHORIZATION_ENDPOINT);
		}

		#region Shows

		/// <summary>
		/// Returns search results for Shows.
		/// </summary>
		/// <param name="keyWords">Keyworkds to search shows.</param>
		/// <returns>Results for Shows.</returns>
		public AudiosearchNetApiResult<Show> GetShowsByKeyWords(string keyWords)
		{
			var response = this.GetJsonResponse(
					string.Concat(Endpoint.SEARCH_SHOW_BY_QUERY, keyWords)
				);

			return JsonConvert.DeserializeObject<AudiosearchNetApiResult<Show>>(response);
		}

		/// <summary>
		/// Returns search results for Shows.
		/// </summary>
		/// <param name="query">Query to search shows.</param>
		/// <returns>Results for Shows.</returns>
		public AudiosearchNetApiResult<Show> GetShowsByQuery(Query query)
		{
			var response = this.GetJsonResponse(
					string.Concat(Endpoint.SEARCH_SHOW_BY_QUERY, query.ToString())
				);

			return JsonConvert.DeserializeObject<AudiosearchNetApiResult<Show>>(response);
		}

		public dynamic GetShowsById(int id)
		{
			var response = this.GetJsonResponse(string.Concat(Endpoint.SHOW_BY_ID, id));

			dynamic results = JsonConvert.DeserializeObject<dynamic>(response);

			return results;
		}

		/// <summary>
		/// Write a JSON response to a temp file so it can be interrogated later
		/// </summary>
		/// <param name="id"></param>
		/// <param name="response"></param>
		/// <returns></returns>
		private bool WriteResponse(int id, string response)
		{
			var directoryInfo = Directory.CreateDirectory(Path.GetTempPath() + @"\Audiosear.ch\");   // Note: This is just temporary until the results are stored in the DB
			string resultsFile = directoryInfo.FullName + "AudioSearchLogShow_" + id + ".json";

			if (System.IO.File.Exists(resultsFile))
			{
				System.IO.File.Delete(resultsFile);
			}

			System.IO.File.WriteAllText(resultsFile, response);

			return true;
		}

		#endregion
	}
}
