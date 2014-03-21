<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;

namespace CommonLibary
{
    /// <summary>
    /// 日期常用操作
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// 获取两个日期的时间差
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public static TimeSpan GetDateDiff(DateTime d1, DateTime d2)
        {
            TimeSpan ts = d2.Subtract(d1);
            return ts;
        }

        /// <summary>
        /// 获得今天是星期几
        /// </summary>
        /// <returns></returns>
        public static string GetDayOfWeek()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        /// <summary>
        /// 获得当月的天数
        /// </summary>
        /// <returns></returns>
        public static int GetDaysOfThisMonth()
        {
            return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        /// <summary>
        /// 判断今年是否是闰年
        /// </summary>
        /// <returns></returns>
        public static bool GetDaysOfThisYear()
        {
            return DateTime.IsLeapYear(DateTime.Now.Year);
        }

        /// <summary>
        /// 比较两个日期的大小
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns>返回结果：-1:d1< d2, 0:d1 = d2;1:d1 > d2</returns>
        public static int CompareTwoDate(DateTime d1, DateTime d2)
        {
            return d1.CompareTo(d2);
        }

        /// <summary>
        /// 昨天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetYesterday()
        {
            return DateTime.Today.AddDays(-1);
        }

        /// <summary>
        /// 明天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTomorrow()
        {
            return DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// 获得本年度的第一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfYear(DateTime d1)
        {
            return new DateTime(d1.Year, 1, 1);
        }

        /// <summary>
        /// 获得本年度的最后一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfYear(DateTime d1)
        {
            DateTime d2 = new DateTime(d1.Year + 1, 1, 1);
            return d2.AddDays(-1);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <param name="dt">要转成时间戳类型的时间</param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime dt)
        {
            TimeSpan ts = dt - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 时间戳转成DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertTimeStampToDateTime(long timestamp)
        {
            DateTime time = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(timestamp);
            return time;
        }
    }
}
=======
﻿using System;

namespace CommonLibary
{
    /// <summary>
    /// 日期常用操作
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// 获取两个日期的时间差
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public static TimeSpan GetDateDiff(this DateTime dt, DateTime d1, DateTime d2)
        {
            TimeSpan ts = d2.Subtract(d1);
            return ts;
        }

        /// <summary>
        /// 获得今天是星期几
        /// </summary>
        /// <returns></returns>
        public static string GetDayOfWeek(this DateTime dt)
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        /// <summary>
        /// 获得当月的天数
        /// </summary>
        /// <returns></returns>
        public static int GetDaysOfThisMonth(this DateTime dt)
        {
            return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        /// <summary>
        /// 判断今年是否是闰年
        /// </summary>
        /// <returns></returns>
        public static bool GetDaysOfThisYear(this DateTime dt)
        {
            return DateTime.IsLeapYear(DateTime.Now.Year);
        }

        /// <summary>
        /// 比较两个日期的大小
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns>返回结果：-1:d1< d2, 0:d1 = d2;1:d1 > d2</returns>
        public static int CompareTwoDate(this DateTime dt, DateTime d1, DateTime d2)
        {
            return d1.CompareTo(d2);
        }

        /// <summary>
        /// 昨天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetYesterday(this DateTime dt)
        {
            return DateTime.Today.AddDays(-1);
        }

        /// <summary>
        /// 明天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTomorrow(this DateTime dt)
        {
            return DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// 获得本年度的第一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfYear(this DateTime dt, DateTime d1)
        {
            return new DateTime(d1.Year, 1, 1);
        }

        /// <summary>
        /// 获得本年度的最后一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfYear(this DateTime dt, DateTime d1)
        {
            DateTime d2 = new DateTime(d1.Year + 1, 1, 1);
            return d2.AddDays(-1);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dt)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <param name="dt">要转成时间戳类型的时间</param>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dt, DateTime date)
        {
            TimeSpan ts = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 时间戳转成DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertTimeStampToDateTime(long timestamp)
        {
            DateTime time = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(timestamp);
            return time;
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;

namespace CommonLibary
{
    /// <summary>
    /// 日期常用操作
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// 获取两个日期的时间差
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public static TimeSpan GetDateDiff(this DateTime dt, DateTime d1, DateTime d2)
        {
            TimeSpan ts = d2.Subtract(d1);
            return ts;
        }

        /// <summary>
        /// 获得今天是星期几
        /// </summary>
        /// <returns></returns>
        public static string GetDayOfWeek(this DateTime dt)
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        /// <summary>
        /// 获得当月的天数
        /// </summary>
        /// <returns></returns>
        public static int GetDaysOfThisMonth(this DateTime dt)
        {
            return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        /// <summary>
        /// 判断今年是否是闰年
        /// </summary>
        /// <returns></returns>
        public static bool GetDaysOfThisYear(this DateTime dt)
        {
            return DateTime.IsLeapYear(DateTime.Now.Year);
        }

        /// <summary>
        /// 比较两个日期的大小
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns>返回结果：-1:d1< d2, 0:d1 = d2;1:d1 > d2</returns>
        public static int CompareTwoDate(this DateTime dt, DateTime d1, DateTime d2)
        {
            return d1.CompareTo(d2);
        }

        /// <summary>
        /// 昨天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetYesterday(this DateTime dt)
        {
            return DateTime.Today.AddDays(-1);
        }

        /// <summary>
        /// 明天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTomorrow(this DateTime dt)
        {
            return DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// 获得本年度的第一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfYear(this DateTime dt, DateTime d1)
        {
            return new DateTime(d1.Year, 1, 1);
        }

        /// <summary>
        /// 获得本年度的最后一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfYear(this DateTime dt, DateTime d1)
        {
            DateTime d2 = new DateTime(d1.Year + 1, 1, 1);
            return d2.AddDays(-1);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dt)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <param name="dt">要转成时间戳类型的时间</param>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dt, DateTime date)
        {
            TimeSpan ts = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 时间戳转成DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertTimeStampToDateTime(long timestamp)
        {
            DateTime time = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(timestamp);
            return time;
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;

namespace CommonLibary
{
    /// <summary>
    /// 日期常用操作
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// 获取两个日期的时间差
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public static TimeSpan GetDateDiff(this DateTime dt, DateTime d1, DateTime d2)
        {
            TimeSpan ts = d2.Subtract(d1);
            return ts;
        }

        /// <summary>
        /// 获得今天是星期几
        /// </summary>
        /// <returns></returns>
        public static string GetDayOfWeek(this DateTime dt)
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        /// <summary>
        /// 获得当月的天数
        /// </summary>
        /// <returns></returns>
        public static int GetDaysOfThisMonth(this DateTime dt)
        {
            return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        /// <summary>
        /// 判断今年是否是闰年
        /// </summary>
        /// <returns></returns>
        public static bool GetDaysOfThisYear(this DateTime dt)
        {
            return DateTime.IsLeapYear(DateTime.Now.Year);
        }

        /// <summary>
        /// 比较两个日期的大小
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns>返回结果：-1:d1< d2, 0:d1 = d2;1:d1 > d2</returns>
        public static int CompareTwoDate(this DateTime dt, DateTime d1, DateTime d2)
        {
            return d1.CompareTo(d2);
        }

        /// <summary>
        /// 昨天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetYesterday(this DateTime dt)
        {
            return DateTime.Today.AddDays(-1);
        }

        /// <summary>
        /// 明天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTomorrow(this DateTime dt)
        {
            return DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// 获得本年度的第一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfYear(this DateTime dt, DateTime d1)
        {
            return new DateTime(d1.Year, 1, 1);
        }

        /// <summary>
        /// 获得本年度的最后一天
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfYear(this DateTime dt, DateTime d1)
        {
            DateTime d2 = new DateTime(d1.Year + 1, 1, 1);
            return d2.AddDays(-1);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dt)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// DateTime转成时间戳
        /// </summary>
        /// <param name="dt">要转成时间戳类型的时间</param>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dt, DateTime date)
        {
            TimeSpan ts = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 时间戳转成DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertTimeStampToDateTime(long timestamp)
        {
            DateTime time = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(timestamp);
            return time;
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
