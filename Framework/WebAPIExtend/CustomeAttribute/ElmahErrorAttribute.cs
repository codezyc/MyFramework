using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace WebAPIExtend.CustomeAttribute
{
    /// <summary>
    /// Elmah异常过滤器
    /// </summary>
    public class ElmahErrorAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 重写OnException方法
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);  //Elmah记录异常
            }
            base.OnException(actionExecutedContext);
        }
    }
}