using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace Common.Tests
{
    [TestClass()]
    public class JsonTests
    {
        [TestMethod()]
        public void GetJsonDictionaryTest()
        {
            JObject ret = Json.GetJsonObject(CommonTests.Properties.Settings.Default.JsonUrl);

            Assert.AreEqual(ret["pinpointLocations"][0]["name"].ToString(),"大牟田市");
        }

        [TestMethod()]
        [ExpectedException(typeof(AggregateException))]
        public void GetJsonDictionaryExceptionTest()
        {
            JObject jsonret = Json.GetJsonObject(CommonTests.Properties.Settings.Default.JsonUrl.Replace("400040","123456"));


        }

    }
}