using Common.Domain.Users;

namespace Common.Application.Services.Users
{
    public interface IUsersService
    {
        Task Create(CreateUserDto request);
        Task Delete(Guid id);
        Task<IEnumerable<ListUsersDto>> ListUsers();
        Task<SuccessLoginDto> Login(LoginDto request);
        Task<ListUsersDto> ListById(Guid userId);
    }
}
