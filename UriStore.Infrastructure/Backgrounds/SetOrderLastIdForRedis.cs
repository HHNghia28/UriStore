using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.Interfaces;
using UriStore.Infrastructure.Redis.Services;
using UriStore.Infrastructure.Repositories;

namespace UriStore.Infrastructure.Backgrounds
{
    public class SetOrderLastIdForRedis(IServiceScopeFactory _scopeFactory, IRedisService _redisService) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                var id = await orderRepository.GetLastId();
                _redisService.Set("orderLastId", id.ToString());

                await Task.CompletedTask;
            }
        }
    }
}
