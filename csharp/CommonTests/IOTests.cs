using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Common.Tests
{
    [TestClass()]
    public class IOTests
    {
        [TestMethod()]
        public void DirectoryCheckOnlyTest()
        {
            // Directory not exist
            // Directory check only
            if (Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
            {
                Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath);
            }

            Assert.AreEqual(true, IO.DirectoryCheck(CommonTests.Properties.Settings.Default.IODirectoryPath));

            DirectoryCheckTestAfterProcess();
        }

        private void DirectoryCheckTestAfterProcess()
        {
            // Delete test object
            if (Directory.Exists(CommonTests.Properties.Settings.Default.IODirectoryPath))
            {
                Directory.Delete(CommonTests.Properties.Settings.Default.IODirectoryPath, true);
            }
        }
    }
}