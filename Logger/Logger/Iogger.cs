﻿using Logger.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Logger
{
    interface ILogger
    {
        public void Log(LogEntry logEntry);
    }
}
