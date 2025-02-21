﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.DTO
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int Stock { get; set; } = 0;
        public string Photo { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid CreatedById { get; set; }
        public Guid LastModifiedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
