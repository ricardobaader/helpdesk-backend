using Common.Domain.Users;

namespace API.DTOs.Requests
{
    public class LoginRequest
    {
        public string Email { get; init; }
        public string Password { get; init; }

        public LoginDto ToLoginDto() => new()
        {
            Email = Email,
            Password = Password,
        };
    }
}
