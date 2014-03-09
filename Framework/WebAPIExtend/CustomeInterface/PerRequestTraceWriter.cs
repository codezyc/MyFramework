using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Tracing;
using WebAPIExtend.HelpExtension;

namespace WebAPIExtend.CustomeInterface
{
    /// <summary>
    /// 记录跟踪每个Http请求
    /// </summary>
    public class PerRequestTraceWriter : ITraceWriter
    {
        private readonly ITraceWriter _innerWriter;

        public PerRequestTraceWriter()
            : this(null)
        { }

        public PerRequestTraceWriter(ITraceWriter innerWriter)
        {
            _innerWriter = innerWriter;
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (request != null)
            {
                var traceQueryString = request.GetQueryStrings().ToString();

                bool shouldTrace;
                if (traceQueryString != null & Boolean.TryParse(traceQueryString, out shouldTrace) & shouldTrace)
                {
                    object perRequestTrace;
                    if (!request.Properties.TryGetValue("perRequestTrace", out perRequestTrace))
                    {
                        perRequestTrace = new List<string>();
                        request.Properties["perRequestTrace"] = perRequestTrace;
                    }

                    var record = new TraceRecord(request, category, level);
                    traceAction(record);
                    (perRequestTrace as List<string>).Add(Log(record));
                }
            }

            if (_innerWriter != null)
            {
                _innerWriter.Trace(request, category, level, traceAction);
            }
        }

        private static string Log(TraceRecord record)
        {
            var message = new StringBuilder();

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message.Append(record.Request.Method);

                if (record.Request.RequestUri != null)
                    message.Append(" ").Append(record.Request.RequestUri.AbsoluteUri);
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append(" ").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append(" ").Append(record.Message);

            if (record.Exception != null & !string.IsNullOrWhiteSpace(record.Exception.GetBaseException().Message))
                message.Append(" ").Append(record.Exception.GetBaseException().Message);

            return string.Format("{0} {1}", record.Level, message);
        }
    }
}