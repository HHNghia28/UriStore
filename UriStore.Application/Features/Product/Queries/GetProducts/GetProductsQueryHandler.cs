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
using UriStore.Infrastructure.Redis.Services;

namespace UriStore.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler(IProductRepository _productRepository, IRedisService _redisService) 
        : IRequestHandler<GetProductsQuery, PagedResponse<List<ProductsResponse>>>
    {
        public async Task<PagedResponse<List<ProductsResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"products:{request.PageNumber}-{request.PageSize}";
            var cachedProducts = await _redisService.GetAsync<PagedResponse<List<ProductsResponse>>>(cacheKey);

            if (cachedProducts != null) return cachedProducts;

            var products = await _productRepository.GetProducts(new PagedRequest()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            });

            await _redisService.SetAsync(cacheKey, products, TimeSpan.FromMinutes(10));

            return products;
        }
    }
}
