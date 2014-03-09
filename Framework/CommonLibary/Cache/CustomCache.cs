﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary.Cache
{
    /// <summary>
    /// 自定义扩展MemoryCache
    /// </summary>
    public class CustomCache : MemoryCache
    {
        public CustomCache() : base("defaultCustomCache") { }

        public override void Set(CacheItem item, CacheItemPolicy policy)
        {
            Set(item.Key, item.Value, policy, item.RegionName);
        }

        public override void Set(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
        {
            Set(key, value, new CacheItemPolicy { AbsoluteExpiration = absoluteExpiration }, regionName);
        }

        public override void Set(string key, object value, CacheItemPolicy policy, string regionName = null)
        {
            base.Set(CreateKeyWithRegion(key, regionName), value, policy);
        }

        public override CacheItem GetCacheItem(string key, string regionName = null)
        {
            CacheItem temporary = base.GetCacheItem(CreateKeyWithRegion(key, regionName));
            return new CacheItem(key, temporary.Value, regionName);
        }

        public override object Get(string key, string regionName = null)
        {
            return base.Get(CreateKeyWithRegion(key, regionName));
        }

        public override DefaultCacheCapabilities DefaultCacheCapabilities
        {
            get
            {
                return (base.DefaultCacheCapabilities | System.Runtime.Caching.DefaultCacheCapabilities.CacheRegions);
            }
        }

        private string CreateKeyWithRegion(string key, string region)
        {
            return "region:" + (region == null ? "null_region" : region) + ";key=" + key;
        }
    }
}
