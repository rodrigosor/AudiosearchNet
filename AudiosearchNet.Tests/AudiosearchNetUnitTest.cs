using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AudiosearchNet.Tests
{
	[TestClass]
	public class AudiosearchNetUnitTest
	{
		private AudiosearchNetClient client;

		public AudiosearchNetUnitTest()
		{
			client = TestHelper.CreateAudiosearchNetClient();

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

		[TestMethod]
		public void AudiosearchNetClient_GetShowsByKeyWordsWithNetworkFieldFilled()
		{
			var shows = client.GetShowsByKeyWords("Savage Love");

			Assert.IsNotNull(shows);
		}
	}
}
