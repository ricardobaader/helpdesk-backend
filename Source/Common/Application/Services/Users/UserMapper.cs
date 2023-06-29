using Common.Domain.Tickets;
using Common.Domain.Users;

namespace Common.Application.Services.Users
{
    public static class UserMapper
    {
        public static User MapCreateUserDtoToUser(CreateUserDto dto) =>
            new(dto.Name, dto.Email, dto.Password, dto.UserType);
    }
}
