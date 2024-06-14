using Common.Domain.Users;
using Identity.DTOs.Requests;
using Identity.DTOs.Responses;

namespace Common.Application.Services.Users
{
    public interface IUsersService
    {
        Task Create(CreateUserRequest request);
        Task<IEnumerable<ListUsersDto>> ListUsers();
        Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
