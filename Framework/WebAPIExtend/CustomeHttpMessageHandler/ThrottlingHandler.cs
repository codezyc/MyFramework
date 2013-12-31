using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace WebAPIExtend.CustomeHttpMessageHandler
{
    public class ThrottlingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var identifier = request.GetClientIpAddress();
            var identifier = "";
            long currentRequests = 1;
            long maxRequestsPerHour = 60;

            if (HttpContext.Current.Cache[string.Format("throttling_{0}", identifier)] != null)
            {
                currentRequests = (long)System.Web.HttpContext.Current.Cache[string.Format("throttling_{0}", identifier)] + 1;
                HttpContext.Current.Cache[string.Format("throttling_{0}", identifier)] = currentRequests;
            }
            else
            {
                HttpContext.Current.Cache.Add(string.Format("throttling_{0}", identifier), currentRequests,
                                                         null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1),
                                                         CacheItemPriority.Low, null);
            }

            Task<HttpResponseMessage> response = null;
            if (currentRequests > maxRequestsPerHour)
            {
                response = CreateResponse(request, HttpStatusCode.Conflict, "You are being throttled.");
            }
            else
            {
                response = base.SendAsync(request, cancellationToken);
            }

            return response;
        }

        protected Task<HttpResponseMessage> CreateResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            var response = request.CreateResponse(statusCode);
            response.ReasonPhrase = message;
            response.Content = new StringContent(message);
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}