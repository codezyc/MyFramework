using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExtend.CustomeViewEngine
{
    public class MyCustomView : IView
    {
        private string _FolderPath; // Define where  our views are stored
        public string FolderPath
        {
            get { return _FolderPath; }
            set { _FolderPath = value; }
        }
        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            // Parsing logic <dateTime>
            // read the view file
            string strFileData = File.ReadAllText(_FolderPath);
            // we need to and replace <datetime> datetime.now value
            string strFinal = strFileData.Replace("<DateTime>", DateTime.Now.ToString());
            // this replaced data has to sent for display
            writer.Write(strFinal);
        }
    }
}