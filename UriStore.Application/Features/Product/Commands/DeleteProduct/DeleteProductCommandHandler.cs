using MediatR;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Product not found");

            product.LastModifiedBy = request.LastModifiedBy;
            product.IsDeleted = true;

            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveAsync();
        }
    }
}
