using Identity.DTOs.Requests;
using Identity.DTOs.Responses;

namespace Identity.Services
{
    public interface IIdentityService
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest userCreate, bool isSupportUser = false);
        Task<UserLoginResponse> Login(UserLoginRequest userLogin);
        Task<bool> DeleteUser(string email);
    }
}