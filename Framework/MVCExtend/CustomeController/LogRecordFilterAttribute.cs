using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace MVCExtend.CustomeController
{
    /// <summary>
    /// 日志记录过滤器(可以记录Action方法的调用日志，并记录相关Action的参数)
    /// </summary>
    public class LogRecordFilterAttribute : Controller
    {
        /// <summary>
        /// 重写OnActionExecuting方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int parametersCount = filterContext.ActionParameters.Count;
            if (parametersCount > 0)
            {
                var keys = filterContext.ActionParameters.Keys;

                foreach (string key in keys)
                {
                    var value = filterContext.ActionParameters[key];
                    if (null == value)
                        continue;
                    if (value.GetType().IsClass && value.GetType().Name != "String")
                    {
                        object objClass = value;
                        PropertyInfo[] infos = objClass.GetType().GetProperties();
                        foreach (PropertyInfo info in infos)
                        {
                            if (info.CanRead)
                            {
                                Console.WriteLine(info.Name + "=" + info.GetValue(objClass, null));
                            }
                        }
                    }
                }
            }
        }
    }
}