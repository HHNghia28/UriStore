using UriStore.Application.Exceptions;
using UriStore.Application.Handlers;
using UriStore.Application.Interfaces;
using UriStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UriStore.Application.Features.Auth.Commands.ResendEmail
{
    public class ResendConfirmEmailCommandHandler(IUserRepository _userRepository, IEmailSender _emailSender, IConfiguration _configuration) 
        : IRequestHandler<ResendConfirmEmailCommand>
    {
        async Task IRequestHandler<ResendConfirmEmailCommand>.Handle(ResendConfirmEmailCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(command.Email);

            if (existingUser == null) throw new NotFoundException("User not found");

            string code = await _userRepository.GenerateCodeConfirmEmail(existingUser.Id);

            await _userRepository.SaveAsync();

            string url = _configuration["Base:Url"] ?? string.Empty;
            string content = url + "/api/v1/auth/confirm-email?userId=" + existingUser.Id + "&code=" + code;

            await _emailSender.SendEmailAsync(existingUser.Email, "Confirm email", content);
        }
    }
}
