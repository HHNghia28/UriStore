﻿using UriStore.Application.DTO;
using UriStore.Application.Exceptions;
using UriStore.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Auth.Commands.AccessToken
{
    public class AccessTokenCommandHandler(IUserRepository _userRepository, ITokenService _tokenService) : IRequestHandler<AccessTokenCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(AccessTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByRefreshToken(command.RefreshToken);

            if (user == null) throw new InvalidCredentialsException("Invalid refresh token");

            var accessToken = _tokenService.GenerateJwtToken(user);

            return new LoginResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                AccessToken = accessToken,
                RefreshToken = command.RefreshToken
            };
        }
    }
}
