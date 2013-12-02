using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommonLibary
{
    /// <summary>
    /// JSON常用操作
    /// </summary>
    public static class JSONUtils
    {
        /// <summary>
        /// json转成xml
        /// </summary>
        /// <param name="xmlpath"></param>
        /// <returns></returns>
        public static XmlDocument JsonToXml(string jsondata)
        {
            if (!string.IsNullOrEmpty(jsondata))
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(jsondata);
                return doc;
            }
            return null;
        }

        /// <summary>
        /// 反序列化成泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public static T DeSerializeToObject<T>(T t, string jsondata) where T : class
        {
            if (!string.IsNullOrEmpty(jsondata))
            {
                return JsonConvert.DeserializeObject<T>(jsondata);
            }
            return null;
        }
    }
}
