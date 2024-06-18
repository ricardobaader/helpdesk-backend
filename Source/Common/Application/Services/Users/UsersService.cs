using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Exceptions;
using Common.Utils.Extensions;

namespace Common.Application.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public UsersService(IUsersRepository userRepository,
            ITicketsRepository ticketsRepository)
        {
            _usersRepository = userRepository;
            _ticketsRepository = ticketsRepository;
        }

        public async Task Create(CreateUserDto request)
        {
            var user = UserMapper.MapCreateUserDtoToUser(request);

            if (!user.IsValid)
                throw new Exceptions.InvalidDataException($"Um ou mais dos dados informados são inválidos: {string.Join(", ", user.Errors)}");

            await _usersRepository.InsertOne(user);
        }

        public async Task Delete(Guid id)
        {
            var userDb = await _usersRepository.SelectOneBy(x => x.Id == id);
            if (userDb is null)
                throw new EntityNotFoundException("A sala informada não existe");

            var existTicketWithUser = await _ticketsRepository.ExistsBy(x => x.UserId == id || x.SupportUserId == id && !x.IsDeleted);
            if (existTicketWithUser)
                throw new ActiveObjectException("Não foi possível excluir esta usuário porque ela está vinculada a um chamado ativo.");

            userDb.SetDelete();
            _usersRepository.UpdateOne(userDb);
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
                Role = x.UserType.GetDescription()
            }, x => x.Id == userId && !x.IsDeleted);
        }

        public async Task<SuccessLoginDto> Login(LoginDto request)
        {
            var user = await _usersRepository
                .SelectOneBy(x => x.Email == request.Email && x.Password == request.Password && !x.IsDeleted);

            if (user is null)
                return new() { IsSuccess = false };

            return new SuccessLoginDto()
            {
                Name = user.Name,
                UserId = user.Id,
                UserType = user.UserType.GetDescription(),
                IsSuccess = true
            };
        }
    }
}
