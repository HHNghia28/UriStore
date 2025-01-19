using UriStore.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
