using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<PagedResponse<List<ProductsResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
