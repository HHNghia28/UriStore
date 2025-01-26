using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            return value.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(value!);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var jsonValue = JsonSerializer.Serialize(value);
            await _database.StringSetAsync(key, jsonValue, expiration);
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }
}
