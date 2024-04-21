using Common.Domain.Rooms;
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

        public async Task<IEnumerable<ListTicketsDto>> ListAllTicketsBy(Guid userId)
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
                    Responsible = x.SupportUser.Name,
                    CreatedAt = x.CreatedAt,
                    RoomDto = new ListRoomDto()
                    {
                        Id = x.RoomId,
                        Name = x.Room.Name,
                        Desciption = x.Room.Description,
                    }
                }).ToListAsync();
        }
    }
}
