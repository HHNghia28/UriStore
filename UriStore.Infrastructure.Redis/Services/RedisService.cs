using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Infrastructure.Redis.Config;

namespace UriStore.Infrastructure.Redis.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public RedisService(IOptions<RedisConfig> redisSettings)
        {
            var redisConfiguration = $"{redisSettings.Value.Host}:{redisSettings.Value.Port},password={redisSettings.Value.Password}";
            _connectionMultiplexer = ConnectionMultiplexer.Connect(redisConfiguration);
            _database = _connectionMultiplexer.GetDatabase();
        }

        public void Set(string key, string value)
        {
            _database.StringSet(key, value);
        }

        public string Get(string key)
        {
            return _database.StringGet(key);
        }
    }
}
