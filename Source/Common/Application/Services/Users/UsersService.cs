using Common.Domain;
using Common.Domain.Users;
using Common.Utils.Extensions;

namespace Common.Application.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public async Task Create(CreateUserDto request)
        {
            var user = UserMapper.MapCreateUserDtoToUser(request);

            if (!user.IsValid)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", user.Errors)}");

            await _usersRepository.InsertOne(user);
        }

        public async Task<IEnumerable<ListUsersDto>> ListUsers()
        {
            return await _usersRepository.ListUsers();
        }

        public async Task<SuccessLoginDto> Login(LoginDto request)
        {
            var user = await _usersRepository
                .SelectOneBy(x => x.Email == request.Email && x.Password == request.Password && !x.IsDeleted);

            if (user is null)
                return new() { IsSuccess = false };

            return new SuccessLoginDto()
            {
                UserId = user.Id,
                UserType = user.UserType.GetDescription(),
                IsSuccess = true
            };
        }
    }
}
