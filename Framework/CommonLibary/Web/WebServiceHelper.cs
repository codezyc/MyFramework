using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace CommonLibary.Web
{
    /// <summary>
    /// C# WebService常用操作
    /// </summary>
    public static class WebServiceHelper
    {
        /// <summary>
        /// 动态调用WebService
        /// </summary>
        /// <param name="url">web服务的地址</param>
        /// <param name="methodname">调用服务的名称</param>
        /// <param name="args">web服务所需的参数数组集合</param>
        /// <returns></returns>
        public static object InvokeWebService(string url, string methodname, object[] args)
        {
            return InvokeWebService(url, null, methodname, args);
        }

        /// <summary>
        /// 动态调用WebService
        /// </summary>
        /// <param name="url">web服务地址</param>
        /// <param name="namespaces">调用服务的命名空间</param>
        /// <param name="methodname">调用服务的名称</param>
        /// <param name="args">web服务所需的参数数组集合</param>
        /// <returns></returns>
        public static object InvokeWebService(string url, string namespaces, string methodname, object[] args)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    using (Stream sr = wc.OpenRead(url + "?WSDL"))
                    {
                        ServiceDescription sd = ServiceDescription.Read(sr);
                        string classname = sd.ServiceDescriptions[0].Name;
                        ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                        sdi.AddServiceDescription(sd, "", "");
                        CodeNamespace cn = new CodeNamespace(namespaces);

                        CodeCompileUnit ccu = new CodeCompileUnit();
                        ccu.Namespaces.Add(cn);
                        sdi.Import(cn, ccu);
                        using (CSharpCodeProvider csc = new CSharpCodeProvider())
                        {
                            ICodeCompiler icc = csc.CreateCompiler();

                            CompilerParameters cp = new CompilerParameters();
                            cp.GenerateExecutable = false;
                            cp.GenerateInMemory = true;
                            cp.ReferencedAssemblies.Add("System.dll");
                            cp.ReferencedAssemblies.Add("System.XML.dll");
                            cp.ReferencedAssemblies.Add("System.Web.Services.dll");
                            cp.ReferencedAssemblies.Add("System.Data.dll");

                            CompilerResults cr = icc.CompileAssemblyFromDom(cp, ccu);
                            if (cr.Errors.HasErrors == true)
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (CompilerError item in cr.Errors)
                                {
                                    sb.Append(item.ToString());
                                    sb.Append(System.Environment.NewLine);
                                }
                                throw new Exception(sb.ToString());
                            }

                            Assembly assembly = cr.CompiledAssembly;
                            Type t = assembly.GetType(namespaces + "." + classname, true, true);
                            object obj = Activator.CreateInstance(t);
                            MethodInfo methodinfo = t.GetMethod(methodname);
                            return methodinfo.Invoke(obj, args);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
