using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPIExtend.CustomeAttribute;
using WebAPIExtend.CustomeHttpMessageHandler;
using WebAPIExtend.FormatterExtend;

namespace WebAPIExtend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.Insert(0, new JsonpMediaTypeFormatter());

            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsMessageHandler());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //GlobalConfiguration.Configuration.Filters.Add(new ElmahErrorAttribute());  //注册Elmah异常过滤器
        }
    }
}
