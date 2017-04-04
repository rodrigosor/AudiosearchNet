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
            var applicationId = "64063835fac8e5913e120bd224aa4ef74920005dace4700a19aad3f7f3302dea";
            var applicationSecret = "3970f51578b743cc8ecbbfb0d61c9798860ccdd159f7092130eaac62273bc667";

            var client = new AudiosearchNetClient(
                    applicationId, applicationSecret
                );
        }
    }
}
