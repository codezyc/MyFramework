using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace WebAPIExtend.CustomeParameterBinding
{
    public class CustomModelBinderWithPropertyName : HttpParameterBinding
    {
        public CustomModelBinderWithPropertyName(HttpParameterDescriptor desc)
            : base(desc)
        {
        }

        public override System.Threading.Tasks.Task ExecuteBindingAsync(System.Web.Http.Metadata.ModelMetadataProvider metadataProvider, HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            // read the query and construct the object myself
            //TestItemRenameProperty property = new TestItemRenameProperty { Name = actionContext.Request.RequestUri.ParseQueryString()["$Name"] };

            // Set the binding result here
            //SetValue(actionContext, property);

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