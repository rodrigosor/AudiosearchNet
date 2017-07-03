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
			string response = ReadResponse(keyWords);

			if (string.IsNullOrEmpty(response))
			{
				response = this.GetJsonResponse(string.Concat(Endpoint.SEARCH_SHOW_BY_QUERY, keyWords));
			}

			WriteResponse(keyWords, response);
			return JsonConvert.DeserializeObject<AudiosearchNetApiResult<Show>>(response);
		}

		/// <summary>
		/// Returns search results for Shows.
		/// </summary>
		/// <param name="query">Query to search shows.</param>
		/// <returns>Results for Shows.</returns>
		public AudiosearchNetApiResult<Show> GetShowsByQuery(Query query)
		{
			var response = this.GetJsonResponse(string.Concat(Endpoint.SEARCH_SHOW_BY_QUERY, query.ToString()));

			return JsonConvert.DeserializeObject<AudiosearchNetApiResult<Show>>(response);
		}

		public dynamic GetShowsById_Dynamic(int id)
		{
			string response = ReadResponse(id.ToString());

			if (string.IsNullOrEmpty(response))
			{
				response = this.GetJsonResponse(string.Concat(Endpoint.SHOW_BY_ID, id));
			}

			dynamic results = JsonConvert.DeserializeObject<dynamic>(response);

			return results;
		}

		#endregion

		#region Categories

		public dynamic GetCategoriesDynamic()
		{
			string response = CachedResponse("Categories");
			dynamic results = JsonConvert.DeserializeObject<dynamic>(response);

			return results;
		}

		public List<Category> GetCategories()
		{
			string response = CachedResponse("Categories");
			var results = JsonConvert.DeserializeObject<List<Category>>(response);

			return results;
		}

		/// <summary>
		/// Returns a cached response based on the given ID.
		/// Cache is in %TEMP%/AudioSearch
		/// </summary>
		/// <param name="id">A unique identifier of the response</param>
		/// <returns>Returns null if the cache file does not exist, else returns the contents of the response in the file identified by the id</returns>
		private string CachedResponse(string id)
		{
			string response = ReadResponse(id);
			if (string.IsNullOrEmpty(response))
			{
				response = this.GetJsonResponse(Endpoint.CATEGORIES);
			}

			return response;
		}

		#endregion

		#region Caching results of a response to file

		/// <summary>
		/// Write a JSON response to a temp file so it can be interrogated later
		/// </summary>
		/// <param name="id"></param>
		/// <param name="response"></param>
		/// <returns></returns>
		private bool WriteResponse(int id, string response)
		{
			DirectoryInfo directoryInfo = GetTempCacheFileName();
			string resultsFile = directoryInfo.FullName + "AudioSearchLogShow_" + id + ".json";

			WriteToFile(response, resultsFile);

			return true;
		}

		/// <summary>
		/// Write a JSON response to a temp file so it can be or used as a cache
		/// </summary>
		/// <param name="from"></param>
		/// <param name="response"></param>
		/// <returns></returns>
		private bool WriteResponse(string from, string response)
		{
			DirectoryInfo directoryInfo = GetTempCacheFileName();
			string resultsFile = directoryInfo.FullName + "AudioSearchLogShow_" + from + ".json";
			WriteToFile(response, resultsFile);

			return true;
		}

		private string ReadResponse(string from)
		{
			DirectoryInfo directoryInfo = GetTempCacheFileName();
			string resultsFile = directoryInfo.FullName + "AudioSearchLogShow_" + from + ".json";
			if (System.IO.File.Exists(directoryInfo.FullName))
			{

				var response = System.IO.File.ReadAllText(directoryInfo.FullName);
				return response;
			}

			return null;
		}

		private static DirectoryInfo GetTempCacheFileName()
		{
			return Directory.CreateDirectory(Path.GetTempPath() + @"\Audiosear.ch\");
			// Note: This is just temporary until the results are stored in the DB
		}

		private static void WriteToFile(string response, string filename)
		{
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}

			System.IO.File.WriteAllText(filename, response);
		}
		#endregion
	}
}
