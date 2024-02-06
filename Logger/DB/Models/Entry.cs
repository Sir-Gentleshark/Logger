using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.DB.Models
{
    public class Entry
    {
        public DateTime LogTime { get; set; }

        public string Id { get; set; }

        public string ServiceName { get; set; }

        public string Description { get; set; }
    }
}
