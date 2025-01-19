using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Auth.Commands.ResendEmail
{
    public class ResendConfirmEmailCommand : IRequest
    {
        public string Email { get; set; }
    }
}
