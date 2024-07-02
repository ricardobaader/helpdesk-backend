using Common.Domain;
using Common.Domain.Chats;
using Common.Domain.Rooms;
using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Exceptions;
using Common.Utils.Extensions;
using InvalidDataException = Common.Exceptions.InvalidDataException;

namespace Common.Application.Services.Chats
{
    public class ChatsService : IChatsService
    {
        private const int MaxImageSizeInBytes = 5 * 1024 * 1024; // 5 MB
        private readonly List<string> AcceptedImageContentTypes = new() { "image/jpg", "image/png", "image/jpeg", "image/webp" };

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

        public async Task SendMessage(Guid ticketId, Guid userId, CreateChatMessageDto request)
        {
            byte[] imageBytes = null;
            if (request.Image != null)
            {
                if (!AcceptedImageContentTypes.Contains(request.Image.ContentType))
                    throw new InvalidDataException($"Tipo de extensão de imagem não suportado: {request.Image.ContentType}. Tipos aceitos: {string.Join(", ", AcceptedImageContentTypes)}");

                if (request.Image.Length > MaxImageSizeInBytes)
                    throw new InvalidDataException("A imagem excede o tamanho máximo permitido de 5 MB.");
                
                imageBytes = await request.Image.ConvertToByteArray();
            }

            var chat = new Chat(request.Message, imageBytes, userId, ticketId);

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
                },
                ImageBase64 = x.Image != null ? Convert.ToBase64String(x.Image) : null,
            }, x => x.TicketId == ticketId).Result.OrderBy(x => x.SendedAt);
        }
    }
}
