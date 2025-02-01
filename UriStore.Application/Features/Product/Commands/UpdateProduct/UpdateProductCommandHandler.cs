using MediatR;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Infrastructure.Redis.Services;

namespace UriStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository _productRepository, IRedisService _redisService) 
        : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"product:{request.Id}";
            await _redisService.RemoveAsync(cacheKey);

            var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Product not found");

            product.Name = request.Name ?? product.Name;
            product.Description = request.Description ?? product.Description;
            product.Price = request.Price ?? product.Price;
            product.Discount = request.Discount ?? product.Discount;
            product.Stock = request.Stock ?? product.Stock;
            product.Photo = request.Photo ?? product.Photo;
            product.CategoryId = request.CategoryId ?? product.CategoryId;
            product.LastModifiedById = request.LastModifiedById ?? product.LastModifiedById;

            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveAsync();
        }
    }
}
