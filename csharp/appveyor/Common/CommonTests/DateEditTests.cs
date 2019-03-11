using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Common.Tests
{
    [TestClass()]
    public class DateEditTests
    {
        [TestMethod()]
        public void GetWeekStartDateTest()
        {
            DateTime testDate = DateTime.Parse("2018/07/19");

            DateTime output = DateEdit.GetWeekStartDate(testDate);

            Assert.AreEqual("2018/07/15", output.ToShortDateString());
        }

        /// <summary>
        /// GetWeekCountTest
        /// </summary>
        [TestMethod()]
        public void GetWeekCountTest()
        {
            DateTime testDate = DateTime.Parse("2018/07/19");

            int output = DateEdit.GetWeekCount(testDate);

            Assert.AreEqual(29, output);
        }

        /// <summary>
        /// GetJapaneseEraNameTest
        /// </summary>
        [TestMethod()]
        public void GetJapaneseEraNameTest()
        {
            string eraName = "";

            eraName = "明治";
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(1868, 1, 25));
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(1912, 7, 29));
            Assert.AreNotEqual(eraName, DateEdit.GetJapaneseEraName(1912, 7, 30));

            eraName = "大正";
            Assert.AreNotEqual(eraName, DateEdit.GetJapaneseEraName(1912, 7, 29));
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(1912, 7, 30));
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(1926, 7 , 30));
            Assert.AreNotEqual(eraName, DateEdit.GetJapaneseEraName(2019, 5, 1));

            eraName = "昭和";
            Assert.AreNotEqual(eraName, DateEdit.GetJapaneseEraName(1926, 12, 24));
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(1926, 12, 25));
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(1989, 1, 7));
            Assert.AreNotEqual(eraName, DateEdit.GetJapaneseEraName(2019, 5, 1));
            
            eraName = "平成";
            Assert.AreNotEqual(eraName, DateEdit.GetJapaneseEraName(1989, 1, 7));
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(1989, 1, 8));
            Assert.AreEqual(eraName, DateEdit.GetJapaneseEraName(2019, 4, 30));
            Assert.AreNotEqual(eraName, DateEdit.GetJapaneseEraName(2019, 5, 1));
        }

        [TestMethod()]
        public void GetJapaneseWeekdayTest()
        {
            Assert.AreEqual("木曜日",DateEdit.GetJapaneseWeekday(2018, 8, 23, false));

            Assert.AreEqual("木", DateEdit.GetJapaneseWeekday(2018, 8, 23, true));

            Assert.AreNotEqual("水", DateEdit.GetJapaneseWeekday(2018, 8, 23, false));

            Assert.AreNotEqual("水", DateEdit.GetJapaneseWeekday(2018, 8, 23, true));
        }

        [TestMethod()]
        public void GetDaysInMonthTest()
        {
            Assert.AreEqual(new DateTime(2018, 8, 31), DateEdit.GetDaysInMonth(2018, 8, 23));
        }

        [TestMethod()]
        public void NextWeekDayTest()
        {
            Assert.AreEqual(new DateTime(2018, 8, 30), DateEdit.NextWeekDay(2018, 8, 23, new DateTime(2018, 8, 23).DayOfWeek));
        }
    }
}