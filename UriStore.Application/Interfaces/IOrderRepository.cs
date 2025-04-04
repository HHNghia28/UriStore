﻿using UriStore.Application.DTO;
using UriStore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Domain.Entities;

namespace UriStore.Application.Interfaces
{
    public interface IOrderRepository : IRepository<Domain.Entities.Order>
    {
        Task<PagedResponse<List<OrdersResponse>>> GetOrders(PagedRequest request);
        Task<PagedResponse<List<OrdersResponse>>> GetOrdersByUserId(PagedRequest request, Guid userId);
        Task<List<Order>> GetExpiredOrders();
        Task<OrderResponse> GetOrder(long id);
        Task<long> GetLastId();
    }
}
