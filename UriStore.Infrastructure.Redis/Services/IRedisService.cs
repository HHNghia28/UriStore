using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Infrastructure.Redis.Services
{
    public interface IRedisService
    {
        public string Get(string key);
        public void Set(string key, string value);
    }
}
