using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExtend.CustomeController
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 重写MVC验证的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controllername = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionname = filterContext.ActionDescriptor.ActionName;
            if (this.GetUserAuthorize(this.HttpContext.User.Identity.Name, controllername, actionname))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                const string ViewName = "~/Views/Account/Login.cshtml";
                var vr = new ViewResult { ViewName = ViewName };
                filterContext.Result = vr;
            }
        }

        /// <summary>
        /// 获取用户是否合法
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        private bool GetUserAuthorize(string userId, string controllerName, string actionName)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            //访问数据库中相关的用户、角色、功能权限等表看是否具有访问此action的权限
            //有返回true,否则false

            return true;
        }
    }
}