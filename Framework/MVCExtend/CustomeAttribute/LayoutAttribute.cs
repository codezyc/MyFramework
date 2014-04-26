using System.Web.Mvc;

namespace MVCExtend.CustomeAttribute
{
    public class LayoutAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 模板页的名称
        /// </summary>
        private readonly string _masterName;
        public LayoutAttribute(string masterName)
        {
            _masterName = masterName;
        }

        /// <summary>
        /// 重写OnActionExecuted方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.MasterName = _masterName;
            }
        }
    }
}