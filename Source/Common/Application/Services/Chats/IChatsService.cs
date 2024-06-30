using Common.Domain.Rooms;

namespace Common.Application.Services.Chats
{
    public interface IChatsService
    {
        Task SendMessage(Guid ticketId, Guid userId, string mensagem);
        IEnumerable<ListChatMessagesDto> ListAllMessages(Guid ticketId);
    }
}
