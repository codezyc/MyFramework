using System;
using ServiceStack.Redis;

namespace CommonLibary.NoSql
{
    /// <summary>
    /// Redis常用操作
    /// </summary>
    public class RedisHelper
    {
        protected RedisClient client;

        public RedisHelper(string address)
        {
            client = new RedisClient(address);
        }

        public RedisHelper(string host, int port)
        {
            client = new RedisClient(host, port);
        }

        public RedisHelper(Uri uri)
        {
            client = new RedisClient(uri);
        }

        /// <summary>
        /// 添加缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="key"></param>
        public void Add<T>(T t, string key)
        {
            client.Set<T>(key, t);
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return client.Get<T>(key);
        }

        /// <summary>
        /// 添加缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            client.Set(key, value);
        }

        /// <summary>
        /// 获取缓存列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return client.GetValue(key);
        }

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        public void ClearAll()
        {
            client.FlushAll();
        }

        /// <summary>
        /// 清空当前数据库所有缓存的对象
        /// </summary>
        public void ClearDb()
        {
            client.FlushDb();
        }
    }
}
