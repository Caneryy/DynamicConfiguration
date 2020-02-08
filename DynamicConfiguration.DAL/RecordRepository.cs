using DynamicConfiguration.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicConfiguration.DAL
{
    public class RecordRepository : BaseRepository<Record>
    {
        public RecordRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }

        public Record GetByName(string name, string applicationName)
        {
            return mongoCollection.Find<Record>(x => x.Name == name && x.ApplicationName == applicationName && x.IsActive).FirstOrDefault();
        }
    }
}
