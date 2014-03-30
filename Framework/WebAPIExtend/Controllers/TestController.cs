using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPIExtend.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    public class TestController : ApiController
    {
        public TestController()
        { }

        /// <summary>
        /// 测试Session是否起效
        /// </summary>
        /// <returns></returns>
        public string GetFromSession()
        {
            if ((HttpContext.Current.Session["SomeData"] as string) == null)
                HttpContext.Current.Session["SomeData"] = "Hello from session";
            return (HttpContext.Current.Session["SomeData"] as string);
        }
    }
}