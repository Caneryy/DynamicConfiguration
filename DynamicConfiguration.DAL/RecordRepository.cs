using DynamicConfiguration.Model;
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
    }
}
