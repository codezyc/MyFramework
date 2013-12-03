using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memcached.ClientLibrary;

namespace CommonLibary.Cache
{
    /// <summary>
    /// MemCache常用操作
    /// </summary>
    public class MemCacheUtils
    {
        /// <summary>
        /// MemCache初始化
        /// </summary>
        /// <param name="serverlist">服务器数组</param>
        /// <param name="InitConnections">初始连接次数</param>
        /// <param name="MinConnections">最小连接次数</param>
        /// <param name="MaxConnections">最大连接次数</param>
        /// <param name="ConnectionTimeout">Socket连接超时时间</param>
        /// <param name="Timeout">Socket超时时间</param>
        /// <param name="MaintenanceSleep">维持睡眠时间</param>
        /// <param name="Failover">故障恢复</param>
        /// <param name="Nagle"></param>
        public void Init(string[] serverlist, int InitConnections, int MinConnections, int MaxConnections, int ConnectionTimeout, int Timeout,
            int MaintenanceSleep, bool Failover, bool Nagle)
        {
            SockIOPool pool = SockIOPool.GetInstance();
            if (serverlist != null && serverlist.Length > 0)
            {
                pool.SetServers(serverlist);
                pool.InitConnections = 3;
                pool.MinConnections = 3;
                pool.MaxConnections = 5;
                pool.SocketConnectTimeout = 10000;
                pool.SocketTimeout = 30000;
                pool.MaintenanceSleep = 30;
                pool.Failover = true;
                pool.Nagle = false;
                pool.Initialize();
            }
        }

        /// <summary>
        /// 插入缓存对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="IsCompress">是否启用压缩</param>
        /// <returns>布尔值</returns>
        public bool Set(string key, object obj, bool IsCompress)
        {
            if (!string.IsNullOrEmpty(key) && obj != null)
            {
                MemcachedClient memclient = new MemcachedClient();
                memclient.EnableCompression = IsCompress;
                return memclient.Set(key, obj);
            }
            return false;
        }

        /// <summary>
        /// 插入缓存对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="IsCompress">是否启用压缩</param>
        /// <param name="second">过期的相对时间，秒为单位</param>
        /// <returns>布尔值</returns>
        public bool Set(string key, object obj, bool IsCompress, int second)
        {
            if (!string.IsNullOrEmpty(key) && obj != null)
            {
                MemcachedClient memclient = new MemcachedClient();
                memclient.EnableCompression = IsCompress;
                return memclient.Set(key, obj, DateTime.Now.AddSeconds(second));
            }
            return false;
        }

        /// <summary>
        /// 插入缓存对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="IsCompress">是否启用压缩</param>
        /// <param name="dt">过期的绝对时间</param>
        /// <returns>布尔值</returns>
        public bool Set(string key, object obj, bool IsCompress, DateTime dt)
        {
            if (!string.IsNullOrEmpty(key) && obj != null)
            {
                MemcachedClient memclient = new MemcachedClient();
                memclient.EnableCompression = IsCompress;
                return memclient.Set(key, obj, dt);
            }
            return false;
        }

        /// <summary>
        /// 判断缓存中是否含有此项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="IsCompress">是否启用压缩</param>
        /// <returns></returns>
        public bool IsExist(string key, bool IsCompress)
        {
            if (!string.IsNullOrEmpty(key))
            {
                MemcachedClient memclient = new MemcachedClient();
                memclient.EnableCompression = IsCompress;
                return memclient.KeyExists(key);
            }
            return false;
        }

        /// <summary>
        /// 删除缓存中的一项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="IsCompress">是否启用压缩</param>
        /// <returns></returns>
        public bool Remove(string key, bool IsCompress)
        {
            if (!string.IsNullOrEmpty(key))
            {
                MemcachedClient memclient = new MemcachedClient();
                memclient.EnableCompression = IsCompress;
                return memclient.Delete(key);
            }
            return false;
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        public bool RemoveAll()
        {
            MemcachedClient memclient = new MemcachedClient();
            return memclient.FlushAll();
        }

        /// <summary>
        /// 关闭MemCache
        /// </summary>
        public void Close()
        {
            SockIOPool.GetInstance().Shutdown();
        }

        /// <summary>
        /// 根据key获取缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <returns>泛型对象类型</returns>
        public T Get<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                MemcachedClient memclient = new MemcachedClient();
                memclient.EnableCompression = false;
                return (T)memclient.Get(key);
            }
            return null;
        }

        /// <summary>
        /// 获取多个键值对应的对象
        /// </summary>
        /// <param name="keys">密钥集合</param>
        /// <returns></returns>
        public static Hashtable GetMultipleKeys(string[] keys)
        {
            if (keys != null && keys.Length > 0)
            {
                MemcachedClient memclient = new MemcachedClient();
                memclient.EnableCompression = false;
                return memclient.GetMultiple(keys);
            }
            return null;
        }
    }
}
