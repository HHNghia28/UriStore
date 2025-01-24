using MediatR;
using UriStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.Exceptions;
using UriStore.Domain.Entities;

namespace UriStore.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IOrderRepository _orderRepository, IProductRepository _productRepository) 
        : IRequestHandler<CreateOrderCommand>
    {
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<OrderDetail> orderDetails = [];
            long lastId = await _orderRepository.GetLastId();

            long orderId = lastId + 1;

            foreach (var item in request.Details)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId) ?? throw new NotFoundException("Product not found");

                if (product.IsDeleted || product.Stock < item.Quantity)
                {
                    throw new InvalidOperationException("Product '" + product.Name + "' not enough");
                }

                product.Stock -= item.Quantity;
                await _productRepository.UpdateAsync(product);

                orderDetails.Add(new OrderDetail()
                {
                    Id = Guid.NewGuid(),
                    Discount = item.Discount,
                    Name = item.Name,
                    OrderId = orderId,
                    Photo = item.Photo,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Category = item.Category,
                });
            }

            var totalPrice = orderDetails.Sum(d => (d.Price * (1 - (d.Discount / 100))) * d.Quantity) * (1 - (request.VoucherValue / 100)) + request.ShippingFee - request.DiscountFee;

            await _orderRepository.AddAsync(new Domain.Entities.Order()
            {
                Id = orderId,
                Address = request.Address,
                DiscountFee = request.DiscountFee,
                FullName = request.FullName,
                Note = request.Note,
                Phone = request.Phone,
                CreatedById = request.CreatedBy,
                LastModifiedById = request.CreatedBy,
                ShippingFee = request.ShippingFee,
                VoucherCode = request.VoucherCode,
                VoucherName = request.VoucherName,
                VoucherValue = request.VoucherValue,
                TotalPrice = totalPrice,
                Details = orderDetails
            });

            await _orderRepository.SaveAsync();
        }

    }
}
