using MediatR;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Infrastructure.Redis.Services;

namespace UriStore.Application.Features.Order.Commands.CancelOrder
{
    public class CancelOrderCommandHandler(IOrderRepository _orderRepository, IRedisService _redisService) 
        : IRequestHandler<CancelOrderCommand>
    {
        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"order:{request.Id}";
            await _redisService.RemoveAsync(cacheKey);

            var order = await _orderRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Order not found");

            if (order.Status != Domain.Enums.OrderStatus.PENDING) throw new InvalidOperationException("The order has expired and cannot be cancel");

            order.Status = Domain.Enums.OrderStatus.CANCEL;

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }
    }
}
