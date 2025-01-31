using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Order.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<PagedResponse<List<OrdersResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
