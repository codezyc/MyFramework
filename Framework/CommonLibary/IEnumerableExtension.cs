using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonLibary
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// 判断集合中的元素是否为空或为空集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            if (list == null)
            {
                return false;
            }
            if (list is ICollection<T>)
            {
                return ((ICollection<T>)list).Count == 0;
            }
            return !list.Any();
        }

        /// <summary>
        /// 查找IEnumerable对象中是否有相等的字符串匹配
        /// </summary>
        /// <param name="list">IEnumerable对象</param>
        /// <param name="itemToMatch">需要匹配的字符串</param>
        /// <returns></returns>
        public static IEnumerable<string> IfMatchWith(this IEnumerable<string> list, string itemToMatch)
        {
            if (!string.IsNullOrWhiteSpace(itemToMatch))
            {
                foreach (var item in list.Where(str => str.Equals(itemToMatch)))
                    yield return item;
            }
        }

        /// <summary>
        /// 查找IEnumerable对象中跟匹配字符串不相等的记录
        /// </summary>
        /// <param name="list">IEnumerable对象</param>
        /// <param name="itemToMatch">比较的字符串</param>
        /// <returns></returns>
        public static IEnumerable<string> IfNotMatchWith(this IEnumerable<string> list, string itemToMatch)
        {
            if (string.IsNullOrWhiteSpace(itemToMatch))
            {
                foreach (var item in list.Where(str => str != itemToMatch))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// 去掉IEnumerable对象中内容为空或null或空格的值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<string> IgnoreNullOrEmptyOrWhiteSpace(this IEnumerable<string> list)
        {
            foreach (var item in list.Where(str => !string.IsNullOrWhiteSpace(str)))
            {
                yield return item;
            }
        }


        /// <summary>
        /// 将集合中所有的字符串变成大写字符
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<string> MakeItAllUpper(this IEnumerable<string> list)
        {
            foreach (var item in list)
            {
                yield return item.ToUpper();
            }
        }

        /// <summary>
        /// 将集合中所有的字符串变成小写字符
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<string> MakeItAllLower(this IEnumerable<string> list)
        {
            foreach (var item in list)
            {
                yield return item.ToLower();
            }
        }

        /// <summary>
        /// 使用正则表达式查找所有匹配的记录
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static IEnumerable<string> IfMatchWithPattern(this IEnumerable<string> list, string pattern)
        {
            foreach (var item in list.Where(str => Regex.IsMatch(str, pattern)))
            {
                yield return item;
            }
        }
    }
}
