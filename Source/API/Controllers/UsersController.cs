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
            await _usersService.CreateUser(request);
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
        public async Task<ActionResult<IEnumerable<ListUsersResponse>>> ListUsers()
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
                return BadRequest(responseLogin);

            return Unauthorized(responseLogin);
        }
    }
}
