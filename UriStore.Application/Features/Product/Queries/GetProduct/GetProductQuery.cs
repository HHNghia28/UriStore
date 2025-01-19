using MediatR;
using UriStore.Application.DTO;
using UriStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
    }
}
