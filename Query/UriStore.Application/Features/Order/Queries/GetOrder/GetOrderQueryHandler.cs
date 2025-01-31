using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.Wrappers;

namespace UriStore.Application.Features.Order.Queries.GetOrder
{
    public class GetOrderQueryHandler(IOrderRepository _orderRepository) 
        : IRequestHandler<GetOrderQuery, Domain.Entities.Order>
    {
        public async Task<Domain.Entities.Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrder(request.Id);

            return order;
        }
    }
}
