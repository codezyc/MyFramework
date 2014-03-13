using Model;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web.Caching;
using MongoDB.Driver.Builders;

namespace MVCExtend.CustomeOutputProvider
{
    public class DocumentDatabaseOutputCacheProvider : OutputCacheProvider, IDisposable
    {
        private MongoClient _mongoclient;
        private MongoServer _mongoserver;
        private MongoCollection<CacheItem> _cacheItems;

        public DocumentDatabaseOutputCacheProvider()
        {

            var connectionString = "mongodb://localhost";
            _mongoclient = new MongoClient(connectionString);
            _mongoserver = _mongoclient.GetServer();

            var database = _mongoserver.GetDatabase("");
            _cacheItems = database.GetCollection<CacheItem>("");
        }

        /// <summary>
        /// 重写OutputCacheProvider的Get方法
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object Get(string key)
        {
            Debug.WriteLine(string.Format("Cache.Get({0})", key));
            key = MD5(key);
            var query = Query<CacheItem>.EQ(e => e.Id, key);
            var cacheItem = _cacheItems.FindOne(query);

            if (cacheItem != null)
            {
                if (cacheItem.Expiration.ToUniversalTime() <= DateTime.UtcNow)
                {
                    _cacheItems.Remove(query);
                }
                else
                {
                    return Deserialize(cacheItem.Item);
                }
            }
            return null;
        }

        /// <summary>
        /// 重写OutputCacheProvider的Add方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entry"></param>
        /// <param name="utcExpiry"></param>
        /// <returns></returns>
        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            Debug.WriteLine("Cache.Add({0}, {1}, {2})", key, entry, utcExpiry);

            key = MD5(key);

            if (utcExpiry == DateTime.MaxValue)
                utcExpiry = DateTime.UtcNow.AddMinutes(5);

            var query = Query<CacheItem>.EQ(e => e.Id, key);
            var item = _cacheItems.FindOne(query);

            if (item != null)
            {
                if (item.Expiration.ToUniversalTime() <= DateTime.UtcNow)
                {
                    _cacheItems.Remove(query);
                }
                else
                {
                    return Deserialize(item.Item);
                }
            }

            _cacheItems.Insert(new CacheItem
            {
                Id = key,
                Item = Serialize(entry),
                Expiration = utcExpiry
            });

            return entry;
        }

        /// <summary>
        /// 重写OutputCacheProvider的Set方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entry"></param>
        /// <param name="utcExpiry"></param>
        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            Debug.WriteLine("Cache.Set({0}, {1}, {2})", key, entry, utcExpiry);

            key = MD5(key);

            var query = Query<CacheItem>.EQ(e => e.Id, key);
            var item = _cacheItems.FindOne(query);

            if (item != null)
            {
                item.Item = Serialize(entry);
                item.Expiration = utcExpiry;
                _cacheItems.Save(item);
            }
            else
            {
                _cacheItems.Insert(new CacheItem
                {
                    Id = key,
                    Item = Serialize(entry),
                    Expiration = utcExpiry
                });
            }
        }

        /// <summary>
        /// 重写Remove方法
        /// </summary>
        /// <param name="key"></param>
        public override void Remove(string key)
        {
            Debug.WriteLine("Cache.Remove({0})", key);

            key = MD5(key);
            var query = Query<CacheItem>.EQ(e => e.Id, key);
            _cacheItems.Remove(query);    //Remove方法有问题
        }

        private static string MD5(string value)
        {
            var cryptoServiceProvider = new MD5CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes(value);
            var builder = new StringBuilder();

            bytes = cryptoServiceProvider.ComputeHash(bytes);

            foreach (var b in bytes)
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

        private static byte[] Serialize(object entry)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, entry);

            return stream.ToArray();
        }

        private static object Deserialize(byte[] serializedEntry)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream(serializedEntry);

            return formatter.Deserialize(stream);
        }

        public void Dispose()
        {
            if (_mongoserver != null)
            {
                _mongoserver = null;
            }
            if (_mongoclient != null)
            {
                _mongoclient = null;
            }
            //_mongoserver.RequestDone();
        }
    }
}