﻿using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Order.Queries.GetOrders
{
    public class GetOrdersQueryHandler(IOrderRepository OrderRepository) : IRequestHandler<GetOrdersQuery, PagedResponse<List<OrdersResponse>>>
    {
        private readonly IOrderRepository _orderRepository = OrderRepository;

        public async Task<PagedResponse<List<OrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrders(new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize });
        }
    }
}
