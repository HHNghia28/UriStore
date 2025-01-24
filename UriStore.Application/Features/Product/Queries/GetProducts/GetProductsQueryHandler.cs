using Dapper;
using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetProductsQuery, PagedResponse<List<ProductsResponse>>>
    {
        public async Task<PagedResponse<List<ProductsResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts(new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize });
        }
    }
}
