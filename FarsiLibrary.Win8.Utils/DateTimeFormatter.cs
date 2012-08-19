using System.Collections.Generic;
using Windows.Globalization.DateTimeFormatting;

namespace FarsiLibrary.Utils
{
    public interface IDateTimeFormatter
    {
        
    }

    public class FADateTimeFormatter : IDateTimeFormatter
    {
        public FADateTimeFormatter(string formatTemplate)
        {
        }

        public FADateTimeFormatter(string formatTemplate, IEnumerable<string> languages)
        {
        }

        public FADateTimeFormatter(string formatTemplate, IEnumerable<string> languages, string geographicRegion, string calendar, string clock) : base(formatTemplate, languages, geographicRegion, calendar, clock)
        {
        }

        public FADateTimeFormatter(YearFormat yearFormat, MonthFormat monthFormat, DayFormat dayFormat, DayOfWeekFormat dayOfWeekFormat) : base(yearFormat, monthFormat, dayFormat, dayOfWeekFormat)
        {
        }

        public FADateTimeFormatter(HourFormat hourFormat, MinuteFormat minuteFormat, SecondFormat secondFormat) : base(hourFormat, minuteFormat, secondFormat)
        {
        }

        public FADateTimeFormatter(YearFormat yearFormat, MonthFormat monthFormat, DayFormat dayFormat, DayOfWeekFormat dayOfWeekFormat, HourFormat hourFormat, MinuteFormat minuteFormat, SecondFormat secondFormat, IEnumerable<string> languages) : base(yearFormat, monthFormat, dayFormat, dayOfWeekFormat, hourFormat, minuteFormat, secondFormat, languages)
        {
        }

        public FADateTimeFormatter(YearFormat yearFormat, MonthFormat monthFormat, DayFormat dayFormat, DayOfWeekFormat dayOfWeekFormat, HourFormat hourFormat, MinuteFormat minuteFormat, SecondFormat secondFormat, IEnumerable<string> languages, string geographicRegion, string calendar, string clock) : base(yearFormat, monthFormat, dayFormat, dayOfWeekFormat, hourFormat, minuteFormat, secondFormat, languages, geographicRegion, calendar, clock)
        {
        }
    }
}