using UriStore.Application.DTO;
using UriStore.Application.Exceptions;
using UriStore.Application.Handlers;
using UriStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler(IUserRepository _userRepository, IPasswordHasher _passwordHasher, ITokenService _tokenService) 
        : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null || !_passwordHasher.VerifyPassword(command.Password, user.PasswordHash)) throw new InvalidCredentialsException("Invalid credentials");

            if (!user.IsEmailConfirmed) throw new InvalidCredentialsException("Please confirm email");

            var accessToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(64);

            await _userRepository.SaveRefreshToken(user.Id, refreshToken, DateTime.UtcNow.AddDays(1));
            await _userRepository.SaveAsync();

            return new LoginResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
