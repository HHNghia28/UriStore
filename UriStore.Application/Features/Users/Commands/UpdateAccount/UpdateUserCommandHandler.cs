using UriStore.Application.Interfaces;
using UriStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Users.Commands.UpdateAccount
{
    public class UpdateUserCommandHandler(IUserRepository _userRepository) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUser(new User
            {
                Id = request.Id,
                Email = request.Email,
                FullName = request.FullName,
                Address = request.Address,
                Phone = request.Phone,
                RoleId = request.RoleId,
            });

            await _userRepository.SaveAsync();
        }
    }
}
