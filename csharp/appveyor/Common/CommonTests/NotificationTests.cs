using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonTests.Properties;

namespace Common.Tests
{
    [TestClass()]
    public class NotificationTests
    {
        [TestMethod()]
        public void ShowNotifyTest()
        {
            try
            {
                Notification.ShowNotify("test1", 
                                        "test2", 
                                        Settings.Default.NotificationAppID,
                                        Settings.Default.NotificationIconPath);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
                throw;
            }

        }
    }
}