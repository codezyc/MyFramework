using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using System.Web.Routing;
using WebAPIExtend.CustomeHandler;
using WebAPIExtend.CustomeParameterBinding;

namespace WebAPIExtend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Register an action to create custom ParameterBinding
            config.ParameterBindingRules.Insert(0, GetCustomParameterBinding);

            config.Services.Add(typeof(IExceptionLogger), new TraceSourceExceptionLogger(new TraceSource("MyTraceSource", SourceLevels.All)));

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            #region 配置路由处理类为SessionRouteHandler
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionRouteHandler();
            #endregion
        }

        public static HttpParameterBinding GetCustomParameterBinding(HttpParameterDescriptor descriptor)
        {
            if (descriptor.ParameterType == typeof(object))
            {
                return new FromUriOrBodyParameterBinding(descriptor);
            }
            return null;
        }
    }
}
