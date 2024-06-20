using Common.Domain.Users;
using Identity.DTOs.Requests;

namespace Common.Application.Services.Users
{
    public static class UserMapper
    {
        public static User MapCreateUserRequestToUser(CreateUserRequest dto) =>
            new(dto.Name, dto.Email);

        public static User MapCreateSupportUserRequestToUser(CreateSupportUserRequest dto) =>
            new(dto.Name, dto.Email, (UserType)dto.UserType);
    }
}
