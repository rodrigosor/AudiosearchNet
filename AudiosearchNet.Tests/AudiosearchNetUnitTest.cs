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
                    "64063835fac8e5913e120bd224aa4ef74920005dace4700a19aad3f7f3302dea",
                    "3970f51578b743cc8ecbbfb0d61c9798860ccdd159f7092130eaac62273bc667"
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
