using Common.Domain.Tickets;
using Common.Infrastructure.SqlServer.Common;
using Common.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.SqlServer.Repositories
{
    public class TicketsRepository : BaseEntityRepository<Ticket>, ITicketsRepository
    {
        public TicketsRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ListTicketsDto>> ListTicketsBy(Guid userId)
        {
            return await Entity
                .Where(x => !x.IsDeleted && x.UserId == userId)
                .AsNoTracking()
                .Select(x => new ListTicketsDto
                {
                    Code = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Status = x.Status.GetDescription(),
                    Room = x.Room,
                }).ToListAsync();
        }
    }
}
