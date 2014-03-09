using Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace MVCExtend.CustomeOutputProvider
{
    public class DocumentDatabaseOutputCacheProvider : OutputCacheProvider, IDisposable
    {
        readonly MongoDB.Driver.MongoServer _mongo;
        readonly MongoDB.Driver.MongoCollection<CacheItem> _cacheItems;

        public DocumentDatabaseOutputCacheProvider()
        {
            //_mongo = new MongoServer(new MongoServerSettings());
            //_mongo.Connect();

            //var store = _mongo.GetDatabase("OutputCacheDB");
            //_cacheItems = store.GetCollection()
        }

        public override object Get(string key)
        {
            Debug.WriteLine(string.Format("Cache.Get({0})", key));

            key = MD5(key);

            //var cacheItem = _cacheItems.FindOne(new { _id = key });      //FindOne方法有问题

            //if (cacheItem != null)
            //{
            //    if (cacheItem.Expiration.ToUniversalTime() <= DateTime.UtcNow)
            //    {
            //        _cacheItems.Remove(cacheItem);
            //    }
            //    else
            //    {
            //        return Deserialize(cacheItem.Item);
            //    }
            //}

            return null;
        }

        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            Debug.WriteLine("Cache.Add({0}, {1}, {2})", key, entry, utcExpiry);

            key = MD5(key);

            //if (utcExpiry == DateTime.MaxValue)
            //    utcExpiry = DateTime.UtcNow.AddMinutes(5);

            //var item = _cacheItems.FindOne(new { _id = key });       //FindOne方法有问题

            //if (item != null)
            //{
            //    if (item.Expiration.ToUniversalTime() <= DateTime.UtcNow)
            //    {
            //        _cacheItems.Remove(item);
            //    }
            //    else
            //    {
            //        return Deserialize(item.Item);
            //    }
            //}

            _cacheItems.Insert(new CacheItem
            {
                Id = key,
                Item = Serialize(entry),
                Expiration = utcExpiry
            });

            return entry;
        }

        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            Debug.WriteLine("Cache.Set({0}, {1}, {2})", key, entry, utcExpiry);

            key = MD5(key);

            //var item = _cacheItems.FindOne(new { _id = key });   //FindOne方法有问题

            //if (item != null)
            //{
            //    item.Item = Serialize(entry);
            //    item.Expiration = utcExpiry;
            //    _cacheItems.Save(item);
            //}
            //else
            //{
            //    _cacheItems.Insert(new CacheItem
            //    {
            //        Id = key,
            //        Item = Serialize(entry),
            //        Expiration = utcExpiry
            //    });
            //}
        }

        public override void Remove(string key)
        {
            Debug.WriteLine("Cache.Remove({0})", key);

            key = MD5(key);

            //_cacheItems.Remove(new { _id = key });    //Remove方法有问题
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
            _mongo.Disconnect();
            //_mongo.Dispose();
        }
    }
}