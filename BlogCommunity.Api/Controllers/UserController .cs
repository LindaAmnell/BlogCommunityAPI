using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Dtos;
using BlogCommunity.Api.Dtos.userDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        // -------------------- GET ALL USERS --------------------

        [HttpGet]
        #region Doc
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Returns a list of all registered users"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        #endregion
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUsersAsync();

            var response = users.Select(u => new UserResponseDto
            {
                Id = u.UserID,
                UserName = u.UserName,
                Email = u.Email
            });

            return Ok(response);
        }

        // -------------------- REGISTER USER --------------------

        [HttpPost("register")]
        #region Doc
        [SwaggerOperation(
            Summary = "Register a new user",
            Description = "Creates a new user account using username, email and password"
        )]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, Description = "User already exists")]

        #endregion
        public async Task<IActionResult> Register(User user)
        {
            var createdUser = await _userService.RegisterAsync(user);
            if (createdUser == null)
                return BadRequest("User already exists");

            var response = new UserResponseDto
            {
                Id = createdUser.UserID,
                UserName = createdUser.UserName,
                Email = createdUser.Email
            };


            return StatusCode(StatusCodes.Status201Created, response);
        }

        // -------------------- LOGIN --------------------

        [HttpPost("login")]
        #region Doc
        [SwaggerOperation(
            Summary = "Login user",
            Description = "Logs in a user by validating username and password"
        )]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized, Description = "Invalid username or password")]

        #endregion
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var user = await _userService.LoginAsync(request.UserName, request.Password);
            if (user == null)
                return Unauthorized("Invalid username or password");

            return Ok(new
            {
                userId = user.UserID,
                userName = user.UserName
            });
        }

        // -------------------- UPDATE USER --------------------

        [HttpPut("{id}")]
        #region Doc
        [SwaggerOperation(
            Summary = "Update user",
            Description = "Updates username, email or password for an existing user"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        #endregion
        public async Task<IActionResult> Update(int id, UpdateUserDto dto)
        {
            var success = await _userService.UpdateUserAsync(id, dto);
            if (!success)
                return NotFound("User not found");

            return NoContent();
        }

        // -------------------- DELETE USER --------------------

        [HttpDelete("{id}")]
        #region Doc
        [SwaggerOperation(
        Summary = "Delete user",
        Description = "Deletes a user by id"
  )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        #endregion
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
                return NotFound("User not found");

            return Ok();
        }


    }
}
