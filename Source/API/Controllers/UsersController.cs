using API.DTOs.Responses;
using Common.Application.Services.Users;
using Identity.DTOs.Requests;
using Identity.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var userId = await _usersService.CreateUser(request);
            return Created(string.Empty, userId);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await _usersService.ListById(id);

            if (user is null)
                return NotFound(string.Empty);

            return Ok(user);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            await _usersService.Delete(id);
            return NoContent();
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost("admCreate")]
        public async Task<IActionResult> CreateUserAsAdministrator([FromBody] CreateUserAsAdministratorRequest request)
        {
            await _usersService.CreateUserAsAdministrator(request);
            return NoContent();
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListUsersResponse>>> GetUsers()
        {
            var usersDto = await _usersService.ListUsers();
            return Ok(usersDto.Select(x => ListUsersResponse.ToListUsersResponse(x)));
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login([FromBody] UserLoginRequest request)
        {
            var responseLogin = await _usersService.Login(request);

            if (responseLogin.IsSuccess)
                return Ok(responseLogin);
            else if (responseLogin.Errors.Count > 0)
                return BadRequest(responseLogin.Errors);

            return Unauthorized(responseLogin);
        }
    }
}
