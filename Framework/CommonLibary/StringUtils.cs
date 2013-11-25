using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary
{
    /// <summary>
    /// 字符串的常用操作
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// 分隔字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string[] SplitByMutipleChar(string s,char[] chars)
        {
            return s.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取字符数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static char[] GetCharArray(string s)
        {
            return s.ToCharArray();
        }

        /// <summary>
        /// 字符串逆序
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseString(string s)
        {
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return c.ToString();
        }

        /// <summary>
        /// 扩展string.format方法
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format,params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
