<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Web.Mvc;

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
=======
﻿using System.Web.Mvc;

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
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System.Web.Mvc;

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
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System.Web.Mvc;

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
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System.Web.Mvc;

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
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
}