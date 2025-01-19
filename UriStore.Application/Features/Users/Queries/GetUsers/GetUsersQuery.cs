using UriStore.Application.DTO;
using UriStore.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<PagedResponse<List<UserListResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
