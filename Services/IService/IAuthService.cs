using ECommerceWebsite.DTOs.AuthDtos;
using ECommerceWebsite.DTOs.UserAuthenticationDto;

namespace ECommerceWebsite.Services.IService
{
    public interface IAuthService
    {
        Task<UserAuthenticationDto?> Login(AuthDto authDto);
    }
}
