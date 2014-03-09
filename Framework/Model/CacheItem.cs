using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 缓存对象
    /// </summary>
    [Serializable]
    public class CacheItem
    {
        public string Id { get; set; }
        public byte[] Item { get; set; }
        public DateTime Expiration { get; set; }
    }
}
