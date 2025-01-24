using Dapper;
using MediatR;
using UriStore.Application.DTO;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetProductQuery, ProductResponse>
    {
        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(request.Id);

            return product ?? throw new NotFoundException("Product not found");
        }
    }
}
