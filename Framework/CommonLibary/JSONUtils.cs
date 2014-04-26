using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Xml;

namespace CommonLibary
{
    /// <summary>
    /// JSON序列化和反序列化常用操作
    /// </summary>
    public static class JSONUtils
    {
        /// <summary>
        /// json转成xml
        /// </summary>
        /// <param name="jsondata">json字符串</param>
        /// <returns>xml文档</returns>
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
        /// <typeparam name="T">需要转成的实体类型</typeparam>
        /// <param name="t">泛型类实例</param>
        /// <param name="jsondata">json字符串</param>
        /// <returns>泛型类的实例</returns>
        public static T DeSerializeToObject<T>(string jsondata) where T : class
        {
            if (!string.IsNullOrEmpty(jsondata))
            {
                return JsonConvert.DeserializeObject<T>(jsondata);
            }
            return null;
        }

        /// <summary>
        /// 转换实体为JSON字符串
        /// </summary>
        /// <typeparam name="T">需要转成json字符串的实体类型</typeparam>
        /// <param name="t">泛型类实例</param>
        /// <returns>json字符串</returns>
        public static string ConvertObjectToString<T>(T t) where T : class
        {
            return t != null ? JsonConvert.SerializeObject(t) : string.Empty;
        }

        /// <summary>
        /// 序列化对象为json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            var js = new JavaScriptSerializer();
            return js.Serialize(obj);
        }

        /// <summary>
        /// 序列化对象为json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="recursionDepth">递归的深度</param>
        /// <returns></returns>
        public static string ToJson(this object obj, int recursionDepth)
        {
            var js = new JavaScriptSerializer();
            js.RecursionLimit = recursionDepth;
            return js.Serialize(obj);
        }
    }
}