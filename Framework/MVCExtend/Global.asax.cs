using MVCExtend.CustomeViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCExtend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //注册自定义视图引擎
            ViewEngines.Engines.Add(new MyViewEngineProvider());
        }

        /// <summary>
        /// 全局异常处理方法
        /// </summary>
        protected void Application_Error()
        {
            Exception unhandledException = Server.GetLastError();
            int httpCode = 0;

            // Handle HTTP errors
            if (unhandledException.GetType() == typeof(HttpException))
            {
                HttpException httpException = unhandledException as HttpException;

                if (httpException == null)
                {
                    Exception innerException = unhandledException.InnerException;
                    httpException = innerException as HttpException;
                }

                if (httpException != null)
                {
                    httpCode = httpException.GetHttpCode();
                    switch (httpCode)
                    {
                        case (int)HttpStatusCode.Unauthorized:
                            Response.Redirect("/Http/Error401");
                            break;
                        case 400:
                            Response.Redirect("~/HTTP404Error.aspx");
                            break;
                        default: Response.Redirect("~/");
                            break;
                    }
                }
            }

            // Log the exception and notify system operators
            // You can create Class file e.g. Exception utility to log error details either in database or text file
            //ExceptionUtility.LogException(unhandledException, Request.Url.ToString(), httpCode);
            // Clear the error from the server
            Server.ClearError();
        }
    }
}
