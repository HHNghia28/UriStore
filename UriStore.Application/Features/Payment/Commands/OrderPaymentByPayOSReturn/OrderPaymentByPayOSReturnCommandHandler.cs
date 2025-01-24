using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using UriStore.PayOS.Config;

namespace UriStore.Application.Features.Payment.Commands.OrderPaymentByPayOSReturn
{
    public class OrderPaymentByPayOSReturnCommandHandler(IPaymentRepository _paymentRepository, IOrderRepository _orderRepository
        , IOptions<PayOSConfig> payosConfigOptions) 
        : IRequestHandler<OrderPaymentByPayOSReturnCommand, string>
    {
        private readonly PayOSConfig _payOSConfig = payosConfigOptions.Value;

        public async Task<string> Handle(OrderPaymentByPayOSReturnCommand request, CancellationToken cancellationToken)
        {
            long orderId = long.Parse(request.OrderCode);
            var order = await _orderRepository.GetByIdAsync(orderId) ?? throw new NotFoundException("Order not found");
            var payment = await _paymentRepository.GetByIdAsync(orderId) ?? throw new NotFoundException("Payment not found");

            if (request.Code == "00" && request.Status == "PAID")
            {
                order.Status = Domain.Enums.OrderStatus.PAIDED;
                payment.Status = Domain.Enums.PaymentStatus.PAIDED;
            }
            else
            {
                payment.Status = Domain.Enums.PaymentStatus.CANCEL;
            }

            await _paymentRepository.UpdateAsync(payment);
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();

            return _payOSConfig.ClientRedirectUrl;
        }
    }
}
