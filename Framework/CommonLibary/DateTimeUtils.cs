using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary
{
    /// <summary>
    /// 日期常用操作
    /// </summary>
    public static class DateTimeUtils
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
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static int GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }

        /// <summary>
        /// 获取时间戳重载方法
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int GetTimeStamp(DateTime time)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }
    }
}
