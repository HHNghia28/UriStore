using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using UriStore.Application.Wrappers;
using UriStore.Domain.Entities;

namespace UriStore.Application.Interfaces
{
    public interface IPaymentRepository :IRepository<Payment>
    {
        Task<PagedResponse<List<PaymentResponse>>> GetPayments(PagedRequest request);
        Task<List<Payment>> GetExpiredsPayments();
    }
}
