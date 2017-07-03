using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AudiosearchNet.Tests
{
	[TestClass, System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
	public class AudiosearchNetUnitTest
	{
		private AudiosearchNetClient client;

		public AudiosearchNetUnitTest()
		{
			client = TestHelper.CreateAudiosearchNetClient();
		}

		[TestCategory("Integration"), TestMethod]
		public void AudiosearchNetClient_Authorize()
		{
			Assert.IsNotNull(client.AccessToken, "Failed: Access Token cannot be null.");
		}

		[TestCategory("Integration"), TestMethod]
		public void AudiosearchNetClient_GetShowsByKeyWords()
		{
			var shows = client.GetShowsByKeyWords("Jovem Nerd");

			Assert.IsNotNull(shows);
		}

		[TestCategory("Integration"), TestMethod]
		public void AudiosearchNetClient_GetShowsByKeyWordsWithNetworkFieldFilled()
		{
			var shows = client.GetShowsByKeyWords("Savage Love");

			Assert.IsNotNull(shows);
		}

		[TestCategory("Integration"), TestMethod]
		public void AudiosearchNetClient_DymamicResults()
		{
			dynamic dynamicShow = client.GetShowsById_Dynamic(613);

			Assert.IsNotNull(dynamicShow.id);
			Assert.IsNotNull(dynamicShow.title);
			Assert.IsNotNull(dynamicShow.description);
			Assert.IsNotNull(dynamicShow.network);
			Assert.IsNotNull(dynamicShow.itunes_id);
			Assert.IsNotNull(dynamicShow.categories);
			Assert.IsNotNull(dynamicShow.buzz_score);
			Assert.IsNotNull(dynamicShow.image_files);
			Assert.IsTrue(dynamicShow.image_files.Count > 0);
			Assert.IsNotNull(dynamicShow.image_files[0].url);
			Assert.IsNotNull(dynamicShow.image_files[0].url.full);
			Assert.IsNotNull(dynamicShow.image_files[0].url.thumb);
			Assert.IsNotNull(dynamicShow.image_files[0].url.thumb);
			Assert.IsTrue(dynamicShow.number_of_episodes > 0);
			Assert.IsTrue(dynamicShow.episode_ids.Count > 0);
			Assert.IsNotNull(dynamicShow.urls);
			Assert.IsNotNull(dynamicShow.urls.self);
			Assert.IsNotNull(dynamicShow.urls.ui);
			Assert.IsNotNull(dynamicShow.rss_url);
			Assert.IsNotNull(dynamicShow.sc_feed);
			Assert.IsNotNull(dynamicShow.web_profiles);
		}

		[TestCategory("Integration"), TestMethod]
		public void AudiosearchNetClient_GetCategories()
		{
			var response = client.GetCategories();
			Assert.IsNotNull(response);

			foreach (var category in response)
			{
				Assert.IsNotNull(category.Id);
				Assert.IsNotNull(category.Name);
			}
		}
	}
}
