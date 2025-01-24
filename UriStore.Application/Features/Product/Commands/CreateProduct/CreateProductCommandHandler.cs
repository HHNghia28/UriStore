using MediatR;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(new Domain.Entities.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Discount = request.Discount,
                Stock = request.Stock,
                Photo = request.Photo,
                CreatedById = request.CreatedById,
                LastModifiedById = request.CreatedById,
                CategoryId = request.CategoryId,
            });

            await _productRepository.SaveAsync();
        }
    }
}
