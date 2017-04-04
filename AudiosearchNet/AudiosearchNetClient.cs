using AudiosearchNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

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
    }
}
