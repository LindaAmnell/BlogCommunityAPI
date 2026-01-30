using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCommunity.Api.Controllers
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
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var createdUser = await _userService.RegisterAsync(user);
            if(createdUser == null)
            {
                return BadRequest("User already exist");  
            }

            return Ok(createdUser);
                
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var loggedInUser = await _userService.LoginAsync(request.UserName, request.Password);
            if( loggedInUser == null)
            {
                return Unauthorized();
            }
            return Ok(loggedInUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, User user)
        {
            var succses = await _userService.UpdateUserAsync(id, user);
            if (!succses)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var succses = await _userService.DeleteUserAsync(id);
            if(!succses)
            {
                return NotFound();
            }

            return Ok();

        }


    }
}
