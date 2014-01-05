using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary
{
    /// <summary>
    /// 枚举的常用操作类
    /// </summary>
    public static class EnumUtils
    {
        /// <summary>
        /// 获取枚举类中的所有名称
        /// </summary>
        /// <param name="t">枚举类的类型</param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllEnumName(Type t)
        {
            IList<string> enumlist = new List<string>();
            foreach (var s in Enum.GetNames(t))
            {
                enumlist.Add(s);
            }
            return enumlist;
        }

        /// <summary>
        /// 字符串转成枚举类型
        /// </summary>
        /// <param name="enumtype">枚举类型</param>
        /// <param name="value">字符串值</param>
        /// <returns></returns>
        public static object StringToEnum(Type enumtype, string value)
        {
            return Enum.Parse(enumtype, value);
        }

        /// <summary>
        /// 获取枚举类型中的所有值
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <returns></returns>
        public static IEnumerable<int> GetAllEnumValue(Type t)
        {
            IList<int> enumlist = new List<int>();
            foreach (int i in Enum.GetValues(t))
            {
                enumlist.Add(i);
            }
            return enumlist;
        }

        /// <summary>
        /// 获得枚举值上定义的描述字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDecriptionString(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute), false);
            if (!string.IsNullOrWhiteSpace(attribute.Description))
            {
                return attribute.Description;
            }
            return string.Empty;
        }

        /// <summary>
        /// 通过枚举值返回此枚举类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="descriptionorvalue"></param>
        /// <returns></returns>
        public static object EnumValueOf<T>(this string descriptionorvalue)
        {
            Array values = Enum.GetValues(typeof(T));
            foreach (Enum item in values)
            {
                if (item.GetDecriptionString().Equals(descriptionorvalue) || item.ToString().Equals(descriptionorvalue))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
