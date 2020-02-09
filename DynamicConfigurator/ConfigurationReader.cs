using DynamicConfiguration.DAL;
using DynamicConfiguration.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicConfigurator
{
    public class ConfigurationReader : HostedService
    {
        public RecordRepository RecordRepository { get; set; }

        public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMs)
        {
            ApplicationName = applicationName;
            ConnectionString = connectionString;
            RefreshTimerIntervalInMs = refreshTimerIntervalInMs;

            this.RecordRepository = new RecordRepository(connectionString, "conff", "records");
        
            this.StartAsync(new CancellationToken());
        }

        public string ApplicationName { get; set; }
        public string ConnectionString { get; set; }
        public int RefreshTimerIntervalInMs { get; set; }

        public List<Record> Records { get; set; }

        public async Task GetRecords()
        {
            Records = RecordRepository.GetListByApplicationName(ApplicationName);
        }

        public T GetValue<T>(string key)
        {
            //var item = RecordRepository.GetByName(key, ApplicationName);
            var item = Records.Find(r => r.Name == key && r.IsActive);
            if (item == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(item.Value, typeof(T));
        }

        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                GetRecords();
                await Task.Delay(RefreshTimerIntervalInMs, cToken);
            }
     
        }
    }
}
