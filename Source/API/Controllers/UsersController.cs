using API.DTOs.Requests;
using Common.Application.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            await _usersService.Create(request.ToCreateUserDto());
            return Ok();
        }
    }
}
