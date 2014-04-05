using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary.CollectionExt
{
    /// <summary>
    /// ArrayList的常用扩展方法
    /// </summary>
    public static class ArrayListExt
    {
        /// <summary>
        /// Convert ArrayList To List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arraylist"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this ArrayList arraylist)
        {
            List<T> list = new List<T>();
            foreach (var item in arraylist)
            {
                list.Add((T)item);
            }
            return list;
        }
    }
}
