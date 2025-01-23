using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;

namespace UriStore.Application.Features.Payment.Queries.GetPayments
{
    public class GetPaymentsQueryHandler(IPaymentRepository paymentRepository) : IRequestHandler<GetPaymentsQuery, PagedResponse<List<PaymentResponse>>>
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;

        public async Task<PagedResponse<List<PaymentResponse>>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            return await _paymentRepository.GetPayments(new PagedRequest()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            });
        }
    }
}
