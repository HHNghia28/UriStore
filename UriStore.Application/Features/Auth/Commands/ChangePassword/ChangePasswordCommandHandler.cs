using UriStore.Application.Exceptions;
using UriStore.Application.Handlers;
using UriStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler(IUserRepository _userRepository, IPasswordHasher _passwordHasher) 
        : IRequestHandler<ChangePasswordCommand>
    {
        public async Task Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null || !_passwordHasher.VerifyPassword(command.OldPassword, user.PasswordHash)) 
                throw new InvalidCredentialsException("Invalid credentials");

            if (!user.IsEmailConfirmed) throw new InvalidCredentialsException("Please confirm email");

            await _userRepository.ChangePassword(user.Id, _passwordHasher.HashPassword(command.NewPassword));

            await _userRepository.SaveAsync();
        }
    }
}
