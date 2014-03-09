using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebAPIExtend.CustomeHttpMessageHandler
{
    public class TraceHelperHandler : DelegatingHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            object perRequestTrace;
            if (request.Properties.TryGetValue("perRequestTrace", out perRequestTrace))
            {
                var trace = perRequestTrace as List<string>;
                if (trace != null)
                {
                    for (var i = 0; i < trace.Count; i++)
                    {
                        response.Headers.Add("Trace" + i.ToString("D2"), trace[i]);
                    }
                }
            }
            return response;
        }
    }
}