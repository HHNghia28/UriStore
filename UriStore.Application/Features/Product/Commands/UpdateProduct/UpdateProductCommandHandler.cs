using MediatR;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
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
