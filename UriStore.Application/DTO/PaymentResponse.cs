using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Domain.Enums;

namespace UriStore.Application.DTO
{
    public class PaymentResponse
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int AmountCharged { get; set; }
        public DateTime TimeCharge { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
    }
}
