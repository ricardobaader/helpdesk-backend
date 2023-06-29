using Common.Domain.Users;

namespace API.DTOs.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public CreateUserDto ToCreateUserDto() => new()
        {
            Email = Email,
            Password = Password,
            Name = Name,
            UserType = UserType
        };
    }
}
