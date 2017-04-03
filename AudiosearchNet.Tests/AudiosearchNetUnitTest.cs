using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AudiosearchNet.Tests
{
    [TestClass]
    public class AudiosearchNetUnitTest
    {
        [TestMethod]
        public void AudiosearchNetClient_Authorize()
        {
            var applicationId = "[Your app ID]";
            var applicationSecret = "[You app Secret]";

            var client = new AudiosearchNetClient(
                    applicationId, applicationSecret
                );

            var results = client.GetShow("Jovem Nerd");
        }
    }
}
