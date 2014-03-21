using System;
using System.Text;

namespace CommonLibary
{
    /// <summary>
    /// C# Base64编码解码操作
    /// </summary>
    public static class Base64Utils
    {
        /// <summary>
        /// Base64位编码字符串
        /// </summary>
        public static string Base64Encode(string str, string charset)
        {
            byte[] bytes = Encoding.GetEncoding(charset).GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64解码字符串
        /// </summary>
        /// <param name="encodetext"></param>
        /// <returns></returns>
        public static string Base64Decode(string encodetext, string charset)
        {
            byte[] bytes = Convert.FromBase64String(encodetext);
            return Encoding.GetEncoding(charset).GetString(bytes);
        }
    }
}
