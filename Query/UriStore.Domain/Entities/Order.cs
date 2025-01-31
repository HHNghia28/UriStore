using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Domain.Enums;
using UriStore.Domain.Shares;
using MongoDB.Bson.Serialization.Attributes;

namespace UriStore.Domain.Entities
{
    public class Order
    {
        [BsonId]
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public int ShippingFee { get; set; } = 0;
        public int DiscountFee { get; set; } = 0;
        public string? VoucherName { get; set; }
        public string? VoucherCode { get; set; }
        public int VoucherValue { get; set; } = 0;
        public int TotalPrice { get; set; } = 0;
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public List<OrderDetail> Details { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateUtility.GetCurrentDateTime();
        public User LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; } = DateUtility.GetCurrentDateTime();
    }

    public class User
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }

    public class OrderDetail
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public string Photo { get; set; }
        public string Category { get; set; }
        public Guid ProductId { get; set; }
    }
}
