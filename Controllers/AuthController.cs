using Azure.Messaging;
using ECommerceWebsite.DTOs.AuthDtos;
using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.Models;
using ECommerceWebsite.Services.IService;
using ECommerceWebsite.Services.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        //private readonly ITokenService _tokenService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
            //_tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(AuthDto authDto)
        {
            var user = await _authService.Login(authDto);
            if (user == null)
            {
                return Unauthorized("Use valid Email and password");
            }

            var jwtToken = TokenService.GenerateToken(user);
            return Ok(jwtToken);
        }
    }
}
