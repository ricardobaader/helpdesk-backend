namespace Common.Domain.Chats
{
    public interface IChatsRepository : IBaseEntityRepository<Chat>
    {
        Task<IEnumerable<Chat>> ListChatWithUser(Guid ticketId);
    }
}
