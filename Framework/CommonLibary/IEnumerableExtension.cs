using System;
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
