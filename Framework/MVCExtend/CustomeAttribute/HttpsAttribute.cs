using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExtend.CustomeAttribute
{
    public class HttpsAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Url.Scheme != "https")
            {
                throw new InvalidOperationException("请使用HTTPS协议");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}