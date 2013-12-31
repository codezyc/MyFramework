using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ApiLoggingInfo
    {
        private List<string> _headers = new List<string>();

        public string HttpMethod { get; set; }
        public string UriAccessed { get; set; }
        public string BodyContent { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }
        public string ResponseStatusMessage { get; set; }
        public string IpAddress { get; set; }
        public HttpMessageType MessageType { get; set; }

        public List<string> Headers
        {
            get { return _headers; }
        }
    }

    public enum HttpMessageType
    {
        Request,
        Response
    }
}
