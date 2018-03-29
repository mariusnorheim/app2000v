using System;
using System.Globalization;

public static class CalculateDate
{
    // Returns the first day of the week that the specified
    // date is in using the current culture. 
    public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
    {
        CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
        return GetFirstDateOfWeek(dayInWeek, defaultCultureInfo);
    }

    // Returns the first date of the week that the specified date is in. 
    public static DateTime GetFirstDateOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
    {
        DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
        DateTime firstDayInWeek = dayInWeek.Date;
        while (firstDayInWeek.DayOfWeek != firstDay) { firstDayInWeek = firstDayInWeek.AddDays(-1); }

        return firstDayInWeek;
    }
}