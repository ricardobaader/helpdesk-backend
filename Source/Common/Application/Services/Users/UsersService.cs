using Common.Domain.Users;
using Common.Exceptions;
using Common.Utils;
using Common.Utils.Extensions;
using Identity.DTOs.Requests;
using Identity.DTOs.Responses;
using Identity.Services;

namespace Common.Application.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IIdentityService _identityService;

        public UsersService(IUsersRepository userRepository, IIdentityService identityService)
        {
            _usersRepository = userRepository;
            _identityService = identityService;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            if (await _usersRepository.ExistsBy(x => x.Email == request.Email && !x.IsDeleted))
                throw new ExistingEntityException("O usuário informado ja existe.");

            var user = UserMapper.MapCreateUserRequestToUser(request);

            if (!user.IsValid)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", user.Errors)}");

            var userCreated = await _identityService.CreateUser(request);

            await _usersRepository.InsertOne(user);

            return userCreated;
        }

        public async Task<CreateUserResponse> CreateSupportUser(CreateSupportUserRequest request)
        {
            if (await _usersRepository.ExistsBy(x => x.Email == request.Email && !x.IsDeleted))
                throw new ExistingEntityException("O usuário informado ja existe.");

            var user = UserMapper.MapCreateSupportUserRequestToUser(request);

            if (!user.IsValid)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", user.Errors)}");

            var userCreated = await _identityService.CreateUser(request);

            await _usersRepository.InsertOne(user);

            return userCreated;
        }

        public async Task<IEnumerable<ListUsersDto>> ListUsers()
        {
            return await _usersRepository.ListUsers();
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var errors = ValidateRequestLogin(request);
            if (errors.Any())
            {
                var response = new UserLoginResponse(false);
                response.AddErrors(errors);
                return response;
            }

            var user = await _usersRepository
                .SelectOneBy(x => x.Email == request.Email && !x.IsDeleted);

            var userLoggedIn = await _identityService.Login(request);

            if (user is not null)
                userLoggedIn.AddCustomFields(user.Name, (int)user.UserType, user.Id);

            return userLoggedIn;
        }

        private static List<string> ValidateRequestLogin(UserLoginRequest request)
        {
            var errors = EntityValidator.New()
                .Requiring(request.Email, "O email deve ser informado")
                .Requiring(request.Password, "A senha deve ser informada")
                .GetErrors();

            return errors;
        }
    }
}
