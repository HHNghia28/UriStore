using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [AllowNull]
        [StringLength(100)]
        public string Name { get; set; }
        [AllowNull]
        [StringLength(500)]
        public string Description { get; set; }
        [AllowNull]
        public int? Price { get; set; }
        [AllowNull]
        public int? Discount { get; set; }
        [AllowNull]
        public int? Stock { get; set; }
        [StringLength(500)]
        [AllowNull]
        public string Photo { get; set; }

        [JsonIgnore]
        public Guid? LastModifiedById { get; set; }
        [AllowNull]
        public int? CategoryId { get; set; }
    }
}
