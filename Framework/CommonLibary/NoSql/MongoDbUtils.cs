using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CommonLibary.NoSql
{
    /// <summary>
    /// MongoDB常用操作
    /// </summary>
    public class MongoDbUtils : IDisposable
    {
        private MongoClient _mongoclient;

        private MongoServer _mongoserver;

        /// <summary>
        /// 连接MongoDB
        /// </summary>
        /// <param name="connectionstring">数据库连接字符串</param>
        /// <returns></returns>
        public MongoServer Init(string connectionstring)
        {
            _mongoclient = new MongoClient(connectionstring);
            _mongoserver = _mongoclient.GetServer();
            return _mongoserver;
        }

        /// <summary>
        /// 获取MongoDB数据库
        /// </summary>
        /// <param name="dbname">数据库名称</param>
        /// <returns></returns>
        public MongoDatabase GetDataBase(string dbname)
        {
            if (_mongoserver != null)
            {
                return _mongoserver.GetDatabase(dbname);
            }
            return null;
        }


        public MongoCollection QueryAll(string dbname, string tablename, IMongoQuery query)
        {
            return null;
        }


        /// <summary>
        /// 实现IDisposable接口
        /// </summary>
        public void Dispose()
        {
            if (_mongoserver != null)
            {
                _mongoserver.Shutdown();
            }
        }
    }
}
