using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Infrastructure.Config
{
    public class MongoDbConfig
    {
        public const string ConfigName = "MongoDb";
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
