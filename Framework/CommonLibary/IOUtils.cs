using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;
using System.Management;

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
                if (!fileinfo.IsReadOnly)
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

        /// <summary>
        /// 删除指定路径的文件或文件夹
        /// </summary>
        /// <param name="path">文件或文件夹路径</param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="filepath">待压缩文件路径</param>
        /// <param name="zipfilepath">压缩后文件路径</param>
        public static void ZipFile(string filepath, string zipfilepath)
        {
            if (File.Exists(filepath))
            {
                FileInfo fileinfo = new FileInfo(filepath);
                using (FileStream fs = fileinfo.OpenRead())
                {
                    if (File.Exists(zipfilepath))
                        DeleteFile(zipfilepath);
                    using (FileStream compressedstream = File.Create(zipfilepath))
                    {
                        using (GZipStream zipstream = new GZipStream(compressedstream, CompressionMode.Compress))
                        {
                            fs.CopyTo(zipstream);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="zipfilepath">压缩文件路径</param>
        /// <param name="filepath">解压后文件路径</param>
        public static void UnZipFile(string zipfilepath, string filepath)
        {
            FileInfo fileinfo = new FileInfo(zipfilepath);
            using (FileStream fs = fileinfo.OpenRead())
            {
                if (File.Exists(zipfilepath))
                    DeleteFile(zipfilepath);
                using (FileStream decompress = File.Create(filepath))
                {
                    using (GZipStream gzip = new GZipStream(fs, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(decompress);
                    }
                }
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
        public static void ReNameDirectory(string path, string newdirectoryname)
        {
            Computer cp = new Computer();
            cp.FileSystem.RenameDirectory(path, newdirectoryname);
        }

        /// <summary>
        /// 递归删除文件夹
        /// </summary>
        /// <param name="path">待删除文件夹的路径</param>
        public static void RecursionDeleteDirectories(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    if (File.Exists(dir))
                    {
                        File.Delete(dir);
                    }
                    else
                        RecursionDeleteDirectories(dir);
                }
                Directory.Delete(path);
            }
        }

        /// <summary>
        /// 递归复制文件夹
        /// </summary>
        /// <param name="currentpath">文件夹路径</param>
        /// <param name="copypath">目标路径</param>
        public static void RecursionCopyDirectory(string currentpath, string copypath)
        {
            currentpath = currentpath.EndsWith(@"\") ? currentpath : currentpath + @"\";
            copypath = copypath.EndsWith(@"\") ? copypath : copypath + @"\";
            if (Directory.Exists(currentpath))
            {
                if (Directory.Exists(copypath))
                {
                    Directory.CreateDirectory(copypath);
                }
                foreach (var file in Directory.GetFiles(currentpath))
                {
                    File.Copy(currentpath, copypath);
                }
                foreach (var dir in Directory.GetDirectories(currentpath))
                {
                    DirectoryInfo dirinfo = new DirectoryInfo(dir);
                    RecursionCopyDirectory(currentpath + dirinfo.Name, copypath + dirinfo.Name);
                }
            }
        }

        #endregion

        #region 硬件相关
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

        /// <summary>
        /// 获取机器CPU相关信息
        /// </summary>
        /// <returns></returns>
        public static string GetCPUInfo()
        {
            string cpuinfo = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (var item in moc)
            {
                cpuinfo = cpuinfo + item.Properties["ProccessorId"].Value.ToString();
            }
            return cpuinfo;
        }

        /// <summary>
        /// 获取硬盘的序列号
        /// </summary>
        /// <returns></returns>
        public static string GetHardDriveNumber()
        {
            string number = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (var item in moc)
            {
                number = number + item.Properties["Model"].Value.ToString();
            }
            return number;
        }

        /// <summary>
        /// 获取网卡地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            string macaddress = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_NetWorkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (var item in moc)
            {
                if ((bool)item["IPEnabled"] == true)
                    macaddress = macaddress + item.Properties["MacAddress"].ToString();
            }
            return macaddress;
        }

        #endregion

        #region 剪贴板相关
        /// <summary>
        /// 向剪贴板上设置数据
        /// </summary>
        /// <param name="content">设置内容</param>
        /// <param name="IsKeep">程序退出时剪贴板是否保持设置的内容</param>
        public static void SetDataOnClipBoard(string content, bool IsKeep)
        {
            Clipboard.SetDataObject(content, IsKeep);
        }

        /// <summary>
        /// 从剪贴板获取数据
        /// </summary>
        /// <returns></returns>
        public static string GetDataFromClipBoard()
        {
            IDataObject dataobj = Clipboard.GetDataObject();
            if (dataobj.GetDataPresent(DataFormats.Text))
            {
                return dataobj.GetData(DataFormats.Text).ToString();
            }
            return string.Empty;
        }

        #endregion
    }
}
