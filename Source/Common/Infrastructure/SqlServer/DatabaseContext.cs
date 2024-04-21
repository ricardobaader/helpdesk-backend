using Common.Domain.Rooms;
using Common.Domain.TicketImages;
using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Infrastructure.SqlServer.Mappings;
using Common.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.SqlServer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            _ = new TicketMapping(modelBuilder.Entity<Ticket>());
            _ = new TicketImageMapping(modelBuilder.Entity<TicketImage>());
            _ = new UserMapping(modelBuilder.Entity<User>());
            _ = new RoomMapping(modelBuilder.Entity<Room>());

            modelBuilder.Seed();
        }
    }
}
