using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.DB.Models
{
    public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime LogTime { get; set; }

        public string ConversationId { get; set; }

        public string ServiceName { get; set; }

        public string Description { get; set; }

        public LogLevel Level { get; set; }
    }
}
