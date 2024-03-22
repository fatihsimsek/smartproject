using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartProject.Application.Common;
using SmartProject.Application.Order;

namespace SmartProject.Application.Identity
{
    public sealed class UserLoginCommand : Common.Command<UserTokenDto>
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserTokenDto>
    {
        private readonly IConfiguration _configuration;

        public UserLoginCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<UserTokenDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            if (!request.Email.Equals("fatih.simsek@outlook.com") || !request.Password.Equals("12345"))
            {
                return Task.FromResult(new UserTokenDto() { IsSuccess = false });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("id", Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, request.Email),
                new Claim(ClaimTypes.Email, request.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWT:ExpireMinute"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new UserTokenDto { IsSuccess = true, Token = tokenHandler.WriteToken(token) });
        }
    }
}

