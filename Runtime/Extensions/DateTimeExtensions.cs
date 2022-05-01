
using System;

public static partial class DateTimeExtensions
{
    public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
    {
        return new DateTime(
            dateTime.Year,
            dateTime.Month,
            dateTime.Day,
            hours,
            minutes,
            seconds,
            milliseconds,
            dateTime.Kind);
    }

    public static DateTime ChangeDate(this DateTime dateTime, int year, int month, int day)
    {
        dateTime = new DateTime(
            year,
            month,
            day,
            dateTime.Hour,
            dateTime.Minute,
            dateTime.Second,
            dateTime.Millisecond,
            dateTime.Kind);
        return dateTime;
    }
}
