using API.DTOs.Requests;
using API.DTOs.Responses;
using Common.Application.Services.Users;
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
            await _usersService.Create(request.ToCreateUserDto());
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await _usersService.ListById(id);

            if (user is null)
                return NotFound(string.Empty);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            await _usersService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListUsersResponse>>> GetUsers()
        {
            var usersDto = await _usersService.ListUsers();
            return Ok(usersDto.Select(x => ListUsersResponse.ToListUsersResponse(x)));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var responseLogin = await _usersService.Login(request.ToLoginDto());

            if (!responseLogin.IsSuccess) return Unauthorized(responseLogin);

            return Ok(LoginResponse.ToLoginResponse(responseLogin));
        }
    }
}
