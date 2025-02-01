using UriStore.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Auth.Commands.AccessToken
{
    public class AccessTokenCommand : IRequest<LoginResponse>
    {
        public string RefreshToken { get; set; }
    }
}
