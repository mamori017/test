using System;
using System.IO;
using NUnit.Framework;

namespace XunitTests
{
    [TestFixture]
    public class XunitTests
    {
        [Test]
        public void Test()
        {
            Assert.That(1,Is.EqualTo(1));
        }
    }
}
