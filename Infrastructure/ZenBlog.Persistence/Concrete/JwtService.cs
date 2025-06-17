using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ZenBlog.Persistence.Concrete
{
    public class JwtService(UserManager<AppUser> _userManager, IOptions<JwtTokenOptions> tokenOptions) : IJwtService
    {
        private readonly JwtTokenOptions _jwtTokenOptions = tokenOptions.Value;
        public async Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result)
        {
            var user = await _userManager.FindByNameAsync(result.UserName);
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key));
            var dateTimeNow = DateTime.UtcNow;

            List<Claim> claims = new()
            {
                new(JwtRegisteredClaimNames.Name, user.UserName),
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new("fullName", string.Join(" ", user.FirstName, user.LastName)),

            };

            JwtSecurityToken jwtSecurityToken = new
            (
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: claims,
                notBefore: dateTimeNow,
                expires: dateTimeNow.AddMinutes(_jwtTokenOptions.ExpireInMinutes),
                signingCredentials: new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            GetLoginQueryResult response = new();

            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.ExpirationTime = dateTimeNow.AddMinutes(_jwtTokenOptions.ExpireInMinutes);

            return response;
            
        }
    }
}
