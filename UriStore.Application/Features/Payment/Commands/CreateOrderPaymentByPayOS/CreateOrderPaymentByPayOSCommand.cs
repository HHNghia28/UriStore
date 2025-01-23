using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UriStore.Application.DTO;
using UriStore.Application.Wrappers;

namespace UriStore.Application.Features.Payment.Commands.CreatePaymentOrder
{
    public class CreateOrderPaymentByPayOSCommand : IRequest<string>
    {
        public long OrderId { get; set; }
        [JsonIgnore]
        public Guid CreatedById { get; set; }
    }
}
