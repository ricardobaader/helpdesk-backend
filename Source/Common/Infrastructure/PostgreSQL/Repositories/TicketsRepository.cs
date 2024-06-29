using Common.Domain.Rooms;
using Common.Domain.Tickets;
using Common.Infrastructure.SqlServer.Common;
using Common.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Common.Infrastructure.SqlServer.Repositories
{
    public class TicketsRepository : BaseEntityRepository<Ticket>, ITicketsRepository
    {
        private const int DaysToWaitBeforeClosing = 7;

        public TicketsRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ListTicketsDto>> ListAllTicketsBy(Guid userId, TicketsFiltersDto filters)
        {
            return await Entity
            .Where(x => (!filters.TicketStatus.HasValue || x.Status == filters.TicketStatus) && x.UserId == userId && !x.IsDeleted)
            .AsNoTracking()
            .Select(x => new ListTicketsDto
            {
                Id = x.Id,
                Number = x.Number,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status.GetDescription(),
                CreatedAt = x.CreatedAt,
                Responsible = x.SupportUser.Name,
                RoomDto = new ListRoomDto
                {
                    Id = x.RoomId,
                    Name = x.Room.Name,
                    Description = x.Room.Description,
                }
            }).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> ListAllSolvedTickets()
        {
            return await Entity
                .Include(x => x.User)
                .Where(x => x.Status == TicketStatus.Solved && x.LastUpdatedAt.AddDays(DaysToWaitBeforeClosing) <= DateTime.UtcNow && !x.IsDeleted)
                .ToListAsync();
        }
    }
}
