using Microsoft.Extensions.Options;
using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;
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
        private readonly Lazy<ConnectionMultiplexer> _lazyConnection;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;

        public RedisService(IOptions<RedisConfig> redisSettings)
        {
            // Cấu hình Redis
            var redisConfiguration = new ConfigurationOptions
            {
                EndPoints = { $"{redisSettings.Value.Host}:{redisSettings.Value.Port}" },
                Password = redisSettings.Value.Password,
                ConnectTimeout = 100, // 100ms cho kết nối ban đầu
                SyncTimeout = 500,    // 500ms cho các thao tác đồng bộ
                AsyncTimeout = 500,   // 500ms cho các thao tác bất đồng bộ
                AbortOnConnectFail = false, // Không throw exception khi connect fail
                ReconnectRetryPolicy = new LinearRetry(500), // Retry sau mỗi 500ms
                ConnectRetry = 3 // Số lần thử kết nối lại
            };

            // Khởi tạo kết nối Redis (Lazy initialization)
            _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                var connection = ConnectionMultiplexer.Connect(redisConfiguration);

                // Đăng ký sự kiện kết nối lại
                connection.ConnectionFailed += (_, e) =>
                {
                    Console.WriteLine($"Redis connection failed: {e.Exception}");
                };

                connection.ConnectionRestored += (_, e) =>
                {
                    Console.WriteLine("Redis connection restored");
                };

                return connection;
            });

            // Circuit Breaker: Mở circuit sau 5 lỗi liên tiếp, đóng sau 30s
            _circuitBreakerPolicy = Policy
                .Handle<RedisException>()
                .Or<TimeoutRejectedException>()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

            // Timeout: 100ms cho mỗi thao tác
            _timeoutPolicy = Policy.TimeoutAsync(TimeSpan.FromMilliseconds(100));
        }

        private IDatabase Database => _lazyConnection.Value.GetDatabase();

        private bool IsConnected()
        {
            return _lazyConnection.Value != null
                   && _lazyConnection.Value.IsConnected
                   && _circuitBreakerPolicy.CircuitState != CircuitState.Open;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            if (!IsConnected()) return default;

            try
            {
                return await _circuitBreakerPolicy
                    .WrapAsync(_timeoutPolicy)
                    .ExecuteAsync(async () =>
                    {
                        var value = await Database.StringGetAsync(key);
                        return value.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(value!);
                    })
                    .ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is RedisException || ex is TimeoutRejectedException)
            {
                Console.WriteLine($"Redis operation failed: {ex.Message}");
                return default;
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            if (!IsConnected()) return;

            try
            {
                await _circuitBreakerPolicy
                    .WrapAsync(_timeoutPolicy)
                    .ExecuteAsync(async () =>
                    {
                        var jsonValue = JsonSerializer.Serialize(value);
                        await Database.StringSetAsync(key, jsonValue, expiration);
                    })
                    .ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is RedisException || ex is TimeoutRejectedException)
            {
                Console.WriteLine($"Redis operation failed: {ex.Message}");
            }
        }

        public async Task RemoveAsync(string key)
        {
            if (!IsConnected()) return;

            try
            {
                await _circuitBreakerPolicy
                    .WrapAsync(_timeoutPolicy)
                    .ExecuteAsync(async () =>
                    {
                        await Database.KeyDeleteAsync(key);
                    })
                    .ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is RedisException || ex is TimeoutRejectedException)
            {
                Console.WriteLine($"Redis operation failed: {ex.Message}");
            }
        }
    }
}
