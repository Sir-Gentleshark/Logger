using Logger.DAO;
using Logger.DB;
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
            Console.WriteLine("This is logged");
            using (Context logContext = new Context())
            {
                var entry = new DB.Models.Entry()
                {
                    LogTime = logEntry.LogTime,
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
