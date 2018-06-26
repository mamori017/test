using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class LogTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            string strFile = @".\errorLog.txt";

            Exception objEx = new Exception("Test");

            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }

            Common.Log.ExceptionOutput(objEx, strFile);

            Assert.AreEqual(true, File.Exists(strFile));

            StreamReader objReader = null;

            if (File.Exists(strFile))
            {
                objReader = new StreamReader(strFile);
                Assert.AreEqual("System.Exception: Test", objReader.ReadLine());

            }

            if (objReader != null)
            {
                objReader.Close();
            }

            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }
        }
    }
}