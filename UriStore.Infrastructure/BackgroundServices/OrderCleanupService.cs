using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using UriStore.Application.Interfaces;

namespace UriStore.Infrastructure.BackgroundServices
{
    public class OrderCleanupService(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                        var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

                        var expiredOrders = await orderRepository.GetExpiredOrders();

                        foreach (var expiredOrder in expiredOrders)
                        {
                            expiredOrder.Status = Domain.Enums.OrderStatus.CANCEL;
                            await orderRepository.UpdateAsync(expiredOrder);

                            foreach (var detail in expiredOrder.Details)
                            {
                                detail.Product.Stock += detail.Quantity;
                                await productRepository.UpdateAsync(detail.Product);
                            }
                        }

                        await orderRepository.SaveAsync();
                    }

                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred in OrderCleanupService: {ex.Message}");
                }
            }
        }
    }
}
