using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Infrastructure.Redis.Services;
using UriStore.Application.Wrappers;

namespace UriStore.Application.Features.Order.Queries.GetOrder
{
    public class GetOrderQueryHandler(IOrderRepository _orderRepository, IRedisService _redisService) 
        : IRequestHandler<GetOrderQuery, OrderResponse>
    {
        public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"order:{request.Id}";
            var cachedOrder = await _redisService.GetAsync<OrderResponse>(cacheKey);

            if (cachedOrder != null) return cachedOrder;

            var order = await _orderRepository.GetOrder(request.Id);

            await _redisService.SetAsync(cacheKey, order, TimeSpan.FromMinutes(1));

            return order;
        }
    }
}
