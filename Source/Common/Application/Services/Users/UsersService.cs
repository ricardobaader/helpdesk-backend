using Common.Domain;
using Common.Domain.Users;

namespace Common.Application.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IBaseEntityRepository<User> _userRepository;

        public UsersService(IBaseEntityRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(CreateUserDto request)
        {
            var user = UserMapper.MapCreateUserDtoToUser(request);
            await _userRepository.InsertOne(user);
        }
    }
}
