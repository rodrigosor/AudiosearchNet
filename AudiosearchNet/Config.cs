namespace AudiosearchNet
{
	/// <summary>
	/// Configuration for the project
	/// </summary> 
    internal class Config
    {
        public const string HOST_PROTOCOL = @"https://";
        public const string HOST_BASE_URL = HOST_PROTOCOL + @"www.audiosear.ch";
        public const string API_URL = HOST_BASE_URL + @"/api";
        public const string CLIENT_VERSION = "1.0.0";
        public const string CLIENT_USER_AGENT = "audiosearch-client-dotNet";
        public const string AUTHORIZATION_ENDPOINT = @"/oauth/token";
    }
}
