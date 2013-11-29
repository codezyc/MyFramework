using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;

namespace CommonLibary
{
    /// <summary>
    /// 文件常用操作
    /// </summary>
    public static class IOUtils
    {

        #region 文件相关操作
        /// <summary>
        /// 读取文件中的所有字符
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string ReadAllText(string path)
        {
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
            return string.Empty;
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
            if (!File.Exists(path))
            {
                using (var sw = new StreamWriter(path))
                {

                    File.Create(path, buffersize, FileOptions.RandomAccess);
                    Task t = sw.WriteAsync(str);
                    if (t.IsCompleted && t.IsFaulted == false)
                    {
                        return true;
                    }

                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 异步读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="buffersize"></param>
        /// <returns></returns>
        public static bool ReadAllTextAsync(string path, int buffersize)
        {
            if (File.Exists(path))
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
            return false;
        }

        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileSuffix(string path)
        {
            if (File.Exists(path))
                return Path.GetExtension(path);
            return string.Empty;
        }

        /// <summary>
        /// 获取文件版本信息
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileVersion(string path)
        {
            string filename = Path.GetFileName(path);
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(filename);
            return fvi.FileVersion;
        }

        /// <summary>
        /// 获取文件的创建时间
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static DateTime GetFileCreateTime(string path)
        {
            string filename = Path.GetFileName(path);
            FileInfo fileinfo = new FileInfo(filename);
            return fileinfo.CreationTime;
        }

        /// <summary>
        /// 获取文件最后的修改时间
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static DateTime GetFileLastModifiedTime(string path)
        {
            string filename = Path.GetFileName(path);
            FileInfo fileinfo = new FileInfo(filename);
            return fileinfo.LastWriteTime;
        }

        /// <summary>
        /// 修改文件后缀名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newsuffix"></param>
        public static bool ChangeFileSuffix(string path, string newsuffix)
        {
            if (File.Exists(path))
            {
                Path.ChangeExtension(path, newsuffix);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 二进制流读取字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string BinaryReadString(string path)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader reader = new BinaryReader(fs);
                return reader.ReadString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 二进制流写文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="content">写入内容</param>
        /// <returns></returns>
        public static bool BinaryWriteString(string path, string content)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                BinaryWriter writer = new BinaryWriter(fs);
                writer.Write(content);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置文件只读属性
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void SetFileReadOnly(string path)
        {
            if (File.Exists(path))
            {
                FileInfo fileinfo = new FileInfo(path);
                if(!fileinfo.IsReadOnly)
                    fileinfo.Attributes = FileAttributes.ReadOnly;
            }
        }

        /// <summary>
        /// 去掉文件只读属性
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void RemoveFileReadOnly(string path)
        {
            if (File.Exists(path))
            {
                FileInfo fileinfo = new FileInfo(path);
                if (fileinfo.IsReadOnly)
                    fileinfo.Attributes = FileAttributes.Normal;
            }
        }


        #endregion

        #region 文件夹相关操作
        /// <summary>
        /// 遍历指定路径的文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<FileSystemInfo> ListAllDirectories(string path)
        {
            var dirinfo = new DirectoryInfo(path);
            foreach (FileSystemInfo info in dirinfo.GetDirectories())
            {
                yield return info;
            }
        }

        /// <summary>
        /// 创建新文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void CreateDiretory(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 重命名文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="newdirectoryname"></param>
        public static void ReNameDirectory(string path,string newdirectoryname)
        {
            Computer cp = new Computer();
            cp.FileSystem.RenameDirectory(path, newdirectoryname);
        }


        #endregion


        #region 驱动器相关
        /// <summary>
        /// 获取驱动器信息
        /// </summary>
        /// <returns>返回驱动器集合</returns>
        public static IEnumerable<DriveInfo> GetDrives()
        {
            IList<DriveInfo> drivers = new List<DriveInfo>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var driveInfo in drives)
            {
                drivers.Add(driveInfo);
            }
            return drivers;
        }

        #endregion
    }
}
