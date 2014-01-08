using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace CommonLibary
{
    /// <summary>
    /// C#反射常用操作
    /// </summary>
    public static class ReflectionUtils
    {
        /// <summary>
        /// 反射创建对象实例
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="dllname">程序集名称</param>
        /// <param name="nameSpace">命名空间</param>
        /// <param name="classname">类名</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string dllname, string nameSpace, string classname) where T : class
        {
            Assembly assembly = Assembly.Load(dllname);
            return (T)assembly.CreateInstance(nameSpace + "." + classname);
        }

        /// <summary>
        /// 反射创建对象实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="dllpath">dll文件路径</param>
        /// <param name="fullname">命名空间.类名</param>
        /// <returns></returns>
        public static T CreatInstance<T>(string dllpath, string fullname) where T : class
        {
            if (File.Exists(dllpath))
            {
                Assembly assembly = Assembly.LoadFile(dllpath);
                return (T)assembly.CreateInstance(fullname);
            }
            return null;
        }

        /// <summary>
        /// 反射动态调用方法
        /// </summary>
        /// <param name="dllpath">dll文件路径</param>
        /// <param name="fullname">命名空间.类名</param>
        /// <param name="methodname">方法名称</param>
        /// <param name="values">所需参数数组</param>
        /// <returns>返回动态调用方法的返回值</returns>
        public static object DynamicCallMethod(string dllpath, string fullname, string methodname, object[] values)
        {
            Assembly assembly = Assembly.LoadFile(dllpath);
            object obj = assembly.CreateInstance(fullname);
            MethodInfo methodinfo = obj.GetType().GetMethod(methodname);
            return methodinfo.Invoke(obj, values);
        }

        /// <summary>
        /// 反射调用泛型方法
        /// </summary>
        /// <param name="dllpath">dll文件路径</param>
        /// <param name="fullname">命名空间.类名</param>
        /// <param name="methodname">调用的方法名称</param>
        /// <param name="t">泛型数组</param>
        /// <param name="values">所需参数数组</param>
        /// <returns>返回动态调用方法的返回值</returns>
        public static object DynamicCallGenericMethod(string dllpath, string fullname, string methodname, Type[] t, object[] values)
        {
            Assembly assembly = Assembly.LoadFile(dllpath);
            object obj = assembly.CreateInstance(fullname);
            MethodInfo methodinfo = obj.GetType().GetMethod(methodname);
            MethodInfo genericmethodinfo = methodinfo.MakeGenericMethod(t);
            return genericmethodinfo.Invoke(obj, values);
        }

        /// <summary>
        /// DataTable转成对象列表
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="dt">DataTable对象</param>
        /// <returns>可遍历的对象列表</returns>
        public static IEnumerable<T> DataTableToModelList<T>(DataTable dt)
        {
            IList<T> modellist = new List<T>();
            Type type = typeof(T);
            string tempname = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] properties = t.GetType().GetProperties();
                foreach (var propertyInfo in properties)
                {
                    tempname = propertyInfo.Name;
                    if (dt.Columns.Contains(tempname))
                    {
                        if (!propertyInfo.CanWrite) continue;
                        object value = dr[tempname];
                        if (value != DBNull.Value)
                        {
                            propertyInfo.SetValue(t, value, null);
                        }
                    }
                    modellist.Add(t);
                }
            }
            return modellist;
        }

        /// <summary>
        /// 通过反射创建泛型类的对象
        /// </summary>
        /// <param name="t">返回泛型类对象的类型</param>
        /// <param name="tkey"></param>
        /// <param name="tvalue"></param>
        /// <returns></returns>
        public static object CreateGenericObject(Type t, string tkey, string tvalue)
        {
            Type typeargument1 = Type.GetType(tkey);
            Type typeargument2 = Type.GetType(tvalue);
            Type genericClass = t;
            Type construtedClass = genericClass.MakeGenericType(new[] { typeargument1, typeargument2 });
            object obj = Activator.CreateInstance(construtedClass);
            return obj;
        }

        /// <summary>
        /// 通过反射创建泛型类的对象
        /// </summary>
        /// <param name="t">返回泛型类对象的类型</param>
        /// <param name="tkey"></param>
        /// <returns></returns>
        public static object CreateGenericObject(Type t, string tkey)
        {
            Type typeargument1 = Type.GetType(tkey);
            Type genericClass = t;
            Type construtedClass = genericClass.MakeGenericType(new[] { typeargument1 });
            object obj = Activator.CreateInstance(construtedClass);
            return obj;
        }
    }
}
