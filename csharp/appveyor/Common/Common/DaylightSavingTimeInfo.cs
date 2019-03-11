using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Common
{
    public class DaylightSavingTimeInfo
    {
        public TimeSpan BaseUtcOffset { get; set; }

        public string Id { get; set; }

        public string DaylightName { get; set; }

        public string DisplayName { get; set; }

        public string StandardName { get; set; }

        public bool SupportsDaylightSavingTime { get; set; }

        public int TransitionStartMonth { get; set; }

        public int TransitionStartDay { get; set; }

        public bool TransitionStartIsFixedDateRule { get; set; }

        public int TransitionStartWeek { get; set; }

        public DayOfWeek TransitionStartDayOfWeek { get; set; }

        public DateTime TransitionStartTimeOfDay { get; set; }

        public int TransitionEndMonth { get; set; }

        public int TransitionEndDay { get; set; }

        public bool TransitionEndIsFixedDateRule { get; set; }

        public int TransitionEndWeek { get; set; }

        public DayOfWeek TransitionEndDayOfWeek { get; set; }

        public DateTime TransitionEndTimeOfDay { get; set; }

        public int DaylightDeltaDays { get; set; }

        public int DaylightDeltaHours { get; set; }

        public int DaylightDeltaMinutes { get; set; }

        public int DaylightDeltaSeconds { get; set; }

        public int DaylightDeltaMilliseconds { get; set; }

        public DateTime DaylightSavingTimeDateStart { get; set; }

        public DateTime DaylightSavingTimeDateEnd { get; set; }

        public DaylightSavingTimeInfo(string timeZoneId)
        {
            List<string> timeZoneList = CreateTimeZoneList();

            if (!timeZoneList.Contains(timeZoneId)){
                timeZoneId = TimeZoneInfo.Local.Id;
            }

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            
            GetInfo(timeZoneInfo);

            if (!SupportsDaylightSavingTime)
            {
                return;
            }
            else
            {
                TimeZoneInfo.AdjustmentRule[] adjustments = timeZoneInfo.GetAdjustmentRules();

                if (adjustments.Length != 0)
                {
                    GetRecentAdjustmentRule(adjustments[adjustments.Length - 1]);
                }
            }
        }

        private List<string> CreateTimeZoneList()
        {
            List<string> timeZoneList = new List<string>();
            foreach (TimeZoneInfo timeZoneInfo in TimeZoneInfo.GetSystemTimeZones())
            {
                timeZoneList.Add(timeZoneInfo.Id);
            }
            return timeZoneList;
        }

        private void GetInfo(TimeZoneInfo timeZoneInfo)
        {
            BaseUtcOffset = timeZoneInfo.BaseUtcOffset;

            Id = timeZoneInfo.Id;

            DaylightName = timeZoneInfo.DaylightName;

            DisplayName = timeZoneInfo.DisplayName;

            StandardName = timeZoneInfo.StandardName;

            SupportsDaylightSavingTime = timeZoneInfo.SupportsDaylightSavingTime;
        }

        private void GetRecentAdjustmentRule(TimeZoneInfo.AdjustmentRule adjustment)
        {

            TransitionStartMonth = adjustment.DaylightTransitionStart.Month;

            TransitionStartDay = adjustment.DaylightTransitionStart.Day;

            TransitionStartIsFixedDateRule = adjustment.DaylightTransitionStart.IsFixedDateRule;

            TransitionStartWeek = adjustment.DaylightTransitionStart.Week;

            TransitionStartDayOfWeek = adjustment.DaylightTransitionStart.DayOfWeek;

            TransitionStartTimeOfDay = adjustment.DaylightTransitionStart.TimeOfDay;

            TransitionEndMonth = adjustment.DaylightTransitionEnd.Month;

            TransitionEndDay = adjustment.DaylightTransitionEnd.Day;

            TransitionEndIsFixedDateRule = adjustment.DaylightTransitionEnd.IsFixedDateRule;

            TransitionEndWeek = adjustment.DaylightTransitionEnd.Week;

            TransitionEndDayOfWeek = adjustment.DaylightTransitionEnd.DayOfWeek;

            TransitionEndTimeOfDay = adjustment.DaylightTransitionEnd.TimeOfDay;

            DaylightDeltaDays = adjustment.DaylightDelta.Days;

            DaylightDeltaHours = adjustment.DaylightDelta.Hours;

            DaylightDeltaMinutes = adjustment.DaylightDelta.Minutes;

            DaylightDeltaSeconds = adjustment.DaylightDelta.Seconds;

            DaylightDeltaMilliseconds = adjustment.DaylightDelta.Milliseconds;

            DaylightSavingTimeDateStart =adjustment.DateStart;

            DaylightSavingTimeDateEnd = adjustment.DateEnd;
        }

        public DateTimeOffset ConvertDateTimeOffset(DateTime dateTime)
        {
            return new DateTimeOffset(DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified), BaseUtcOffset);
        }

        public TimeSpan GetDstTimeSpan()
        {
            return new TimeSpan(DaylightDeltaDays, DaylightDeltaHours, DaylightDeltaMinutes, DaylightDeltaSeconds, DaylightDeltaMilliseconds);
        }
        
        public DateTime GetTransitionStartDateTime(int year)
        {
            DateTime transitionStartDate;
            int dayCount = 0;
            int weekDayCount = 0;

            if (TransitionStartIsFixedDateRule)
            {
                transitionStartDate = new DateTime(year,
                                                   TransitionStartMonth,
                                                   TransitionStartDay,
                                                   TransitionStartTimeOfDay.Hour,
                                                   TransitionStartTimeOfDay.Minute,
                                                   TransitionStartTimeOfDay.Second);
            }
            else
            {
                transitionStartDate = new DateTime(year,
                                                   TransitionStartMonth,
                                                   1,
                                                   TransitionStartTimeOfDay.Hour,
                                                   TransitionStartTimeOfDay.Minute,
                                                   TransitionStartTimeOfDay.Second);
                do
                {
                    if (transitionStartDate.AddDays(dayCount).DayOfWeek == TransitionStartDayOfWeek)
                    {
                        weekDayCount++;
                        if (weekDayCount == TransitionStartWeek)
                        {
                            break;
                        }
                    }
                    dayCount++;
                } while (true);
            }
            return transitionStartDate.AddDays(dayCount);
        }

        public DateTime GetTransitionEndDateTime(int year)
        {
            DateTime transitionEndDate;
            int dayCount = 0;
            int weekDayCount = 0;

            if (TransitionEndIsFixedDateRule)
            {
                transitionEndDate = new DateTime(year,
                                                   TransitionEndMonth,
                                                   TransitionEndDay,
                                                   TransitionEndTimeOfDay.Hour,
                                                   TransitionEndTimeOfDay.Minute,
                                                   TransitionEndTimeOfDay.Second);
            }
            else
            {
                transitionEndDate = new DateTime(year,
                                                   TransitionEndMonth,
                                                   1,
                                                   TransitionEndTimeOfDay.Hour,
                                                   TransitionEndTimeOfDay.Minute,
                                                   TransitionEndTimeOfDay.Second);
                do
                {
                    if (transitionEndDate.AddDays(dayCount).DayOfWeek == TransitionEndDayOfWeek)
                    {
                        weekDayCount++;
                        if (weekDayCount == TransitionEndWeek)
                        {
                            break;
                        }
                    }
                    dayCount++;
                } while (true);
            }
            return transitionEndDate.AddDays(dayCount);
        }

        public DateTime ConvertDstMoveForward(DateTime dateTime)
        {
            DateTime ret = dateTime;

            if (dateTime.Kind != DateTimeKind.Utc) 
            {
                if (dateTime >= GetTransitionStartDateTime(dateTime.Year) && dateTime < GetTransitionStartDateTime(dateTime.Year).AddTicks(GetDstTimeSpan().Ticks))
                {
                    ret = dateTime.AddTicks(GetDstTimeSpan().Ticks);
                }
            }
            return ret;
        }

        public DateTime ConvertDstMoveBack(DateTime dateTime)
        {
            DateTime ret = dateTime;

            if (dateTime.Kind != DateTimeKind.Utc)
            {
                if (dateTime >= GetTransitionStartDateTime(dateTime.Year) && dateTime <= GetTransitionEndDateTime(dateTime.Year))
                {
                    ret = dateTime.AddTicks(-GetDstTimeSpan().Ticks);
                }
            }
            return ret;
        }

    }
}
