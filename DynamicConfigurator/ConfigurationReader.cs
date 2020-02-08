using DynamicConfiguration.DAL;
using DynamicConfiguration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicConfigurator
{
    public class ConfigurationReader
    {
        public RecordRepository RecordRepository { get; set; }

        public ConfigurationReader(string applicationName, string connectionString, long refreshTimerIntervalInMs)
        {
            ApplicationName = applicationName;
            ConnectionString = connectionString;
            RefreshTimerIntervalInMs = refreshTimerIntervalInMs;

            this.RecordRepository = new RecordRepository(connectionString, "conff", "records");
        }



        public string ApplicationName { get; set; }
        public string ConnectionString { get; set; }
        public long RefreshTimerIntervalInMs { get; set; }

        public T GetValue<T>(string key)
        {
            var item = RecordRepository.GetByName(key, ApplicationName);

            if (item == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(item.Value, typeof(T));
        }
    }
}
