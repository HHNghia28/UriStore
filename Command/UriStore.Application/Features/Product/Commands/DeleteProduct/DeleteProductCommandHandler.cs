using MediatR;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Infrastructure.Redis.Services;
using UriStore.Application.DTO;

namespace UriStore.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository _productRepository, IRedisService _redisService) 
        : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"product:{request.Id}";
            await _redisService.RemoveAsync(cacheKey);

            var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Product not found");

            product.LastModifiedById = request.LastModifiedById;
            product.IsDeleted = true;

            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveAsync();
        }
    }
}
