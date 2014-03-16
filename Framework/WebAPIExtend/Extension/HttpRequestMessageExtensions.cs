using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Hosting;
using System.Web.Http.ModelBinding;
using System.Web.Http.Properties;
using System.Web.Http.Results;
using System.Web.Http.Routing;

namespace WebAPIExtend.Extension
{
    /// <summary>
    /// 扩展HttpRequestMessage类的方法
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        #region 属性
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        #endregion

        /// <summary>
        /// Returns a dictionary of QueryStrings that's easier to work with 
        /// than GetQueryNameValuePairs KevValuePairs collection.
        /// If you need to pull a few single values use GetQueryString instead.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetQueryStrings(this HttpRequestMessage request)
        {
            return request.GetQueryNameValuePairs()
                          .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns an individual querystring value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetQueryString(this HttpRequestMessage request, string key)
        {
            // IEnumerable<KeyValuePair<string,string>> - right!
            var queryStrings = request.GetQueryNameValuePairs();
            if (queryStrings == null)
                return null;

            var match = queryStrings.FirstOrDefault(kv => string.Compare(kv.Key, key, true) == 0);
            if (string.IsNullOrEmpty(match.Value))
                return null;

            return match.Value;
        }

        /// <summary>
        /// Returns an individual HTTP Header value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHeader(this HttpRequestMessage request, string key)
        {
            IEnumerable<string> keys = null;
            if (!request.Headers.TryGetValues(key, out keys))
                return null;

            return keys.First();
        }

        /// <summary>
        /// Retrieves an individual cookie from the cookies collection
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static string GetCookie(this HttpRequestMessage request, string cookieName)
        {
            CookieHeaderValue cookie = request.Headers.GetCookies(cookieName).FirstOrDefault();
            if (cookie != null)
                return cookie[cookieName].Value;

            return null;
        }

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <param name="requestmessage"></param>
        /// <returns></returns>
        public static string GetClientIpAddress(this HttpRequestMessage requestmessage)
        {
            if (requestmessage.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = requestmessage.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }
            if (requestmessage.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = requestmessage.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }
            return null;
        }

        /// <summary>
        /// 检测调用是否来自于本地
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsLocal(this HttpRequestMessage request)
        {
            var localFlag = request.Properties["MS_IsLocal"] as Lazy<bool>;
            return localFlag != null && localFlag.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsPreflightRequest(this HttpRequestMessage request)
        {
            return request.Method == HttpMethod.Options &&
                request.Headers.GetValues("Origin").Any() &&
                request.Headers.GetValues("Access-Control-Request-Method").Any();
        }
    }
}