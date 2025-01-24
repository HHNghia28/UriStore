﻿using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Order.Queries.GetOrder
{
    public class GetOrderQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetOrderQuery, OrderResponse>
    {
        public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrder(request.Id);
        }
    }
}
