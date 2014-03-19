using System;
using System.IO;
using System.Web.Mvc;

namespace MVCExtend.Extensions
{
    /// <summary>
    /// MVC扩展方法
    /// </summary>
    public static class MVCExtensions
    {
        /// <summary>
        /// 渲染视图，获得html代码
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string RenderingViewToString(this ControllerContext context, string viewName, object model)
        {
            if (string.IsNullOrWhiteSpace(viewName))
            {
                viewName = context.RouteData.GetRequiredString("action");
            }
            context.Controller.ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewresult = ViewEngines.Engines.FindPartialView(context, viewName);
                ViewContext vc = new ViewContext(context, viewresult.View, context.Controller.ViewData,
                    context.Controller.TempData, sw);
                try
                {
                    viewresult.View.Render(vc, sw);
                }
                catch (Exception ex)
                {
                    //进行异常处理
                }
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}