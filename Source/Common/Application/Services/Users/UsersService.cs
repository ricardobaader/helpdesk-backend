using Common.Domain.Tickets;
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
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IIdentityService _identityService;

        public UsersService(IUsersRepository userRepository,
            ITicketsRepository ticketsRepository,
            IIdentityService identityService)
        {
            _usersRepository = userRepository;
            _ticketsRepository = ticketsRepository;
            _identityService = identityService;
        }

        public async Task<Guid> CreateUser(CreateUserRequest request)
        {
            if (await _usersRepository.ExistsBy(x => x.Email == request.Email && !x.IsDeleted))
                throw new ExistingEntityException("O usuário informado ja existe.");

            var user = UserMapper.MapCreateUserRequestToUser(request);

            if (!user.IsValid)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", user.Errors)}");

            var userCreated = await _identityService.CreateUser(request);

            if (!userCreated.IsSuccess)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", userCreated.Errors)}");

            await _usersRepository.InsertOne(user);

            return user.Id;
        }

        public async Task<CreateUserResponse> CreateUserAsAdministrator(CreateUserAsAdministratorRequest request)
        {
            if (await _usersRepository.ExistsBy(x => x.Email == request.Email && !x.IsDeleted))
                throw new ExistingEntityException("O usuário informado ja existe.");

            var user = UserMapper.MapCreateUserAsAdministratorRequestToUser(request);

            if (!user.IsValid)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", user.Errors)}");

            var userCreated = await _identityService.CreateUser(request, request.UserType);

            if (!userCreated.IsSuccess)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", userCreated.Errors)}");

            await _usersRepository.InsertOne(user);

            return userCreated;
        }

        public async Task Delete(Guid id)
        {
            var userDb = await _usersRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);
            if (userDb is null)
                throw new EntityNotFoundException("A usuário informado não existe ou ja está inativado");

            var existTicketWithUser = await _ticketsRepository.ExistsBy(x => x.UserId == id || x.SupportUserId == id && !x.IsDeleted);
            if (existTicketWithUser)
                throw new ActiveObjectException("Não foi possível excluir este usuário porque ele está vinculado a um chamado ativo.");

            userDb.SetDelete();
            _usersRepository.UpdateOne(userDb);

            await _identityService.DeleteUser(userDb.Email);
        }

        public async Task<IEnumerable<ListUsersDto>> ListUsers()
        {
            return await _usersRepository.ListUsers();
        }

        public async Task<ListUsersDto> ListById(Guid userId)
        {
            return await _usersRepository.ProjectOneBy(x => new ListUsersDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                UserType = x.UserType.GetDescription()
            }, x => x.Id == userId && !x.IsDeleted);
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

            if (user is null)
                throw new EntityNotFoundException("O usuário informado é inválido");

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
