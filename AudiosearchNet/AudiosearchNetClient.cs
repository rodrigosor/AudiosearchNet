using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AudiosearchNet
{
    public class AudiosearchNetClient
    {
        private string _accessToken;
        private string _accessTokenType;
        private string _applicationId;
        private string _applicationSecret;

        public AudiosearchNetClient(string applicationId, string applicationSecret)
        {
            this._applicationId = applicationId;
            this._applicationSecret = applicationSecret;

            if (string.IsNullOrWhiteSpace(this._applicationId) || string.IsNullOrWhiteSpace(this._applicationSecret))
            {
                throw new NullReferenceException("Must define application id and application secret");
            }

            var signature = string.Concat(this._applicationId, ":", this._applicationSecret).Base64Encode();
            var parameters = new[] { new KeyValuePair<string, string>("grant_type", "client_credentials") };
            var results = string.Concat(Config.HOST_BASE_URL, "/oauth/token").Authorize(signature, parameters).Result;

            this._accessToken = results["access_token"].ToString();
            this._accessTokenType = results["token_type"].ToString();
        }

        public string GetShow(string query)
        {
            var endpoint = string.Format("/search/shows/{0}", query);
            var url = string.Concat(Config.API_URL, endpoint);
            var results = url.Get(this._accessToken).Result;

            return results;
        }
    }
}
