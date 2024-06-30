using Common.Domain;
using Common.Domain.Chats;
using Common.Domain.Rooms;
using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Exceptions;
using Common.Utils.Extensions;

namespace Common.Application.Services.Chats
{
    public class ChatsService : IChatsService
    {
        public readonly IChatsRepository _chatsRepository;
        private readonly IBaseEntityRepository<User> _usersRepository;
        private readonly IBaseEntityRepository<Ticket> _ticketsRepository;

        public ChatsService(IChatsRepository chatsRepository,
            IBaseEntityRepository<User> usersRepository,
            IBaseEntityRepository<Ticket> ticketsRepository)
        {
            _chatsRepository = chatsRepository;
            _usersRepository = usersRepository;
            _ticketsRepository = ticketsRepository;
        }

        public async Task SendMessage(Guid ticketId, Guid userId, string message)
        {
            var chat = new Chat(message, userId, ticketId);

            var user = await _usersRepository.SelectOneBy(x => x.Id == userId && !x.IsDeleted);
            if (user is null)
                throw new EntityNotFoundException("O usuário informado não existe");

            var ticket = await _ticketsRepository.SelectOneBy(x => x.Id == ticketId && !x.IsDeleted);
            if (ticket is null)
                throw new EntityNotFoundException("O chamado informado não existe");

            await _chatsRepository.InsertOne(chat);
        }

        public IEnumerable<ListChatMessagesDto> ListAllMessages(Guid ticketId)
        {
            return _chatsRepository.ProjectManyBy(x => new ListChatMessagesDto
            {
                Message = x.Message,
                SendedAt = x.CreatedAt,
                User = new ListUsersDto 
                {
                    Id = x.UserId,
                    Name = x.User.Name,
                    Email = x.User.Email,
                    UserType = x.User.UserType.GetDescription(),
                }
            }, x => x.TicketId == ticketId).Result.OrderBy(x => x.SendedAt);
        }
    }
}
