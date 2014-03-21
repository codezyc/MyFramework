<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace CommonLibary.Cache
{
    /// <summary>
    /// 此为ASP.NET自带缓存常用操作
    /// </summary>
    public static class CacheUtils
    {
        //生成或创建缓存对象的委托
        public delegate T CreateCacheValue<T>();

        /// <summary>
        /// 向缓存中添加一项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="dt">绝对到期时间</param>
        /// <param name="tp">相对到期时间</param>
        public static void Add(string key, object obj, DateTime dt, TimeSpan tp)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            HttpContext.Current.Cache.Insert(key, obj, null, dt, tp, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 判断缓存中是否存在此项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>是否存在的布尔值</returns>
        public static bool IsItemExist(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
                return true;
            return false;
        }

        /// <summary>
        /// 从缓存中获取指定类型的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>指定类型的对象</returns>
        public static T Get<T>(string key) where T : class
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                return (T)HttpContext.Current.Cache.Get(key);
            }
            return null;
        }

        /// <summary>
        /// 删除缓存中的对象
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveItem(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void RemoveAll()
        {
            IDictionaryEnumerator ide = HttpContext.Current.Cache.GetEnumerator();
            while (ide.MoveNext())
            {
                RemoveItem(ide.Key.ToString());
            }
        }

        /// <summary>
        /// 向缓存中添加缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachevalue"></param>
        /// <returns></returns>
        public static void Get<T>(string key, CreateCacheValue<T> cachevalue)
        {
            if (HttpContext.Current.Cache.Get(key) == null)
            {
                HttpContext.Current.Cache.Insert(key, cachevalue);
            }
        }
    }
}
=======
﻿using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace CommonLibary.Cache
{
    /// <summary>
    /// 此为ASP.NET自带缓存常用操作
    /// </summary>
    public static class CacheUtils
    {
        //生成或创建缓存对象的委托
        public delegate T CreateCacheValue<T>();

        /// <summary>
        /// 向缓存中添加一项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="dt">绝对到期时间</param>
        /// <param name="tp">相对到期时间</param>
        public static void Add(string key, object obj, DateTime dt, TimeSpan tp)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            HttpContext.Current.Cache.Insert(key, obj, null, dt, tp, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 判断缓存中是否存在此项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>是否存在的布尔值</returns>
        public static bool IsItemExist(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
                return true;
            return false;
        }

        /// <summary>
        /// 从缓存中获取指定类型的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>指定类型的对象</returns>
        public static T Get<T>(string key) where T : class
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                return (T)HttpContext.Current.Cache.Get(key);
            }
            return null;
        }

        /// <summary>
        /// 删除缓存中的对象
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveItem(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void RemoveAll()
        {
            IDictionaryEnumerator ide = HttpContext.Current.Cache.GetEnumerator();
            while (ide.MoveNext())
            {
                RemoveItem(ide.Key.ToString());
            }
        }

        /// <summary>
        /// 向缓存中添加缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachevalue"></param>
        /// <returns></returns>
        public static void Get<T>(string key, CreateCacheValue<T> cachevalue)
        {
            if (HttpContext.Current.Cache.Get(key) == null)
            {
                HttpContext.Current.Cache.Insert(key, cachevalue);
            }
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace CommonLibary.Cache
{
    /// <summary>
    /// 此为ASP.NET自带缓存常用操作
    /// </summary>
    public static class CacheUtils
    {
        //生成或创建缓存对象的委托
        public delegate T CreateCacheValue<T>();

        /// <summary>
        /// 向缓存中添加一项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="dt">绝对到期时间</param>
        /// <param name="tp">相对到期时间</param>
        public static void Add(string key, object obj, DateTime dt, TimeSpan tp)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            HttpContext.Current.Cache.Insert(key, obj, null, dt, tp, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 判断缓存中是否存在此项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>是否存在的布尔值</returns>
        public static bool IsItemExist(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
                return true;
            return false;
        }

        /// <summary>
        /// 从缓存中获取指定类型的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>指定类型的对象</returns>
        public static T Get<T>(string key) where T : class
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                return (T)HttpContext.Current.Cache.Get(key);
            }
            return null;
        }

        /// <summary>
        /// 删除缓存中的对象
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveItem(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void RemoveAll()
        {
            IDictionaryEnumerator ide = HttpContext.Current.Cache.GetEnumerator();
            while (ide.MoveNext())
            {
                RemoveItem(ide.Key.ToString());
            }
        }

        /// <summary>
        /// 向缓存中添加缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachevalue"></param>
        /// <returns></returns>
        public static void Get<T>(string key, CreateCacheValue<T> cachevalue)
        {
            if (HttpContext.Current.Cache.Get(key) == null)
            {
                HttpContext.Current.Cache.Insert(key, cachevalue);
            }
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace CommonLibary.Cache
{
    /// <summary>
    /// 此为ASP.NET自带缓存常用操作
    /// </summary>
    public static class CacheUtils
    {
        //生成或创建缓存对象的委托
        public delegate T CreateCacheValue<T>();

        /// <summary>
        /// 向缓存中添加一项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="dt">绝对到期时间</param>
        /// <param name="tp">相对到期时间</param>
        public static void Add(string key, object obj, DateTime dt, TimeSpan tp)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
            HttpContext.Current.Cache.Insert(key, obj, null, dt, tp, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 判断缓存中是否存在此项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>是否存在的布尔值</returns>
        public static bool IsItemExist(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
                return true;
            return false;
        }

        /// <summary>
        /// 从缓存中获取指定类型的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>指定类型的对象</returns>
        public static T Get<T>(string key) where T : class
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                return (T)HttpContext.Current.Cache.Get(key);
            }
            return null;
        }

        /// <summary>
        /// 删除缓存中的对象
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveItem(string key)
        {
            if (HttpContext.Current.Cache.Get(key) != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void RemoveAll()
        {
            IDictionaryEnumerator ide = HttpContext.Current.Cache.GetEnumerator();
            while (ide.MoveNext())
            {
                RemoveItem(ide.Key.ToString());
            }
        }

        /// <summary>
        /// 向缓存中添加缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachevalue"></param>
        /// <returns></returns>
        public static void Get<T>(string key, CreateCacheValue<T> cachevalue)
        {
            if (HttpContext.Current.Cache.Get(key) == null)
            {
                HttpContext.Current.Cache.Insert(key, cachevalue);
            }
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
