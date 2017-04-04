using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AudiosearchNet
{
    /// <summary>
    /// Extends HttpWebRequest class adding some util methods.
    /// </summary>
    public static class HttpWebRequestExtensions
    {
        /// <summary>
        /// Make a HttpPost using the HttpWebRequest object.
        /// </summary>
        /// <param name="request">A HttpWebRequest object.</param>
        /// <param name="parameters">A dictionary of post parameters.</param>
        /// <returns>A String response.</returns>
        public static string Post(this HttpWebRequest request, Dictionary<string, string> parameters)
        {
            var data = parameters.ToPostData().ToByteArray();

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseString = new StreamReader(response.GetResponseStream()))
                    {
                        return responseString.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// Make a HttpGet using the HttpWebRequest object.
        /// </summary>
        /// <param name="request">A HttpWebRequest object.</param>
        /// <returns>A String response.</returns>
        public static string Get(this HttpWebRequest request)
        {
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var responseString = new StreamReader(response.GetResponseStream()))
                {
                    return responseString.ReadToEnd();
                }
            }
        }
    }
}
