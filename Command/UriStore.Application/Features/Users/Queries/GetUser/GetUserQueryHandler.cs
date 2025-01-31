using Dapper;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler(IUserRepository _userRepository) : IRequestHandler<GetUserQuery, UserResponse>
    {
        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUser(request.Id);
        }
    }
}
