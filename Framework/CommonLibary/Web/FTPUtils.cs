using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CommonLibary.Web
{
    /// <summary>
    /// FTP工具类
    /// </summary>
    public class FtpUtils
    {
        /// <summary>
        /// FTP上传文件
        /// </summary>
        /// <param name="filepath">上传文件的路径</param>
        /// <param name="uri">ftp路径</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool UpLoadSingleFile(string filepath, string uri, string username, string password)
        {
            if (!File.Exists(filepath))
            {
                return false;
            }
            using (FileStream fs = File.OpenRead(filepath))
            {

            }


            return true;
        }

        /// <summary>
        /// 上传多个文件
        /// </summary>
        /// <param name="filepath">多个上传文件的路径</param>
        /// <param name="uri">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool UpLoadMultiFile(IEnumerable<string> filepath, string uri, string username, string password)
        {

            return true;
        }

        /// <summary>
        /// 列出FTP上的所有目录
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static IEnumerable<string> ListAllDirectories(string uri, string username, string password)
        {


            return null;
        }

        /// <summary>
        /// 从FTP上下载单个文件
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="localpath">文件下载的物理路径</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool DownLoadSingleFile(string uri, string localpath, string username, string password)
        {
            try
            {
                using (FileStream outputStream = new FileStream("", FileMode.Create))
                {
                    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("" + "/" + ""));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = false;
                    reqFTP.UsePassive = false;
                    reqFTP.KeepAlive = true;
                    reqFTP.Credentials = new NetworkCredential("", "");
                    using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                    {
                        using (Stream ftpStream = response.GetResponseStream())
                        {
                            int bufferSize = 2048;
                            int readCount;
                            byte[] buffer = new byte[bufferSize];
                            readCount = ftpStream.Read(buffer, 0, bufferSize);
                            while (readCount > 0)
                            {
                                outputStream.Write(buffer, 0, readCount);
                                readCount = ftpStream.Read(buffer, 0, bufferSize);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 下载多个文件
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="filenames">下载的文件名的集合</param>
        /// <param name="localpath">下载地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool DownLoadMultiFile(string uri, IEnumerable<string> filenames, string localpath, string username, string password)
        {


            return true;
        }

        /// <summary>
        /// FTP上创建文件夹
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="directoryname">创建文件夹的名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool CreateDirectory(string uri, string directoryname, string username, string password)
        {

            return true;
        }

        /// <summary>
        /// FTP上修改文件夹名称
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="directoryname">修改的文件夹名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool ModifyDirectory(string uri, string directoryname, string username, string password)
        {

            return true;
        }

        /// <summary>
        /// FTP上删除指定的文件夹
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="direcotryname">删除的文件夹名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool RemoveDirectory(string uri, string direcotryname, string username, string password)
        {

            return true;
        }

        /// <summary>
        /// FTP上删除指定的文件
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="filename">文件名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool RemoveFile(string uri, string filename, string username, string password)
        {

            return true;
        }

        /// <summary>
        /// 查看FTP上指定文件是否存在
        /// </summary>
        /// <param name="uri">ftp地址</param>
        /// <param name="filename">文件名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool CheckFileExist(string uri, string filename, string username, string password)
        {

            return true;
        }
    }
}
