using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.DTOs.UserDto;
using ECommerceWebsite.Models;
using ECommerceWebsite.Services.IService;
using ECommerceWebsite.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserAsync()
        {
            var user = await _userService.GetUsersAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto userDto)
        {
            var data = await _userService.CreateAsync(userDto);

            if (data == null)
            {
                return Unauthorized("Email already registered");
            }
            return CreatedAtAction("GetUser", new { id = data.UserId }, userDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<User?>> UpdateAsync(int id, UpdateUserDto userDto)
        {
            var user = await _userService.UpdateAsync(id, userDto);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var user = await _userService.DeleteAsync(id);
            if (user == false)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}
