using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }

        public Guid LastModifiedBy { get; set; }
    }
}
