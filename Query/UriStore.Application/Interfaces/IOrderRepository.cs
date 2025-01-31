using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using UriStore.Application.Wrappers;
using UriStore.Domain.Entities;

namespace UriStore.Application.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<PagedResponse<List<OrdersResponse>>> GetOrders(PagedRequest request);
        Task<PagedResponse<List<OrdersResponse>>> GetOrdersByUserId(PagedRequest request, Guid userId);
        Task<Order> GetOrder(long id);
    }
}
