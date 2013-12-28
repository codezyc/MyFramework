using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace WebAPIExtend.CustomeAttribute
{
    /// <summary>
    /// 自定义Web Api相关的配置
    /// </summary>
    public class CustomControllerConfigAttribute:Attribute,IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            // Insert custom parameter binder as the first in line
            //controllerSettings.ParameterBindingRules.Insert(0,parameterDescriptor => new MultipleParameterFromBodyParameterBinding(parameterDescriptor));

            // Register an additional plain text media type formatter
            //controllerSettings.Formatters.Add(new PlainTextBufferedFormatter());
        }
    }
}