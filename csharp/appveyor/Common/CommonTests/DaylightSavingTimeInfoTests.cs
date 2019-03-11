using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class DaylightSavingTimeInfoTests
    {
        [TestMethod()]
        public void ConvertDstMoveForwardTest()
        {
            DateTime DstMoveForward;
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo(TimeZoneInfo.Local.Id);

            // Local
            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 0, 0, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 30, 0, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 30, 0, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 59, 59, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 59, 59, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Local));

            // Unspecified
            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 0, 0, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 30, 0, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 30, 0, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 59, 59, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 59, 59, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Local));

            // Utc
            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 0, 0, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 2, 0, 0, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 30, 0, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 2, 30, 0, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 2, 59, 59, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 2, 59, 59, 0, DateTimeKind.Local));

            DstMoveForward = dst.ConvertDstMoveForward(new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveForward, new DateTime(2018, 3, 11, 3, 0, 0, 0, DateTimeKind.Local));
        }

        [TestMethod()]
        public void ConvertDstMoveBackTest()
        {
            DateTime DstMoveBack;
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo(TimeZoneInfo.Local.Id);

            // Local
            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 2, 0, 0, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 1, 0, 0, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 59, 59, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 0, 59, 59, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 30, 0, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 0, 30, 0, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 0, 0, 0, DateTimeKind.Local));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 0, 0, 0, 0, DateTimeKind.Local));

            // Unspecified
            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 2, 0, 0, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 1, 0, 0, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 59, 59, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 0, 59, 59, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 30, 0, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 0, 30, 0, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 0, 0, 0, DateTimeKind.Unspecified));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 0, 0, 0, 0, DateTimeKind.Local));

            // Utc
            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 2, 0, 0, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 2, 0, 0, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 59, 59, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 1, 59, 59, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 30, 0, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 1, 30, 0, 0, DateTimeKind.Local));

            DstMoveBack = dst.ConvertDstMoveBack(new DateTime(2018, 11, 4, 1, 0, 0, 0, DateTimeKind.Utc));
            Assert.AreEqual(DstMoveBack, new DateTime(2018, 11, 4, 1, 0, 0, 0, DateTimeKind.Local));
        }

        [TestMethod()]
        public void GetTransitionStartDateTimeTest()
        {
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo(TimeZoneInfo.Local.Id);
            Assert.AreEqual(dst.GetTransitionStartDateTime(2018), new DateTime(2018, 3, 11, 2, 0, 0, 0, DateTimeKind.Local));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetTransitionStartDateTimeExceptionTest()
        {
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo("Tokyo Standard Time");
            Assert.AreEqual(dst.GetTransitionStartDateTime(2018), new DateTime(2018, 3, 11, 2, 0, 0, 0, DateTimeKind.Local));
        }

        [TestMethod()]
        public void GetTransitionEndDateTimeTest()
        {
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo(TimeZoneInfo.Local.Id);
            Assert.AreEqual(dst.GetTransitionEndDateTime(2018), new DateTime(2018, 11, 4, 2, 0, 0, 0, DateTimeKind.Local));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetTransitionEndDateTimeExceptionTest()
        {
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo("Tokyo Standard Time");
            Assert.AreEqual(dst.GetTransitionEndDateTime(2018), new DateTime(2018, 11, 4, 2, 0, 0, 0, DateTimeKind.Local));
        }

        [TestMethod()]
        public void GetTimeSpanTest()
        {
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo(TimeZoneInfo.Local.Id);
            Assert.AreEqual(new TimeSpan(0, 1, 0, 0, 0), dst.GetDstTimeSpan());
        }

        [TestMethod()]
        public void ConvertDateTimeOffsetTest()
        {
            DateTime obj = DateTime.Now;
            DaylightSavingTimeInfo dst = new DaylightSavingTimeInfo(TimeZoneInfo.Local.Id);
            Assert.AreEqual(
                new DateTimeOffset(obj.Year,
                                   obj.Month,
                                   obj.Day,
                                   obj.Hour,
                                   obj.Minute,
                                   obj.Second,
                                   obj.Millisecond,
                                   new TimeSpan(0, -8, 0, 0, 0)).ToString(),
                                   dst.ConvertDateTimeOffset(obj).ToString());
        }
    }
}