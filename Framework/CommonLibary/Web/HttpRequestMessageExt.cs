using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CommonLibary.Web
{
    /// <summary>
    /// HttpRequestMessage常用扩展方法
    /// </summary>
    public static class HttpRequestMessageExt
    {
        /// <summary>
        /// 从Http请求头信息中获取用户名和密码
        /// </summary>
        /// <param name="httprequestmessage"></param>
        /// <returns></returns>
        public static Tuple<string, string> ExtractUserNameAndPasswordFromHttpHeader(this HttpRequestMessage httprequestmessage)
        {
            Dictionary<string, string> headers = httprequestmessage.ReadHeaders();
            if (headers.ContainsKey("Authorization"))
            {
                string authHeaderValue = headers["Authorization"];
                authHeaderValue = authHeaderValue.Trim();
                string encodedCredentials = authHeaderValue.Substring(6);
                byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
                string s = new ASCIIEncoding().GetString(decodedBytes);
                string[] userPass = s.Split(new char[] { ':' });
                string username = userPass[0];
                string password = userPass[1];
                return new Tuple<string, string>(username, password);
            }
            else
            {
                //throw new ArgumentNullException("Username and password couldn't be extracted from the HttpHeaders collection.");
                return null;
            }
        }

        /// <summary>
        /// 读取Http请求头信息
        /// </summary>
        /// <param name="requestmessage"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadHeaders(this HttpRequestMessage requestmessage)
        {
            return ExtractHeaders(requestmessage.Headers);
        }

        /// <summary>
        /// 获取Http请求头信息
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ExtractHeaders(HttpHeaders headers)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var kvp in headers.ToList())
            {
                if (kvp.Value != null)
                {
                    string header = string.Empty;
                    foreach (var j in kvp.Value)
                    {
                        header += j + " ";
                    }
                    dic.Add(kvp.Key, header);
                }
            }
            return dic;
        }
    }
}
