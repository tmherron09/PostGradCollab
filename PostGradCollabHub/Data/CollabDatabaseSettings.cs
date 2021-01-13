using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostGradCollabHub.Data;

namespace PostGradCollabHub.Data
{
    public class CollabHubDatabaseSettings : ICollabHubDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
