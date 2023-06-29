using Common.Domain.Tickets;
using Common.Infrastructure.SqlServer.Mappings;
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
        }
    }
}
