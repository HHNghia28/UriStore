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
using UriStore.Infrastructure.Redis.Services;

namespace UriStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQueryHandler(IProductRepository _productRepository, IRedisService _redisService) 
        : IRequestHandler<GetProductQuery, ProductResponse>
    {
        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"product:{request.Id}";
            var cachedProduct = await _redisService.GetAsync<ProductResponse>(cacheKey);

            if (cachedProduct != null) return cachedProduct;

            var product = await _productRepository.GetProduct(request.Id) ?? throw new NotFoundException("Product not found");

            await _redisService.SetAsync(cacheKey, product, TimeSpan.FromMinutes(10));

            return product;
        }
    }
}
