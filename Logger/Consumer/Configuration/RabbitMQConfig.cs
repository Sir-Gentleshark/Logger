using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Consumer.Configuration
{
    public class RabbitMQConfig
    {
        public string Hostname { set; get; }
        public string QueueName { set; get; }
        public bool QueueDurability { set; get; }
        public bool QueueExlusivity { set; get; }
        public bool QueueAutoDelete { set; get; }
    }
}
