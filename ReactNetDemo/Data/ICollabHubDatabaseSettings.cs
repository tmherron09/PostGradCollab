﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetDemo.Data
{
    public interface ICollabHubDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
