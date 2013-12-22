using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebAPIExtend.Extension
{
    public static class HttpRequestMessageExtensions
    {
        public static bool IsPreflightRequest(this HttpRequestMessage request)
        {
            return request.Method == HttpMethod.Options &&
                request.Headers.GetValues("Origin").Any() &&
                request.Headers.GetValues("Access-Control-Request-Method").Any();
        }
    }
}