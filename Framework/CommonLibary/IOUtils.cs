using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary
{
    /// <summary>
    /// 文件常用操作
    /// </summary>
    public static class IOUtils
    {
        /// <summary>
        /// 读取文件中的所有字符
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string ReadAllText(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// 同步写文件
        /// </summary>
        /// <param name="str">写入内容</param>
        /// <param name="path">文件路径</param>
        /// <param name="buffersize">缓冲区大小</param>
        /// <returns></returns>
        public static void WriteToFile(string str, string path, int buffersize)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                if (File.Exists(path))
                    sw.Write(str);
                else
                {
                    File.Create(path, buffersize, FileOptions.RandomAccess);
                    sw.Write(str);
                }
            }
        }

        /// <summary>
        /// 异步写文件
        /// </summary>
        /// <param name="str">写入内容</param>
        /// <param name="path">文件路径</param>
        /// <param name="buffersize">缓冲区大小</param>
        /// <returns>操作结果的布尔值</returns>
        public static bool WriteToFileAsync(string str, string path, int buffersize)
        {
            using (var sw = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path, buffersize, FileOptions.RandomAccess);
                    Task t = sw.WriteAsync(str);
                    if (t.IsCompleted && t.IsFaulted == false)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 异步读取文件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        /// <param name="buffersize"></param>
        /// <returns></returns>
        public static bool ReadAllTextAsync(string str, string path, int buffersize)
        {
            using (var sr = new StreamReader(path))
            {
                Task t = sr.ReadToEndAsync();
                if (t.IsCompleted && t.IsFaulted == false)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
