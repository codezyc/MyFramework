<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CommonLibary
{
    /// <summary>
    /// 字符串常用扩展方法
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// 分隔字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string[] SplitByMutipleChar(this string str, string s, char[] chars)
        {
            return s.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取字符数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static char[] GetCharArray(this string s, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str.ToCharArray();
            }
            return new char[] { };
        }

        /// <summary>
        /// 字符串逆序
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ReverseString(this string s, string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                char[] c = str.ToCharArray();
                Array.Reverse(c);
                return c.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 扩展string.format方法
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 去除特殊字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="specialchar">特殊字符</param>
        /// <returns></returns>
        public static string RemoveSpecialChar(this string s, string str, string specialchar)
        {
            if (!string.IsNullOrEmpty(str))
            {
                foreach (char c in specialchar)
                {
                    if (str.Contains(c))
                    {
                        str = str.Replace(c.ToString(), "");
                    }
                }
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <returns></returns>
        public static int GetMatchCount(this string s, Regex reg, string str)
        {
            MatchCollection mc = reg.Matches(str);
            return mc.Count;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <param name="startat">开始匹配的位置</param>
        /// <returns></returns>
        public static int GetMatchCount(this string s, Regex reg, string str, int startat)
        {
            MatchCollection mc = reg.Matches(str, startat);
            return mc.Count;
        }

        /// <summary>
        /// 字符串数组转成字符串
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="splitstr">分隔符</param>
        /// <returns></returns>
        public static string ArrayToString(this string str, string[] array, string splitstr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
                sb.Append(splitstr);
            }
            string result = sb.ToString();
            return result.Substring(0, result.Length - 1);
        }

        /// <summary>
        /// 获取字符串指定位置左侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetLeftString(this string s, string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(0, position);
            }
        }

        /// <summary>
        /// 获取字符串指定位置右侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetRightString(this string s, string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(position, str.Length);
            }
        }

        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="str">半角字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string s, string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 32)
                {
                    chars[i] = (char)12288;
                    continue;
                }
                if (chars[i] < 127)
                {
                    chars[i] = (char)(chars[i] + 65248);
                }
            }
            return new string(chars);
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="str">全角字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string s, string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }
                if (chars[i] > 65280 && chars[i] < 65375)
                    chars[i] = (char)(chars[i] - 65248);
            }
            return new string(chars);
        }

        /// <summary>
        /// 字符串转成繁体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>繁体中文字符串</returns>
        public static string ToTraditionalChinese(this string s, string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese);
        }

        /// <summary>
        /// 字符串转成简体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>简体中文字符串</returns>
        public static string ToSimplifiedChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese);
        }

        /// <summary>
        /// 比较两个字符串大小
        /// </summary>
        /// <param name="s1">字符串变量</param>
        /// <param name="s2">字符串变量</param>
        /// <param name="IsIgnoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static int CompareString(this string s, string s1, string s2, bool IsIgnoreCase)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
            {
                if (string.Compare(s1, s2, IsIgnoreCase) == 0)
                    return 0;
                else if (string.Compare(s1, s2, IsIgnoreCase) > 0)
                    return 1;
                else if (string.Compare(s1, s2, IsIgnoreCase) < 0)
                    return -1;
            }
            return -2;
        }

        /// <summary>
        /// 字符串转成Guid
        /// </summary>
        /// <param name="str">字符串变量</param>
        /// <returns>Guid</returns>
        public static Guid StringToGuid(this string s, string str)
        {
            if (string.IsNullOrEmpty(str))
                return Guid.Empty;
            return new Guid(str);
        }

        /// <summary>
        /// 去掉Guid中间的横杠
        /// </summary>
        /// <param name="guid">guid变量</param>
        /// <returns>字符串</returns>
        public static string RemoveGuidDash(this string s, Guid guid)
        {
            return guid.ToString("N");
        }

        /// <summary>
        /// 去掉字符串的前缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string TrimPrefix(this string str, string prefix)
        {
            if (!String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(prefix) && str.StartsWith(prefix))
            {
                return str.Substring(prefix.Length);
            }
            return str;
        }

        /// <summary>
        /// 去掉字符串的后缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string TrimSuffix(this string str, string suffix)
        {
            if (string.IsNullOrWhiteSpace(str) && !string.IsNullOrWhiteSpace(suffix) && str.EndsWith(suffix))
            {
                return str.Remove(str.Length - suffix.Length);
            }
            return str;
        }
    }
}
=======
﻿using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace CommonLibary
{
    /// <summary>
    /// 字符串常用扩展方法
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// 分隔字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string[] SplitByMutipleChar(this string s, char[] chars)
        {
            return s.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取字符数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static char[] GetCharArray(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str.ToCharArray();
            }
            return new char[] { };
        }

        /// <summary>
        /// 字符串逆序
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ReverseString(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                char[] c = str.ToCharArray();
                Array.Reverse(c);
                return c.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 扩展string.format方法
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 去除特殊字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="specialchar">特殊字符</param>
        /// <returns></returns>
        public static string RemoveSpecialChar(this string str, string specialchar)
        {
            if (!string.IsNullOrEmpty(str))
            {
                foreach (char c in specialchar)
                {
                    if (str.Contains(c))
                    {
                        str = str.Replace(c.ToString(), "");
                    }
                }
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <returns></returns>
        public static int GetMatchCount(this string s, Regex reg, string str)
        {
            MatchCollection mc = reg.Matches(str);
            return mc.Count;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <param name="startat">开始匹配的位置</param>
        /// <returns></returns>
        public static int GetMatchCount(this string str, Regex reg, int startat)
        {
            MatchCollection mc = reg.Matches(str, startat);
            return mc.Count;
        }

        /// <summary>
        /// 字符串数组转成字符串
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="splitstr">分隔符</param>
        /// <returns></returns>
        public static string ArrayToString(this string str, string[] array, string splitstr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
                sb.Append(splitstr);
            }
            string result = sb.ToString();
            return result.Substring(0, result.Length - 1);
        }

        /// <summary>
        /// 获取字符串指定位置左侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetLeftString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(0, position);
            }
        }

        /// <summary>
        /// 获取字符串指定位置右侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetRightString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(position, str.Length);
            }
        }

        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="str">半角字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 32)
                {
                    chars[i] = (char)12288;
                    continue;
                }
                if (chars[i] < 127)
                {
                    chars[i] = (char)(chars[i] + 65248);
                }
            }
            return new string(chars);
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="str">全角字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }
                if (chars[i] > 65280 && chars[i] < 65375)
                    chars[i] = (char)(chars[i] - 65248);
            }
            return new string(chars);
        }

        /// <summary>
        /// 字符串转成繁体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>繁体中文字符串</returns>
        public static string ToTraditionalChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese);
        }

        /// <summary>
        /// 字符串转成简体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>简体中文字符串</returns>
        public static string ToSimplifiedChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese);
        }

        /// <summary>
        /// 比较两个字符串大小
        /// </summary>
        /// <param name="s1">字符串变量</param>
        /// <param name="s2">字符串变量</param>
        /// <param name="IsIgnoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static int CompareString(this string s1, string s2, bool IsIgnoreCase)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
            {
                if (string.Compare(s1, s2, IsIgnoreCase) == 0)
                    return 0;
                else if (string.Compare(s1, s2, IsIgnoreCase) > 0)
                    return 1;
                else if (string.Compare(s1, s2, IsIgnoreCase) < 0)
                    return -1;
            }
            return -2;
        }

        /// <summary>
        /// 字符串转成Guid
        /// </summary>
        /// <param name="str">字符串变量</param>
        /// <returns>Guid</returns>
        public static Guid StringToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return Guid.Empty;
            return new Guid(str);
        }

        /// <summary>
        /// 去掉Guid中间的横杠
        /// </summary>
        /// <param name="guid">guid变量</param>
        /// <returns>字符串</returns>
        public static string RemoveGuidDash(this string s, Guid guid)
        {
            return guid.ToString("N");
        }

        /// <summary>
        /// 去掉字符串的前缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string TrimPrefix(this string str, string prefix)
        {
            if (!String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(prefix) && str.StartsWith(prefix))
            {
                return str.Substring(prefix.Length);
            }
            return str;
        }

        /// <summary>
        /// 去掉字符串的后缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string TrimSuffix(this string str, string suffix)
        {
            if (string.IsNullOrWhiteSpace(str) && !string.IsNullOrWhiteSpace(suffix) && str.EndsWith(suffix))
            {
                return str.Remove(str.Length - suffix.Length);
            }
            return str;
        }

        /// <summary>
        /// 判断字符可以转成数字
        /// </summary>
        /// <param name="theValue"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace CommonLibary
{
    /// <summary>
    /// 字符串常用扩展方法
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// 分隔字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string[] SplitByMutipleChar(this string s, char[] chars)
        {
            return s.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取字符数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static char[] GetCharArray(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str.ToCharArray();
            }
            return new char[] { };
        }

        /// <summary>
        /// 字符串逆序
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ReverseString(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                char[] c = str.ToCharArray();
                Array.Reverse(c);
                return c.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 扩展string.format方法
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 去除特殊字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="specialchar">特殊字符</param>
        /// <returns></returns>
        public static string RemoveSpecialChar(this string str, string specialchar)
        {
            if (!string.IsNullOrEmpty(str))
            {
                foreach (char c in specialchar)
                {
                    if (str.Contains(c))
                    {
                        str = str.Replace(c.ToString(), "");
                    }
                }
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <returns></returns>
        public static int GetMatchCount(this string s, Regex reg, string str)
        {
            MatchCollection mc = reg.Matches(str);
            return mc.Count;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <param name="startat">开始匹配的位置</param>
        /// <returns></returns>
        public static int GetMatchCount(this string str, Regex reg, int startat)
        {
            MatchCollection mc = reg.Matches(str, startat);
            return mc.Count;
        }

        /// <summary>
        /// 字符串数组转成字符串
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="splitstr">分隔符</param>
        /// <returns></returns>
        public static string ArrayToString(this string str, string[] array, string splitstr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
                sb.Append(splitstr);
            }
            string result = sb.ToString();
            return result.Substring(0, result.Length - 1);
        }

        /// <summary>
        /// 获取字符串指定位置左侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetLeftString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(0, position);
            }
        }

        /// <summary>
        /// 获取字符串指定位置右侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetRightString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(position, str.Length);
            }
        }

        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="str">半角字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 32)
                {
                    chars[i] = (char)12288;
                    continue;
                }
                if (chars[i] < 127)
                {
                    chars[i] = (char)(chars[i] + 65248);
                }
            }
            return new string(chars);
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="str">全角字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }
                if (chars[i] > 65280 && chars[i] < 65375)
                    chars[i] = (char)(chars[i] - 65248);
            }
            return new string(chars);
        }

        /// <summary>
        /// 字符串转成繁体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>繁体中文字符串</returns>
        public static string ToTraditionalChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese);
        }

        /// <summary>
        /// 字符串转成简体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>简体中文字符串</returns>
        public static string ToSimplifiedChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese);
        }

        /// <summary>
        /// 比较两个字符串大小
        /// </summary>
        /// <param name="s1">字符串变量</param>
        /// <param name="s2">字符串变量</param>
        /// <param name="IsIgnoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static int CompareString(this string s1, string s2, bool IsIgnoreCase)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
            {
                if (string.Compare(s1, s2, IsIgnoreCase) == 0)
                    return 0;
                else if (string.Compare(s1, s2, IsIgnoreCase) > 0)
                    return 1;
                else if (string.Compare(s1, s2, IsIgnoreCase) < 0)
                    return -1;
            }
            return -2;
        }

        /// <summary>
        /// 字符串转成Guid
        /// </summary>
        /// <param name="str">字符串变量</param>
        /// <returns>Guid</returns>
        public static Guid StringToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return Guid.Empty;
            return new Guid(str);
        }

        /// <summary>
        /// 去掉Guid中间的横杠
        /// </summary>
        /// <param name="guid">guid变量</param>
        /// <returns>字符串</returns>
        public static string RemoveGuidDash(this string s, Guid guid)
        {
            return guid.ToString("N");
        }

        /// <summary>
        /// 去掉字符串的前缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string TrimPrefix(this string str, string prefix)
        {
            if (!String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(prefix) && str.StartsWith(prefix))
            {
                return str.Substring(prefix.Length);
            }
            return str;
        }

        /// <summary>
        /// 去掉字符串的后缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string TrimSuffix(this string str, string suffix)
        {
            if (string.IsNullOrWhiteSpace(str) && !string.IsNullOrWhiteSpace(suffix) && str.EndsWith(suffix))
            {
                return str.Remove(str.Length - suffix.Length);
            }
            return str;
        }

        /// <summary>
        /// 判断字符可以转成数字
        /// </summary>
        /// <param name="theValue"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace CommonLibary
{
    /// <summary>
    /// 字符串常用扩展方法
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// 分隔字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string[] SplitByMutipleChar(this string s, char[] chars)
        {
            return s.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取字符数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static char[] GetCharArray(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str.ToCharArray();
            }
            return new char[] { };
        }

        /// <summary>
        /// 字符串逆序
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ReverseString(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                char[] c = str.ToCharArray();
                Array.Reverse(c);
                return c.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 扩展string.format方法
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 去除特殊字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="specialchar">特殊字符</param>
        /// <returns></returns>
        public static string RemoveSpecialChar(this string str, string specialchar)
        {
            if (!string.IsNullOrEmpty(str))
            {
                foreach (char c in specialchar)
                {
                    if (str.Contains(c))
                    {
                        str = str.Replace(c.ToString(), "");
                    }
                }
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <returns></returns>
        public static int GetMatchCount(this string s, Regex reg, string str)
        {
            MatchCollection mc = reg.Matches(str);
            return mc.Count;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <param name="startat">开始匹配的位置</param>
        /// <returns></returns>
        public static int GetMatchCount(this string str, Regex reg, int startat)
        {
            MatchCollection mc = reg.Matches(str, startat);
            return mc.Count;
        }

        /// <summary>
        /// 字符串数组转成字符串
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="splitstr">分隔符</param>
        /// <returns></returns>
        public static string ArrayToString(this string str, string[] array, string splitstr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
                sb.Append(splitstr);
            }
            string result = sb.ToString();
            return result.Substring(0, result.Length - 1);
        }

        /// <summary>
        /// 获取字符串指定位置左侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetLeftString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(0, position);
            }
        }

        /// <summary>
        /// 获取字符串指定位置右侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetRightString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(position, str.Length);
            }
        }

        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="str">半角字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 32)
                {
                    chars[i] = (char)12288;
                    continue;
                }
                if (chars[i] < 127)
                {
                    chars[i] = (char)(chars[i] + 65248);
                }
            }
            return new string(chars);
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="str">全角字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }
                if (chars[i] > 65280 && chars[i] < 65375)
                    chars[i] = (char)(chars[i] - 65248);
            }
            return new string(chars);
        }

        /// <summary>
        /// 字符串转成繁体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>繁体中文字符串</returns>
        public static string ToTraditionalChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese);
        }

        /// <summary>
        /// 字符串转成简体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>简体中文字符串</returns>
        public static string ToSimplifiedChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese);
        }

        /// <summary>
        /// 比较两个字符串大小
        /// </summary>
        /// <param name="s1">字符串变量</param>
        /// <param name="s2">字符串变量</param>
        /// <param name="IsIgnoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static int CompareString(this string s1, string s2, bool IsIgnoreCase)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
            {
                if (string.Compare(s1, s2, IsIgnoreCase) == 0)
                    return 0;
                else if (string.Compare(s1, s2, IsIgnoreCase) > 0)
                    return 1;
                else if (string.Compare(s1, s2, IsIgnoreCase) < 0)
                    return -1;
            }
            return -2;
        }

        /// <summary>
        /// 字符串转成Guid
        /// </summary>
        /// <param name="str">字符串变量</param>
        /// <returns>Guid</returns>
        public static Guid StringToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return Guid.Empty;
            return new Guid(str);
        }

        /// <summary>
        /// 去掉Guid中间的横杠
        /// </summary>
        /// <param name="guid">guid变量</param>
        /// <returns>字符串</returns>
        public static string RemoveGuidDash(this string s, Guid guid)
        {
            return guid.ToString("N");
        }

        /// <summary>
        /// 去掉字符串的前缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string TrimPrefix(this string str, string prefix)
        {
            if (!String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(prefix) && str.StartsWith(prefix))
            {
                return str.Substring(prefix.Length);
            }
            return str;
        }

        /// <summary>
        /// 去掉字符串的后缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string TrimSuffix(this string str, string suffix)
        {
            if (string.IsNullOrWhiteSpace(str) && !string.IsNullOrWhiteSpace(suffix) && str.EndsWith(suffix))
            {
                return str.Remove(str.Length - suffix.Length);
            }
            return str;
        }

        /// <summary>
        /// 判断字符可以转成数字
        /// </summary>
        /// <param name="theValue"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace CommonLibary
{
    /// <summary>
    /// 字符串常用扩展方法
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// 分隔字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string[] SplitByMutipleChar(this string s, char[] chars)
        {
            return s.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取字符数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static char[] GetCharArray(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str.ToCharArray();
            }
            return new char[] { };
        }

        /// <summary>
        /// 字符串逆序
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ReverseString(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                char[] c = str.ToCharArray();
                Array.Reverse(c);
                return c.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 扩展string.format方法
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 去除特殊字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="specialchar">特殊字符</param>
        /// <returns></returns>
        public static string RemoveSpecialChar(this string str, string specialchar)
        {
            if (!string.IsNullOrEmpty(str))
            {
                foreach (char c in specialchar)
                {
                    if (str.Contains(c))
                    {
                        str = str.Replace(c.ToString(), "");
                    }
                }
                return str;
            }
            return string.Empty;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <returns></returns>
        public static int GetMatchCount(this string s, Regex reg, string str)
        {
            MatchCollection mc = reg.Matches(str);
            return mc.Count;
        }

        /// <summary>
        /// 正则匹配字符串出现的次数
        /// </summary>
        /// <param name="reg">正则表达式</param>
        /// <param name="str">被匹配的字符串</param>
        /// <param name="startat">开始匹配的位置</param>
        /// <returns></returns>
        public static int GetMatchCount(this string str, Regex reg, int startat)
        {
            MatchCollection mc = reg.Matches(str, startat);
            return mc.Count;
        }

        /// <summary>
        /// 字符串数组转成字符串
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="splitstr">分隔符</param>
        /// <returns></returns>
        public static string ArrayToString(this string str, string[] array, string splitstr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
                sb.Append(splitstr);
            }
            string result = sb.ToString();
            return result.Substring(0, result.Length - 1);
        }

        /// <summary>
        /// 获取字符串指定位置左侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetLeftString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(0, position);
            }
        }

        /// <summary>
        /// 获取字符串指定位置右侧的所有字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="position">位置</param>
        /// <returns></returns>
        public static string GetRightString(this string str, int position)
        {
            if (position <= 0)
                return string.Empty;
            else
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                return str.Substring(position, str.Length);
            }
        }

        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="str">半角字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 32)
                {
                    chars[i] = (char)12288;
                    continue;
                }
                if (chars[i] < 127)
                {
                    chars[i] = (char)(chars[i] + 65248);
                }
            }
            return new string(chars);
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="str">全角字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 12288)
                {
                    chars[i] = (char)32;
                    continue;
                }
                if (chars[i] > 65280 && chars[i] < 65375)
                    chars[i] = (char)(chars[i] - 65248);
            }
            return new string(chars);
        }

        /// <summary>
        /// 字符串转成繁体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>繁体中文字符串</returns>
        public static string ToTraditionalChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese);
        }

        /// <summary>
        /// 字符串转成简体中文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>简体中文字符串</returns>
        public static string ToSimplifiedChinese(this string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese);
        }

        /// <summary>
        /// 比较两个字符串大小
        /// </summary>
        /// <param name="s1">字符串变量</param>
        /// <param name="s2">字符串变量</param>
        /// <param name="IsIgnoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static int CompareString(this string s1, string s2, bool IsIgnoreCase)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
            {
                if (string.Compare(s1, s2, IsIgnoreCase) == 0)
                    return 0;
                else if (string.Compare(s1, s2, IsIgnoreCase) > 0)
                    return 1;
                else if (string.Compare(s1, s2, IsIgnoreCase) < 0)
                    return -1;
            }
            return -2;
        }

        /// <summary>
        /// 字符串转成Guid
        /// </summary>
        /// <param name="str">字符串变量</param>
        /// <returns>Guid</returns>
        public static Guid StringToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return Guid.Empty;
            return new Guid(str);
        }

        /// <summary>
        /// 去掉Guid中间的横杠
        /// </summary>
        /// <param name="guid">guid变量</param>
        /// <returns>字符串</returns>
        public static string RemoveGuidDash(this string s, Guid guid)
        {
            return guid.ToString("N");
        }

        /// <summary>
        /// 去掉字符串的前缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string TrimPrefix(this string str, string prefix)
        {
            if (!String.IsNullOrEmpty(str) && !String.IsNullOrEmpty(prefix) && str.StartsWith(prefix))
            {
                return str.Substring(prefix.Length);
            }
            return str;
        }

        /// <summary>
        /// 去掉字符串的后缀
        /// </summary>
        /// <param name="str"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string TrimSuffix(this string str, string suffix)
        {
            if (string.IsNullOrWhiteSpace(str) && !string.IsNullOrWhiteSpace(suffix) && str.EndsWith(suffix))
            {
                return str.Remove(str.Length - suffix.Length);
            }
            return str;
        }

        /// <summary>
        /// 判断字符可以转成数字
        /// </summary>
        /// <param name="theValue"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
