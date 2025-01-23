using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using UriStore.PayOS.DTO;
using UriStore.PayOS.Services;

namespace UriStore.Application.Features.Payment.Commands.CreatePaymentOrder
{
    public class CreateOrderPaymentByPayOSCommandHandler(IPaymentRepository paymentRepository, IOrderRepository orderRepository, IPayOSService payOSService)
                : IRequestHandler<CreateOrderPaymentByPayOSCommand, string>
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IPayOSService _payOSService = payOSService;

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
