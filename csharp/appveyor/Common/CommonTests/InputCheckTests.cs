using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class InputCheckTests
    {
        [TestMethod()]
        public void ContainsHalfWidthAlpthabetTest()
        {

            string target = "";

            // [\u0041-\u005A]
            target = "@";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));

            target = "A";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));

            target = "Z";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));

            target = "[";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));

            // [\u0061-\u007A]
            target = "`";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));

            target = "a";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));

            target = "z";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));

            target = "{";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthAlpthabet(target));
        }

        [TestMethod()]
        public void ContainsHalfWidthKanaTest()
        {
            string target = "";

            // [\uFF61-\uFF9F]
            target = "｠";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthKana(target));

            target = "｡";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthKana(target));

            target = "ﾟ";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthKana(target));

            target = "ﾠ";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthKana(target));
        }

        [TestMethod()]
        public void ContainsHalfWidthSybolTest()
        {
            string target = "";

            // [\u0021-\002F]
            target = " ";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "!";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "/";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "0";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            // [\u003A-\u0040]
            target = "9";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = ":";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "@";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "A";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            // [\u007B-\u007F]
            target = "Z";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "[";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "`";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "a";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            // [\u007B-\u007F]
            target = "z";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "{";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "";
            Assert.AreEqual(true, InputCheck.ContainsHalfWidthSybol(target));

            target = "";
            Assert.AreNotEqual(true, InputCheck.ContainsHalfWidthSybol(target));

        }

        [TestMethod()]
        public void ContainsFullWidthNumberTest()
        {
            string target = "";

            // [\uFF10-\uFF19]
            target = "／";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthNumber(target));

            target = "０";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthNumber(target));

            target = "９";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthNumber(target));

            target = "：";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthNumber(target));
        }

        [TestMethod()]
        public void ContainsFullWidthAlpthabetTest()
        {
            string target = "";

            // [\uFF21-\uFF3A]
            target = "＠";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));

            target = "Ａ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));

            target = "Ｚ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));

            target = "［";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));

            // [\uFF41-\uFF5A]
            target = "｀";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));

            target = "ａ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));

            target = "ｚ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));

            target = "｛";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthAlpthabet(target));
        }

        [TestMethod()]
        public void ContainsFullWidthHiraganaTest()
        {
            string target = "";

            // [\u3041-\u3096]
            target = "぀";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthHiragana(target));

            target = "ぁ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthHiragana(target));

            target = "ゖ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthHiragana(target));

            target = "゗";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthHiragana(target));
        }

        [TestMethod()]
        public void ContainsFullWidthKanaTest()
        {
            string target = "";

            // [\u30A1-\u30FA]
            target = "゠";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthKana(target));

            target = "ァ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthKana(target));

            target = "ヺ";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthKana(target));

            target = "・";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthKana(target));
        }

        [TestMethod()]
        public void ContainsFullWidthSybolTest()
        {
            string target = "";

            // [\uFF01-\uFF0F]
            target = "＀";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "！";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "／";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "０";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));

            // [\uFF1A-\uFF20]
            target = "９";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "：";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "＠";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "Ａ";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));

            // [\uFF3B-\uFF40]
            target = "Ｚ";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "［";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "｀";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "ａ";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));

            // [\uFF5B-\uFF65]
            target = "ｚ";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "｛";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "･";
            Assert.AreEqual(true, InputCheck.ContainsFullWidthSybol(target));

            target = "ｦ";
            Assert.AreNotEqual(true, InputCheck.ContainsFullWidthSybol(target));
        }
    }
}