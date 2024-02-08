using Logger.DAO;
using Logger.DB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Logger
{
    public class Logger : ILogger
    {
        public void Log(LogEntry logEntry)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            Console.WriteLine("This is logged");
            using (Context logContext = new Context(config.GetSection("DBConfig").GetValue<string>("DBConnectionString")))
            {
                var entry = new DB.Models.Entry()
                {
                    LogTime = logEntry.LogTime.ToUniversalTime(),
                    ServiceName = logEntry.ServiceName,
                    Description = logEntry.Description,
                    Id = logEntry.Id
                };
                logContext.Entries.AddAsync(entry);
                logContext.SaveChanges();
            }
        }
    }
}
