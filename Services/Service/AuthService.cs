using ECommerceWebsite.DTOs.AuthDtos;
using ECommerceWebsite.DTOs.UserAuthenticationDto;
using ECommerceWebsite.Interface;
using ECommerceWebsite.Services.IService;

namespace ECommerceWebsite.Services.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserAuthenticationDto?> Login(AuthDto authDto)
        {
            var users = await _userRepository.GetUsersAsync();
            var user = users.FirstOrDefault(x => 
                x.Email.ToLower() == authDto.Email.ToLower() &&
                x.Password == authDto.Password);

            if (user == null)
            {
                return null;
            }

            return new UserAuthenticationDto()
            {
                Email = authDto.Email,
                UserAuthenticationId = user.UserId
            };
        }
    }
}
