using Common.Domain.Users;
using Identity.DTOs.Requests;
using Identity.DTOs.Responses;

namespace Common.Application.Services.Users
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(CreateUserRequest request);
        Task<CreateUserResponse> CreateUserAsAdministrator(CreateUserAsAdministratorRequest request);
        Task Delete(Guid id);
        Task<IEnumerable<ListUsersDto>> ListUsers();
        Task<ListUsersDto> ListById(Guid userId);
        Task<UserLoginResponse> Login(UserLoginRequest request);
    }
}
