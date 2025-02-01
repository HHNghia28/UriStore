using UriStore.Application.Handlers;
using UriStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler(IUserRepository _userRepository, IPasswordHasher _passwordHasher) 
        : IRequestHandler<ResetPasswordCommand>
    {
        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var confirm = await _userRepository.IsVerifyCode(request.UserId, request.Code);

            if (confirm) await _userRepository.ChangePassword(request.UserId, _passwordHasher.HashPassword(request.Password));

            await _userRepository.SaveAsync();
        }
    }
}
