using System;
using System.Globalization;

namespace Common
{
    public static class DateEdit
    {
        public static DateTime GetWeekStartDate(DateTime targetDate)
        {
                return targetDate.AddDays(-(int)targetDate.DayOfWeek);
        }

        public static int GetWeekCount(DateTime startDate)
        {
            int weekCount = 0;

            weekCount = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(startDate,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            return weekCount;
        }

        public static string GetJapaneseEraName(int year, int month, int day)
        {
            string ret = "";

            DateTime dateTime = new DateTime(year, month, day);
            CultureInfo cultureInfo = new CultureInfo("ja-Jp");

            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();

            ret = cultureInfo.DateTimeFormat.GetEraName(cultureInfo.DateTimeFormat.Calendar.GetEra(dateTime));

            return ret;
        }

        public static string GetJapaneseWeekday(int year, int month, int day, bool shortest = false)
        {
            string ret = "";

            DateTime dateTime = new DateTime(year, month, day);
            CultureInfo cultureInfo = new CultureInfo("ja-Jp");

            if (shortest)
            {
                ret = cultureInfo.DateTimeFormat.GetShortestDayName(dateTime.DayOfWeek);
            }
            else
            {
                ret = cultureInfo.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            }
            return ret;
        }

        public static DateTime GetDaysInMonth(int year, int month, int day)
        {
            DateTime dateTime = new DateTime(year, month, day);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            return new DateTime(year, month, daysInMonth);
        }

        public static DateTime NextWeekDay(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            DateTime dateTime = new DateTime(year, month, day);

            int dayDiff = (int)dayOfWeek - (int)dateTime.DayOfWeek;

            if(dayDiff <= 0)
            {
                dayDiff += 7;
            }
            return dateTime.AddDays(dayDiff);
        }
    }
}
