<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonLibary
{
    /// <summary>
    /// 部分方法参考
    /// http://extensionmethod.net/csharp/ienumerable-t
    /// </summary>
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

        /// <summary>
        /// 遍历集合中每一个元素，每一个委托元素都执行一个委托方法
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="enumeration">可遍历的泛型集合</param>
        /// <param name="action">委托方法</param>
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration) action(item);
        }

        /// <summary>
        /// Allows you to filter an IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> filterParam)
        {
            return list.Where(filterParam);
        }

        /// <summary>
        /// 删除字典中满足条件的键
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="condition"></param>
        public static void RemoveKeysByCondition<TKey, TValue>(this Dictionary<TKey, TValue> dict,
            Func<KeyValuePair<TKey, TValue>, bool> condition)
        {
            foreach (var cur in dict.Where(condition).ToList())
            {
                dict.Remove(cur.Key);
            }
        }

        /// <summary>
        /// 向字典中加入数据，如果数据存在，则不重复添加
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            return dict;
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonLibary
{
    /// <summary>
    /// 部分方法参考
    /// http://extensionmethod.net/csharp/ienumerable-t
    /// </summary>
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

        /// <summary>
        /// 遍历集合中每一个元素，每一个委托元素都执行一个委托方法
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="enumeration">可遍历的泛型集合</param>
        /// <param name="action">委托方法</param>
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration) action(item);
        }

        /// <summary>
        /// Allows you to filter an IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> filterParam)
        {
            return list.Where(filterParam);
        }

        /// <summary>
        /// 删除字典中满足条件的键
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="condition"></param>
        public static void RemoveKeysByCondition<TKey, TValue>(this Dictionary<TKey, TValue> dict,
            Func<KeyValuePair<TKey, TValue>, bool> condition)
        {
            foreach (var cur in dict.Where(condition).ToList())
            {
                dict.Remove(cur.Key);
            }
        }

        /// <summary>
        /// 向字典中加入数据，如果数据存在，则不重复添加
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            return dict;
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonLibary
{
    /// <summary>
    /// 部分方法参考
    /// http://extensionmethod.net/csharp/ienumerable-t
    /// </summary>
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

        /// <summary>
        /// 遍历集合中每一个元素，每一个委托元素都执行一个委托方法
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="enumeration">可遍历的泛型集合</param>
        /// <param name="action">委托方法</param>
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration) action(item);
        }

        /// <summary>
        /// Allows you to filter an IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> filterParam)
        {
            return list.Where(filterParam);
        }

        /// <summary>
        /// 删除字典中满足条件的键
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="condition"></param>
        public static void RemoveKeysByCondition<TKey, TValue>(this Dictionary<TKey, TValue> dict,
            Func<KeyValuePair<TKey, TValue>, bool> condition)
        {
            foreach (var cur in dict.Where(condition).ToList())
            {
                dict.Remove(cur.Key);
            }
        }

        /// <summary>
        /// 向字典中加入数据，如果数据存在，则不重复添加
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            return dict;
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
