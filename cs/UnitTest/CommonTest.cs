using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nslookup2csv;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LogOutput()
        {
            Exception objEx = new Exception("Test!");

            if (File.Exists(@".\errorLog.txt") == true)
            {
                File.Delete(@".\errorLog.txt");
            }

            Common.LogOutput(objEx);

            Assert.AreEqual(true, File.Exists(@".\errorLog.txt"));
        }
    }
}
