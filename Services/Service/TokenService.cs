using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ECommerceWebsite.DTOs.UserAuthenticationDto;
using ECommerceWebsite.Services.IService;

namespace ECommerceWebsite.Services.Service
{
    public static class TokenService
    {
        private static readonly string _key = "tomiwatomiwatomitomiwatomiwatomitomiwatomiwatomi";
        private static readonly string _issuer = "tomiwa";
        private static readonly string _audience = "tomiwa";
        

        public static string GenerateToken(UserAuthenticationDto user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserAuthenticationId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_issuer, _audience, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
