using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AudiosearchNet.Tests
{
    [TestClass]
    public class AudiosearchNetUnitTest
    {
        private AudiosearchNetClient client;

        public AudiosearchNetUnitTest()
        {
            client = new AudiosearchNetClient(
                    "[YOUR APPLICATION ID]",
                    "[YOUR APPLICATION SECRET]"
                );
        }

        [TestMethod]
        public void AudiosearchNetClient_Authorize()
        {
            Assert.IsNotNull(client.AccessToken, "Failed: Access Token cannot be null.");
        }

        [TestMethod]
        public void AudiosearchNetClient_GetShowsByKeyWords()
        {
            var shows = client.GetShowsByKeyWords("Jovem Nerd");

            Assert.IsNotNull(shows);
        }
    }
}
