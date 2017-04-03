using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AudiosearchNet
{
    public static class AudiosearchNetExtensions
    {
        public static string Base64Encode(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        public static string ToEndpoint(this string path)
        {
            return string.Concat(Config.API_URL, path);
        }

        public static async Task<Dictionary<string, object>> Authorize(this string url, string signature, KeyValuePair<string, string>[] parameters)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Basic {0}", signature));
                var results = await httpClient.PostAsync(url, new FormUrlEncodedContent(parameters));
                var content = await results.Content.ReadAsStringAsync();
                return new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(content);
            }
        }

        public static async Task<string> Get(this string url, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                httpClient.DefaultRequestHeaders.Add("User-Agent", "audiosearch-client-dotNet/1.0.0");

                var results = await httpClient.GetAsync(url);
                var content = await results.Content.ReadAsStringAsync();

                return content;
            }
        }
    }
}
