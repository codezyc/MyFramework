using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace WebAPIExtend.FormatterExtend
{
    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public string Callback { set; get; }

        public JsonpMediaTypeFormatter()
        {
        }

        public JsonpMediaTypeFormatter(string callback = null)
        {
            this.Callback = callback;
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            if (string.IsNullOrWhiteSpace(this.Callback))
            {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
            try
            {
                this.WriteToStream(type, value, writeStream, content);
                return Task.FromResult<AsyncVoid>(new AsyncVoid());
            }
            catch (Exception ex)
            {
                TaskCompletionSource<AsyncVoid> source = new TaskCompletionSource<AsyncVoid>();
                source.SetException(ex);
                return source.Task;
            }

        }

        private void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
            using (StreamWriter sw = new StreamWriter(writeStream, this.SupportedEncodings.First()))
            {
                using (JsonTextWriter jtw = new JsonTextWriter(sw) { CloseOutput = false })
                {
                    jtw.WriteRaw(this.Callback + "(");
                    serializer.Serialize(jtw, value);
                    jtw.WriteRaw(")");
                }
            }
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, System.Net.Http.Headers.MediaTypeHeaderValue mediaType)
        {
            if (request.Method == HttpMethod.Get)
            {
                return this;
            }
            string callback;
            if (request.GetQueryNameValuePairs().ToDictionary(pair => pair.Key, pair => pair.Value)
                .TryGetValue("callback", out callback))
            {
                return new JsonpMediaTypeFormatter(callback);
            }
            return this;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid
        { }
    }
}