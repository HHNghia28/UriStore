using Dapper;
using UriStore.Application.DTO;
using UriStore.Application.Interfaces;
using UriStore.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, PagedResponse<List<UserListResponse>>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<PagedResponse<List<UserListResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers(new PagedRequest
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            });
        }
    }
}
