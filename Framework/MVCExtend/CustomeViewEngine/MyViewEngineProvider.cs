using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExtend.CustomeViewEngine
{
    public class MyViewEngineProvider : VirtualPathProviderViewEngine
    {
        public MyViewEngineProvider()
        {
            // Define the location of the View file
            this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.myview", 
          "~/Views/Shared/{0}.myview" }; //location and extension of our views
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
            MyCustomView obj = new MyCustomView(); // Custom view engine class
            obj.FolderPath = physicalpath; // set the path where the views will be stored
            return obj; // returned this view paresing
            // logic so that it can be registered in the view engine collection
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(partialPath);
            MyCustomView obj = new MyCustomView(); // Custom view engine class
            obj.FolderPath = physicalpath; // set the path where the views will be stored
            return obj;
            // returned this view paresing logic
            // so that it can be registered in the view engine collection
        }
    }
}