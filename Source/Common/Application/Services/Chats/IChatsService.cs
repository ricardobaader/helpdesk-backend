using Common.Domain.Chats;
using Common.Domain.Rooms;

namespace Common.Application.Services.Chats
{
    public interface IChatsService
    {
        Task SendMessage(Guid ticketId, Guid userId, CreateChatMessageDto request);
        IEnumerable<ListChatMessagesDto> ListAllMessages(Guid ticketId);
    }
}
