using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace WebAPIExtend.CustomeHttpMessageHandler
{
    /// <summary>
    /// 自定义证书验证消息处理类
    /// </summary>
    public class CustomCertificateMessageHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Retrieving the Client certificate sent by the client
            X509Certificate cert = request.GetClientCertificate();

            // The following code SHOULD be replaced with some custom mapping logic from client certificate to their roles. 
            // The client certificate is not being checked for certificate revocation or ensure PKI validity. 
            if (cert != null)
            {
                if (cert.GetCertHashString() == "") //Program.ClientCertHash
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(cert.Subject), new[] { "Administrators" });
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}