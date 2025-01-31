using MediatR;
using UriStore.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Order.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<Domain.Entities.Order>
    {
        public long Id { get; set; }
    }
}
