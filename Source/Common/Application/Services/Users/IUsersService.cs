using Common.Domain.Users;

namespace Common.Application.Services.Users
{
    public interface IUsersService
    {
        Task Create(CreateUserDto request);
    }
}
