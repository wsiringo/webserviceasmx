using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceAsmx.Web.Classes
{
    public class NextDayDateFinder
    {
        // list all days of week text, in uppercase, as a static reference
        private static string[] _daysOfWeek =
            {
            DayOfWeek.Monday.ToString().ToUpper(),
            DayOfWeek.Tuesday.ToString().ToUpper(),
            DayOfWeek.Wednesday.ToString().ToUpper(),
            DayOfWeek.Thursday.ToString().ToUpper(),
            DayOfWeek.Friday.ToString().ToUpper(),
            DayOfWeek.Saturday.ToString().ToUpper(),
            DayOfWeek.Sunday.ToString().ToUpper(),
        };
        // core method to calculate next date for any given day of week
        // a parameter for base date is included to facilitate unit testing
        public DateTime GetNextDate(string dayOfWeek, DateTimeOffset baseDateTime)
        {
            string dowCaps = string.IsNullOrWhiteSpace(dayOfWeek) ? string.Empty : dayOfWeek.ToUpper();
            if (string.IsNullOrEmpty(dowCaps) || !_daysOfWeek.Contains(dowCaps)) return DateFinderConstants.DefaultInvalidResult;
            // WS 29/11/2021 translate to local NZ time so users can see it correctly
            TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById(@"New Zealand Standard Time");
            DateTimeOffset localDateTime = TimeZoneInfo.ConvertTime(baseDateTime, hwZone);
            for (int i = 0; i < 7; i++)
            {
                DateTimeOffset possibleDay = localDateTime.AddDays(i + 1);
                if (possibleDay.DayOfWeek.ToString().ToUpper().Equals(dowCaps)) return possibleDay.Date;
            }
            return DateFinderConstants.DefaultInvalidResult;
        }

        // core method to calculate next date for any given day of week, as used by the API controller
        public DateTime GetNextDate(string dayOfWeek)
        {
            return GetNextDate(dayOfWeek, DateTimeOffset.UtcNow);
        }
    }
}