using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace CommonLibary
{
    public class EnvironmentUtils
    {
        /// <summary>
        /// 获取NetBIOS名称
        /// </summary>
        /// <returns></returns>
        public static string GetMachineName()
        {
            return System.Environment.MachineName;
        }

        /// <summary>
        /// 获取计算机DNS的名称
        /// </summary>
        /// <returns></returns>
        public static string GetDNSName()
        {
            return System.Net.Dns.GetHostByName("LocalHost").HostName;
        }

        /// <summary>
        /// 获取计算机系统环境变量
        /// </summary>
        /// <returns></returns>
        public static string GetEnvironmentVariables()
        {
            string str = "";
            IDictionary dic = Environment.GetEnvironmentVariables();
            foreach (var key in dic.Keys)
            {
                str = str + key + ":" + dic[key] + Environment.NewLine;
            }
            return str;
        }

        // Import the kernel32 dll.
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

        /// <summary>
        /// 通过互操作来实现设置环境变量的值
        /// </summary>
        /// <param name="environmentVariable">环境变量的名称</param>
        /// <param name="variableValue">环境变量的值</param>
        /// <returns></returns>
        public static bool SetEnvironmentVariableEx(string environmentVariable, string variableValue)
        {
            try
            {
                // Get the write permission to set the environment variable.
                EnvironmentPermission environmentPermission = new EnvironmentPermission(EnvironmentPermissionAccess.Write, environmentVariable);
                environmentPermission.Demand();
                return SetEnvironmentVariable(environmentVariable, variableValue);
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Exception:" + e.Message);
            }
            return false;
        }
    }
}