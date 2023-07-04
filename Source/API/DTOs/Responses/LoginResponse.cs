using Common.Domain.Users;

namespace API.DTOs.Responses
{
    public class LoginResponse
    {
        public string UserType { get; init; }
        public Guid? UserId { get; init; }
        public bool IsSuccess { get; init; }

        public static LoginResponse ToLoginResponse(SuccessLoginDto successLoginDto) => new()
        {
            UserId = successLoginDto.UserId,
            UserType = successLoginDto.UserType,
            IsSuccess = successLoginDto.IsSuccess,
        };
    }
}
