using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Logger.DAO
{
    public class LogEntry
    {
        public DateTime LogTime { get; set; }

        public string ConversationId {  get; set; }

        public string ServiceName { get; set; }

        public string Description { get; set; }
        public LogLevel Level { get; set; }

        public LogEntry() 
        {
            LogTime = DateTime.Now;
            ConversationId = Guid.NewGuid().ToString();
            ServiceName = String.Empty;
            Description = String.Empty;
        }
        public LogEntry(string entry)
        {
            LogEntry temp = JsonConvert.DeserializeObject<LogEntry>(entry);
            LogTime = temp.LogTime;
            ConversationId = temp.ConversationId;
            ServiceName = temp.ServiceName;
            Description = temp.Description;
            Level = temp.Level;
        }
    }
}
