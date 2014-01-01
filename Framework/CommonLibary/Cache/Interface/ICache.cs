using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary.Cache.Interface
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 向缓存中添加项
        /// </summary>
        /// <param name="o">需要缓存的对象</param>
        void Add(object o);

        /// <summary>
        /// 向缓存中添加项
        /// </summary>
        /// <param name="o">需要缓存的对象</param>
        /// <param name="dt">过期时间</param>
        void Add(object o, DateTime dt);

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">键值</param>
        void Get(string key);

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// 初始化缓存容器
        /// </summary>
        void Init();
    }
}
