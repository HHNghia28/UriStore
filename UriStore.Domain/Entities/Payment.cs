using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Domain.Common;
using UriStore.Domain.Enums;

namespace UriStore.Domain.Entities
{
    public class Payment : AuditableBaseEntity<long>
    {
        public int AmountCharged { get; set; }
        public DateTime TimeCharge { get; set; } = DateTime.UtcNow;
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
        public string PaymentLink { get; set; }
        [ForeignKey(nameof(Id))]
        public Order Order { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public User CreatedBy { get; set; }
        [ForeignKey(nameof(LastModifiedById))]
        public User LastModifiedBy { get; set; }
    }
}
