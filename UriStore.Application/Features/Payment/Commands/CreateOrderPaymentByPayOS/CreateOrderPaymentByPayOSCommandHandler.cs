using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using UriStore.Infrastructure.PayOS.DTO;
using UriStore.Infrastructure.PayOS.Services;

namespace UriStore.Application.Features.Payment.Commands.CreatePaymentOrder
{
    public class CreateOrderPaymentByPayOSCommandHandler(IPaymentRepository _paymentRepository, 
                IOrderRepository _orderRepository, IPayOSService _payOSService)
                : IRequestHandler<CreateOrderPaymentByPayOSCommand, string>
    {
        public async Task<string> Handle(CreateOrderPaymentByPayOSCommand request, CancellationToken cancellationToken)
        {
            string paymentLink = "";
            var order = await _orderRepository.GetOrder(request.OrderId) ?? throw new NotFoundException("Order not found");

            var payment = await _paymentRepository.GetByIdAsync(order.Id);

            if (payment == null)
            {
                paymentLink = await _payOSService.CreatePaymentAsync(new CreatePaymentDTO()
                {
                    OrderCode = order.Id,
                    Content = order.Id.ToString(),
                    RequiredAmount = 5000,
                });

                await _paymentRepository.AddAsync(new Domain.Entities.Payment()
                {
                    Id = request.OrderId,
                    AmountCharged = order.TotalPrice,
                    PaymentLink = paymentLink,
                    CreatedById = request.CreatedById,
                    LastModifiedById = request.CreatedById,
                });

                await _paymentRepository.SaveAsync();
            }
            else
            {
                if (payment.Status == Domain.Enums.PaymentStatus.PAIDED) throw new InvalidOperationException("Order paided");

                paymentLink = payment.PaymentLink;
            }

            return paymentLink;
        }
    }
}
