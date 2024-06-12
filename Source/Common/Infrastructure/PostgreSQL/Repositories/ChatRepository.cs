using Common.Domain.Chats;
using Common.Infrastructure.SqlServer.Common;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.SqlServer.Repositories
{
    public class ChatRepository : BaseEntityRepository<Chat>, IChatsRepository
    {
        public ChatRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Chat>> ListChatWithUser(Guid ticketId)
        {
            return await Entity
                .Include(x => x.User)
                .Where(x => x.TicketId == ticketId && !x.IsDeleted)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

        }
    }
}
