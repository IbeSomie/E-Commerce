using ECommerceWebsite.DTOs.UserAuthenticationDto;

namespace ECommerceWebsite.Services.IService
{
    public interface ITokenService
    {
        string GenerateToken(UserAuthenticationDto user);
    }
}
