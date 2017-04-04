using AudiosearchNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AudiosearchNet
{
    /// <summary>
    /// Extends AudiosearchNetClient class adding some util methods.
    /// </summary>
    public static class AudiosearchNetExtensions
    {
        /// <summary>
        /// Creates a basic signature for Authorization headers.
        /// </summary>
        /// <returns>A basic signature for Authorization headers.</returns>
        public static string CreateSignature(this AudiosearchNetClient client)
        {
            return string.Format("Basic {0}",
                    string.Concat(client.ApplicationId, ":", client.ApplicationSecret).ToBase64String()
                );
        }

        /// <summary>
        /// Creates an AccessToken OAuth object.
        /// </summary>
        /// <param name="endpoint">The Audiosear.ch endpoint authorization path.</param>
        /// <returns>An AccessToken object</returns>
        public static AccessToken Authorize(this AudiosearchNetClient client, string endpoint)
        {
            try
            {
                var parameters = new Dictionary<string, string> { { "grant_type", "client_credentials" } };
                var request = (HttpWebRequest)WebRequest.Create(string.Concat(Config.HOST_BASE_URL, endpoint));

                request.Headers.Add(
                        HttpRequestHeader.Authorization,
                        client.CreateSignature()
                    );

                return JsonConvert.DeserializeObject<AccessToken>(
                        request.Post(parameters)
                    );
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Failure in authorization process", ex);
            }
        }

        /// <summary>
        /// Gets the json response for an API call.
        /// </summary>
        /// <param name="endpoint">An Audiosear.ch api endpoint path.</param>
        /// <returns>The json response for an API call</returns>
        public static string GetJsonResponse(this AudiosearchNetClient client, string endpoint)
        {
            try
            {
                if (client.AccessToken != null)
                {
                    var request = (HttpWebRequest)WebRequest.Create(string.Concat(Config.API_URL, endpoint));

                    request.UserAgent = string.Concat(Config.CLIENT_USER_AGENT, "/", Config.CLIENT_VERSION);
                    request.Headers.Add(
                            HttpRequestHeader.Authorization,
                            string.Format("Bearer {0}", client.AccessToken.Token)
                        );

                    return request.Get();
                }
                else
                {
                    throw new NullReferenceException("Access Token cannot be null");
                }
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Failure in get json response process", ex);
            }
        }
    }
}
