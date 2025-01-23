using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using UriStore.Application.Wrappers;

namespace UriStore.Application.Features.Payment.Queries.GetPayments
{
    public class GetPaymentsQuery : IRequest<PagedResponse<List<PaymentResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
