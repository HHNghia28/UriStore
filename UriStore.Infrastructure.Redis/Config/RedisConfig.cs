using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Infrastructure.Redis.Config
{
    public class RedisConfig
    {
        public static string ConfigName => "Redis";
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}
