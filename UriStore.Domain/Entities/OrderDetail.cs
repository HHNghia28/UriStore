﻿using UriStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Domain.Entities
{
    public class OrderDetail : BaseEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        [MinLength(1)]
        public int Quantity { get; set; } = 0;
        [StringLength(500)]
        public string Photo { get; set; }
        public string Category { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public long OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }
}
