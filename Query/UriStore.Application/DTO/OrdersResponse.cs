using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.Domain.Enums;
using UriStore.Domain.Shares;

namespace UriStore.Application.DTO
{
    public class OrdersResponse
    {
        [BsonId]
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
