using Newtonsoft.Json;

namespace AudiosearchNet.Models
{
    /// <summary>
    /// Audiosear.ch OAuth Access Token.
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// Type of access token.
        /// </summary>
        [JsonProperty("token_type")]
        public string Type { get; set; }

        /// <summary>
        /// The token it self.
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
