using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace WebAPIExtend.CustomeParameterBinding
{
    public class PrincipalParameterBinding : HttpParameterBinding
    {
        public PrincipalParameterBinding(HttpParameterDescriptor desc)
            : base(desc)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            // Set the binding result here
            SetValue(actionContext, new GenericPrincipal(new GenericIdentity("MyIdentity"), new string[] { "myrole" }));

            // now, we can return a completed task with no result
            TaskCompletionSource<AsyncVoid> tcs = new TaskCompletionSource<AsyncVoid>();
            tcs.SetResult(default(AsyncVoid));
            return tcs.Task;
        }

        private struct AsyncVoid
        {
        }
    }
}